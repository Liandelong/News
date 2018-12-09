using EFModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EFDal
{
  public abstract partial  class BaseDal<T> where T:class//封装父类
    {
        DbContext dbcontext = new MyContext();//获取上下文


        /// <summary>
        ///根据页码查询数据
        /// </summary>
        /// <param name="pageSize">每页多少条数据</param>
        /// <param name="PageIndex">当前页码</param>
        /// <returns></returns>
        public IQueryable<T> GetNewsList(int pageSize, int PageIndex)
        {
            return dbcontext.Set<T>().OrderByDescending(GetKey())//根据id排序
                  .Skip((PageIndex - 1) * pageSize)
                  .Take(pageSize);
        }

        /// <summary>
        /// 根据id获取单条数据
        /// </summary>
        /// <param name="id">NewsId</param>
        /// <returns></returns>
        public T GetOneNew(int id)
        {
            return dbcontext.Set<T>().Where(GetWhere(id)).FirstOrDefault();
        }

        /// <summary>
        /// 根据对象添加一条数据
        /// </summary>
        /// <param name="news">新闻对象</param>
        /// <returns></returns>
        public int Add(T news)
        {
            dbcontext.Set<T>().Add(news);
            return dbcontext.SaveChanges();
        }

        /// <summary>
        /// 根据对象修改数据
        /// </summary>
        /// <param name="news"></param>
        /// <returns></returns>
        public int Edit(T news)
        {
            dbcontext.Set<T>().Attach(news);//将新闻对象添加到上下文集
            dbcontext.Entry(news).State = EntityState.Modified;//将实体设置为修改
            return dbcontext.SaveChanges();
        }

        /// <summary>
        /// 根据id删除数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int Remove(int id)
        {
            var news = GetOneNew(id);//根据id获取新闻对象
            dbcontext.Set<T>().Remove(news);
            return dbcontext.SaveChanges();
        }

        public abstract Expression<Func<T, int>> GetKey();//交给子类实现  返回（U=>u.id）

        public abstract Expression<Func<T, bool>> GetWhere(int id);//交给子类实现 返回（U=>u.id==id）
    }
}
