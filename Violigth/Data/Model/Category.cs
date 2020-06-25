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
    [Table("tb_m_category")]
    public class Category : BaseModel
    {
        public string Name { get; set; }

        public virtual Type Type { get; set; }

        public Category() { }

        public Category(CategoryVM categoryVM)
        {
            this.Name = categoryVM.Name;
            this.CreateDate = DateTimeOffset.Now.LocalDateTime;
        }

        public virtual void Update(int id, CategoryVM categoryVM)
        {
            this.Id = id;
            this.Name = categoryVM.Name;
            this.UpdateDate = DateTimeOffset.Now.LocalDateTime;
        }
    }
}
