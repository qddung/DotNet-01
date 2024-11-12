using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ManagementProduct.Model.ProductModel;
using ManagementProduct.Helper;
namespace ManagemnentProduct.Model.ProductModel.DetailProductModel
{
    public class ThoiTrang : Product
    {
        public ThoiTrang() : base()
        {
            Console.WriteLine("Nhập giá giảm (%)");
            GiaGiam = Helper.NhapTien();
        }
        public double GiaGiam { get; set; }
        public override void HienThiThongTin()
        {
            Console.WriteLine($"Mã:{MaSanPham.ToString()}, Tên:{Ten}, Giá bán: {TinhGiaBan()}, Giá giảm (%): {GiaGiam}");
        }

        public override double TinhGiaBan()
        {
            return (1 - GiaGiam / 100) * GiaGoc;
        }
    }
}
