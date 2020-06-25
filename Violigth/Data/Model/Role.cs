using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Violigth.Data.Base;
using Violigth.Data.ViewModel;

namespace Violigth.Data.Model
{
    public class Role : BaseModel
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        public Role() { }

        public Role(RoleVM roleVM)
        {
            this.Name = roleVM.Name;
            this.CreateDate = DateTimeOffset.Now.LocalDateTime;
        }

        public virtual void Update(int id, RoleVM roleVM)
        {
            this.Id = id;
            this.Name = roleVM.Name;
            this.UpdateDate = DateTimeOffset.Now.LocalDateTime;
        }
    }
}
