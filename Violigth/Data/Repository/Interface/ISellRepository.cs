using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Violigth.Data.ViewModel;

namespace Violigth.Data.Repository.Interface
{
    public interface ISellRepository
    {
        bool Insert(SellVM sellVM);
    }
}
