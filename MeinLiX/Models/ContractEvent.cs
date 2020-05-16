using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MeinLiX
{
    public partial class ContractEvent
    {
        [Display(Name = "Contract")]
        public int IdContract { get; set; }
        [Required]
        [Display(Name = "Sponsor")]
        public int IdSponsor { get; set; }
        [Required]
        [Display(Name = "Event")]
        public int IdEvent { get; set; }
        [Required]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "The term of the contract until")]
        public DateTime ContractValidUntil { get; set; }
        [Required]
        [Display(Name ="Balance")]
        public decimal ContractBalance { get; set; }

        [Display(Name = "Event")]
        public virtual Event IdEventNavigation { get; set; }

        [Display(Name = "Sponsor")]
        public virtual Sponsor IdSponsorNavigation { get; set; }
    }
}
