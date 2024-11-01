using OOP_JSON.Model.StudentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_JSON.Model.InventoryModel
{
    public class Product
    {
        public Product()
        {
            Id = Guid.NewGuid();
            NhapThongTin();
        }
        public Guid Id { get; private set; }
        public string Code { get; protected set; }
        public string Name { get; set; }

        public int Price { get; private set; }

        public int Inventory { get; private set; }

        public int TotalValue
        {
            get
            {
                return Inventory * Price;
            }
        }

        public void SetPrice(int price)
        {
            Price = price;
        }


        public void XuatThongTin(bool showValue = false)
        {
            string val = showValue ? $"Tổng giá trị: {TotalValue}" : string.Empty;
            Console.WriteLine($@"
                Mã sản phẩm : {Code}
                Tên         : {Name}
                Giá         : {Price}
                Tồn kho     : {Inventory}
                {val}
            ");
        }


        private void NhapThongTin()
        {
            Console.WriteLine("Nhập mã sản phẩm");
            Code = OOP_JSON.Helper.Helper.ReadInput();
            Console.WriteLine("Nhập tên sản phẩm");
            Name = OOP_JSON.Helper.Helper.ReadInput();
            Console.WriteLine("Nhập giá bán sản phẩm");
            var nhapGia = OOP_JSON.Helper.Helper.NhapSo();
            if (nhapGia.parseInt == false)
            {
                Console.WriteLine("Nhập sai định dạng");
                return;
            }
            Price = nhapGia.value;


            Console.WriteLine("Nhập số lượng tồn sản phẩm");


            var nhapSoLuong = OOP_JSON.Helper.Helper.NhapSo();
            if (nhapSoLuong.parseInt == false)
            {
                Console.WriteLine("Nhập sai định dạng");
                return;
            }
            Inventory = nhapSoLuong.value;
        }

        public bool ContainName(string name)
        {
            if (string.IsNullOrEmpty(name)) return false;
            var search = Helper.Helper.RemoveDiacritics(name.ToLower());
            var studentName = Helper.Helper.RemoveDiacritics(Name.ToLower());
            return studentName.Contains(search) || Name.ToLower().Contains(name.ToLower());
        }

        public void CapNhatGiaHoacSoLuong()
        {
            Helper.Helper.HienThiChucNang<EnumGiaHoacTonKho>();
            EnumGiaHoacTonKho input = Helper.Helper.NhapEnum<EnumGiaHoacTonKho>();
            var number = OOP_JSON.Helper.Helper.NhapSo();
            if (number.parseInt == false)
            {
                Console.WriteLine("Nhập sai định dạng");
                return;
            }
            switch (input)
            {
                case EnumGiaHoacTonKho.Price:
                    Price = number.value;
                    break;
                case EnumGiaHoacTonKho.Warehouse:
                    Inventory = number.value;
                    break;
            }
        }

    }
}
