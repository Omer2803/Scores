namespace Scores.Client
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SourceLocation
    {
        public int SourceLocationID { get; set; }

        [StringLength(36)]
        public string Id { get; set; }

        [StringLength(23)]
        public string LocationOnDisk { get; set; }
    }
}
