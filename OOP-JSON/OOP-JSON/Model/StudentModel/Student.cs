using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OOP_JSON.Model.StudentModel
{
    public class Student
    {
        public Student()
        {
            Id = Guid.NewGuid();
        }
        public Guid Id { get; private set; }
        public string Code { get; protected set; }
        public string Name { get; set; }
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

        public void XuatThongTin(bool showHocLuc)
        {
            Console.WriteLine($@"
                Mã học sinh : {Code}
                Tên         : {Name}
                Toán        : {Toan}
                Văn         : {Van}
                Anh         : {Anh}
            ");
            if (showHocLuc)
            {
                Console.WriteLine($"Học lục: {XepLoai}");
            }
        }

        public void NhapThongTin()
        {
            Console.WriteLine("Nhập tên học sinh");
            Code = OOP_JSON.Helper.Helper.ReadInput();
            Console.WriteLine("Nhập tên học sinh");
            Name = OOP_JSON.Helper.Helper.ReadInput();
            Console.WriteLine("Nhập điểm toán học sinh");
            Toan = OOP_JSON.Helper.Helper.NhapDiem();
            Console.WriteLine("Nhập điểm văn học sinh");
            Van = OOP_JSON.Helper.Helper.NhapDiem();
            Console.WriteLine("Nhập điểm anh học sinh");
            Anh = OOP_JSON.Helper.Helper.NhapDiem();
        }
    }
}
