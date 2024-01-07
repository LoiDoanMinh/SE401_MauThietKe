namespace DemoDesign
{
    public class ReturnCommand : ICommand
    {
        private BorrowReturnBook form;
        private string cbbReaderIdText;

        public ReturnCommand(BorrowReturnBook form, string cbbReaderIdText)
        {
            this.form = form;
            this.cbbReaderIdText = cbbReaderIdText;
        }

        public void Execute()
        {
            form.CreateReturnCard.reader = reader;
            new form.CreateReturnCard().ShowDialog();

            if (form.CreateReturnCard.state == "Success")
            {
                MessageBox.Show($"Tạo phiếu trả {cardId} thành công!", "Thông báo");

                form.LoadReturnCardList();
                form.CheckDateExpriedReaderCard(reader.dateExpried);
                form.LoadNumBorrowBooks(cbbReaderIdText);
            }
        }
    }

}
