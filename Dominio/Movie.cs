using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Movie
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Director {  get; set; }
        public string Synopsis { get; set; }
        public DateTime Release {  get; set; }
        public int Rating {  get; set; }
        public bool Oscar { get; set; }

        public Movie(int id, string title, string director, string synopsis, DateTime release, int rating, bool oscar)
        {
            ID = id;
            Title = title;
            Director = director;
            Synopsis = synopsis;
            Release = release;
            Rating = rating;
            Oscar = oscar;
        }

        public override string ToString()
        {
            return $"ID: {ID}\n" +
                   $"Título: {Title}\n" +
                   $"Director: {Director}\n" +
                   $"Sinopsis: {Synopsis}\n" +
                   $"Fecha: {Release}\n" +
                   $"Rating: {Rating}\n" +
                   $"Oscar: {Oscar}";
        }
    }
}
