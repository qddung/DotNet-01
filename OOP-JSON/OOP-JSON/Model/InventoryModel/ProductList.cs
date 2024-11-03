using OOP_JSON.Helper;
using OOP_JSON.Model.StudentModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace OOP_JSON.Model.InventoryModel
{
    public enum ProductFunction : int
    {
        [Display(Description = "Thêm sản phẩm")]
        ThemSanPham = 1,
        [Display(Description = "Tìm kiếm theo tên sản phầm")]
        TimKiemTheoTenSanPham = 2,
        [Display(Description = "Cập nhật giá bán hoặc số lượng tồn kho")]
        CapNhatGiaHoacSoLuongTonKho = 3,
        [Display(Description = "Tính tổng giá trị sản phẩm trong kho")]
        TongGiaTriSanPhamTrongKho = 4,
        [Display(Description = "Xóa sản phẩm")]
        XoaSanPham = 5,
        [Display(Description = "Hiển thị danh sách sản phẩm cùng tổng giá trị kho hàng")]
        HienThiDanhSachCungTongGiaTri = 6,
        [Display(Description = "Hiển thị sản phẩm theo giá bán tăng dần")]
        HienThiSanPhamTheoGiaBanTangDan = 7,
        [Display(Description = "Sắp xếp và hiển thị danh sách sản phẩm theo giá bán từ thấp tới cao")]
        SapXepVaHienThiDanhSachTheoGiaTangDan = 8,
        [Display(Description = "Hiển thị danh sách sản phẩm theo tên")]
        HienThiDanhSachTheoTen = 9,
        [Display(Description = "Hiển thị danh sách sản phẩm theo tên cuối cùng")]
        HienThiDanhSachTheoTenCuoiCung = 10,
        [Display(Description = "Đọc thông tin Json")]
        DocJson = 11,
        [Display(Description = "Ghi Thông Tin Json")]
        GhiJson = 12,

        [Display(Description = "Thoát")]
        Exit = 13,
    }

    public enum EnumGiaHoacTonKho : int
    {
        [Display(Description = "Cập nhật Giá")]
        Price = 1,
        [Display(Description = "Cập nhật tồn kho")]
        Warehouse = 2,
    }
    public class ProductList
    {
        public ProductFunction? ProductFunction { get; set; }
        public void ChonChucNang()
        {
            var func = Helper.Helper.NhapEnum<ProductFunction>();
            ProductFunction = func;
        }

        public static readonly string FilePathData = "Database/Inventory/Inventory.json";
        public ProductList()
        {
            ListProduct = new List<Product>();
            ListProduct = ReadFileJson();
        }

        private List<Product> ReadFileJson()
        {
            return JsonHelper.LoadDataFromFile<Product>(FilePathData);
        }
        public List<Product> ListProduct { get; set; }

        public void ThemSanPham()
        {
            var product = new Product();
            var checkExit = ListProduct.Any(i => i.Code == product.Code);
            if (string.IsNullOrEmpty(product.Name))
            {
                Console.WriteLine("Tên không được để trống");
                return;
            }
            if (checkExit == true)
            {
                Console.WriteLine("Bị trùng mã sản phẩm");
                return;
            }
            ListProduct.Add(product);
        }

        public void HienThiChucNang()
        {
            Helper.Helper.HienThiChucNang<ProductFunction>("Danh sách chức năng");
        }


        private bool SaveData()
        {
            try
            {
                JsonHelper.WriteFileJson<Product>(FilePathData, ListProduct);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
                return false;
            }
        }

        public void TimKiemTheoTenSanPham()
        {
            string input = Helper.Helper.ReadInput();
            var list = ListProduct.Where(i => i.ContainName(input)).ToList();
            foreach (var item in list)
            {
                item.XuatThongTin();
            }
        }

        public void CapNhatGiaHoacSoLuongTonKho()
        {
            string maSanPham = Helper.Helper.ReadInput();
            Product product = ListProduct.FirstOrDefault(i => i.Code == maSanPham);
            if (product != null)
            {
                product.CapNhatGiaHoacSoLuong();
            }
            else
            {
                Console.WriteLine("Không tìm thấy sản phẩm");
            }
        }
        public int GetTongGiaTriTrongKho()
        {
            int tong = 0;
            foreach (var item in ListProduct)
            {
                tong += item.TotalValue;
            }
            return tong;
        }

        public void TongGiaTriSanPhamTrongKho()
        {
            int tong = GetTongGiaTriTrongKho();
            Console.WriteLine($"Tổng giá trị trong kho là {tong}");
        }

        public void XoaSanPham()
        {
            string maSanPham = Helper.Helper.ReadInput();
            Product product = ListProduct.FirstOrDefault(i => i.Code == maSanPham);
            if (product != null)
            {
                ListProduct.Remove(product);
            }
            else
            {
                Console.WriteLine("Không tìm thấy sản phẩm");
            }
        }

        public void HienThiDanhSachCungTongGiaTri()
        {
            foreach (var item in ListProduct)
            {
                item.XuatThongTin(showValue: true);
            }
        }

        public void HienThiSanPhamTheoGiaBanTangDan()
        {
            var listSortPrice = ListProduct.OrderBy(i => i.Price).ToList();
            foreach (var item in listSortPrice)
            {
                item.XuatThongTin(showValue: false);
            }
        }

        public void SapXepVaHienThiDanhSachTheoGiaTangDan()
        {
            ListProduct = ListProduct.OrderBy(i => i.Price).ToList();
            foreach (var item in ListProduct)
            {
                item.XuatThongTin(showValue: false);
            }
        }

        public void HienThiDanhSachTheoTen()
        {
            var listSortName = ListProduct.OrderBy(i => i.Name).ToList();
            foreach (var item in listSortName)
            {
                item.XuatThongTin(showValue: false);
            }
        }

        public void HienThiDanhSachTheoTenCuoiCung()
        {

            var listSortName = ListProduct
                .OrderBy(i => string.IsNullOrEmpty(i.Name) ? "" : (i.Name.Split(" ").LastOrDefault() ?? ""))
                .ToList();
            foreach (var item in listSortName)
            {
                item.XuatThongTin(showValue: false);
            }
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
    }
}
