
namespace ThayDoiQuyDinh
{
    partial class FormThayDoiQuyDinh
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormThayDoiQuyDinh));
            this.lbTieuDe = new System.Windows.Forms.Label();
            this.lbTien = new System.Windows.Forms.Label();
            this.lbSachMax = new System.Windows.Forms.Label();
            this.lbNgayMax = new System.Windows.Forms.Label();
            this.lbTuoiMin = new System.Windows.Forms.Label();
            this.lbTuoiMax = new System.Windows.Forms.Label();
            this.lbLuuHanh = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.lbthoihan = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txbThoiHanThe = new System.Windows.Forms.TextBox();
            this.txbThoiGianLuuHanh = new System.Windows.Forms.TextBox();
            this.txbTuoiToiDa = new System.Windows.Forms.TextBox();
            this.txbSoNgayMuonMax = new System.Windows.Forms.TextBox();
            this.txbTuoiToiThieu = new System.Windows.Forms.TextBox();
            this.txbSoSachMuonMax = new System.Windows.Forms.TextBox();
            this.txbMucThuTienPhat = new System.Windows.Forms.TextBox();
            this.btnCapNhat = new ThayDoiQuyDinh.nButton();
            this.gbQuyDinhHienHanh = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.gbQuyDinhHienHanh)).BeginInit();
            this.SuspendLayout();
            // 
            // lbTieuDe
            // 
            this.lbTieuDe.AutoSize = true;
            this.lbTieuDe.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTieuDe.ForeColor = System.Drawing.Color.Navy;
            this.lbTieuDe.Location = new System.Drawing.Point(477, 9);
            this.lbTieuDe.Name = "lbTieuDe";
            this.lbTieuDe.Size = new System.Drawing.Size(283, 36);
            this.lbTieuDe.TabIndex = 0;
            this.lbTieuDe.Text = "Thay Đổi Quy Định";
            // 
            // lbTien
            // 
            this.lbTien.AutoSize = true;
            this.lbTien.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTien.ForeColor = System.Drawing.Color.LavenderBlush;
            this.lbTien.Location = new System.Drawing.Point(672, 579);
            this.lbTien.Name = "lbTien";
            this.lbTien.Size = new System.Drawing.Size(187, 39);
            this.lbTien.TabIndex = 19;
            this.lbTien.Text = "1000 đồng";
            // 
            // lbSachMax
            // 
            this.lbSachMax.AutoSize = true;
            this.lbSachMax.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbSachMax.ForeColor = System.Drawing.Color.LavenderBlush;
            this.lbSachMax.Location = new System.Drawing.Point(808, 500);
            this.lbSachMax.Name = "lbSachMax";
            this.lbSachMax.Size = new System.Drawing.Size(125, 39);
            this.lbSachMax.TabIndex = 20;
            this.lbSachMax.Text = "4 cuốn";
            this.lbSachMax.Click += new System.EventHandler(this.lbSachMax_Click);
            // 
            // lbNgayMax
            // 
            this.lbNgayMax.AutoSize = true;
            this.lbNgayMax.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbNgayMax.ForeColor = System.Drawing.Color.LavenderBlush;
            this.lbNgayMax.Location = new System.Drawing.Point(758, 430);
            this.lbNgayMax.Name = "lbNgayMax";
            this.lbNgayMax.Size = new System.Drawing.Size(125, 39);
            this.lbNgayMax.TabIndex = 21;
            this.lbNgayMax.Text = "5 ngày";
            this.lbNgayMax.Click += new System.EventHandler(this.lbNgayMax_Click);
            // 
            // lbTuoiMin
            // 
            this.lbTuoiMin.AutoSize = true;
            this.lbTuoiMin.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTuoiMin.ForeColor = System.Drawing.Color.LavenderBlush;
            this.lbTuoiMin.Location = new System.Drawing.Point(830, 349);
            this.lbTuoiMin.Name = "lbTuoiMin";
            this.lbTuoiMin.Size = new System.Drawing.Size(126, 39);
            this.lbTuoiMin.TabIndex = 22;
            this.lbTuoiMin.Text = "18 tuổi";
            // 
            // lbTuoiMax
            // 
            this.lbTuoiMax.AutoSize = true;
            this.lbTuoiMax.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTuoiMax.ForeColor = System.Drawing.Color.LavenderBlush;
            this.lbTuoiMax.Location = new System.Drawing.Point(834, 263);
            this.lbTuoiMax.Name = "lbTuoiMax";
            this.lbTuoiMax.Size = new System.Drawing.Size(126, 39);
            this.lbTuoiMax.TabIndex = 23;
            this.lbTuoiMax.Text = "55 tuổi";
            // 
            // lbLuuHanh
            // 
            this.lbLuuHanh.AutoSize = true;
            this.lbLuuHanh.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbLuuHanh.ForeColor = System.Drawing.Color.LavenderBlush;
            this.lbLuuHanh.Location = new System.Drawing.Point(915, 188);
            this.lbLuuHanh.Name = "lbLuuHanh";
            this.lbLuuHanh.Size = new System.Drawing.Size(116, 39);
            this.lbLuuHanh.TabIndex = 24;
            this.lbLuuHanh.Text = "5 năm";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.ForeColor = System.Drawing.Color.Navy;
            this.label16.Location = new System.Drawing.Point(178, 578);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(612, 39);
            this.label16.TabIndex = 25;
            this.label16.Text = "7.Mức tiền phạt cho mỗi cuốn sách là";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.Color.Navy;
            this.label15.Location = new System.Drawing.Point(178, 501);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(772, 39);
            this.label15.TabIndex = 26;
            this.label15.Text = "6.Số Sách được mượn tối đa của một độc giả là";
            this.label15.Click += new System.EventHandler(this.label15_Click);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.Navy;
            this.label14.Location = new System.Drawing.Point(178, 430);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(727, 39);
            this.label14.TabIndex = 27;
            this.label14.Text = "5.Số ngày mượn tối đa của một cuốn sách là";
            this.label14.Click += new System.EventHandler(this.label14_Click);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.Navy;
            this.label13.Location = new System.Drawing.Point(178, 349);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(853, 39);
            this.label13.TabIndex = 28;
            this.label13.Text = "4.Tuổi tối thiểu của độc giả được phép mượn sách là";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.Navy;
            this.label12.Location = new System.Drawing.Point(178, 263);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(814, 39);
            this.label12.TabIndex = 29;
            this.label12.Text = "3.Tuổi tối đa của độc giả được phép mượn sách là";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.Navy;
            this.label11.Location = new System.Drawing.Point(178, 188);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(931, 39);
            this.label11.TabIndex = 30;
            this.label11.Text = "2.Chỉ nhận sách có thời gian lưu hành bé hơn hoặc bằng ";
            // 
            // lbthoihan
            // 
            this.lbthoihan.AutoSize = true;
            this.lbthoihan.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbthoihan.ForeColor = System.Drawing.Color.LavenderBlush;
            this.lbthoihan.Location = new System.Drawing.Point(648, 109);
            this.lbthoihan.Name = "lbthoihan";
            this.lbthoihan.Size = new System.Drawing.Size(137, 39);
            this.lbthoihan.TabIndex = 31;
            this.lbthoihan.Text = "7 tháng";
            this.lbthoihan.Click += new System.EventHandler(this.lbthoihan_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.Navy;
            this.label10.Location = new System.Drawing.Point(178, 110);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(582, 39);
            this.label10.TabIndex = 32;
            this.label10.Text = "1.Thời hạn giá trị của thẻ độc giả là";
            this.label10.Click += new System.EventHandler(this.label10_Click);
            // 
            // txbThoiHanThe
            // 
            this.txbThoiHanThe.BackColor = System.Drawing.SystemColors.Control;
            this.txbThoiHanThe.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbThoiHanThe.Location = new System.Drawing.Point(1016, 110);
            this.txbThoiHanThe.MaxLength = 4;
            this.txbThoiHanThe.Name = "txbThoiHanThe";
            this.txbThoiHanThe.Size = new System.Drawing.Size(185, 38);
            this.txbThoiHanThe.TabIndex = 1;
            this.txbThoiHanThe.TextChanged += new System.EventHandler(this.txbThoiHanThe_TextChanged);
            this.txbThoiHanThe.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
            // 
            // txbThoiGianLuuHanh
            // 
            this.txbThoiGianLuuHanh.BackColor = System.Drawing.SystemColors.Control;
            this.txbThoiGianLuuHanh.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbThoiGianLuuHanh.Location = new System.Drawing.Point(1016, 195);
            this.txbThoiGianLuuHanh.Name = "txbThoiGianLuuHanh";
            this.txbThoiGianLuuHanh.Size = new System.Drawing.Size(185, 38);
            this.txbThoiGianLuuHanh.TabIndex = 2;
            this.txbThoiGianLuuHanh.TextChanged += new System.EventHandler(this.txbThoiGianLuuHanh_TextChanged);
            this.txbThoiGianLuuHanh.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox2_KeyPress);
            // 
            // txbTuoiToiDa
            // 
            this.txbTuoiToiDa.BackColor = System.Drawing.SystemColors.Control;
            this.txbTuoiToiDa.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbTuoiToiDa.Location = new System.Drawing.Point(1016, 267);
            this.txbTuoiToiDa.Name = "txbTuoiToiDa";
            this.txbTuoiToiDa.Size = new System.Drawing.Size(185, 38);
            this.txbTuoiToiDa.TabIndex = 3;
            this.txbTuoiToiDa.TextChanged += new System.EventHandler(this.txbTuoiToiDa_TextChanged);
            this.txbTuoiToiDa.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox3_KeyPress);
            // 
            // txbSoNgayMuonMax
            // 
            this.txbSoNgayMuonMax.BackColor = System.Drawing.SystemColors.Control;
            this.txbSoNgayMuonMax.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbSoNgayMuonMax.Location = new System.Drawing.Point(1016, 431);
            this.txbSoNgayMuonMax.Name = "txbSoNgayMuonMax";
            this.txbSoNgayMuonMax.Size = new System.Drawing.Size(185, 38);
            this.txbSoNgayMuonMax.TabIndex = 5;
            this.txbSoNgayMuonMax.TextChanged += new System.EventHandler(this.txbSoNgayMuonMax_TextChanged);
            this.txbSoNgayMuonMax.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox4_KeyPress);
            // 
            // txbTuoiToiThieu
            // 
            this.txbTuoiToiThieu.BackColor = System.Drawing.SystemColors.Control;
            this.txbTuoiToiThieu.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbTuoiToiThieu.Location = new System.Drawing.Point(1016, 351);
            this.txbTuoiToiThieu.Name = "txbTuoiToiThieu";
            this.txbTuoiToiThieu.Size = new System.Drawing.Size(185, 38);
            this.txbTuoiToiThieu.TabIndex = 4;
            this.txbTuoiToiThieu.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox5_KeyPress);
            // 
            // txbSoSachMuonMax
            // 
            this.txbSoSachMuonMax.BackColor = System.Drawing.SystemColors.Control;
            this.txbSoSachMuonMax.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbSoSachMuonMax.Location = new System.Drawing.Point(1016, 503);
            this.txbSoSachMuonMax.Name = "txbSoSachMuonMax";
            this.txbSoSachMuonMax.Size = new System.Drawing.Size(185, 38);
            this.txbSoSachMuonMax.TabIndex = 6;
            this.txbSoSachMuonMax.TextChanged += new System.EventHandler(this.txbSoSachMuonMax_TextChanged);
            this.txbSoSachMuonMax.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox6_KeyPress);
            // 
            // txbMucThuTienPhat
            // 
            this.txbMucThuTienPhat.BackColor = System.Drawing.SystemColors.Control;
            this.txbMucThuTienPhat.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbMucThuTienPhat.Location = new System.Drawing.Point(1016, 576);
            this.txbMucThuTienPhat.Name = "txbMucThuTienPhat";
            this.txbMucThuTienPhat.Size = new System.Drawing.Size(185, 38);
            this.txbMucThuTienPhat.TabIndex = 7;
            this.txbMucThuTienPhat.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox7_KeyPress);
            // 
            // btnCapNhat
            // 
            this.btnCapNhat.BackColor = System.Drawing.Color.YellowGreen;
            this.btnCapNhat.BackgroundColor = System.Drawing.Color.YellowGreen;
            this.btnCapNhat.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.btnCapNhat.BorderRadius = 20;
            this.btnCapNhat.BorderSize = 0;
            this.btnCapNhat.FlatAppearance.BorderSize = 0;
            this.btnCapNhat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCapNhat.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCapNhat.ForeColor = System.Drawing.Color.White;
            this.btnCapNhat.Location = new System.Drawing.Point(554, 650);
            this.btnCapNhat.Name = "btnCapNhat";
            this.btnCapNhat.Size = new System.Drawing.Size(155, 42);
            this.btnCapNhat.TabIndex = 8;
            this.btnCapNhat.Text = "Cập Nhật";
            this.btnCapNhat.TextColor = System.Drawing.Color.White;
            this.btnCapNhat.UseVisualStyleBackColor = false;
            this.btnCapNhat.Click += new System.EventHandler(this.nButton1_Click);
            // 
            // gbQuyDinhHienHanh
            // 
            this.gbQuyDinhHienHanh.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbQuyDinhHienHanh.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gbQuyDinhHienHanh.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.gbQuyDinhHienHanh.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            this.gbQuyDinhHienHanh.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(142)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Navy;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gbQuyDinhHienHanh.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.gbQuyDinhHienHanh.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gbQuyDinhHienHanh.EnableHeadersVisualStyles = false;
            this.gbQuyDinhHienHanh.GridColor = System.Drawing.SystemColors.ActiveCaption;
            this.gbQuyDinhHienHanh.Location = new System.Drawing.Point(12, 68);
            this.gbQuyDinhHienHanh.Name = "gbQuyDinhHienHanh";
            this.gbQuyDinhHienHanh.RowHeadersVisible = false;
            this.gbQuyDinhHienHanh.RowHeadersWidth = 51;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Navy;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(90)))), ((int)(((byte)(114)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.Control;
            this.gbQuyDinhHienHanh.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.gbQuyDinhHienHanh.RowTemplate.Height = 24;
            this.gbQuyDinhHienHanh.Size = new System.Drawing.Size(1228, 643);
            this.gbQuyDinhHienHanh.TabIndex = 4;
            this.gbQuyDinhHienHanh.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gbQuyDinhHienHanh_CellContentClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Snow;
            this.label1.Location = new System.Drawing.Point(39, 162);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(1563, 16);
            this.label1.TabIndex = 34;
            this.label1.Text = resources.GetString("label1.Text");
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Snow;
            this.label2.Location = new System.Drawing.Point(39, 236);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(1563, 16);
            this.label2.TabIndex = 35;
            this.label2.Text = resources.GetString("label2.Text");
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Snow;
            this.label3.Location = new System.Drawing.Point(39, 308);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(1563, 16);
            this.label3.TabIndex = 36;
            this.label3.Text = resources.GetString("label3.Text");
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Snow;
            this.label4.Location = new System.Drawing.Point(39, 392);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(1563, 16);
            this.label4.TabIndex = 37;
            this.label4.Text = resources.GetString("label4.Text");
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.Snow;
            this.label5.Location = new System.Drawing.Point(39, 484);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(1563, 16);
            this.label5.TabIndex = 38;
            this.label5.Text = resources.GetString("label5.Text");
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.Snow;
            this.label6.Location = new System.Drawing.Point(39, 557);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(1563, 16);
            this.label6.TabIndex = 39;
            this.label6.Text = resources.GetString("label6.Text");
            // 
            // FormThayDoiQuyDinh
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1260, 724);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbTien);
            this.Controls.Add(this.txbMucThuTienPhat);
            this.Controls.Add(this.btnCapNhat);
            this.Controls.Add(this.lbSachMax);
            this.Controls.Add(this.lbNgayMax);
            this.Controls.Add(this.txbSoSachMuonMax);
            this.Controls.Add(this.lbTuoiMin);
            this.Controls.Add(this.lbTuoiMax);
            this.Controls.Add(this.txbTuoiToiThieu);
            this.Controls.Add(this.txbSoNgayMuonMax);
            this.Controls.Add(this.lbLuuHanh);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.txbTuoiToiDa);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.txbThoiGianLuuHanh);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.lbthoihan);
            this.Controls.Add(this.txbThoiHanThe);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.gbQuyDinhHienHanh);
            this.Controls.Add(this.lbTieuDe);
            this.DoubleBuffered = true;
            this.ForeColor = System.Drawing.Color.Snow;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormThayDoiQuyDinh";
            this.Text = "0";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gbQuyDinhHienHanh)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lbTieuDe;
        private System.Windows.Forms.Label lbTien;
        private System.Windows.Forms.Label lbSachMax;
        private System.Windows.Forms.Label lbNgayMax;
        private System.Windows.Forms.Label lbTuoiMin;
        private System.Windows.Forms.Label lbTuoiMax;
        private System.Windows.Forms.Label lbLuuHanh;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label lbthoihan;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txbThoiHanThe;
        private System.Windows.Forms.TextBox txbThoiGianLuuHanh;
        private System.Windows.Forms.TextBox txbTuoiToiDa;
        private System.Windows.Forms.TextBox txbSoNgayMuonMax;
        private System.Windows.Forms.TextBox txbTuoiToiThieu;
        private System.Windows.Forms.TextBox txbSoSachMuonMax;
        private nButton btnCapNhat;
        private System.Windows.Forms.TextBox txbMucThuTienPhat;
        private System.Windows.Forms.DataGridView gbQuyDinhHienHanh;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
    }
}

