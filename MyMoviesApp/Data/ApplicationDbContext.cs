using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyMoviesApp.Models;

namespace MyMoviesApp.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Movie>Movies {get;set;}

        public DbSet<Series> SeriesTV { get; set; }

        public DbSet<MovieType> MovieTypes { get; set; }
    } 
}
