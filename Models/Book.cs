using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceApi.Models
{
    public enum Genre
    {

        Fiction,
        NonFiction,
        History
    }


    public class Book
    {
        public int Id { get; set; }
        public DateTime ReleaseDate { get; set; }
        public int AuthorId { get; set; }
        public string Title { get; set; }
        public bool BestSeller { get; set; }

        public Genre BookGenre { get; set; }

        public int Price { get; set; }


        public Author AuthorData { get; set; }


    }
}
