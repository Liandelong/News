using EFModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace EFDal
{
    public partial class NewTypesDal : BaseDal<NewTypes>
    {
        public override Expression<Func<NewTypes, int>> GetKey()
        {
            return u => u.TypeId;
        }

        public override Expression<Func<NewTypes, bool>> GetWhere(int id)
        {
            return u => u.TypeId == id;
        }
    }
}
