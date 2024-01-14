using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls.Primitives;
using System.Windows.Forms;
using System.Windows.Shapes;

namespace LibraryManagement.Models
{
    public class DatabaseInfo
    {
        //Change the connectionString value before re-build the app
        public static string connectionString = @"Data Source=LAPTOP-281DQ5C3\SQLEXPRESS;Initial Catalog=QLTV;Integrated Security=True";
        public static string bookStockQueryCmd = @"SELECT DISTINCT CUONSACH.MaCuonSach, CUONSACH.MaSach, TenDauSach, TenTacGia, TenTheLoai
FROM SACH, DAUSACH, CUONSACH, THELOAI, CTTACGIA, TACGIA
WHERE SACH.MaDauSach = DAUSACH.MaDauSach AND DAUSACH.MaTheLoai = THELOAI.MaTheLoai
AND DAUSACH.MaDauSach = CTTACGIA.MaDauSach AND CTTACGIA.MaTacGia = TACGIA.MaTacGia
AND SACH.MaSach = CUONSACH.MaSach AND TinhTrang = 1
AND CUONSACH.MaCuonSach = (SELECT MAX(B.MaCuonSach)
    FROM CUONSACH B
    WHERE B.MaSach = CUONSACH.MaSach AND B. TinhTrang = 1)
ORDER BY CUONSACH.MaSach";
        public static string parametersQueryCmd = @"SELECT * from THAMSO";
        public static string readersQueryCmd = "SELECT MaDocGia, HoTen, NgHetHan, Email FROM DOCGIA";
        public static string getBookSlipCode = @"SELECT TOP (1) MAPHIEUMUONSACH
FROM PHIEUMUON
ORDER BY MaPhieuMuonSach DESC";
        public static string GetNumOfBooksBorrowed(string readerCode)
        {
            return $@"SELECT COUNT(*)
FROM PHIEUMUON, CTPHIEUMUON
WHERE MaDocGia = '{readerCode}' AND PHIEUMUON.MaPhieuMuonSach = CTPHIEUMUON.MaPhieuMuonSach AND TinhTrangPM = 0";
        }
        public static string borrowSlipQuery = @"SELECT DISTINCT PHIEUMUON.MaPhieuMuonSach, PHIEUMUON.MaDocGia, HoTen, HanTra, TongNo, Email
FROM PHIEUMUON, CTPHIEUMUON, DOCGIA
WHERE PHIEUMUON.MaPhieuMuonSach = CTPHIEUMUON.MaPhieuMuonSach AND PHIEUMUON.MaDocGia = DOCGIA.MaDocGia
                        AND TinhTrangPM = 0";
        public static string borrowedBooksQuery = @"SELECT CTPHIEUMUON.MaPhieuMuonSach, SACH.MaSach, TenDauSach, NgMuon, CTPHIEUMUON.MaCuonSach, MaChiTietPhieuMuon
FROM SACH, CUONSACH, PHIEUMUON, CTPHIEUMUON, DAUSACH
WHERE PHIEUMUON.MaPhieuMuonSach = CTPHIEUMUON.MaPhieuMuonSach AND CTPHIEUMUON.MaCuonSach = CUONSACH.MaCuonSach AND TinhTrangPM = 0";

        public static string getNewReturnSlipCode = @"SELECT TOP (1) MAPHIEUTRASACH
FROM PHIEUTRASACH
ORDER BY MAPHIEUTRASACH DESC";

        public static string getAllBorrowCards = @"SELECT MaPhieuMuonSach, PHIEUMUON.MaDocGia, HoTen, NgMuon, HanTra
FROM PHIEUMUON, DOCGIA
WHERE PHIEUMUON.MaDocGia = DOCGIA.MaDocGia
ORDER BY MaPhieuMuonSach";

        public static string getAllReturnCards = @"SELECT DISTINCT PHIEUTRASACH.MaPhieuTraSach, PHIEUTRASACH.MaDocGia, HoTen, NgTra, TienPhatKyNay
FROM PHIEUTRASACH, DOCGIA
WHERE PHIEUTRASACH.MaDocGia = DOCGIA.MaDocGia 
ORDER BY MaPhieuTraSach, PHIEUTRASACH.MaDocGia";

        public static string GetBorrowCardById(string id)
        {
            return $@"SELECT PHIEUMUON.MaPhieuMuonSach, PHIEUMUON.MaDocGia, HoTen, NgMuon, HanTra
FROM PHIEUMUON, DOCGIA
WHERE PHIEUMUON.MaDocGia = DOCGIA.MaDocGia AND PHIEUMUON.MaPhieuMuonSach ='{id}'";
        }

        public static string InsertBorrowCard(BorrowCard card)
        {
            string insertNewCard = $@"INSERT INTO PHIEUMUON (MaPhieuMuonSach, MaDocGia, NgMuon, HanTra) VALUES('{card.id}', '{card.readerId}','{card.borrowDate}','{card.returnDate}')";
            string insertDetailCard = "";
            string updateBookState = "";

            foreach (Book book in card.borrowBooks)
            {
                insertDetailCard += "\n" + $@"INSERT INTO CTPHIEUMUON(MaPhieuMuonSach, MaCuonSach, TinhTrangPM) VALUES('{card.id}','{book.id}', 0)";
                updateBookState += book.RequestBorrow();
            }
            return insertNewCard + insertDetailCard + updateBookState;
        }

        public static string DeleteBorrowCard(string id)
        {
            return "EXEC DeleteBorrowCard " + id; 
        }

        public static string UpdateBorrowCard(string id, string borrowDate, string returnDate)
        {
            return $@"UPDATE PHIEUMUON
SET NgMuon = '{borrowDate}', HanTra = '{returnDate}'
WHERE MaPhieuMuonSach = '{id}'";
        }

        public static string GetAllDetailBorrowByBorrowCardId(string id)
        {
            return $@"SELECT MaChiTietPhieuMuon, CTPHIEUMUON.MaCuonSach, TenDauSach, TinhTrangPM
FROM CTPHIEUMUON, PHIEUMUON, DAUSACH, SACH, CUONSACH
WHERE PHIEUMUON.MaPhieuMuonSach = '{id}' 
AND PHIEUMUON.MaPhieuMuonSach = CTPHIEUMUON.MaPhieuMuonSach
AND CUONSACH.MaCuonSach = CTPHIEUMUON.MaCuonSach
AND CUONSACH.MaSach = SACH.MaSach
AND DAUSACH.MaDauSach = SACH.MaDauSach
ORDER BY MaChiTietPhieuMuon, CTPHIEUMUON.MaCuonSach";
        }

        public static string GetDetailBorrowIdByBorrowCardIdAndBookId(string id, string bookId)
        {
            return $@"SELECT MaChiTietPhieuMuon FROM CTPHIEUMUON WHERE MaPhieuMuonSach = '{id}' AND MaCuonSach = '{bookId}'";
        }

        public static string DeleteDetailBorrowCardById(string id, string detailId, string bookId, bool deleteCard)
        {
            string query = $@"DELETE FROM CTPT
WHERE 1 = (SELECT COUNT(*) FROM CTPT CTPT1 WHERE CTPT1.MaPhieuTraSach IN 
    (SELECT DISTINCT PTS.MaPhieuTraSach
    FROM PHIEUTRASACH PTS, CTPT
    WHERE PTS.MaPhieuTraSach = CTPT.MaPhieuTraSach AND CTPT.MaCuonSach IN 
        (SELECT CTPT.MaCuonSach FROM CTPT
        WHERE CTPT.MaPhieuMuonSach = '{id}') AND MaPhieuMuonSach = '{id}'))

DELETE FROM CTPT WHERE MaPhieuMuonSach = '{id}' AND MaCuonSach = '{bookId}'
DELETE FROM CTPHIEUMUON WHERE MaChiTietPhieuMuon = '{detailId}'
UPDATE CUONSACH SET TinhTrang = 1 WHERE MaCuonSach = '{bookId}'";

            if (deleteCard)
                query += "\n" + $@"DELETE FROM PHIEUMUON WHERE MaPhieuMuonSach = '{id}'";
            return query;
        }

        public static string GetReturnCardById(string id)
        {
            return $@"SELECT PHIEUTRASACH.MaPhieuTraSach, PHIEUTRASACH.MaDocGia, HoTen, NgTra, TienPhatKyNay
FROM PHIEUTRASACH, DOCGIA
WHERE PHIEUTRASACH.MaDocGia = DOCGIA.MaDocGia AND PHIEUTRASACH.MaPhieuTraSach ='{id}'";
        }

        public static string InsertReturnCard(ReturnCard card)
        {
            string insertNewCard = $@"INSERT INTO PHIEUTRASACH(MaDocGia, NgTra, TienPhatKyNay) VALUES('{card.readerId}', '{card.returnDate}', {card.fineThisPeriod})";
            string insertDetailCard = "";
            string updateBookState = "";

            foreach (BorrowedBook book in card.returnBooks)
            {
                insertDetailCard += "\n" + $@"INSERT INTO CTPT(MaPhieuTraSach, MaCuonSach, MaPhieuMuonSach, SoNgayMuon, TienPhat) VALUES('{card.id}','{book.id}','{book.borrowCardId}','{book.borrowedDays}', '{book.fine}')";
                updateBookState += "\n" + $@"UPDATE CTPHIEUMUON SET TinhTrangPM = 1 WHERE MaChiTietPhieuMuon = '{book.detailBorrowId}'" + "\n" + book.RequestReturn();
            }
            return insertNewCard + insertDetailCard + updateBookState;
        }

        public static string DeleteReturnCard(string id)
        {
            return $@"UPDATE CTPHIEUMUON SET TinhTrangPM = 0  WHERE MaChiTietPhieuMuon IN 
(SELECT MaChiTietPhieuMuon FROM CTPHIEUMUON, CTPT WHERE  CTPHIEUMUON.MaPhieuMuonSach = CTPT.MaPhieuMuonSach AND CTPT.MaPhieuTraSach = '{id}')
UPDATE CUONSACH SET TinhTrang = 0 WHERE CUONSACH.MaCuonSach IN(SELECT CTPT.MaCuonSach FROM CTPT WHERE CTPT.MaPhieuTraSach = '{id}')
DELETE FROM CTPT WHERE MaPhieuTraSach = '{id}'
DELETE FROM PHIEUTRASACH WHERE MaPhieuTraSach = '{id}'";
        }

        public static string GetDetailReturnCardById(string id)
        {
            return $@"SELECT MaChiTietPhieuTra, CTPT.MaCuonSach, TenDauSach, CTPT.MaPhieuTraSach, CTPT.MaPhieuMuonSach, SoNgayMuon, SoNgayTraTre, TienPhat
FROM CTPT, PHIEUTRASACH, SACH, CUONSACH, DAUSACH, PHIEUMUON
WHERE CTPT.MaPhieuTraSach = PHIEUTRASACH.MaPhieuTraSach 
AND CTPT.MaPhieuMuonSach = PHIEUMUON.MaPhieuMuonSach
AND CUONSACH.MaCuonSach = CTPT.MaCuonSach
AND CUONSACH.MaSach = SACH.MaSach
AND DAUSACH.MaDauSach = SACH.MaDauSach
AND CTPT.MaChiTietPhieuTra = '{id}'";
        }

        public static string DeleteDetailReturnCardById(DetailReturnCard detail, string detailBorrowId, bool deleteCard)
        {
            string query = $@"DELETE FROM CTPT WHERE MaChiTietPhieuTra = '{detail.id}'
UPDATE CUONSACH SET TinhTrang = 0 WHERE MaCuonSach = '{detail.bookId}'
UPDATE CTPHIEUMUON SET TinhTrangPM = 0 WHERE MaChiTietPhieuMuon = '{detailBorrowId}'
UPDATE PHIEUTRASACH SET TienPhatKyNay = TienPhatKyNay - {detail.fine} WHERE MaPhieuTraSach = '{detail.returnCardId}'";

            if (deleteCard)
                query += $"\nDELETE FROM PHIEUTRASACH WHERE MaPhieuTraSach = '{detail.returnCardId}'";
            return query;
        }

        public static string GetBorrowedBooksByReaderId(string id)
        {
            return $@"SELECT DISTINCT CUONSACH.MaCuonSach,TenDauSach, CTPHIEUMUON.MaPhieuMuonSach, MaChiTietPhieuMuon, NgMuon, HanTra
FROM PHIEUMUON, CTPHIEUMUON, SACH, CUONSACH, DAUSACH
WHERE PHIEUMUON.MaPhieuMuonSach = CTPHIEUMUON.MaPhieuMuonSach 
AND CTPHIEUMUON.MaCuonSach = CUONSACH.MaCuonSach
AND CUONSACH.MaSach = SACH.MaSach 
AND SACH.MaDauSach = DAUSACH.MaDauSach 
AND TinhTrangPM = 0 AND MaDocGia='{id}'
ORDER BY MaCuonSach";
        }

        public static string GetBorrowedBooks(string bookId, string readerId)
        {
            return $@"SELECT DISTINCT TenDauSach, CTPHIEUMUON.MaPhieuMuonSach, MaChiTietPhieuMuon, NgMuon, HanTra
FROM PHIEUMUON, CTPHIEUMUON, SACH, CUONSACH, DAUSACH
WHERE PHIEUMUON.MaPhieuMuonSach = CTPHIEUMUON.MaPhieuMuonSach 
AND CTPHIEUMUON.MaCuonSach = CUONSACH.MaCuonSach
AND CUONSACH.MaSach = SACH.MaSach 
AND SACH.MaDauSach = DAUSACH.MaDauSach 
AND TinhTrangPM = 0 AND CUONSACH.MaCuonSach='{bookId}' AND MaDocGia='{readerId}'";
        }

        public static string GetAllDetailReturnByReturnCardId(string id)
        {
            return $@"SELECT MaChiTietPhieuTra, CTPT.MaCuonSach, TenDauSach, CTPT.MaPhieuMuonSach, SoNgayMuon, TienPhat
FROM CTPT, PHIEUTRASACH, SACH, CUONSACH, DAUSACH, PHIEUMUON
WHERE CTPT.MaPhieuTraSach = PHIEUTRASACH.MaPhieuTraSach 
AND CTPT.MaPhieuMuonSach = PHIEUMUON.MaPhieuMuonSach
AND CUONSACH.MaCuonSach = CTPT.MaCuonSach
AND CUONSACH.MaSach = SACH.MaSach
AND DAUSACH.MaDauSach = SACH.MaDauSach
AND CTPT.MaPhieuTraSach = '{id}' 
ORDER BY MaChiTietPhieuTra, MaCuonSach";
        }

        public static string GetDebtByReaderId(string id)
        {
            return $@"SELECT TongNo FROM DOCGIA WHERE MaDocGia='{id}'";
        }

        public static string GetReaderById(string id)
        {
            return $"SELECT MaDocGia, HoTen, NgHetHan, Email FROM DOCGIA WHERE MaDocGia ='{id}'";
        }

        public static string GetNumberOfDetailReturnByBorrowIdAndBookId(string borrow, string book)
        {
            return $@"SELECT COUNT(*) 
FROM PHIEUTRASACH, CTPT
WHERE PHIEUTRASACH.MaPhieuTraSach = CTPT.MaPhieuTraSach AND CTPT.MaPhieuTraSach = 
(SELECT CTPT.MaPhieuTraSach FROM CTPT
WHERE CTPT.MaPhieuMuonSach = '{borrow}' AND MaCuonSach='{book}')";
        }

        public static string DeleteReturnCardByDeleteBorrowCard(string borrow, string book)
        {
            return $@"DELETE FROM PHIEUTRASACH WHERE 1 = 
    (SELECT COUNT(*) FROM PHIEUTRASACH PTS, CTPT
    WHERE PHIEUTRASACH.MaPhieuTraSach = CTPT.MaPhieuTraSach 
    AND PHIEUTRASACH.MaPhieuTraSach = PTS.MaPhieuTraSach AND PTS.MaPhieuTraSach =
        (SELECT CTPT.MaPhieuTraSach FROM CTPT WHERE CTPT.MaPhieuMuonSach = '{borrow}' AND MaCuonSach = '{book}'))";
        }
    }
}
