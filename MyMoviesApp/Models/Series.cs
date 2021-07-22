using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyMoviesApp.Models
{
    public class Series
    {

        [Key]
        public int IdS { get; set; }

        [DisplayName("Tv Show Name")]
        [Required]
        public string NameS { get; set; }

        [DisplayName("Year")]
        [Required]
        [Range(1900, int.MaxValue, ErrorMessage = "Year should be bigger than 1900")]
        public int YearS { get; set; }

        [DisplayName("Status")]
        [Required]
        public string statusS { get; set; }

        [DisplayName("Rating")]
        [Range(0, 10, ErrorMessage = "Rating should be between 0 to 10")]
        public int RatingS { get; set; }

        [DisplayName("Series Type")]
        public int MovieTypeId { get; set; }
        [ForeignKey("MovieTypeId")]
        public virtual MovieType SeriesType { get; set; }

    }
}
