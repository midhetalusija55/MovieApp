using Movie.Common.Models;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace Movie.Common.Repository
{
    public interface IMovieRepository
    {
        Task<ObservableCollection<Movies>> GetMovies(MovieCall movieCall);
    }
}