namespace LibraryManagement.Models
{
    public class Book
    {
        public string id { get; set; }
        public string bookId { get; set; }
        public string name { get; set; }
        public string author { get; set; }
        public string category { get; set; }

        public Book(string id, string bookId = "", string name = "", string author = "", string category = "")
        {
            this.id = id;
            this.bookId = bookId;
            this.name = name;
            this.author = author;
            this.category = category;
        }
    }
}
