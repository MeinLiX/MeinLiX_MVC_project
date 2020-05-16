using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MeinLiX
{
    public partial class Player
    {
        public Player()
        {
            ContractPlayer = new HashSet<ContractPlayer>();
        }

        [Display(Name = "Player")]
        public int IdPlayer { get; set; }
        [Display(Name = "Subdivision")]
        public int? IdSubdivision { get; set; }

        [Display(Name = "Name")]
        public string PlayerName { get; set; }
        [Required]
        [Display(Name = "Nickname")]
        public string PlayerNickname { get; set; }
        [Required]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Join date")]
        public DateTime PlayerJoin { get; set; }
        [Required]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Birthday")]
        public DateTime PlayerBirth { get; set; }

        [Display(Name = "Subdivision")]
        public virtual Subdivision IdSubdivisionNavigation { get; set; }
        public virtual ICollection<ContractPlayer> ContractPlayer { get; set; }
    }
}
