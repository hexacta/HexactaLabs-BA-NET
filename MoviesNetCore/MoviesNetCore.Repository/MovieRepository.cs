using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using MoviesNetCore.Model;

namespace MoviesNetCore.Repository
{
    public class MovieRepository : IMovieRepository
    {
        private readonly DatabaseContext db;
        
        public MovieRepository(DatabaseContext db)
        {
            this.db = db;
        }

        public void Delete(int id)
        {
            var movie = this.Get(id);

            this
                .db
                .Movies
                .Remove(movie);
                
            this.db.SaveChanges();
        }

        public Movie Get(int id)
        {
            this.db.Movies.Include(x => x.MovieGenres).Load();

            return this
                .db                
                .Movies
                .Find(id);
        }

        public IEnumerable<Movie> List()
        {
            return this
                .db
                .Movies
                .AsEnumerable();
        }

        public void Add(Movie movie)
        {           
            this.db.Movies.Add(movie);

            this.db.MovieGenre.AddRange(movie.MovieGenres);

            this.db.SaveChanges();      
        }

        public void Update(Movie movie)
        {
            var movieGenres = this.db.MovieGenre.Where(x => x.MovieId == movie.Id);
            
            this.db.MovieGenre.RemoveRange(movieGenres);
            this.db.MovieGenre.AddRange(movie.MovieGenres);           

            this.db.Movies.Update(movie);
            this.db.SaveChanges();      
        }
    }
}