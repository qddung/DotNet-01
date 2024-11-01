using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OOP_JSON.Model.StudentModel
{
    public enum DiemCapNhat : int
    {
        [Display(Description = "Toán")]
        Toan = 1,
        [Display(Description = "Van")]
        Van = 2,
        [Display(Description = "Anh")]
        Anh = 3
    }

    public class Student
    {
        public Student()
        {
            Id = Guid.NewGuid();
            NhapThongTin();
        }
        public Guid Id { get; private set; }
        public string Code { get; protected set; }
        public string FullName { get; set; }

        public string Name
        {
            get
            {
                if (string.IsNullOrEmpty(FullName)) return "";
                return FullName.Split(" ").LastOrDefault() ?? "";
            }
        }
        public double Toan { get; set; }
        public double Van { get; set; }
        public double Anh { get; set; }

        public double DiemTrungBinh
        {
            get
            {
                return (Toan + Van + Anh) / 3;
            }
        }

        public string XepLoai
        {
            get
            {

                if (DiemTrungBinh >= 8)
                {
                    return "Giỏi";
                }
                else if (DiemTrungBinh >= 6.5)
                {
                    return "Khá";
                }
                else if (DiemTrungBinh >= 5)
                {
                    return "Trung bình";
                }
                return "Yếu";
            }
        }

        public void XuatThongTin(bool showHocLuc = false)
        {
            Console.WriteLine($@"
                Mã học sinh : {Code}
                Tên         : {FullName}
                Toán        : {Toan}
                Văn         : {Van}
                Anh         : {Anh}
            ");
            if (showHocLuc)
            {
                Console.WriteLine($"Học lục: {XepLoai}");
            }
        }

        public void CapNhatDiemSo()
        {
            Helper.Helper.HienThiChucNang<DiemCapNhat>("Chọn môn cần cập nhật");
            var diemMon = Helper.Helper.NhapEnum<DiemCapNhat>();
            switch (diemMon)
            {
                case DiemCapNhat.Toan:
                    double diemToan = Helper.Helper.NhapDiem();
                    Toan = diemToan;
                    break;
                case DiemCapNhat.Van:
                    double diemVan = Helper.Helper.NhapDiem();
                    Van = diemVan;
                    break;
                case DiemCapNhat.Anh:
                    double diemAnh = Helper.Helper.NhapDiem();
                    Anh = diemAnh;
                    break;
                default:
                    Console.WriteLine("Nhập sai thông tin");
                    break;
            }
        }

        private void NhapThongTin()
        {
            Console.WriteLine("Nhập mã học sinh");
            Code = OOP_JSON.Helper.Helper.ReadInput();
            Console.WriteLine("Nhập tên học sinh");
            FullName = OOP_JSON.Helper.Helper.ReadInput();
            Console.WriteLine("Nhập điểm toán học sinh");
            Toan = OOP_JSON.Helper.Helper.NhapDiem();
            Console.WriteLine("Nhập điểm văn học sinh");
            Van = OOP_JSON.Helper.Helper.NhapDiem();
            Console.WriteLine("Nhập điểm anh học sinh");
            Anh = OOP_JSON.Helper.Helper.NhapDiem();
        }


        public bool ContainName(string name)
        {
            if (string.IsNullOrEmpty(name)) return false;
            var search = Helper.Helper.RemoveDiacritics(name.ToLower());
            var studentName = Helper.Helper.RemoveDiacritics(FullName.ToLower());
            return studentName.Contains(search) || FullName.ToLower().Contains(name.ToLower());
        }
    }
}
