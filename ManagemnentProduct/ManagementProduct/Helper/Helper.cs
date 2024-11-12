using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ManagementProduct.Model.ProductModel;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace ManagementProduct.Helper
{
    public static class Helper
    {
        public static string ReadInput()
        {
            string? input = Console.ReadLine();
            return input ?? String.Empty;
        }

        public static (bool parseInt, int value) NhapSo()
        {
            string? input = Console.ReadLine();
            string intInput = input ?? String.Empty;
            int value = 0;
            bool parseInt = Int32.TryParse(intInput, out value);
            return (parseInt, value);
        }

        public static int NhapNumber()
        {
            var nhapSo = NhapSo();
            if(nhapSo.parseInt == false)
            {
                throw new Exception("Số không hợp lệ");
            }
            return nhapSo.value;
        }

        public static double NhapTien()
        {
            string doubleInput = ReadInput();
            double x = -1;
            try
            {
                bool parseDouble = Double.TryParse(doubleInput, out x);
                if (parseDouble == false)
                {

                    throw new Exception("Điểm số không hợp lệ");
                }
                if (x > 10 || x < 0)
                {
                    throw new Exception("Điểm số không hợp lệ");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return x;
        }

        public static T NhapEnum<T>() where T : Enum
        {
            (bool check, int diem) = NhapSo();
            T result = default(T);
            try
            {
                if (check == false) throw new Exception("Tham số không hợp lệ");
                bool checkEnum = EnumHelper.CheckValueInEnum<T>(diem);
                if (checkEnum == false) throw new Exception("Không tìm thấy lựa chọn đã nhập");

                result = (T)(object)diem;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
            return result;
        }


        public static void HienThiChucNang<T>(string title = "") where T : Enum
        {
            var listFuncName = EnumHelper.GetEnumSelectable<T>();
            Console.WriteLine(title);
            foreach (var funcName in listFuncName)
            {
                Console.WriteLine($"{(int)(object)funcName.Value}. {funcName.Label}");
            }
        }

        public static string RemoveDiacritics(string text)
        {
            var normalizedString = text.Normalize(NormalizationForm.FormD);
            var stringBuilder = new StringBuilder(capacity: normalizedString.Length);

            for (int i = 0; i < normalizedString.Length; i++)
            {
                char c = normalizedString[i];
                var unicodeCategory = CharUnicodeInfo.GetUnicodeCategory(c);
                if (unicodeCategory != UnicodeCategory.NonSpacingMark)
                {
                    stringBuilder.Append(c);
                }
            }

            return stringBuilder.ToString().Normalize(NormalizationForm.FormC);
        }
    }
}
