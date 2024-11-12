using ManagementProduct.Model.ProductModel;

var productProgram = new ProductList();
while (productProgram.ProductFunction != ProductFunction.Thoat)
{
    productProgram.ChonChucNang();
    switch (productProgram.ProductFunction)
    {
        case ProductFunction.ThemSanPham:
            productProgram.ThemSanPham();
            break;
        case ProductFunction.DanhSachSanPham:
            productProgram.DanhSachSanPham();
            break;
        case ProductFunction.XoaSanPham:
            productProgram.XoaSanPham();
            break;
        case ProductFunction.TinhDoanhThu:
            productProgram.TinhDoanhThu();
            break;
        default:
            break;
    }
}