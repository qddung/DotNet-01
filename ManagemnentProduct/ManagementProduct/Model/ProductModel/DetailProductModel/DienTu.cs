using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ManagementProduct.Helper;
using ManagementProduct.Model.ProductModel;
namespace ManagemnentProduct.Model.ProductModel.DetailProductModel
{
    public class DienTu : Product
    {
        public DienTu() : base()
        {
            Console.WriteLine("Nhập thuế bảo hành (%)");
            ThueBaoHanh = Helper.NhapTien();
        }
        public double ThueBaoHanh { get; set; } // %
        public override void HienThiThongTin()
        {
            Console.WriteLine($"Mã:{MaSanPham.ToString()}, Tên:{Ten}, Giá bán: {TinhGiaBan()}, Thuế bảo hành(%): {ThueBaoHanh}");
        }

        public override double TinhGiaBan()
        {
            return (ThueBaoHanh / 100 + 1) * GiaGoc;
        }
    }
}
