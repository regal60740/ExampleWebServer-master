namespace WebApplication
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("RequestLog")]
    public partial class RequestLog
    {
        public int ID { get; set; }

        public string Request { get; set; }
    }
}
