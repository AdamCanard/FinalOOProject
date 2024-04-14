using SQLite;
using System.ComponentModel.DataAnnotations;


namespace OOProject.Models
{
    public class Book
    {
        [Required]
        [PrimaryKey]
        public int ISBN { get; set; }
        [Required]
        public int Quantity { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Genre { get; set; }

        public Book() { }
        public Book(int isbn, int quant, string title, string author, string cat)
        {
            ISBN = isbn;
            Quantity = quant;
            Title = title;
            Author = author;
            Genre = cat;
        }

        public override string ToString()
        {
            return $"ISBN: {ISBN}\t" +
                $"Quantity: {Quantity}\t" +
                $"Title: {Title}\t" +
                $"Author: {Author}\t" +
                $"Genre: {Genre}";
        }
    }
}
