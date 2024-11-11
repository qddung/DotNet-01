using Payment.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payment.Services
{
    public abstract class BasePaymentService
    {
        protected IDatabaseJsonService LogDataService { get; set; }
        public BasePaymentService(IDatabaseJsonService jsonDataService)
        {
            LogDataService = jsonDataService;
        }
    }
}
