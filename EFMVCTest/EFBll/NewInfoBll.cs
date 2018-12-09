using EFModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EFDal;

namespace EFBll
{
    public partial class NewInfoBll : BaseBll<News>
    {
        public override BaseDal<News> GetDal()
        {
            return new NewsInfoDal();
        }
    }
}
