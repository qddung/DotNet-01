using Payment.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payment.Services.PaymentService
{
    public class TransferPaymentService : IPaymentInterface
    {
        public TransferPaymentService() { }
        public void ThanhToan(double money)
        {
            Console.WriteLine("Thanh toán online thành công");
        }
    }
}
