using System.Collections.Generic;
using MoviesNetCore.Model;

namespace MoviesNetCore.Repository
{
    public interface IGenreRepository
    {
        Genre Get(int id);

        IEnumerable<Genre> List();

        void Update(Genre movie);

        void Insert(Genre genero);

        void Delete(int id);
    }
}