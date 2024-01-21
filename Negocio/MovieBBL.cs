using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Negocio
{
    public class MovieBBL
    {
        public static List<Movie> GetMovieList()
        {
            List<Movie> movieList = new List<Movie>
            {
                new Movie
                (
                    1,
                    "El Gran Gastby",
                    "Baz Luhrmann",
                    "La película sigue la historia de Jay Gatsby, un hombre misterioso y millonario que organiza fiestas extravagantes en su mansión de Long Island durante la década de 1920. La trama se centra en su obsesión por recuperar a su antiguo amor, Daisy Buchanan.",
                    DateTime.Parse("10/3/2013"),
                    7,
                    true
                ),
                new Movie
                (
                    2,
                    "El Padrino",
                    "Francis Ford Coppola",
                    "La película narra la historia de la familia Corleone, una poderosa familia de la mafia italiana en Estados Unidos. Se centra en el ascenso al poder de Michael Corleone, interpretado por Al Pacino, y los conflictos y traiciones que enfrenta en el mundo del crimen organizado.",
                    DateTime.Parse("24/3/1972"),
                    9,
                    true
                )
            };
            return movieList;
        }
    }
}
