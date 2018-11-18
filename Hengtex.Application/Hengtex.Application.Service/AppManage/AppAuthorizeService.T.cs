using Hengtex.Application.Code;
using Hengtex.Application.Entity.AppManage;
using Hengtex.Application.Entity.AppManage;
using Hengtex.Application.IService.AppManage;
using Hengtex.Data;
using Hengtex.Data.Repository;
using Hengtex.Util.Extension;
using Hengtex.Util.WebControl;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Hengtex.Application.Service.AppManage
{
    /// <summary>
    /// 版 本
    /// Copyright (c) 2012-2017 恒泰纺织
    /// 创建人：刘晓雷
    /// 日 期：2016.03.29 22:35
    /// 描 述：授权认证
    /// </summary>
    public class AppAuthorizeService<T> : RepositoryFactory<T>, IAppAuthorizeService<T> where T : class,new()
    {
        private IRepository db = new RepositoryFactory().ERPRepository();
        private AppAuthorizeService authorizeService = new AppAuthorizeService();
        #region 带权限的数据源查询
        public IQueryable<T> IQueryable()
        {
            if (GetReadUserId() == "")
            {
                return this.ERPRepository().IQueryable();
            }
            else
            {
                var parameter = Expression.Parameter(typeof(T), "t");
                var authorConditon = Expression.Constant(GetReadUserId()).Call("Contains", parameter.Property("CreateUserId"));
                var lambda = authorConditon.ToLambda<Func<T, bool>>(parameter);
                return this.ERPRepository().IQueryable(lambda);
            }
        }
        public IQueryable<T> IQueryable(Expression<Func<T, bool>> condition)
        {
            if (GetReadUserId() != "")
            {
                var parameter = Expression.Parameter(typeof(T), "t");
                var authorConditon = Expression.Constant(GetReadUserId()).Call("Contains", parameter.Property("CreateUserId"));
                var lambda = authorConditon.ToLambda<Func<T, bool>>(parameter);
                condition = condition.And(lambda);
            }
            return db.IQueryable<T>(condition);
        }
        public IEnumerable<T> FindList(Pagination pagination)
        {
            if (GetReadUserId() == "")
            {
                return this.ERPRepository().FindList(pagination);
            }
            else
            {
                var parameter = Expression.Parameter(typeof(T), "t");
                var authorConditon = Expression.Constant(GetReadUserId()).Call("Contains", parameter.Property("CreateUserId"));
                var lambda = authorConditon.ToLambda<Func<T, bool>>(parameter);
                return this.ERPRepository().FindList(lambda, pagination);
            }
        }
        public IEnumerable<T> FindList(Expression<Func<T, bool>> condition, Pagination pagination)
        {
            if (GetReadUserId() != "")
            {
                var parameter = Expression.Parameter(typeof(T), "t");
                //var authorConditon = Expression.LessThanOrEqual(Expression.Constant(DateTime.Parse("1900-01-01"),typeof(DateTime)), parameter.Property("CreateTime"));
                var authorConditon = Expression.Equal(Expression.Constant("1"), Expression.Constant("1"));

                //var authorConditon = Expression.Equal(Expression.Constant(false), Expression.Constant(false));
                //var authorConditon = Expression.Constant(GetReadUserId()).Call("Contains", parameter.Property("Account"));

                var lambda = authorConditon.ToLambda<Func<T, bool>>(parameter);
                condition = condition.And(lambda);
            }
            return this.ERPRepository().FindList("select * from tb_MyUser where IsLocked=0 ", pagination);
        }
        public IEnumerable<T> FindList(string strSql)
        {
            strSql = strSql + (GetReadSql() == "" ? "" : string.Format("and CreateUserId in({0})", GetReadSql()));
            return this.ERPRepository().FindList(strSql);
        }
        public IEnumerable<T> FindList(string strSql, DbParameter[] dbParameter)
        {
            strSql = strSql + (GetReadSql() == "" ? "" : string.Format("and CreateUserId in({0})", GetReadSql()));
            return this.ERPRepository().FindList(strSql, dbParameter);
        }
        public IEnumerable<T> FindList(string strSql, Pagination pagination)
        {
            strSql = strSql + (GetReadSql() == "" ? "" : string.Format("and CreateUserId in({0})", GetReadSql()));
            return this.ERPRepository().FindList(strSql, pagination);
        }
        public IEnumerable<T> FindList(string strSql, DbParameter[] dbParameter, Pagination pagination)
        {
            strSql = strSql + (GetReadSql() == "" ? "" : string.Format("and CreateUserId in({0})", GetReadSql()));
            return this.ERPRepository().FindList(strSql, dbParameter, pagination);
        }
        #endregion

        #region 取数据权限用户
        private string GetReadUserId()
        {
            if (OperatorProvider.Provider.Current().IsSystem)
            {
                return "system";
            }
            return OperatorProvider.Provider.Current().DataAuthorize.ReadAutorizeUserId;
        }
        private string GetReadSql()
        {
            return OperatorProvider.Provider.Current().DataAuthorize.ReadAutorize;
        }

        public IEnumerable<T> FindList2(string strSql, Pagination pagination)
        {
            string sql = "select * from tb_MyUser where IsLocked=0 ";
            if (!string.IsNullOrEmpty(strSql)) {
                sql += strSql ;
            }
            return this.ERPRepository().FindList("select * from tb_MyUser where IsLocked=0 ", pagination);
            //return this.ERPRepository().FindList(sql, pagination);
        }
        #endregion
    }
}
