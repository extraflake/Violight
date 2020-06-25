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
    [Table("tb_m_supplier")]
    public class Supplier : BaseModel
    {
        public string Name { get; set; }

        public Supplier() { }

        public Supplier(SupplierVM supplierVM)
        {
            this.Name = supplierVM.Name;
            this.CreateDate = DateTimeOffset.Now.LocalDateTime;
        }

        public virtual void Update(int id, SupplierVM supplierVM)
        {
            this.Id = id;
            this.Name = supplierVM.Name;
            this.UpdateDate = DateTimeOffset.Now.LocalDateTime;
        }
    }
}
