using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EFDal;
using EFModel;

namespace EFBll
{
    public partial class NewTypesBll : BaseBll<NewTypes>
    {
        public override BaseDal<NewTypes> GetDal()
        {
            return new NewTypesDal();
        }
    }
}
