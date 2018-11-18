using Hengtex.Application.Code;
using Hengtex.Application.Entity.AppManage;
//using Hengtex.Application.Entity.AppManage.ViewModel;
using Hengtex.Application.Entity.AppManage;
using Hengtex.Application.Entity.AuthorizeManage.ViewModel;
using Hengtex.Application.IService.AppManage;
using Hengtex.Data;
using Hengtex.Data.Repository;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using Hengtex.Application.Entity.AppManage.ViewModel;

namespace Hengtex.Application.Service.AppManage
{
    /// <summary>
    /// 版 本
    /// Copyright (c) 2012-2017 恒泰纺织
    /// 创建人：菠萝绒
    /// 日 期：2015.12.5 22:35
    /// 描 述：授权认证
    /// </summary>
    public class AppAuthorizeService : RepositoryFactory, IAppAuthorizeService
    {
        /// <summary>
        /// 获取授权功能菜单
        /// </summary>
        /// <param name="userId">用户Id</param>
        /// <returns></returns>
        public IEnumerable<AppModuleEntity> GetModuleList(string userId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(@"SELECT  *
                            FROM    App_Module
                            WHERE   ModuleId IN (
                                    SELECT  ItemId
                                    FROM    App_Authorize
                                    WHERE   ItemType = 1
                                            AND ( ObjectId IN (
                                                  SELECT    ObjectId
                                                  FROM      App_UserRelation
                                                  WHERE     UserId = @UserId ) )
                                            OR (ItemType = 1 and ObjectId = @UserId) )
                            AND EnabledMark = 1  AND DeleteMark = 0 Order By SortCode");
     
            DbParameter[] parameter = 
            {
                DbParameters.CreateDbParameter("@UserId",userId)
            };
            return this.ERPRepository().FindList<AppModuleEntity>(strSql.ToString(), parameter);
        }

        /// <summary>
        /// 获取授权功能菜单
        /// </summary>
        /// <param name="userId">用户Id</param>
        /// <returns></returns>
        public IEnumerable<AppModuleEntity> GetModuleList(string userId,string menuName)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(@"SELECT  *
                            FROM    App_Module
                            WHERE   ModuleId IN (
                                    SELECT  ItemId
                                    FROM    App_Authorize
                                    WHERE   ItemType = 1
                                            AND ( ObjectId IN (
                                                  SELECT    ObjectId
                                                  FROM      App_UserRelation
                                                  WHERE     UserId = @UserId ) )
                                            OR (ItemType = 1 and ObjectId = @UserId) )
                            AND EnabledMark = 1  AND DeleteMark = 0 and ParentId in (select ModuleId from App_Module where EnCode = @menuName)Order By SortCode");

            DbParameter[] parameter = 
            {
                DbParameters.CreateDbParameter("@UserId",userId),
                DbParameters.CreateDbParameter("@menuName",menuName)
            };
            return this.ERPRepository().FindList<AppModuleEntity>(strSql.ToString(), parameter);
        }

        /// <summary>
        /// 获取授权功能按钮
        /// </summary>
        /// <param name="userId">用户Id</param>
        /// <returns></returns>
        public IEnumerable<AppModuleButtonEntity> GetModuleButtonList(string userId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(@"SELECT  *
                            FROM    Base_ModuleButton
                            WHERE   ModuleButtonId IN (
                                    SELECT  ItemId
                                    FROM    Base_Authorize
                                    WHERE   ItemType = 2
                                            AND ( ObjectId IN (
                                                  SELECT    ObjectId
                                                  FROM      Base_UserRelation
                                                  WHERE     UserId = @UserId ) )
                                            OR (ItemType = 2 and ObjectId = @UserId) ) Order By SortCode");

            DbParameter[] parameter = 
            {
                DbParameters.CreateDbParameter("@UserId",userId)
            };
            return this.ERPRepository().FindList<AppModuleButtonEntity>(strSql.ToString(), parameter);
        }
        /// <summary>
        /// 获取授权功能视图
        /// </summary>
        /// <param name="userId">用户Id</param>
        /// <returns></returns>
        public IEnumerable<AppModuleColumnEntity> GetModuleColumnList(string userId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(@"SELECT  *
                            FROM    Base_ModuleColumn
                            WHERE   ModuleColumnId IN (
                                    SELECT  ItemId
                                    FROM    Base_Authorize
                                    WHERE   ItemType = 3
                                            AND ( ObjectId IN (
                                                  SELECT    ObjectId
                                                  FROM      Base_UserRelation
                                                  WHERE     UserId = @UserId ) )
                                            OR (ItemType = 3 and ObjectId = @UserId) )  Order By SortCode");
           
            DbParameter[] parameter = 
            {
                DbParameters.CreateDbParameter("@UserId",userId)
            };
            return this.ERPRepository().FindList<AppModuleColumnEntity>(strSql.ToString(), parameter);
        }
        /// <summary>
        /// 获取授权功能Url、操作Url
        /// </summary>
        /// <param name="userId">用户Id</param>
        /// <returns></returns>
        public IEnumerable<AuthorizeUrlModel> GetUrlList(string userId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(@"SELECT  ModuleId AS AuthorizeId ,
                                    ModuleId ,
                                    UrlAddress ,
                                    FullName
                            FROM    Base_Module
                            WHERE   ModuleId IN (
                                    SELECT  ItemId
                                    FROM    Base_Authorize
                                    WHERE   ItemType = 1
                                            AND ( ObjectId IN (
                                                  SELECT    ObjectId
                                                  FROM      Base_UserRelation
                                                  WHERE     UserId = @UserId ) )
                                            OR (ItemType = 1 and ObjectId = @UserId) )
                                    AND EnabledMark = 1
                                    AND DeleteMark = 0
                                    AND IsMenu = 1
                                    AND UrlAddress IS NOT NULL
                            UNION
                            SELECT  ModuleButtonId AS AuthorizeId ,
                                    ModuleId ,
                                    ActionAddress AS UrlAddress ,
                                    FullName
                            FROM    Base_ModuleButton
                            WHERE   ModuleButtonId IN (
                                    SELECT  ItemId
                                    FROM    Base_Authorize
                                    WHERE   ItemType = 2
                                            AND ( ObjectId IN (
                                                  SELECT    ObjectId
                                                  FROM      Base_UserRelation
                                                  WHERE     UserId = @UserId ) )
                                            OR (ItemType = 2 and ObjectId = @UserId) )
                                    AND ActionAddress IS NOT NULL");
           
            DbParameter[] parameter = 
            {
                DbParameters.CreateDbParameter("@UserId",userId)
            };
            return this.ERPRepository().FindList<AuthorizeUrlModel>(strSql.ToString(), parameter);
        }
        /// <summary>
        /// 获取关联用户关系
        /// </summary>
        /// <param name="userId">用户Id</param>
        /// <returns></returns>
        public IEnumerable<AppUserRelationEntity> GetUserRelationList(string userId)
        {
            return this.ERPRepository().IQueryable<AppUserRelationEntity>(t => t.UserId == userId);
        }
        /// <summary>
        /// 获得权限范围用户ID
        /// </summary>
        /// <param name="operators">当前登陆用户信息</param>
        /// <param name="isWrite">可写入</param>
        /// <returns></returns>
        public string GetDataAuthorUserId(Operator operators, bool isWrite = false)
        {
            string userIdList = GetDataAuthor(operators, isWrite);
            if (userIdList == "")
            {
                return "";
            }
            IRepository db = new RepositoryFactory().ERPRepository();
            string userId = operators.UserId;
            List<AppUserEntity> userList = db.FindList<AppUserEntity>(userIdList).ToList();
            StringBuilder userSb = new StringBuilder("");
            if (userList != null)
            {
                int a = 0;
                foreach (var item in userList)
                {
                    
                    userSb.Append(item.isid);
                    if (a<userList.Count-1)
                    {
                        userSb.Append(",");
                    }
                    a++;
                }
            }
            return userSb.ToString();
        }
        /// <summary>
        /// 获得可读数据权限范围SQL
        /// </summary>
        /// <param name="operators">当前登陆用户信息</param>
        /// <param name="isWrite">可写入</param>
        /// <returns></returns>
        public string GetDataAuthor(Operator operators, bool isWrite = false)
        {
            //如果是系统管理员直接给所有数据权限
            if (operators.IsSystem)
            {
                return "";
            }
            IRepository db = new RepositoryFactory().ERPRepository();
            string userId = operators.UserId;
            StringBuilder whereSb = new StringBuilder(" select isid from tb_MyUser where 1=1 ");
            string strAuthorData = "";
            if (isWrite)
            {
                strAuthorData = @"   SELECT    *
                                        FROM      App_AuthorizeData
                                        WHERE     IsRead=0 AND
                                        ObjectId IN (
                                                SELECT  ObjectId
                                                FROM    App_UserRelation
                                                WHERE   UserId =@UserId) or ObjectId =@UserId";
            }
            else
            {
                strAuthorData = @"   SELECT    *
                                        FROM      App_AuthorizeData
                                        WHERE     
                                        ObjectId IN (
                                                SELECT  ObjectId
                                                FROM    App_UserRelation
                                                WHERE   UserId =@UserId) or ObjectId =@UserId";
            }

            DbParameter[] parameter = 
            {
                DbParameters.CreateDbParameter("@UserId",userId),
            };
            whereSb.Append(string.Format("AND( isid ='{0}'", userId));
            IEnumerable<AppAuthorizeDataEntity> listAuthorizeData = db.FindList<AppAuthorizeDataEntity>(strAuthorData, parameter);
            foreach (AppAuthorizeDataEntity item in listAuthorizeData)
            {

                switch (item.AuthorizeType)
                {
                    //0代表最大权限
                    case 0://
                        return "";
                    //case -1://本人
                    //    whereSb.Append("");
                    //    break;
                    //本人及下属
                    case -2://
                        whereSb.Append(string.Format("  OR ManagerId ='{0}'", userId));
                        break;
                    case -3:
                        whereSb.Append(string.Format(@" or DepartmentId = (  SELECT  DepartmentId
                                                                    FROM    Base_User
                                                                    WHERE   UserId ='{0}'
                                                                  )", userId));
                        break;
                    case -4:
//                        whereSb.Append(string.Format(@"  or OrganizeId = (    SELECT  OrganizeId
//                                                                    FROM    Base_User
//                                                                    WHERE   UserId ='{0}'
//                                                                  )", userId));
//                        break;
                        return "";
                    case -5:
                        whereSb.Append(string.Format(@"  or DepartmentId='{0}'", item.ResourceId));
                        break;
                }
            }
            whereSb.Append(")");
            return whereSb.ToString();
        }

    }
}
