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
    [Table("tb_m_type")]
    public class Type : BaseModel
    {
        public string Name { get; set; }
        
        public Type() { }

        public Type(TypeVM typeVM)
        {
            this.Name = typeVM.Name;
            this.CreateDate = DateTimeOffset.Now.LocalDateTime;
        }

        public virtual void Update(TypeVM typeVM)
        {
            this.Name = typeVM.Name;
            this.UpdateDate = DateTimeOffset.Now.LocalDateTime;
        }
    }
}
