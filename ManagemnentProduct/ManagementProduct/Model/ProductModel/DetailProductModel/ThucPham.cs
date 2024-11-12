using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ManagementProduct.Helper;
using ManagementProduct.Model.ProductModel;

namespace ManagemnentProduct.Model.ProductModel.DetailProductModel
{
    public class ThucPham : Product
    {
        public ThucPham() : base()
        {
            Console.WriteLine("Nhập phí vận chuyển (%)");
            PhiVanChuyen = Helper.NhapTien();
        }
        public double PhiVanChuyen { get; set; }
        public override void HienThiThongTin()
        {
            Console.WriteLine($"Mã:{MaSanPham.ToString()}, Tên:{Ten}, Giá bán: {TinhGiaBan()}, Phí vận chuyển(%): {PhiVanChuyen}");
        }

        public override double TinhGiaBan()
        {
            return PhiVanChuyen + GiaGoc;
        }
    }
}
