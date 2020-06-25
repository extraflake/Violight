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
    [Table("tb_m_sell")]
    public class Sell
    {
        [Key]
        public int Id { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public double SubTotal { get; set; }

        public DateTimeOffset CreateDate { get; set; }
        public DateTimeOffset UpdateDate { get; set; }

        public virtual Item Item { get; set; }
        public virtual Receipt Receipt { get; set; }

        public Sell() { }

        public Sell(SellVM sellVM)
        {
            this.Price = sellVM.Price;
            this.Quantity = sellVM.Quantity;
            this.SubTotal = sellVM.SubTotal;
            this.CreateDate = DateTimeOffset.Now.LocalDateTime;
        }

        public virtual void Update(int id, SellVM sellVM)
        {
            this.Id = id;
            this.Price = sellVM.Price;
            this.Quantity = sellVM.Quantity;
            this.SubTotal = sellVM.SubTotal;
            this.UpdateDate = DateTimeOffset.Now.LocalDateTime;
        }
    }
}
