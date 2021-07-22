using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyMoviesApp.Models
{
    public class Movie
    {
        [Key]
        public int IdM { get; set; }

        //show different name on frontend
        [DisplayName("Movie Name")]
        [Required]
        public string NameM { get; set; }

        [Required]
        [Range(1900, int.MaxValue, ErrorMessage = "Year should be bigger than 1900")]
        [DisplayName("Year")]
        public int YearM { get; set; }

        [Required]
        [DisplayName("Status")]
        public string statusM { get; set; }

        [DisplayName("Rating")]
        [Range(0, 10, ErrorMessage = "Rating should be between 0 to 10")]
        public int RatingM { get; set; }

        [DisplayName("Movie Type")]
        public int MovieTypeID { get; set; }
        [ForeignKey("MovieTypeID")]
        public virtual MovieType MovieType {get; set;} 
    }
}
