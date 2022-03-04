using Movie.Common.Models;
using Movie.Common.Constants;
using Newtonsoft.Json;
using System;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Threading.Tasks;

namespace Movie.Common.Repository
{
    class MovieRepository : IMovieRepository
    {
        public async Task<ObservableCollection<Movies>> GetMovies(MovieCall movieCall)
        {
            string url = string.Format(Constant.API_FORMAT, ApiKeys.BASE_URL, movieCall.Type, ApiKeys.API_KEY, movieCall.Page);
            HttpClient clientCabinets = new HttpClient();
            try
            {
                HttpResponseMessage response = await clientCabinets.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    string result = await response.Content.ReadAsStringAsync();
                    MovieResponse movieResponse = JsonConvert.DeserializeObject<MovieResponse>(result);
                    return movieResponse.results;
                }
            }
            catch (Exception)
            {
            }
            return null;
        }
    }
}