using Payment.Model;
using Payment.Model.TransactionModel;
using Payment.Services;
using Payment.Services.PaymentService;
using System;
using System.ComponentModel.DataAnnotations;

namespace Application
{
    public enum TransactionAction : int
    {
        [Display(Description = "Thanh toán bằng tiền măt")]
        Cash = 1,
        [Display(Description = "Thanh toán thẻ")]
        Card = 2,
        [Display(Description = "Thanh toán online")]
        Online = 3,
        [Display(Description = "Xem lịch sử giao dịch")]
        ViewHistory = 4,
        [Display(Description = "Thoát")]
        Exit = 5,
    }
    class Program
    {
        static void Main(string[] args)
        {
            LogJsonService db = new LogJsonService();
            CardPaymentService cardPaymentService = new CardPaymentService();
            CashPaymentService cashPaymentService = new CashPaymentService();
            TransferPaymentService transferPaymentService = new TransferPaymentService();

            TransactionService transactionService = new TransactionService(db);
            while (transactionService.TransactionAction != TransactionAction.Exit)
            {
                transactionService.HienThiChucNang();
                transactionService.ChonChucNang();
                switch (transactionService.TransactionAction)
                {
                    case TransactionAction.Cash:
                        transactionService.SetPaymentService(cashPaymentService);
                        transactionService.ThanhToan(TransactionType.Cash);
                        break;
                    case TransactionAction.Card:
                        var otp = transactionService.NhapOTP();
                        if (otp == false) continue;
                        transactionService.SetPaymentService(cardPaymentService);
                        transactionService.ThanhToan(TransactionType.Cash);
                        break;
                    case TransactionAction.Online:
                        var pin = transactionService.NhapPIN();
                        if (pin == false) continue;
                        transactionService.SetPaymentService(transferPaymentService);
                        transactionService.ThanhToan(TransactionType.Cash);
                        break;
                    case TransactionAction.ViewHistory:
                        transactionService.Log();
                        break;
                    case TransactionAction.Exit:
                        break;
                }
            }
        }

    }
}
