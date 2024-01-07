namespace DemoDesign
{
    public class BorrowCommand : ICommand
    {
        private BorrowReturnBook form;
        private string cbbReaderIdText;

        public BorrowCommand(BorrowReturnBook form, string cbbReaderIdText)
        {
            this.form = form;
            this.cbbReaderIdText = cbbReaderIdText;
        }

        public void Execute()
        {
            form.CreateBorrowCard.reader = reader;
            form.CreateBorrowCard.numBorrowedBooks = numBorrowedBooks;
            new form.CreateBorrowCard().ShowDialog();
            if (form.borrowState == "Success")
            {
                MessageBox.Show($"Tạo phiếu mượn {cardId} thành công!", "Thông báo");
                form.borrowState = "";

                form.LoadBorrowCardList();
                form.CheckDateExpriedReaderCard(reader.dateExpried);
                form.LoadNumBorrowBooks(cbbReaderIdText);
            }
        }
    }

}
