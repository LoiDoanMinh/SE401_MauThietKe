using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Data.SqlClient;
using LibraryManagement.Models;
using LibraryManagement.Forms;
using System.Threading;
using System.ComponentModel;
using System.Reflection;
using System.Data;
using LibraryManagement.Command;
using LibraryManagement.State;
using static System.Windows.Forms.AxHost;
using LibraryManagement.Models.AbstractFactory;

namespace DemoDesign
{
    public partial class BorrowReturnBook : Form
    {
        private ICommand command;

        public static string borrowState = "";
        public static string cardId = "";

        List<Reader> readers;
        BindingList<Receipt> borrowCardList;
        BindingList<Receipt> returnCardList;
        BindingSource bingdingBorrow;
        BindingSource bingdingReturn;
        Thread tdLoadBorrowCardList;
        Thread tdLoadReturnCardList;
        Reader reader = null;

        int numBorrowedBooks = -1, listIndex = -1;

        //State
        private StateContext state = new StateContext();

        public BorrowReturnBook()
        {
            CheckForIllegalCrossThreadCalls = false;
            InitializeComponent();
        }

        #region Load data to components
        private void BorrowBook_Load(object sender, EventArgs e)
        {
            readers = new List<Reader>();
            borrowCardList = new BindingList<Receipt>();
            returnCardList = new BindingList<Receipt>();
            bingdingBorrow = new BindingSource();
            bingdingReturn = new BindingSource();

            btnOpenDetail.BorderRadius = 20;
            btnDelete.BorderRadius = 20;
            btnCreateBorrowCard.BorderRadius = 20;
            btnCreateReturnCard.BorderRadius = 20;
            this.dtgvBorrowList.AutoGenerateColumns = false;
            this.dtgvReturnList.AutoGenerateColumns = false;

            LoadData();

            cbbList.SelectedIndex = 0;
        }

        private void cbbList_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cbb = sender as ComboBox;
            if (cbb.SelectedIndex != listIndex)
            {
                if (cbb.SelectedIndex == 0)
                {
                    lblBorrowList.BringToFront();
                    dtgvBorrowList.BringToFront();
                }
                else if (cbb.SelectedIndex == 1)
                {
                    lblReturnList.BringToFront();
                    dtgvReturnList.BringToFront();
                }
                listIndex = cbb.SelectedIndex;
                txbSearchBook.Text = "Tìm kiếm thông tin phiếu mượn/trả sách";
            }
        }

        private void LoadData()
        {
            Thread tdLoadReaders = new Thread(new ThreadStart(LoadReaders));
            tdLoadBorrowCardList = new Thread(new ThreadStart(LoadBorrowCardList));
            tdLoadReturnCardList = new Thread(new ThreadStart(LoadReturnCardList));

            tdLoadBorrowCardList.Start();
            tdLoadReturnCardList.Start();
            tdLoadReaders.Start();

            tdLoadReaders.Join();
            UpdateComboBoxReaders();
        }

        private void UpdateComboBoxReaders()
        {
            foreach (Reader reader in readers)
                cbbReaderId.Items.Add(reader.code);
        }

        private void LoadReaders()
        {
            SqlConnection conn = new SqlConnection(DatabaseInfo.connectionString);
            conn.Open();
            SqlCommand cmd = new SqlCommand(DatabaseInfo.readersQueryCmd, conn);
            using (SqlDataReader reader = cmd.ExecuteReader())
                while (reader.Read())
                    readers.Add(new Reader(reader.GetString(0), reader.GetString(1), reader.GetDateTime(2), reader.GetString(3)));
            conn.Close();

            btnCreateBorrowCard.Enabled = false;
            btnCreateReturnCard.Enabled = false;
        }

        private void LoadBorrowCardList()
        {
            AbstractSlipFactory borrowReceiptFactory = new BorrowReceiptFactory();

            SqlConnection conn = new SqlConnection(DatabaseInfo.connectionString);
            conn.Open();
            SqlCommand cmd = new SqlCommand(DatabaseInfo.getAllBorrowCards, conn);
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                int stt = 1;
                bingdingBorrow.DataSource = borrowCardList;
                borrowCardList.Clear();
                while (reader.Read())
                {
                    Receipt card = borrowReceiptFactory.CreateReceipt(stt, reader.GetString(0), reader.GetString(1), reader.GetString(2), reader.GetDateTime(3).ToString("dd/MM/yyyy"), reader.GetDateTime(4).ToString("dd/MM/yyyy"));
                    borrowCardList.Add(card);
                    stt++;
                }
            }

            foreach (BorrowCard card in borrowCardList)
            {
                SqlCommand cmd2 = new SqlCommand(DatabaseInfo.GetAllDetailBorrowByBorrowCardId(card.id), conn);
                bool status = true;
                using (SqlDataReader reader2 = cmd2.ExecuteReader())
                    while (reader2.Read())
                        if (!reader2.GetBoolean(3))
                            status = false;
                card.status = status;
            }

            conn.Close();
            try {
                dtgvBorrowList.DataSource = bingdingBorrow;
            }
            catch { }
            
        }

        private void LoadReturnCardList()
        {
            ReturnReceiptFactory returnReceiptFactory = new ReturnReceiptFactory();

            SqlConnection conn = new SqlConnection(DatabaseInfo.connectionString);
            conn.Open();
            SqlCommand cmd = new SqlCommand(DatabaseInfo.getAllReturnCards, conn);
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                int stt = 1;
                bingdingReturn.DataSource = returnCardList;
                returnCardList.Clear();
                while (reader.Read())
                {
                    Receipt card = returnReceiptFactory.CreateReceipt1(stt, reader.GetString(0), reader.GetString(1), reader.GetString(2), reader.GetDateTime(3).ToString("dd/MM/yyyy"), (long)reader.GetDecimal(4));
                    returnCardList.Add(card);
                    stt++;
                }
            }
            conn.Close();
            try
            {
                dtgvReturnList.DataSource = bingdingReturn;
            }
            catch { }
            
        }

        //Hàm của receiver thực hiện
        public void CreateBorrowCardMethod()
        {
            CreateBorrowCard.reader = reader;
            CreateBorrowCard.numBorrowedBooks = numBorrowedBooks;
            new CreateBorrowCard().ShowDialog();
            if (borrowState == "Success")
            {
                state.setState(new CreateBorrowCardState());
                string content = state.applyState(id: cardId, type: 0);
                MessageBox.Show(content, "Thông báo");

                borrowState = "";

                LoadBorrowCardList();
                CheckDateExpriedReaderCard(reader.dateExpried);
                LoadNumBorrowBooks(cbbReaderId.Text);
            }
        }

        //Hàm của receiver thực hiện
        public void CreateReturnCardMethod()
        {
            CreateReturnCard.reader = reader;
            new CreateReturnCard().ShowDialog();

            if (CreateReturnCard.state == "Success")
            {
                state.setState(new CreateReturnCardState());
                string content = state.applyState(id: cardId, type: 0);
                MessageBox.Show(content, "Thông báo");

                LoadReturnCardList();
                CheckDateExpriedReaderCard(reader.dateExpried);
                LoadNumBorrowBooks(cbbReaderId.Text);
            }
        }
        #endregion

        #region Search information
        private void txbSearchBook_MouseDown(object sender, MouseEventArgs e)
        {
            TextBox txb = sender as TextBox;
            if (txb.Text.Length > 0 || txb.Text != "Tìm kiếm thông tin phiếu mượn/trả sáchh")
            {
                (sender as TextBox).Select(0, (sender as TextBox).Text.Length);
                (sender as TextBox).Focus();
            }
        }

        private void txbSearchBook_TextChanged(object sender, EventArgs e)
        {
            TextBox txt = (TextBox)sender;
            if (borrowCardList.Count != 0)
            {
                if (txt.Text.Length == 0 || txt.Text == "Tìm kiếm thông tin phiếu mượn/trả sách")
                    switch (listIndex)
                    {
                        case 0:
                            LoadBorrowCardList();
                            break;
                        case 1:
                            LoadReturnCardList();
                            break;
                    }
                else
                {
                    try
                    {
                        switch (listIndex)
                        {
                            case 0:
                                {
                                    var table = ToDataTable(borrowCardList);
                                    var results = table.Select(string.Format("id LIKE '%{0}%' OR readerId LIKE '%{0}%' OR readerName LIKE '%{0}%' OR borrowDate LIKE '%{0}%' OR returnDate LIKE '%{0}%'", txt.Text));

                                    if (results.Length > 0)
                                    {
                                        dtgvBorrowList.DataSource = results.CopyToDataTable();
                                        dtgvBorrowList.Refresh();
                                    }
                                    else
                                        dtgvBorrowList.DataSource = null;

                                    break;
                                }
                            case 1:
                                {
                                    var table = ToDataTable(returnCardList);
                                    var results = table.Select(string.Format("id LIKE '%{0}%' OR readerId LIKE '%{0}%' OR readerName LIKE '%{0}%' OR returnDate LIKE '%{0}%'", txt.Text));

                                    if (results.Length > 0)
                                    {
                                        dtgvReturnList.DataSource = results.CopyToDataTable();
                                        dtgvReturnList.Refresh();
                                    }
                                    else
                                        dtgvReturnList.DataSource = null;

                                    break;
                                }
                        }

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
            else if (txt.TextLength == 0 || txt.Text == "Tìm kiếm thông tin phiếu mượn/trả sách")
                switch (listIndex)
                {
                    case 0:
                        LoadBorrowCardList();
                        break;
                    case 1:
                        LoadReturnCardList();
                        break;
                }
        }

        private void txbSearchBook_Leave(object sender, EventArgs e)
        {
            if ((sender as TextBox).Text == "")
                (sender as TextBox).Text = "Tìm kiếm thông tin phiếu mượn/trả sách";
        }

        public static DataTable ToDataTable<T>(BindingList<T> items)
        {
            DataTable dataTable = new DataTable(typeof(T).Name);

            //Get all the properties
            PropertyInfo[] Props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (PropertyInfo prop in Props)
            {
                //Defining type of data column gives proper data table 
                var type = (prop.PropertyType.IsGenericType && prop.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>) ? Nullable.GetUnderlyingType(prop.PropertyType) : prop.PropertyType);
                //Setting column names as Property names
                dataTable.Columns.Add(prop.Name, type);
            }
            foreach (T item in items)
            {
                var values = new object[Props.Length];
                for (int i = 0; i < Props.Length; i++)
                {
                    //inserting property values to datatable rows
                    values[i] = Props[i].GetValue(item, null);
                }
                dataTable.Rows.Add(values);
            }
            //put a breakpoint here and check datatable
            return dataTable;
        }
        #endregion

        #region Input information to continue 
        private void cbbReaderId_SelectedIndexChanged(object sender, EventArgs e)
        {
            txbReaderName.Text = readers[cbbReaderId.SelectedIndex].name;
        }

        private void cbbReaderId_TextChanged(object sender, EventArgs e)
        {
            ComboBox cbb = sender as ComboBox;

            if (cbb.Focused && cbb.Text.Length != 0)
            {
                reader = null;
                //Uppercase input 
                string text = cbb.Text;
                if (cbb.Text != "Nhập hoặc chọn mã độc giả")
                    cbb.Text = text.ToUpper();
                cbb.Select(cbb.Text.Length, 0);

                //Find and display errors if data is incorrectly/data is not found
                foreach (Reader r in readers)
                    if (cbb.Text == r.code)
                    {
                        reader = r;
                        txbReaderName.Text = reader.name;
                        break;
                    }

                lbErrorId.Visible = (reader != null) ? false : true;

                //Hide one of the two error labels if the other label is displayed
                if (lbErrorId.Visible)
                {
                    txbReaderName.Text = "Nhập tên độc giả";
                    lbErrorName.Visible = false;
                }

                //Show an error if the reader card is expired
                else if (reader != null)
                    CheckDateExpriedReaderCard(reader.dateExpried);

                LoadNumBorrowBooks(cbbReaderId.Text);
            }
        }

        private void LoadNumBorrowBooks(string readerId)
        {
            //Load the number of books this reader is borrowing
            SqlConnection conn = new SqlConnection(DatabaseInfo.connectionString);
            conn.Open();
            SqlCommand cmd = new SqlCommand(DatabaseInfo.GetNumOfBooksBorrowed(readerId), conn);
            numBorrowedBooks = int.Parse(cmd.ExecuteScalar().ToString());
            conn.Close();

            if (cbbReaderId.Text == readerId)
            {
                if (numBorrowedBooks > 0)
                    btnCreateReturnCard.Enabled = true;
                else btnCreateReturnCard.Enabled = false;
                txbQuantity.Text = numBorrowedBooks.ToString();
            }
        }

        protected void CheckDateExpriedReaderCard(DateTime date)
        {
            if (date >= DateTime.Now.Date)
            {
                btnCreateBorrowCard.Enabled = true;
                lbExpried.Visible = false;
            }
            else
            {
                btnCreateBorrowCard.Enabled = false; lbExpried.Visible = true;
            }
        }

        private void cbbReaderId_Leave(object sender, EventArgs e)
        {
            //When not focus on combobox and text of combobox is already removed  
            if (cbbReaderId.Text == "")
            {
                cbbReaderId.Text = "Nhập hoặc chọn mã độc giả";
                lbErrorId.Visible = false;
            }
        }

        private void txbReaderName_TextChanged(object sender, EventArgs e)
        {
            TextBox txb = (sender as TextBox);
            if (txb.Focused && (txbReaderName.Text != "Nhập tên độc giả" || txbReaderName.Text.Length != 0))
            {
                reader = null;
                //Find and display errors if data is incorrectly/data is not found
                foreach (Reader r in readers)
                    if (txb.Text.ToUpper() == r.name.ToUpper())
                    {
                        reader = r;
                        cbbReaderId.Text = reader.code;
                        break;
                    }

                if (txbReaderName.Text.Length != 0)
                    if (reader != null)
                        lbErrorName.Visible = false;
                    else lbErrorName.Visible = true;
                else lbErrorName.Visible = false;

                //Hide one of the two error labels if the other label is displayed
                if (lbErrorName.Visible)
                {
                    cbbReaderId.Text = "Nhập hoặc chọn mã độc giả";
                    lbErrorId.Visible = false;
                }

                //Show an error if the reader card is expired
                else if (reader != null)
                    CheckDateExpriedReaderCard(reader.dateExpried);

                LoadNumBorrowBooks(cbbReaderId.Text);
            }
        }

        private void txbReaderName_MouseDown(object sender, MouseEventArgs e)
        {
            TextBox txb = sender as TextBox;
            if (txb.Text.Length > 0 || txb.Text != "Nhập tên độc giả")
            {
                (sender as TextBox).Select(0, (sender as TextBox).Text.Length);
                (sender as TextBox).Focus();
            }
        }

        private void txbReaderName_Leave(object sender, EventArgs e)
        {
            //When not focus on combobox and text of combobox is already removed  
            if ((sender as TextBox).Text == "")
            {
                (sender as TextBox).Text = "Nhập tên độc giả";
                lbErrorName.Visible = false;
            }
        }
        #endregion

        #region Handle create new card, view detail of card, delete card and 
        //Tạo Return card --> Mượn sách (Invoker)
        private void btnCreateBorrowCard_Click(object sender, EventArgs e)
        {
            command = new BorrowCommand(this);
            command.Execute();
        }

        //Tạo Return card --> Trả sách (Invoker)
        private void btnCreateReturnCard_Click(object sender, EventArgs e)
        {
            command = new ReturnCommand(this);
            command.Execute();
        }

        private void btnOpenDetail_Click(object sender, EventArgs e)
        {
            if (cbbList.SelectedIndex == 0)
                OpenDetailBorrowCard();
            else if (cbbList.SelectedIndex == 1)
                OpenDetailReturnCard();
        }

        private void dtgvBorrowCardList_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            OpenDetailBorrowCard();
        }

        private void OpenDetailBorrowCard()
        {
            if (dtgvBorrowList.Rows.Count > 0)
                if (dtgvBorrowList.SelectedRows.Count > 0)
                {
                    BorrowCard chosenCard = BorrowCard.GetBorrowCard(dtgvBorrowList.SelectedRows[0].Cells[1].Value.ToString());
                    if (chosenCard != null)
                    {
                        LibraryManagement.Forms.DetailBorrowCard.borrowCard = chosenCard;
                        new LibraryManagement.Forms.DetailBorrowCard().ShowDialog();

                        if (LibraryManagement.Forms.DetailBorrowCard.update || LibraryManagement.Forms.DetailBorrowCard.deleteBorrowCard)
                        {
                            if (LibraryManagement.Forms.DetailBorrowCard.deleteBorrowCard)
                                MessageBox.Show($"Xóa phiếu mượn {chosenCard.id} thành công!", "Thông báo");
                            LoadBorrowCardList();
                        }

                        if (LibraryManagement.Forms.DetailBorrowCard.delete || LibraryManagement.Forms.DetailBorrowCard.insertReturn)
                        {
                            if (LibraryManagement.Forms.DetailBorrowCard.insertReturn)
                                LoadReturnCardList();
                            LoadNumBorrowBooks(chosenCard.readerId);
                        }
                    }
                    else
                        MessageBox.Show("Không tìm thấy phiếu bạn muốn xem chi tiết trong cơ sở dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                    MessageBox.Show("Bạn chưa chọn phiếu mượn để xem chi tiết", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
                MessageBox.Show("Danh sách phiếu mượn trống!", "Thông báo");
        }

        private void dtgvReturnList_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            OpenDetailReturnCard();
        }

        private void OpenDetailReturnCard()
        {
            if (dtgvReturnList.Rows.Count > 0)
                if (dtgvReturnList.SelectedRows.Count > 0)
                {
                    ReturnCard chosenCard = ReturnCard.GetReturnCard(dtgvReturnList.SelectedRows[0].Cells[1].Value.ToString());
                    if (chosenCard != null)
                    {
                        LibraryManagement.Forms.DetailReturnCard.returnCard = chosenCard;
                        new LibraryManagement.Forms.DetailReturnCard().ShowDialog();

                        if (LibraryManagement.Forms.DetailReturnCard.deleteReturn)
                        {
                            MessageBox.Show($"Xóa phiếu mượn {chosenCard.id} thành công!", "Thông báo");
                            LoadReturnCardList();
                        }

                        if (LibraryManagement.Forms.DetailReturnCard.delete)
                            LoadNumBorrowBooks(chosenCard.readerId);
                    }
                    else MessageBox.Show("Không tìm thấy phiếu bạn muốn xem chi tiết trong cơ sở dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                    MessageBox.Show("Bạn chưa chọn phiếu trả để xem chi tiết", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
                MessageBox.Show("Danh sách phiếu trả trống!", "Thông báo");
        }

        //Thực hiện xóa phiếu mượn sách và trả sách
        private void btnDelete_Click(object sender, EventArgs e) 
        {
            if (cbbList.SelectedIndex == 0)
            {
                if (dtgvBorrowList.Rows.Count > 0)
                    if (dtgvBorrowList.SelectedRows.Count > 0)
                    {
                        BorrowCard delete = BorrowCard.GetBorrowCard(dtgvBorrowList.SelectedRows[0].Cells[1].Value.ToString());
                        if (delete != null)
                        {
                            state.setState(new DeleteDetailBorrowCard());
                            string content = state.applyState(id: delete.id, type: 1);

                            var result = MessageBox.Show(content, "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                            if (result == DialogResult.OK)
                                if (BorrowCard.DeleteBorrowCard(delete.id))
                                {
                                    content = state.applyState(id: delete.id, type: 0);

                                    //Xóa phiếu mượn
                                    MessageBox.Show(content, "Thông báo");
                                    LoadBorrowCardList();
                                    LoadReturnCardList();
                                    LoadNumBorrowBooks(delete.readerId);
                                }
                        }
                    }
                    else
                        MessageBox.Show("Không tìm thấy phiếu bạn muốn xem chi tiết trong cơ sở dữ liệu", "Thông báo");
                else
                    MessageBox.Show("Danh sách phiếu mượn trống!", "Thông báo");
            }
            else if (cbbList.SelectedIndex == 1)
            {
                if (dtgvReturnList.Rows.Count > 0)
                    if (dtgvReturnList.SelectedRows.Count > 0)
                    {
                        ReturnCard delete = ReturnCard.GetReturnCard(dtgvReturnList.SelectedRows[0].Cells[1].Value.ToString());
                        if (delete != null)
                        {
                            state.setState(new DeleteDetailReturnCard());
                            string content = state.applyState(id: delete.id, type: 1);

                            var result = MessageBox.Show(content, "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                            if (result == DialogResult.OK)
                                if (ReturnCard.DeleteReturnCard(delete.id))
                                {
                                    content = state.applyState(id: delete.id, type: 0);

                                    MessageBox.Show(content, "Thông báo");
                                    LoadReturnCardList();
                                    LoadNumBorrowBooks(delete.readerId);
                                }
                        }
                    }
                    else
                        MessageBox.Show("Không tìm thấy phiếu bạn muốn xem chi tiết trong cơ sở dữ liệu", "Thông báo");
                else
                    MessageBox.Show("Danh sách phiếu trả trống!", "Thông báo");
            }
        }

        private void dtgvReturnList_SelectionChanged(object sender, EventArgs e)
        {
            DataGridView dtgv = sender as DataGridView;
            if (dtgv.SelectedRows.Count >= 0)
            {
                btnDelete.Enabled = true;
                btnOpenDetail.Enabled = true;
            }
            else
            {
                btnDelete.Enabled = false;
                btnOpenDetail.Enabled = false;
            }
        }

        private void dtgvBorrowList_SelectionChanged(object sender, EventArgs e)
        {
            DataGridView dtgv = sender as DataGridView;
            if (dtgv.SelectedRows.Count >= 0)
            {
                btnDelete.Enabled = true;
                btnOpenDetail.Enabled = true;
            }
            else
            {
                btnDelete.Enabled = false;
                btnOpenDetail.Enabled = false;
            }
        }
        #endregion
    }
}

