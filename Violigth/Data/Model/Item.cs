using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Violigth.Data.Base;
using Violigth.Data.ViewModel;

namespace Violigth.Data.Model
{
    [Table("tb_m_item")]
    public class Item : BaseModel
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public double Stock { get; set; }

        public virtual Category Category { get; set; }

        public virtual Supplier Supplier { get; set; }

        public Item() { }

        public Item(ItemVM itemVM)
        {
            this.Name = itemVM.Name;
            this.Price = itemVM.Price;
            this.Stock = itemVM.Stock;
            this.CreateDate = DateTimeOffset.Now.LocalDateTime;
        }

        public virtual void Update(ItemVM itemVM)
        {
            this.Id = itemVM.Id;
            this.Name = itemVM.Name;
            this.Price = itemVM.Price;
            this.Stock = itemVM.Stock;
            this.UpdateDate = DateTimeOffset.Now.LocalDateTime;
        }
    }
}
