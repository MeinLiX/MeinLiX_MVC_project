using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MeinLiX
{
    public partial class Event
    {
        public Event()
        {
            ContractEvent = new HashSet<ContractEvent>();
        }
        [Display(Name = "Event")]
        public int IdEvent { get; set; }
        [Required]
        [Display(Name = "Event")]
        public string EventName { get; set; }
        [Required]
        [Display(Name = "Location")]
        public string EventLocation { get; set; }
        [Required]
        [Display(Name = "Web Page")]
        public string EventWebpage { get; set; }
        [Required]
        [Display(Name = "Prize Fund")]
        public int EventPrizeFund { get; set; }
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Start date")]
        public DateTime? EventStartDate { get; set; }

        public virtual ICollection<ContractEvent> ContractEvent { get; set; }
    }
}
