using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using OOP_JSON.Model;
using OOP_JSON.Model.InventoryModel;
using OOP_JSON.Model.StudentModel;
using System;
using System.ComponentModel.DataAnnotations;

namespace Application
{
    class Program
    {
        static void Main(string[] args)
        {
            ProgramModel program = new ProgramModel();
            while (program.ProgramType != EnumProgram.Stop)
            {
                program.HienThiChucNang();
                program.ChonChuongTrinh();
                switch (program.ProgramType)
                {
                    case EnumProgram.Student:
                        StudentProgram();
                        break;
                    case EnumProgram.Inventory:
                        InvetoryProgram();
                        break;
                    default:
                        break;
                }
            }
        }

        public static void StudentProgram()
        {
            StudentList studentList = new StudentList();
            while (studentList.StudentFunction != StudentFunction.Exit)
            {
                studentList.HienThiChucNang();
                studentList.ChonChucNang();
                switch (studentList.StudentFunction)
                {
                    case StudentFunction.ThemHocSinh:
                        studentList.ThemHocSinh();
                        break;
                    case StudentFunction.CapNhatDiemSo:
                        studentList.CapNhatDiemSo();
                        break;
                    case StudentFunction.TimKiemHocSinhTheoTen:
                        studentList.TimKiemHocSinhTheoTen();
                        break;
                    case StudentFunction.XoaHocSinh:
                        studentList.XoaHocSinh();
                        break;
                    case StudentFunction.XepTheoHocLuc:
                        studentList.XepTheoHocLuc();
                        break;
                    case StudentFunction.SapXepTheoDiemTrungBinh:
                        studentList.SapXepTheoDiemTrungBinh();
                        break;
                    case StudentFunction.SapXepTheoTenHocSinhTangDan:
                        studentList.SapXepTheoTenHocSinhTangDan();
                        break;
                    case StudentFunction.DocJson:
                        studentList.DocJson();
                        break;
                    case StudentFunction.GhiJson:
                        studentList.GhiJson();
                        break;
                }
            }
        }

        public static void InvetoryProgram()
        {
            ProductList products = new ProductList();
            while (products.ProductFunction != ProductFunction.Exit)
            {
                products.HienThiChucNang();
                products.ChonChucNang();
                switch (products.ProductFunction)
                {

                    case ProductFunction.ThemSanPham:
                        products.GhiJson();
                        break;

                    case ProductFunction.TimKiemTheoTenSanPham:
                        products.TimKiemTheoTenSanPham();
                        break;

                    case ProductFunction.CapNhatGiaHoacSoLuongTonKho:
                        products.CapNhatGiaHoacSoLuongTonKho();
                        break;

                    case ProductFunction.TongGiaTriSanPhamTrongKho:
                        products.TongGiaTriSanPhamTrongKho();
                        break;

                    case ProductFunction.XoaSanPham:
                        products.XoaSanPham();
                        break;

                    case ProductFunction.HienThiDanhSachCungTongGiaTri:
                        products.HienThiDanhSachCungTongGiaTri();
                        break;

                    case ProductFunction.HienThiSanPhamTheoGiaBanTangDan:
                        products.HienThiSanPhamTheoGiaBanTangDan();
                        break;

                    case ProductFunction.SapXepVaHienThiDanhSachTheoGiaTangDan:
                        products.SapXepVaHienThiDanhSachTheoGiaTangDan();
                        break;

                    case ProductFunction.HienThiDanhSachTheoTen:
                        products.HienThiDanhSachTheoTen();
                        break;

                    case ProductFunction.HienThiDanhSachTheoTenCuoiCung:
                        products.HienThiDanhSachTheoTenCuoiCung();
                        break;

                    case ProductFunction.DocJson:
                        products.DocJson();
                        break;

                    case ProductFunction.GhiJson:
                        products.GhiJson();
                        break;

                }
            }
        }

    }
}
}
