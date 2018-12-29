namespace WebApplication
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Content
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string ResourceName { get; set; }

        [Column("Content")]
        [Required]
        public string Content1 { get; set; }
    }
}
