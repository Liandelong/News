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
    public partial class NewsInfoDal : BaseDal<News>
    {

        #region
        //DbContext dbcontext = new MyContext();//获取上下文
        ///// <summary>
        /////根据页码查询数据
        ///// </summary>
        ///// <param name="pageSize">每页多少条数据</param>
        ///// <param name="PageIndex">当前页码</param>
        ///// <returns></returns>
        //public IQueryable<News> GetNewsList(int pageSize,int PageIndex)
        //{
        //  return  dbcontext.Set<News>().OrderByDescending(u => u.NewsId)//根据id排序
        //        .Skip((PageIndex - 1) * pageSize)
        //        .Take(pageSize);
        //}

        ///// <summary>
        ///// 根据id获取单条数据
        ///// </summary>
        ///// <param name="id">NewsId</param>
        ///// <returns></returns>
        //public News GetOneNew(int id)
        //{
        //    return dbcontext.Set<News>().Where(u => u.NewsId == id).FirstOrDefault();
        //}

        ///// <summary>
        ///// 根据对象添加一条数据
        ///// </summary>
        ///// <param name="news">新闻对象</param>
        ///// <returns></returns>
        //public int Add(News news)
        //{
        //    dbcontext.Set<News>().Add(news);
        //    return dbcontext.SaveChanges();
        //}

        ///// <summary>
        ///// 根据对象修改数据
        ///// </summary>
        ///// <param name="news"></param>
        ///// <returns></returns>
        //public int Edit(News news)
        //{
        //    dbcontext.Set<News>().Attach(news);//将新闻对象添加到上下文集
        //    dbcontext.Entry(news).State = EntityState.Modified;//将实体设置为修改
        //    return dbcontext.SaveChanges();
        //}

        ///// <summary>
        ///// 根据id删除数据
        ///// </summary>
        ///// <param name="id"></param>
        ///// <returns></returns>
        //public int Remove(int id)
        //{
        //    var news = GetOneNew(id);//根据id获取新闻对象
        //    dbcontext.Set<News>().Remove(news);
        //   return dbcontext.SaveChanges();
        //}
        #endregion //普通方法
        public override Expression<Func<News, int>> GetKey()
        {
            return u => u.NewsId;
        }

        public override Expression<Func<News, bool>> GetWhere(int id)
        {
            return u => u.NewsId == id;
        }
    }
}
