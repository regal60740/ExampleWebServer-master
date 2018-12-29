using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace LogHandler
{
    public class CustomLogHandler : DelegatingHandler
    {
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var logMetadata = BuildRequestMetadata(request);
            var response = await base.SendAsync(request, cancellationToken);
            logMetadata = BuildResponseMetadata(logMetadata, response);
            SendToLog(logMetadata);
            return response;
        }
        private LogMetadata BuildRequestMetadata(HttpRequestMessage request)
        {
            LogMetadata log = new LogMetadata
            {
                RequestMethod = request.Method.Method,
                RequestTimestamp = DateTime.Now,
                RequestUri = request.RequestUri.ToString()
            };
            return log;
        }
        private LogMetadata BuildResponseMetadata(LogMetadata logMetadata, HttpResponseMessage response)
        {
            logMetadata.ResponseStatusCode = response.StatusCode;
            logMetadata.ResponseTimestamp = DateTime.Now;
            logMetadata.ResponseContentType = response.Content.Headers.ContentType.MediaType;
            return logMetadata;
        }
        private bool SendToLog(LogMetadata logMetadata)
        {
            // TODO: Write code here to store the logMetadata instance to a pre-configured log store...
            try
            {
                string connectionString = "Data Source=54.213.195.209;Initial Catalog=Example;User ID=example;Password=example";
                string sql = "INSERT INTO RequestLog (Request) values (@Request)";
                using (SqlConnection cnn = new SqlConnection(connectionString))
                {
                    cnn.Open();
                    SqlCommand cmd = new SqlCommand(sql, cnn);
                    cmd.Parameters.Add("@Request", SqlDbType.VarChar);
                    cmd.Parameters["@Request"].Value = logMetadata.RequestUri;
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                //Console.WriteLine("Can not open data connection");
                Console.WriteLine(ex.Message);
            }
            return true;
        }
    }
}
