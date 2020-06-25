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
    [Table("tb_m_supply")]
    public class Supply : BaseModel
    {
        public int Quantity { get; set; }
        public decimal CapitalPrice { get; set; }

        public virtual Item Item { get; set; }

        public Supply() { }

        public Supply(SupplyVM supplyVM)
        {
            this.Quantity = supplyVM.Quantity;
            this.CapitalPrice = supplyVM.CapitalPrice;
            this.CreateDate = DateTimeOffset.Now.LocalDateTime;
        }

        public virtual void Update(int id, SupplyVM supplyVM)
        {
            this.Id = id;
            this.Quantity = supplyVM.Quantity;
            this.CapitalPrice = supplyVM.CapitalPrice;
            this.UpdateDate = DateTimeOffset.Now.LocalDateTime;
        }
    }
}
