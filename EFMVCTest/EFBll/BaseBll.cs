using EFDal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFBll
{
   public abstract partial class BaseBll<T> where T:class//T为引用类型
    {
        private BaseDal<T> dal;

        public abstract BaseDal<T> GetDal();//通过子类获取相应的BaseDal<T>

        public BaseBll()//创建构造方法，当子类创建实例时也执行该方法
        {
            this.dal = GetDal();
        }

        /// <summary>
        /// 查询多条数据
        /// </summary>
        /// <param name="pageSize"></param>
        /// <param name="PageIndex"></param>
        /// <returns></returns>
        public IQueryable<T> GetList(int pageSize,int PageIndex)
        {
            return dal.GetNewsList(pageSize,PageIndex);
        }

        /// <summary>
        /// 根据id获取一个对象
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public T GetOneList(int id)
        {
            return dal.GetOneNew(id);
        }

        /// <summary>
        /// 根据对象添加信息
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public bool Add(T t)
        {
            return dal.Add(t)>0;
        }

        /// <summary>
        /// 根据对象修改
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public bool Edit(T t)
        {
            return dal.Edit(t) > 0;
        }

        /// <summary>
        /// 根据id删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool Remov(int id)
        {
            return dal.Remove(id) > 0;

        }
    }
}
