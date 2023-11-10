using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace CRUDFootball.Models
{
    public partial class Players
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int? ShirtNo { get; set; }
        public string Name { get; set; }
        public int? PositionId { get; set; }
        public int? Appearances { get; set; }
        public int? Goals { get; set; }

        public virtual Positions Position { get; set; }
    }
}
