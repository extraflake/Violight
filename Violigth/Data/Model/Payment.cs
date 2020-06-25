using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Violigth.Data.Base;
using Violigth.Data.ViewModel;

namespace Violigth.Data.Model
{
    [Table("tb_m_payment")]
    public class Payment : BaseModel
    {
        public string Name { get; set; }

        public Payment() { }

        public Payment(PaymentVM paymentVM)
        {
            this.Name = paymentVM.Name;
            this.CreateDate = DateTimeOffset.Now.LocalDateTime;
        }

        public virtual void Update(int id, PaymentVM paymentVM)
        {
            this.Id = id;
            this.Name = paymentVM.Name;
            this.UpdateDate = DateTimeOffset.Now.LocalDateTime;
        }
    }
}
