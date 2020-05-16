using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MeinLiX
{
    public partial class Subdivision
    {
        public Subdivision()
        {
            Player = new HashSet<Player>();
        }
        [Display(Name = "Subdivision")]
        public int IdSubdivision { get; set; }
        [Required]
        [Display(Name = "Organisation")]
        public int IdOrganisation { get; set; }
        [Display(Name =  "Subdivision")]
        public string SubdivisionName { get; set; }
        [Required]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Foundation")]
        public DateTime SubdivisionFoundation { get; set; }
        [Required]
        [Display(Name = "Game")]
        public int IdGame { get; set; }

        [Display(Name ="Game")]
        public virtual Game IdGameNavigation { get; set; }
        [Display(Name = "Organisation")]
        public virtual Organisation IdOrganisationNavigation { get; set; }
        public virtual ICollection<Player> Player { get; set; }
    }
}
