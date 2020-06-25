using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Violigth.Data.Model;
using Violigth.Data.ViewModel;

namespace Violigth.Data.Repository.Interface
{
    public interface IPaymentRepository
    {
        IEnumerable<Payment> Get();
        IEnumerable<Payment> GetbyParam(string param);
        Payment GetbyId(int id);
        Payment Check(string param);
        bool Insert(PaymentVM paymentVM);
        bool Update(int id, PaymentVM paymentVM);
        bool Delete(int id);
    }
}
