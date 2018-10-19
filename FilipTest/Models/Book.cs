using MessagePack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilipTest.Models
{
    [Serializable]
    [MessagePackObject]
    public class Book
    {
        public static List<Book> Data = new List<Book>
            {
                new Book {
                    Title = "Our Mathematical Universe: My Quest for the Ultimate Nature of Reality",
                    Author = "Max Tegmark",
                    Price = 935.23,
                    Words = 142524},
                new Book {
                    Title = "Hockey Towns",
                    Author = "Ron MacLean",
                    Price = 1235.23,
                    Words = 654456},
            };

        [Key(0)] public string Title { get; set; }
        [Key(1)] public string Author { get; set; }
        [Key(2)] public double Price { get; set; }
        [Key(3)] public long Words { get; set; }

    }
}
