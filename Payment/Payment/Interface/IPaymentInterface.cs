using Payment.Model.TransactionModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Payment.Interface
{
    public interface IPaymentInterface
    {
        void ThanhToan(double money);
    }

    public interface ILogTransaction
    {
        void LogTransaction();
    }

    public interface IDatabaseJsonService : ILogTransaction
    {
        public List<Transaction> ReadJsonDesirialize();
        public bool WriteJson(List<Transaction> data);

        public string ReadJsonStringData();
    }
}
