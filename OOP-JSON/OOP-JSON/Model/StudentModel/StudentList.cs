using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_JSON.Model.StudentModel
{
    public enum StudentFunction : int
    {
        ThemHocSinh = 1,
        CapNhatDiemSo = 2,  
        TimKiemThongTinTheoTenHocSinh = 3,
        XoaHocSinh = 4,


    }
    public class StudentList
    {
        public StudentList()
        {

        }
        public List<Student> ListStudent { get; set; }

        public void HienThiChucNang()
        {

        }
    }
}
