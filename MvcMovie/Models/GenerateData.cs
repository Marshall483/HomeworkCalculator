using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MvcMovie.Data;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

namespace MvcMovie.Models
{
    public static class GenerateData
    {

        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new MvcMovieContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<MvcMovieContext>>()))
            {
                // Look for any movies.
                if (context.Movie.Any())
                {
                    return;   // DB has been seeded
                }

                context.Movie.AddRange(
                    new Movie
                    {
                        Title = "Еhe wind is getting stronger",
                        ReleaseDate = DateTime.Parse("2012-2-12"),
                        Genre = "Anime",
                        Raiting = "A",
                        Price = 7.99M
                    },

                    new Movie
                    {
                        Title = "Shreck",
                        ReleaseDate = DateTime.Parse("1984-3-13"),
                        Genre = "Animation Comedy",
                        Raiting = "B",
                        Price = 8.99M
                    },

                    new Movie
                    {
                        Title = "Walking castle",
                        ReleaseDate = DateTime.Parse("2001-2-23"),
                        Genre = "Anime",
                        Raiting = "B",
                        Price = 9.99M
                    },

                    new Movie
                    {
                        Title = "Harry Potter and Globet of fire",
                        ReleaseDate = DateTime.Parse("2001-4-15"),
                        Genre = "Action",
                        Raiting = "A",
                        Price = 3.99M
                    }
                );
                context.SaveChanges();
            }

        }
    }
}
