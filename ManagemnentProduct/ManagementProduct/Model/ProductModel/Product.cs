using ManagementProduct.Model.ProductModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementProduct.Model.ProductModel
{
    public abstract class Product
    {
        public Product()
        {
            Console.WriteLine("Nhập mã sản phẩm");
            MaSanPham = Helper.Helper.NhapNumber();
            Console.WriteLine("Nhập tên sản phẩm");
            Ten = Helper.Helper.ReadInput();
            Console.WriteLine("Nhập giá sản phẩm");
            GiaGoc = Helper.Helper.NhapTien();
        }
        public int MaSanPham { get; private set; }

        public string Ten { get; private set; }

        public double GiaGoc { get; private set; }

        public abstract double TinhGiaBan();
        public virtual void HienThiThongTin()
        {
            Console.WriteLine($"Mã:{MaSanPham.ToString()}, Tên:{Ten}, Giá bán: {TinhGiaBan()}");
        }
    }
}