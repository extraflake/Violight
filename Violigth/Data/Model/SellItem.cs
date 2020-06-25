using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Violigth.Data.Model
{
    [Table("tb_tr_transaction_sell")]
    public class SellItem
    {
        [Key]
        public int Id { get; set; }
        public int Quantity { get; set; }
        public int Price { get; set; }

        public virtual Item Item { get; set; }
        public virtual Sell Sell { get; set; }
    }
}
