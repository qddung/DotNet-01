using System.Text.Json;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using SignalR.ViewModels;

namespace SignalR.Helper
{
    public static class ModelExt
    {
        public static CategoryViewModel GetCateModel(this string categoryString)
        {
            if (string.IsNullOrEmpty(categoryString)) return null as CategoryViewModel;
            var productModel = null as CategoryViewModel;
            try
            {
                productModel = JsonSerializer.Deserialize<CategoryViewModel>(categoryString);
            }
            catch (Exception ex)
            {
                return null as CategoryViewModel;
            }
            if (productModel != null)
            {
                return productModel;
            }
            return null as CategoryViewModel;
        }
    }
}