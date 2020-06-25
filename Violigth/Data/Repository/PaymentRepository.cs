using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Violigth.Data.Context;
using Violigth.Data.Model;
using Violigth.Data.Repository.Interface;
using Violigth.Data.ViewModel;

namespace Violigth.Data.Repository
{
    public class PaymentRepository : IPaymentRepository
    {
        MyContext myContext = new MyContext();

        public Payment Check(string param)
        {
            var get = myContext.Payments.FirstOrDefault(x => x.Name == param);
            return get;
        }

        public bool Delete(int id)
        {
            var delete = GetbyId(id);
            myContext.Payments.Remove(delete);
            var result = myContext.SaveChanges();
            return result > 0;
        }

        public IEnumerable<Payment> Get()
        {
            var get = myContext.Payments.Where(x => x.IsDelete == false).ToList().OrderBy(x => x.Name);
            return get;
        }

        public Payment GetbyId(int id)
        {
            var get = myContext.Payments.FirstOrDefault(x => x.Id == id);
            return get;
        }

        public IEnumerable<Payment> GetbyParam(string param)
        {
            var get = myContext.Payments.Where(x => (x.Id.ToString().Contains(param) || x.Name.Contains(param)) && x.IsDelete == false).ToList();
            return get;
        }

        public bool Insert(PaymentVM paymentVM)
        {
            var check = Check(paymentVM.Name);
            if (check != null)
            {
                return false;
            }
            else
            {
                var push = new Payment(paymentVM);
                myContext.Payments.Add(push);
                var result = myContext.SaveChanges();
                return result > 0;
            }
        }

        public bool Update(int id, PaymentVM paymentVM)
        {
            var pull = GetbyId(id);
            pull.Update(id, paymentVM);
            myContext.Entry(pull).State = EntityState.Modified;
            var result = myContext.SaveChanges();
            return result > 0;
        }
    }
}
