using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SQLJatko.Models
{
    public class Movie
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [DisplayName("Movie name")]
        public string MovieName { get; set; }

        [Required]
        [DisplayName("Release year")]
        public int ReleaseYear { get; set; }

        [Required]
        public string Description { get; set; }
 
    }
}
