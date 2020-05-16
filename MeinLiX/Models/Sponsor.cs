using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MeinLiX
{
    public partial class Sponsor
    {
        public Sponsor()
        {
            ContractEvent = new HashSet<ContractEvent>();
            ContractOrganisation = new HashSet<ContractOrganisation>();
            ContractPlayer = new HashSet<ContractPlayer>();
        }

        [Display(Name = "Sponsor")]
        public int IdSponsor { get; set; }
        [Required]
        [Display(Name = "Sponsor")]
        public string SponsorName { get; set; }
        [Required]
        [Display(Name = "Web Page")]
        public string SponsorWebpage { get; set; }
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Foundation")]
        public DateTime? SponsorFoundation { get; set; }

        
        [Display(Name = "Event")]
        public virtual ICollection<ContractEvent> ContractEvent { get; set; }
        [Display(Name = "Organisation")]
        public virtual ICollection<ContractOrganisation> ContractOrganisation { get; set; }
        [Display(Name = "Player")]
        public virtual ICollection<ContractPlayer> ContractPlayer { get; set; }
    }
}
