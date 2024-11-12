using ManagementProduct.Helper;
using ManagementProduct.ProductModel.Helper;
using ManagemnentProduct.Model.ProductModel.DetailProductModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace ManagementProduct.Model.ProductModel
{
    public enum ProductFunction : int
    {
        [Display(Description = "Thêm sản phẩm")]
        ThemSanPham = 1,
        [Display(Description = "Hiển thị danh sách sản phẩm")]
        DanhSachSanPham = 2,
        [Display(Description = "Tính tổng doanh thu")]
        TinhDoanhThu = 3,
        [Display(Description = "Xóa sản phẩm")]
        XoaSanPham = 4,
        [Display(Description = "Thoát")]
        Thoat = 5,
    }

    public enum ProductType : int
    {
        [Display(Description = "Điện từ")]
        DienTu = 1,
        [Display(Description = "Thực phẩm")]
        ThucPham = 2,
        [Display(Description = "Thời trang")]
        ThoiTrang = 3,

    }
    public class ProductList
    {
        public ProductFunction? ProductFunction { get; set; }
        public void ChonChucNang()
        {
            HienThiChucNang();
            var func = Helper.Helper.NhapEnum<ProductFunction>();
            ProductFunction = func;
        }
        public ProductList()
        {
            ListProduct = new List<Product>();
        }

        public List<Product> ListProduct { get; private set; }

        private void HienThiChucNang()
        {
            Helper.Helper.HienThiChucNang<ProductFunction>("Danh sách chức năng");
        }

        public void TinhDoanhThu()
        {
            double tong = 0;
            foreach (var item in ListProduct)
            {
                tong += item.TinhGiaBan();
            }
            Console.WriteLine($"Tổng doanh thu: {tong}");
        }

        public void DanhSachSanPham()
        {
            Console.WriteLine("Hiển thị danh sách sản phẩm");
            foreach (var item in ListProduct)
            {
                item.HienThiThongTin();
            }
        }

        public void XoaSanPham()
        {
            Console.WriteLine("Nhập mã sản phẩm");
            var ma = Helper.Helper.NhapNumber();
            var prod = ListProduct.FirstOrDefault(i => i.MaSanPham == ma);
            if (prod == null)
            {
                Console.WriteLine("Không tìm thấy sản phẩm");
                return;
            }
            ListProduct.Remove(prod);
            Console.WriteLine("Xóa sản phẩm thành công");

        }

        public void ThemSanPham()
        {
            Helper.Helper.HienThiChucNang<ProductType>("Chọn loại sản phẩm ");
            var prodType = Helper.Helper.NhapEnum<ProductType>();
            Product product;
            switch (prodType)
            {
                case ProductType.DienTu:
                    product = new DienTu();
                    break;
                case ProductType.ThoiTrang:
                    product = new ThoiTrang();
                    break;
                default:
                    product = new ThucPham();
                    break;
            }

            ListProduct.Add(product);
        }
    }
}
