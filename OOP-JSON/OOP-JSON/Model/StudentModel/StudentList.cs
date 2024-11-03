using OOP_JSON.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_JSON.Model.StudentModel
{
    public enum StudentFunction : int
    {
        [Display(Description = "Thêm học sinh")]
        ThemHocSinh = 1,
        [Display(Description = "Cập nhật điểm số học sinh")]
        CapNhatDiemSo = 2,
        [Display(Description = "Tìm kiếm học sinh theo tên")]
        TimKiemHocSinhTheoTen = 3,
        [Display(Description = "Xóa học sinh")]
        XoaHocSinh = 4,
        [Display(Description = "Hiển thị danh sách kèm học lực")]
        XepTheoHocLuc = 5,
        [Display(Description = "Sắp xếp danh sách học sinh theo điểm trung bình")]
        SapXepTheoDiemTrungBinh = 6,
        [Display(Description = "Sắp xếp theo tên học sinh tăng dần")]
        SapXepTheoTenHocSinhTangDan = 7,
        [Display(Description = "Đọc thông tin Json")]
        DocJson = 8,
        [Display(Description = "Ghi Thông Tin Json")]
        GhiJson = 9,
        [Display(Description = "Thoát")]
        Exit = 10,
    }


    public class StudentList
    {
        public StudentFunction? StudentFunction { get; set; }
        public static readonly string FilePathData = "Database/Student/Students.json";
        public StudentList()
        {
            StudentFunction = null;
            ListStudent = ReadFileJson();
            if (ListStudent == null) ListStudent = new List<Student>();
        }

        public void DocJson()
        {
            var jsonString = JsonHelper.DocJsonString(FilePathData);
            Console.WriteLine(jsonString);
        }

        public void GhiJson()
        {
            bool checkSaveList = SaveData();
            if (checkSaveList == false)
            {
                Console.WriteLine("Lỗi lưu data chương trình");
            }
        }

        private List<Student> ReadFileJson()
        {
            return JsonHelper.LoadDataFromFile<Student>(FilePathData);
        }
        private List<Student> ListStudent { get; set; }

        public void HienThiChucNang()
        {
            Helper.Helper.HienThiChucNang<StudentFunction>("Danh sách chức năng");
        }

        public void ChonChucNang()
        {
            var func = Helper.Helper.NhapEnum<StudentFunction>();
            StudentFunction = func;
        }

        public bool ValidateHocSinh(Student student)
        {
            return student != null && ListStudent.Any(x => x.Code == student.Code);
        }

        public void ThemHocSinh()
        {
            var student = new Student();
            if (ValidateHocSinh(student))
            {
                Console.WriteLine("Mã bị trùng");
                return;
            }
            ListStudent.Add(student);
        }

        public void CapNhatDiemSo()
        {
            string code = OOP_JSON.Helper.Helper.ReadInput();
            Student st = ListStudent.FirstOrDefault(x => x.Code == code);
            if (st != null)
            {
                st.CapNhatDiemSo();
                bool checkSaveList = SaveData();
                if (checkSaveList == false)
                {
                    Console.WriteLine("Lỗi lưu data chương trình");
                }
            }
            else
            {
                Console.WriteLine($"Không tồn tại mã học sinh {code}");
            }
        }

        public bool SaveData()
        {
            try
            {
                JsonHelper.WriteFileJson<Student>(FilePathData, ListStudent);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
                return false;
            }
        }

        private void ShowListStudent(List<Student> students, bool showHosLuc = false)
        {
            foreach (Student student in students)
            {
                student.XuatThongTin(showHosLuc);
            }
        }

        public void XepTheoHocLuc()
        {
            ShowListStudent(ListStudent, true);
        }

        public void SapXepTheoDiemTrungBinh()
        {
            ShowListStudent(ListStudent.OrderBy(i => i.DiemTrungBinh).ToList());
        }

        public void SapXepTheoTenHocSinhTangDan()
        {
            ShowListStudent(ListStudent.OrderBy(i => i.Name).ToList());
        }

        public void TimKiemHocSinhTheoTen()
        {
            string searchName = Helper.Helper.ReadInput();
            ShowListStudent(ListStudent.Where(i => i.ContainName(searchName)).ToList());
        }

        public void XoaHocSinh()
        {
            string code = OOP_JSON.Helper.Helper.ReadInput();
            Student st = ListStudent.FirstOrDefault(x => x.Code == code);
            if (st != null)
            {
                ListStudent.Remove(st);
                bool checkSaveList = SaveData();
                if (checkSaveList == false)
                {
                    Console.WriteLine("Lỗi lưu data chương trình");
                }
            }
            else
            {
                Console.WriteLine($"Không tồn tại mã học sinh {code}");
            }
        }
    }
}
