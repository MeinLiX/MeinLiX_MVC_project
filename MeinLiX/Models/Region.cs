using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MeinLiX
{
    public partial class Region
    {
        public Region()
        {
            Organisation = new HashSet<Organisation>();
        }

        [Display(Name = "Region")]
        public int IdRegion { get; set; }
        [Required]
        [Display(Name = "Region")]
        public string RegionName { get; set; }

        public virtual ICollection<Organisation> Organisation { get; set; }
    }
}
