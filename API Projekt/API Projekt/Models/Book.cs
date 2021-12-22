using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Projekt.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }

        public string AuthorImage { get; set; }

        public string ImageCover { get; set; }

        public string Description { get; set; }

        public string ImageBackground { get; set; }

        public string Genre { get; set; }

        public int price { get; set; }
    }
}
