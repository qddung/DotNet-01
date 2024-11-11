using Application;
using Payment.Helper;
using Payment.Interface;
using Payment.Model.TransactionModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payment.Services
{
    public class TransactionService : BasePaymentService
    {
        public TransactionAction? TransactionAction { get; set; }
        public TransactionService(LogJsonService logService) : base(logService)
        {
            TransactionAction = null;
        }

        public void SetPaymentService(IPaymentInterface paymentMethod)
        {
            PaymentMethod = paymentMethod;
        }

        private static string PinCode = "999999";
        private static string OTPCode = "123456";

        private IPaymentInterface PaymentMethod { get; set; }

        public void HienThiChucNang()
        {
            Helper.Helper.HienThiChucNang<TransactionAction>(title: "Hiển thị chức năng");
        }

        public void ChonChucNang()
        {
            Console.WriteLine("Chọn chức năng");
            var transactionAction = Helper.Helper.NhapEnum<TransactionAction>();
            TransactionAction = transactionAction;
        }

        public void ThanhToan(TransactionType type)
        {
            Transaction newTrans = new Transaction(type);
            LogDataService.WriteJson(newTrans.ToSingleList());
            PaymentMethod.ThanhToan(newTrans.Money);
        }

        public void Log()
        {
            LogDataService.LogTransaction();
        }

        public bool NhapOTP()
        {
            Console.WriteLine("Nhập OTP");
            var otp = Payment.Helper.Helper.ReadInput();
            if (otp != OTPCode)
            {
                Console.WriteLine("Không đúng mã otp");
                return false;
            }
            return true;
        }

        public bool NhapPIN()
        {
            Console.WriteLine("Nhập mã pin");
            var pin = Payment.Helper.Helper.ReadInput();
            if (pin != PinCode)
            {
                Console.WriteLine("Không đúng mã pin");
                return false;
            }
            return true;
        }




    }
}
