using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SQLJatko.Models
{
    public class Game
    {
        [Key]
        public int Id { get; set; }
        [DisplayName("Game name")]
        public string GameName { get; set; }
        
        [DisplayName("Release year")]
        public int ReleaseYear { get; set; }

        public string Description { get; set; }

        [DisplayName("Game genre")]
        public Genre GameGenre { get; set; }

        [DisplayName("Game platform")]
        public Platform GamePlatform { get; set; }
    }

    public enum Genre
    {
        FPS = 1,
        Strategy,
        RPG,
        Fighting
    }

    public enum Platform
    {
        PC = 1,
        PS5,
        PS4,
        [Display(Name ="Xbox One")]
        XboxOne,
        [Display(Name = "Xbox 360")]
        Xbox360
    }

}