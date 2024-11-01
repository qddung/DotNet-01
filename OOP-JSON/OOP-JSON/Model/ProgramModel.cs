using OOP_JSON.Helper;
using OOP_JSON.Model.StudentModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_JSON.Model
{
    public enum EnumProgram : int
    {
        [Display(Description = "Chương trình học sinh")]
        Student = 1,
        [Display(Description = "Chương trình quản lý hàng hóa")]
        Inventory = 2,
        [Display(Description = "Dừng chương trình")]
        Stop = 3,
    }
    class ProgramModel
    {

        public ProgramModel()
        {
            ProgramType = null;
        }
        public EnumProgram? ProgramType { get; private set; }
        public void ChonChuongTrinh()
        {
            var program = Helper.Helper.NhapEnum<EnumProgram>();
            ProgramType = program;
        }
        public void HienThiChucNang()
        {
            Helper.Helper.HienThiChucNang<EnumProgram>("Danh sách chương trình");
        }

    }
}
