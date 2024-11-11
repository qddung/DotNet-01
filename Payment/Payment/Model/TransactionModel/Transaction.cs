using Payment.Helper;
using Payment.Model;
using Payment.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Payment.Model.TransactionModel
{
    public enum TransactionType
    {
        [Display(Description = "Tiền mặt")]
        Cash = 1,
        [Display(Description = "Thẻ")]
        Card = 2,
        [Display(Description = "Chuyển khoản")]
        Online = 3,
    }
    public class Transaction
    {
        public Transaction()
        {
            TransactionId = Guid.NewGuid();
            CreateDate = DateTime.Now;
        }

        public Transaction(TransactionType type) : this()
        {
            NhapTien();
            TransactionType = type;
        }

        public void NhapTien()
        {
            Console.WriteLine("Nhập số tiền cần thanh toán");
            Money = Payment.Helper.Helper.NhapTien();
        }

        public Guid TransactionId { get; private set; }

        public TransactionType TransactionType { get; private set; }

        public double Money { get; private set; }

        public bool IsSuccess { get; private set; }

        public DateTime CreateDate { get; private set; }
        public void SetMoney(double money)
        {
            Money = money;
        }

        private string GetTransactionType()
        {
            return EnumHelper.GetDescriptionAtt(TransactionType);
        }

        public void SetAction(TransactionType action)
        {
            TransactionType = action;
        }

        public void XuatThongTin()
        {
            var succes = IsSuccess ? "Thành công" : "Thất bại";
            Console.WriteLine($"Phương thức: {GetTransactionType()}; Số tiền: {Money}; Kết quả: {succes}; Thời gian: {CreateDate.ToString()}");
        }
    }
}
