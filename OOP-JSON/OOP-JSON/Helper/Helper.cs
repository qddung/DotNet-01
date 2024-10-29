using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_JSON.Helper
{
    public static class Helper
    {
        public static string ReadInput()
        {
            string? input = Console.ReadLine();
            return input ?? String.Empty;
        }

        public static double NhapDiem()
        {
            string input = ReadInput();
            double x;
            try
            {
                x = double.Parse(input);
                if (x > 10 || x < 0)
                {
                    throw new Exception("Điểm số không hợp lệ");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw ex;
            }
            return x;

        }
    }
}
