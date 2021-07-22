using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyMoviesApp.Models.ViewModels
{
    public class TypesVM
    {
        public Movie Movie { get; set; }

        public Series Series { get; set; }
        
        public IEnumerable<SelectListItem> TypeDropDown { get; set; }
    }
}
