using LibraryManagement.Models.State;
namespace LibraryManagement.Models
{
    public class Book
    {
        public string id { get; set; }
        public string bookId { get; set; }
        public string name { get; set; }
        public string author { get; set; }
        public string category { get; set; }
        private BookState bookState;

        public Book(string id, string bookId = "", string name = "", string author = "", string category = "", BookState bookState = null)
        {
            this.id = id;
            this.bookId = bookId;
            this.name = name;
            this.author = author;
            this.category = category;
            if(bookState == null)
            {
                TransitionTo(new AvailableState());
            }
            else
            {
                this.bookState = bookState;
                TransitionTo(this.bookState);
            }
        }

        public Book(BookState state)
        {
            this.TransitionTo(state);
        }

        // The Context allows changing the State object at runtime.
        public void TransitionTo(BookState state)
        {
            this.bookState = state;
            this.bookState.SetContext(this);
        }

        // The Context delegates part of its behavior to the current State
        // object.
        public string RequestBorrow()
        {
            return this.bookState.HandleBorrowRequest();
        }

        public string RequestReturn()
        {
            return this.bookState.HandleReturnRequest();
        }
    }
}
