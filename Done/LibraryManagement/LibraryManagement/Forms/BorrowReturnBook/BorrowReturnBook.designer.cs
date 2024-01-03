namespace DemoDesign
{
    partial class BorrowReturnBook
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lbTitle = new System.Windows.Forms.Label();
            this.tlTip = new System.Windows.Forms.ToolTip(this.components);
            this.dtgvBorrowList = new System.Windows.Forms.DataGridView();
            this.stt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.borrowId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.readerCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn14 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.borrowDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.returnDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.status = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dtgvReturnList = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cbbList = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lbExpried = new System.Windows.Forms.Label();
            this.lbErrorName = new System.Windows.Forms.Label();
            this.txbQuantity = new System.Windows.Forms.TextBox();
            this.txbReaderName = new System.Windows.Forms.TextBox();
            this.cbbReaderId = new System.Windows.Forms.ComboBox();
            this.lbErrorId = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txbSearchBook = new System.Windows.Forms.TextBox();
            this.lblReturnList = new System.Windows.Forms.Label();
            this.lblBorrowList = new System.Windows.Forms.Label();
            this.btnCreateReturnCard = new LibraryManagement.nButton();
            this.btnDelete = new LibraryManagement.nButton();
            this.btnOpenDetail = new LibraryManagement.nButton();
            this.btnCreateBorrowCard = new LibraryManagement.nButton();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvBorrowList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvReturnList)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbTitle
            // 
            this.lbTitle.AutoSize = true;
            this.lbTitle.BackColor = System.Drawing.Color.Transparent;
            this.lbTitle.Font = new System.Drawing.Font("Segoe UI", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTitle.ForeColor = System.Drawing.Color.Navy;
            this.lbTitle.Location = new System.Drawing.Point(490, 10);
            this.lbTitle.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbTitle.Name = "lbTitle";
            this.lbTitle.Size = new System.Drawing.Size(271, 41);
            this.lbTitle.TabIndex = 1;
            this.lbTitle.Text = "Mượn Và Trả Sách";
            // 
            // tlTip
            // 
            this.tlTip.AutoPopDelay = 5000;
            this.tlTip.InitialDelay = 100;
            this.tlTip.ReshowDelay = 100;
            // 
            // dtgvBorrowList
            // 
            this.dtgvBorrowList.AllowUserToAddRows = false;
            this.dtgvBorrowList.AllowUserToDeleteRows = false;
            this.dtgvBorrowList.AllowUserToOrderColumns = true;
            this.dtgvBorrowList.AllowUserToResizeRows = false;
            this.dtgvBorrowList.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            this.dtgvBorrowList.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.MidnightBlue;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.MidnightBlue;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgvBorrowList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dtgvBorrowList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgvBorrowList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.stt,
            this.borrowId,
            this.readerCode,
            this.dataGridViewTextBoxColumn14,
            this.borrowDate,
            this.returnDate,
            this.status});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgvBorrowList.DefaultCellStyle = dataGridViewCellStyle2;
            this.dtgvBorrowList.EnableHeadersVisualStyles = false;
            this.dtgvBorrowList.Location = new System.Drawing.Point(442, 182);
            this.dtgvBorrowList.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dtgvBorrowList.MultiSelect = false;
            this.dtgvBorrowList.Name = "dtgvBorrowList";
            this.dtgvBorrowList.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.LightSalmon;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgvBorrowList.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dtgvBorrowList.RowHeadersVisible = false;
            this.dtgvBorrowList.RowHeadersWidth = 40;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Navy;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black;
            this.dtgvBorrowList.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dtgvBorrowList.RowTemplate.Height = 26;
            this.dtgvBorrowList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgvBorrowList.Size = new System.Drawing.Size(807, 531);
            this.dtgvBorrowList.TabIndex = 64;
            this.dtgvBorrowList.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dtgvBorrowCardList_CellMouseDoubleClick);
            this.dtgvBorrowList.SelectionChanged += new System.EventHandler(this.dtgvBorrowList_SelectionChanged);
            // 
            // stt
            // 
            this.stt.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.stt.DataPropertyName = "stt";
            this.stt.FillWeight = 32F;
            this.stt.HeaderText = "STT";
            this.stt.MinimumWidth = 6;
            this.stt.Name = "stt";
            this.stt.ReadOnly = true;
            // 
            // borrowId
            // 
            this.borrowId.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.borrowId.DataPropertyName = "id";
            this.borrowId.FillWeight = 116F;
            this.borrowId.HeaderText = "Mã phiếu mượn";
            this.borrowId.MinimumWidth = 6;
            this.borrowId.Name = "borrowId";
            this.borrowId.ReadOnly = true;
            // 
            // readerCode
            // 
            this.readerCode.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.readerCode.DataPropertyName = "readerId";
            this.readerCode.FillWeight = 90F;
            this.readerCode.HeaderText = "Mã độc giả";
            this.readerCode.MinimumWidth = 6;
            this.readerCode.Name = "readerCode";
            this.readerCode.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn14
            // 
            this.dataGridViewTextBoxColumn14.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn14.DataPropertyName = "readerName";
            this.dataGridViewTextBoxColumn14.FillWeight = 160F;
            this.dataGridViewTextBoxColumn14.HeaderText = "Tên độc giả";
            this.dataGridViewTextBoxColumn14.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn14.Name = "dataGridViewTextBoxColumn14";
            this.dataGridViewTextBoxColumn14.ReadOnly = true;
            // 
            // borrowDate
            // 
            this.borrowDate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.borrowDate.DataPropertyName = "borrowDate";
            this.borrowDate.FillWeight = 90F;
            this.borrowDate.HeaderText = "Ngày mượn";
            this.borrowDate.MinimumWidth = 6;
            this.borrowDate.Name = "borrowDate";
            this.borrowDate.ReadOnly = true;
            // 
            // returnDate
            // 
            this.returnDate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.returnDate.DataPropertyName = "returnDate";
            this.returnDate.FillWeight = 90F;
            this.returnDate.HeaderText = "Hạn trả";
            this.returnDate.MinimumWidth = 8;
            this.returnDate.Name = "returnDate";
            this.returnDate.ReadOnly = true;
            // 
            // status
            // 
            this.status.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.status.DataPropertyName = "status";
            this.status.FillWeight = 72F;
            this.status.HeaderText = "Tình trạng";
            this.status.MinimumWidth = 8;
            this.status.Name = "status";
            this.status.ReadOnly = true;
            this.status.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.status.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // dtgvReturnList
            // 
            this.dtgvReturnList.AllowUserToAddRows = false;
            this.dtgvReturnList.AllowUserToDeleteRows = false;
            this.dtgvReturnList.AllowUserToOrderColumns = true;
            this.dtgvReturnList.AllowUserToResizeRows = false;
            this.dtgvReturnList.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            this.dtgvReturnList.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.Navy;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.Navy;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgvReturnList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dtgvReturnList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgvReturnList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn6,
            this.dataGridViewTextBoxColumn5});
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgvReturnList.DefaultCellStyle = dataGridViewCellStyle6;
            this.dtgvReturnList.EnableHeadersVisualStyles = false;
            this.dtgvReturnList.Location = new System.Drawing.Point(442, 182);
            this.dtgvReturnList.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dtgvReturnList.MultiSelect = false;
            this.dtgvReturnList.Name = "dtgvReturnList";
            this.dtgvReturnList.ReadOnly = true;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.LightSalmon;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgvReturnList.RowHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.dtgvReturnList.RowHeadersVisible = false;
            this.dtgvReturnList.RowHeadersWidth = 40;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.Navy;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.Black;
            this.dtgvReturnList.RowsDefaultCellStyle = dataGridViewCellStyle8;
            this.dtgvReturnList.RowTemplate.Height = 26;
            this.dtgvReturnList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgvReturnList.Size = new System.Drawing.Size(807, 531);
            this.dtgvReturnList.TabIndex = 84;
            this.dtgvReturnList.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dtgvReturnList_CellMouseDoubleClick);
            this.dtgvReturnList.SelectionChanged += new System.EventHandler(this.dtgvReturnList_SelectionChanged);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn1.DataPropertyName = "stt";
            this.dataGridViewTextBoxColumn1.FillWeight = 32F;
            this.dataGridViewTextBoxColumn1.HeaderText = "STT";
            this.dataGridViewTextBoxColumn1.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn2.DataPropertyName = "id";
            this.dataGridViewTextBoxColumn2.FillWeight = 96F;
            this.dataGridViewTextBoxColumn2.HeaderText = "Mã phiếu trả";
            this.dataGridViewTextBoxColumn2.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn3.DataPropertyName = "readerId";
            this.dataGridViewTextBoxColumn3.FillWeight = 96F;
            this.dataGridViewTextBoxColumn3.HeaderText = "Mã độc giả";
            this.dataGridViewTextBoxColumn3.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn4.DataPropertyName = "readerName";
            this.dataGridViewTextBoxColumn4.FillWeight = 160F;
            this.dataGridViewTextBoxColumn4.HeaderText = "Tên độc giả";
            this.dataGridViewTextBoxColumn4.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn6.DataPropertyName = "returnDate";
            this.dataGridViewTextBoxColumn6.FillWeight = 90F;
            this.dataGridViewTextBoxColumn6.HeaderText = "Ngày trả";
            this.dataGridViewTextBoxColumn6.MinimumWidth = 8;
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn5.DataPropertyName = "fineThisPeriod";
            this.dataGridViewTextBoxColumn5.FillWeight = 90F;
            this.dataGridViewTextBoxColumn5.HeaderText = "Tiền phạt kỳ này";
            this.dataGridViewTextBoxColumn5.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.cbbList);
            this.panel1.Location = new System.Drawing.Point(12, 78);
            this.panel1.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(420, 73);
            this.panel1.TabIndex = 85;
            // 
            // cbbList
            // 
            this.cbbList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbList.Font = new System.Drawing.Font("Arial", 13.8F);
            this.cbbList.ForeColor = System.Drawing.SystemColors.WindowText;
            this.cbbList.FormattingEnabled = true;
            this.cbbList.Items.AddRange(new object[] {
            "Danh sách phiếu mượn sách",
            "Danh sách phiếu trả sách"});
            this.cbbList.Location = new System.Drawing.Point(11, 26);
            this.cbbList.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cbbList.Name = "cbbList";
            this.cbbList.Size = new System.Drawing.Size(390, 29);
            this.cbbList.TabIndex = 84;
            this.cbbList.SelectedIndexChanged += new System.EventHandler(this.cbbList_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.Color.Chocolate;
            this.label4.Location = new System.Drawing.Point(20, 65);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(222, 24);
            this.label4.TabIndex = 86;
            this.label4.Text = "Chọn danh sách phiếu";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.lbExpried);
            this.panel2.Controls.Add(this.btnCreateReturnCard);
            this.panel2.Controls.Add(this.btnDelete);
            this.panel2.Controls.Add(this.btnOpenDetail);
            this.panel2.Controls.Add(this.btnCreateBorrowCard);
            this.panel2.Controls.Add(this.lbErrorName);
            this.panel2.Controls.Add(this.txbQuantity);
            this.panel2.Controls.Add(this.txbReaderName);
            this.panel2.Controls.Add(this.cbbReaderId);
            this.panel2.Controls.Add(this.lbErrorId);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Location = new System.Drawing.Point(12, 182);
            this.panel2.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(420, 531);
            this.panel2.TabIndex = 86;
            // 
            // lbExpried
            // 
            this.lbExpried.AutoSize = true;
            this.lbExpried.BackColor = System.Drawing.Color.Transparent;
            this.lbExpried.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbExpried.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lbExpried.Location = new System.Drawing.Point(15, 124);
            this.lbExpried.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbExpried.Name = "lbExpried";
            this.lbExpried.Size = new System.Drawing.Size(386, 16);
            this.lbExpried.TabIndex = 68;
            this.lbExpried.Text = "Thẻ độc giả đã hết hạn. Độc giả này không thể mượn được sách!";
            this.lbExpried.Visible = false;
            // 
            // lbErrorName
            // 
            this.lbErrorName.AutoSize = true;
            this.lbErrorName.BackColor = System.Drawing.Color.Transparent;
            this.lbErrorName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbErrorName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lbErrorName.Location = new System.Drawing.Point(115, 124);
            this.lbErrorName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbErrorName.Name = "lbErrorName";
            this.lbErrorName.Size = new System.Drawing.Size(141, 16);
            this.lbErrorName.TabIndex = 39;
            this.lbErrorName.Text = "Không tìm thấy độc giả";
            this.lbErrorName.Visible = false;
            // 
            // txbQuantity
            // 
            this.txbQuantity.Font = new System.Drawing.Font("Arial", 13.8F);
            this.txbQuantity.Location = new System.Drawing.Point(294, 169);
            this.txbQuantity.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txbQuantity.Name = "txbQuantity";
            this.txbQuantity.ReadOnly = true;
            this.txbQuantity.Size = new System.Drawing.Size(107, 29);
            this.txbQuantity.TabIndex = 35;
            this.txbQuantity.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txbReaderName
            // 
            this.txbReaderName.Font = new System.Drawing.Font("Arial", 13.8F);
            this.txbReaderName.Location = new System.Drawing.Point(118, 93);
            this.txbReaderName.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txbReaderName.Name = "txbReaderName";
            this.txbReaderName.Size = new System.Drawing.Size(283, 29);
            this.txbReaderName.TabIndex = 36;
            this.txbReaderName.Text = "Nhập tên độc giả";
            this.txbReaderName.TextChanged += new System.EventHandler(this.txbReaderName_TextChanged);
            this.txbReaderName.Leave += new System.EventHandler(this.txbReaderName_Leave);
            this.txbReaderName.MouseDown += new System.Windows.Forms.MouseEventHandler(this.txbReaderName_MouseDown);
            // 
            // cbbReaderId
            // 
            this.cbbReaderId.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbbReaderId.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbbReaderId.Font = new System.Drawing.Font("Arial", 13.8F);
            this.cbbReaderId.FormattingEnabled = true;
            this.cbbReaderId.Location = new System.Drawing.Point(118, 32);
            this.cbbReaderId.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cbbReaderId.Name = "cbbReaderId";
            this.cbbReaderId.Size = new System.Drawing.Size(283, 29);
            this.cbbReaderId.TabIndex = 31;
            this.cbbReaderId.Text = "Nhập hoặc chọn mã độc giả";
            this.cbbReaderId.SelectedIndexChanged += new System.EventHandler(this.cbbReaderId_SelectedIndexChanged);
            this.cbbReaderId.TextChanged += new System.EventHandler(this.cbbReaderId_TextChanged);
            this.cbbReaderId.Leave += new System.EventHandler(this.cbbReaderId_Leave);
            // 
            // lbErrorId
            // 
            this.lbErrorId.AutoSize = true;
            this.lbErrorId.BackColor = System.Drawing.Color.Transparent;
            this.lbErrorId.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbErrorId.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lbErrorId.Location = new System.Drawing.Point(115, 63);
            this.lbErrorId.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbErrorId.Name = "lbErrorId";
            this.lbErrorId.Size = new System.Drawing.Size(141, 16);
            this.lbErrorId.TabIndex = 37;
            this.lbErrorId.Text = "Không tìm thấy độc giả";
            this.lbErrorId.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Navy;
            this.label1.Location = new System.Drawing.Point(14, 36);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 20);
            this.label1.TabIndex = 32;
            this.label1.Text = "Mã độc giả:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Navy;
            this.label3.Location = new System.Drawing.Point(14, 173);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(198, 20);
            this.label3.TabIndex = 33;
            this.label3.Text = "Số lượng sách đang mượn:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Navy;
            this.label2.Location = new System.Drawing.Point(14, 97);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 20);
            this.label2.TabIndex = 34;
            this.label2.Text = "Tên độc giả:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold);
            this.label5.ForeColor = System.Drawing.Color.Chocolate;
            this.label5.Location = new System.Drawing.Point(20, 169);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(217, 24);
            this.label5.TabIndex = 88;
            this.label5.Text = "Nhập thông tin tra cứu";
            // 
            // txbSearchBook
            // 
            this.txbSearchBook.Font = new System.Drawing.Font("Arial", 13.8F);
            this.txbSearchBook.Location = new System.Drawing.Point(859, 122);
            this.txbSearchBook.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txbSearchBook.Name = "txbSearchBook";
            this.txbSearchBook.Size = new System.Drawing.Size(390, 29);
            this.txbSearchBook.TabIndex = 83;
            this.txbSearchBook.Text = "Tìm kiếm thông tin phiếu mượn/trả sách";
            this.txbSearchBook.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txbSearchBook.TextChanged += new System.EventHandler(this.txbSearchBook_TextChanged);
            this.txbSearchBook.Leave += new System.EventHandler(this.txbSearchBook_Leave);
            this.txbSearchBook.MouseDown += new System.Windows.Forms.MouseEventHandler(this.txbSearchBook_MouseDown);
            // 
            // lblReturnList
            // 
            this.lblReturnList.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold);
            this.lblReturnList.ForeColor = System.Drawing.Color.Chocolate;
            this.lblReturnList.Location = new System.Drawing.Point(684, 78);
            this.lblReturnList.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblReturnList.Name = "lblReturnList";
            this.lblReturnList.Size = new System.Drawing.Size(385, 36);
            this.lblReturnList.TabIndex = 90;
            this.lblReturnList.Text = "Danh sách phiếu trả sách";
            this.lblReturnList.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblBorrowList
            // 
            this.lblBorrowList.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold);
            this.lblBorrowList.ForeColor = System.Drawing.Color.Chocolate;
            this.lblBorrowList.Location = new System.Drawing.Point(684, 78);
            this.lblBorrowList.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblBorrowList.Name = "lblBorrowList";
            this.lblBorrowList.Size = new System.Drawing.Size(385, 36);
            this.lblBorrowList.TabIndex = 90;
            this.lblBorrowList.Text = "Danh sách phiếu mượn sách";
            this.lblBorrowList.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnCreateReturnCard
            // 
            this.btnCreateReturnCard.BackColor = System.Drawing.Color.LightSeaGreen;
            this.btnCreateReturnCard.BackgroundColor = System.Drawing.Color.LightSeaGreen;
            this.btnCreateReturnCard.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.btnCreateReturnCard.BorderRadius = 25;
            this.btnCreateReturnCard.BorderSize = 0;
            this.btnCreateReturnCard.FlatAppearance.BorderSize = 0;
            this.btnCreateReturnCard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCreateReturnCard.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.btnCreateReturnCard.ForeColor = System.Drawing.Color.White;
            this.btnCreateReturnCard.Location = new System.Drawing.Point(221, 216);
            this.btnCreateReturnCard.Margin = new System.Windows.Forms.Padding(1);
            this.btnCreateReturnCard.Name = "btnCreateReturnCard";
            this.btnCreateReturnCard.Size = new System.Drawing.Size(180, 42);
            this.btnCreateReturnCard.TabIndex = 67;
            this.btnCreateReturnCard.Text = "Tạo phiếu trả sách";
            this.btnCreateReturnCard.TextColor = System.Drawing.Color.White;
            this.btnCreateReturnCard.UseVisualStyleBackColor = false;
            this.btnCreateReturnCard.Click += new System.EventHandler(this.btnCreateReturnCard_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.LightCoral;
            this.btnDelete.BackgroundColor = System.Drawing.Color.LightCoral;
            this.btnDelete.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.btnDelete.BorderRadius = 25;
            this.btnDelete.BorderSize = 0;
            this.btnDelete.FlatAppearance.BorderSize = 0;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.btnDelete.ForeColor = System.Drawing.Color.White;
            this.btnDelete.Location = new System.Drawing.Point(221, 277);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(1);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(180, 42);
            this.btnDelete.TabIndex = 66;
            this.btnDelete.Text = "Xóa phiếu";
            this.btnDelete.TextColor = System.Drawing.Color.White;
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnOpenDetail
            // 
            this.btnOpenDetail.BackColor = System.Drawing.Color.YellowGreen;
            this.btnOpenDetail.BackgroundColor = System.Drawing.Color.YellowGreen;
            this.btnOpenDetail.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.btnOpenDetail.BorderRadius = 25;
            this.btnOpenDetail.BorderSize = 0;
            this.btnOpenDetail.FlatAppearance.BorderSize = 0;
            this.btnOpenDetail.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOpenDetail.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.btnOpenDetail.ForeColor = System.Drawing.Color.White;
            this.btnOpenDetail.Location = new System.Drawing.Point(18, 277);
            this.btnOpenDetail.Margin = new System.Windows.Forms.Padding(2);
            this.btnOpenDetail.Name = "btnOpenDetail";
            this.btnOpenDetail.Size = new System.Drawing.Size(180, 42);
            this.btnOpenDetail.TabIndex = 65;
            this.btnOpenDetail.Text = "Xem chi tiết phiếu";
            this.btnOpenDetail.TextColor = System.Drawing.Color.White;
            this.btnOpenDetail.UseVisualStyleBackColor = false;
            this.btnOpenDetail.Click += new System.EventHandler(this.btnOpenDetail_Click);
            // 
            // btnCreateBorrowCard
            // 
            this.btnCreateBorrowCard.BackColor = System.Drawing.Color.LightSeaGreen;
            this.btnCreateBorrowCard.BackgroundColor = System.Drawing.Color.LightSeaGreen;
            this.btnCreateBorrowCard.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.btnCreateBorrowCard.BorderRadius = 25;
            this.btnCreateBorrowCard.BorderSize = 0;
            this.btnCreateBorrowCard.Enabled = false;
            this.btnCreateBorrowCard.FlatAppearance.BorderSize = 0;
            this.btnCreateBorrowCard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCreateBorrowCard.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.btnCreateBorrowCard.ForeColor = System.Drawing.Color.White;
            this.btnCreateBorrowCard.Location = new System.Drawing.Point(18, 216);
            this.btnCreateBorrowCard.Margin = new System.Windows.Forms.Padding(1);
            this.btnCreateBorrowCard.Name = "btnCreateBorrowCard";
            this.btnCreateBorrowCard.Size = new System.Drawing.Size(180, 42);
            this.btnCreateBorrowCard.TabIndex = 64;
            this.btnCreateBorrowCard.Text = "Tạo phiếu mượn sách";
            this.btnCreateBorrowCard.TextColor = System.Drawing.Color.White;
            this.btnCreateBorrowCard.UseVisualStyleBackColor = false;
            this.btnCreateBorrowCard.Click += new System.EventHandler(this.btnCreateBorrowCard_Click);
            // 
            // BorrowReturnBook
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1260, 724);
            this.Controls.Add(this.lblBorrowList);
            this.Controls.Add(this.txbSearchBook);
            this.Controls.Add(this.lblReturnList);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dtgvBorrowList);
            this.Controls.Add(this.lbTitle);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dtgvReturnList);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "BorrowReturnBook";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.BorrowBook_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtgvBorrowList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvReturnList)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lbTitle;
        private System.Windows.Forms.ToolTip tlTip;
        private System.Windows.Forms.DataGridView dtgvBorrowList;
        private System.Windows.Forms.DataGridView dtgvReturnList;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox cbbList;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lbErrorName;
        private System.Windows.Forms.TextBox txbQuantity;
        private System.Windows.Forms.TextBox txbReaderName;
        private System.Windows.Forms.ComboBox cbbReaderId;
        private System.Windows.Forms.Label lbErrorId;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private LibraryManagement.nButton btnCreateReturnCard;
        private LibraryManagement.nButton btnDelete;
        private LibraryManagement.nButton btnOpenDetail;
        private LibraryManagement.nButton btnCreateBorrowCard;
        private System.Windows.Forms.TextBox txbSearchBook;
        private System.Windows.Forms.Label lblReturnList;
        private System.Windows.Forms.Label lblBorrowList;
        private System.Windows.Forms.Label lbExpried;
        private System.Windows.Forms.DataGridViewTextBoxColumn stt;
        private System.Windows.Forms.DataGridViewTextBoxColumn borrowId;
        private System.Windows.Forms.DataGridViewTextBoxColumn readerCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn14;
        private System.Windows.Forms.DataGridViewTextBoxColumn borrowDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn returnDate;
        private System.Windows.Forms.DataGridViewCheckBoxColumn status;
    }
}

