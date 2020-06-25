using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Violigth.Data.ViewModel;

namespace Violigth.Data.Model
{
    [Table("tb_m_receipt")]
    public class Receipt
    {
        [Key]
        public string Id { get; set; }
        public decimal Discount { get; set; }
        public decimal Total { get; set; }

        public DateTimeOffset CreateDate { get; set; }
        public DateTimeOffset UpdateDate { get; set; }
        
        public virtual Payment Payment { get; set; }

        public Receipt() { }

        public Receipt(ReceiptVM receiptVM)
        {
            this.Id = receiptVM.Id;
            this.Discount = receiptVM.Discount;
            this.Total = receiptVM.Total;
            this.CreateDate = DateTimeOffset.Now.LocalDateTime;
        }

        public virtual void Update(string id, ReceiptVM receiptVM)
        {
            this.Id = id;
            this.Discount = receiptVM.Discount;
            this.Total = receiptVM.Total;
            this.UpdateDate = DateTimeOffset.Now.LocalDateTime;
        }
    }
}
