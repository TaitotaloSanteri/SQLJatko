using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SQLJatko.Models
{

    public class Game
    {
        [Key]
        public int Id { get; set; }
        public string GameName { get; set; }
        public int ReleaseYear { get; set; }
        public string Description { get; set; }
        public Genre GameGenre { get; set; }
        public Platform GamePlatform { get; set; }
    }

    public enum Genre
    {
        FPS,
        Strategy,
        RPG
    }
    public enum Platform
    {
        PC,
        PS5,
        PS4,
        XboxOne,
        Xbox360
    }

}