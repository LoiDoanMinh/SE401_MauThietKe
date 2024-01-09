using System.ComponentModel;
using System.Runtime.CompilerServices;
using LibraryManagement.Models.State;
namespace LibraryManagement.Models
{
    public class BorrowedBook : INotifyPropertyChanged
    {
        [System.ComponentModel.DisplayName("Mã cuốn")]
        public string id { get; set; }
        [System.ComponentModel.DisplayName("Tên sách")]
        public string bookName { get; set; }
        public string detailBorrowId { get; set; }
        public string borrowCardId { get; set; }
        [System.ComponentModel.DisplayName("Hạn trả")]
        public string returnDate { get; set; }
        [System.ComponentModel.DisplayName("Ngày mượn")]
        public string borrowDate { get; set; }
        public int borrowedDays { get; set; }
        [System.ComponentModel.DisplayName("Số ngày trễ hạn")]
        public int lateDays { get; set; }
        public long fine { get; set; }
        private BookState bookState;

        public BorrowedBook(string id, string bookName, string borrowCardId, string detailBorrowId, string borrowDate, string returnDate)
        {
            this.id = id;
            this.bookName = bookName;
            this.borrowCardId = borrowCardId;
            this.detailBorrowId = detailBorrowId;
            this.returnDate = returnDate;
            this.borrowDate = borrowDate;

            this.bookState = new BorrowedState();
            TransitionTo(this.bookState);
        }

        public BorrowedBook(BorrowedBook book)
        {
            this.id = book.id;
            this.bookName = book.bookName;
            this.borrowCardId = book.borrowCardId;
            this.detailBorrowId = detailBorrowId;
            this.returnDate = book.returnDate;
            this.borrowDate = book.borrowDate;
            this.borrowedDays = book.borrowedDays;
            this.fine = book.fine;
            this.lateDays = book.lateDays;

            this.bookState = new BorrowedState();
            TransitionTo(this.bookState);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            //C# 6 null-safe operator. No need to check for event listeners
            //If there are no listeners, this will be a noop
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        // The Context allows changing the State object at runtime.
        public void TransitionTo(BookState state)
        {
            this.bookState = state;
        }

        // The Context delegates part of its behavior to the current State
        // object.
        public string RequestBorrow()
        {
            return this.bookState.HandleBorrowRequest(this.id);
        }

        public string RequestReturn()
        {
            return this.bookState.HandleReturnRequest(this.id);
        }
    }
}
