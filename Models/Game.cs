using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace JYTGameStore.Models
{
    public class Game
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int gameId { get; set; }

        [Display (Name ="Game Name")]
        [Required]
        public string GameName { get; set; }

        [Display(Name = "Game Description")]
        [Required]
        public string GameDescription { get; set; }

        public string IsActive { get; set; }

        public DateTime releaseDate { get; set; }

    }

    public class GameModel
    {
        public List<Game> gameList { get; set; }
    }
}
