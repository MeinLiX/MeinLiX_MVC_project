using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MeinLiX
{
    public partial class Organisation
    {
        public Organisation()
        {
            ContractOrganisation = new HashSet<ContractOrganisation>();
            Subdivision = new HashSet<Subdivision>();
        }

        [Display(Name = "Organisation")]
        public int IdOrganisation { get; set; }

        [Required]
        [Display(Name = "Region")]
        public int IdRegion { get; set; }

        [Required]
        [Display(Name = "Organisation")]
        public string OrganisationName { get; set; }
        [Required]
        [Display(Name = "Web Page")]
        public string OrganisationWebpage { get; set; }
        [Required]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Foundation")]
        public DateTime OrganisationFoundation { get; set; }

        [Display(Name = "Region")]
        public virtual Region IdRegionNavigation { get; set; }

        public virtual ICollection<ContractOrganisation> ContractOrganisation { get; set; }
        public virtual ICollection<Subdivision> Subdivision { get; set; }
    }
}
