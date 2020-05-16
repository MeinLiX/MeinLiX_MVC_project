using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MeinLiX
{
    public partial class Game
    {
        public Game()
        {
            Subdivision = new HashSet<Subdivision>();
        }
        
        [Display(Name = "Game")]
        public int IdGame { get; set; }
        [Required]
        [Display(Name = "Game")]
        public string GameName { get; set; }

        public virtual ICollection<Subdivision> Subdivision { get; set; }
    }
}
