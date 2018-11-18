using Hengtex.Data;
using Hengtex.Data.Repository;
using Hengtex.Util;
using Hengtex.Util.WebControl;
using Hengtex.Util.Extension;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;
using System.Linq;
using Hengtex.Application.Entity.AppManage;
using Hengtex.Application.IService.AppManage;
using Hengtex.Application.IService.AppManage;
using Hengtex.Application.Service.AppManage;
using System;
using Hengtex.Application.Code;

namespace Hengtex.Application.Service.AppManage
{
    /// <summary>
    /// 版 本
    /// Copyright (c) 2012-2017 恒泰纺织
    /// 创建人：菠萝绒
    /// 日 期：2015.11.03 10:58
    /// 描 述：用户管理
    /// </summary>
    public class AppUserService : RepositoryFactory<AppUserEntity>, IAppUserService
    {
        private IAppAuthorizeService<AppUserEntity> iauthorizeservice = new AppAuthorizeService<AppUserEntity>();

        #region 获取数据
        /// <summary>
        /// 用户列表
        /// </summary>
        /// <returns></returns>
        public DataTable GetTable()
        {
            var strSql = new StringBuilder();
            strSql.Append(@"SELECT  u.*,
                                    '' AS DepartmentName 
                            FROM    tb_MyUser u
                                    --LEFT JOIN Base_Department d ON d.DepartmentId = u.DepartmentId
                            WHERE   1=1");
            strSql.Append(" AND u.Account <> 'System' AND  u.IsLocked=0");
            return this.ERPRepository().FindTable(strSql.ToString());
        }
        /// <summary>
        /// 用户列表
        /// </summary>
        /// <returns></returns>
        public IEnumerable<AppUserEntity> GetList()
        {
            var expression = LinqExtensions.True<AppUserEntity>();
            expression = expression.And(t => t.Account != "System").And(t => t.IsLocked == true);//.And(t => t.fla == 0);
            return this.ERPRepository().IQueryable(expression).OrderByDescending(t => t.isid).ToList();
        }
       
        /// <summary>
        /// 用户列表
        /// </summary>
        /// <param name="pagination">分页</param>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        public IEnumerable<AppUserEntity> GetPageList(Pagination pagination, string queryJson)
        {

            var expression = LinqExtensions.True<AppUserEntity>();
            var queryParam = queryJson.ToJObject();

            //公司主键
            //if (!queryParam["organizeId"].IsEmpty())
            //{
            //    string organizeId = queryParam["organizeId"].ToString();
            //    expression = expression.And(t => t..Equals(organizeId));
            //}
            //部门主键
            //if (!queryParam["departmentId"].IsEmpty())
            //{
            //    string departmentId = queryParam["departmentId"].ToString();
            //    expression = expression.And(t => t.DepartmentId.Equals(departmentId));
            //}
            //查询条件
            string sqlCondation = "";
            if (!queryParam["condition"].IsEmpty() && !queryParam["keyword"].IsEmpty())
            {
                string condition = queryParam["condition"].ToString();
                string keyord = queryParam["keyword"].ToString();
                
                switch (condition)
                {
                    case "Account":            //账户
                        expression = expression.And(t => t.Account.Equals(keyord));
                        sqlCondation = " and Account='"+keyord+"' ";
                        break;
                    case "UserName":          //姓名
                        expression = expression.And(t => t.UserName.Equals(keyord));
                        sqlCondation = " and UserName='" + keyord + "' ";
                        break;
                    case "Tel":          //手机
                        expression = expression.And(t => t.Tel.Equals(keyord));
                        sqlCondation = " and Tel='" + keyord + "' ";
                        break;
                    default:
                        break;
                }
            }
            //expression = expression.And(t => t.UserId != "System");
            return iauthorizeservice.FindList(expression, pagination);
            //return iauthorizeservice.FindList2(sqlCondation, pagination);
        }
        /// <summary>
        /// 用户列表（ALL）
        /// </summary>
        /// <returns></returns>
        public DataTable GetAllTable()
        {
            var strSql = new StringBuilder();
            strSql.Append(@"SELECT  u.UserId ,
                                    u.EnCode ,
                                    u.Account ,
                                    u.RealName ,
                                    u.Gender ,
                                    u.Birthday ,
                                    u.Mobile ,
                                    u.Manager ,
                                    u.OrganizeId,
                                    u.DepartmentId,
                                    o.FullName AS OrganizeName ,
                                    d.FullName AS DepartmentName ,
                                    u.RoleId ,
                                    u.DutyName ,
                                    u.PostName ,
                                    u.EnabledMark ,
                                    u.CreateDate,
                                    u.Description
                            FROM    Base_User u
                                    LEFT JOIN Base_Organize o ON o.OrganizeId = u.OrganizeId
                                    LEFT JOIN Base_Department d ON d.DepartmentId = u.DepartmentId
                            WHERE   1=1");
            strSql.Append(" AND u.UserId <> 'System' AND u.EnabledMark = 1 AND u.DeleteMark=0 order by o.FullName,d.FullName,u.RealName");
            return this.ERPRepository().FindTable(strSql.ToString());
        }
        /// <summary>
        /// 用户列表（导出Excel）
        /// </summary>
        /// <returns></returns>
        public DataTable GetExportList()
        {
            var strSql = new StringBuilder();
            strSql.Append(@"SELECT [Account]
                                  ,[RealName]
                                  ,CASE WHEN Gender=1 THEN '男' ELSE '女' END AS Gender
                                  ,[Birthday]
                                  ,[Mobile]
                                  ,[Telephone]
                                  ,u.[Email]
                                  ,[WeChat]
                                  ,[MSN]
                                  ,u.[Manager]
                                  ,o.FullName AS Organize
                                  ,d.FullName AS Department
                                  ,u.[Description]
                                  ,u.[CreateDate]
                                  ,u.[CreateUserName]
                              FROM Base_User u
                              INNER JOIN Base_Department d ON u.DepartmentId=d.DepartmentId
                              INNER JOIN Base_Organize o ON u.OrganizeId=o.OrganizeId");
            return this.ERPRepository().FindTable(strSql.ToString());
        }
        /// <summary>
        /// 用户实体
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        public AppUserEntity GetEntity(string keyValue)
        {
            return this.ERPRepository().FindEntity(keyValue);
        }
        /// <summary>
        /// 登录验证
        /// </summary>
        /// <param name="username">用户名</param>
        /// <returns></returns>
        public AppUserEntity CheckLogin(string username)
        {
            var expression = LinqExtensions.True<AppUserEntity>();
            expression = expression.And(t => t.Account == username);
            //expression = expression.Or(t => t.Tel == username);
            //expression = expression.Or(t => t.Email == username);
            return this.ERPRepository().FindEntity(expression);
        }
        #endregion

        #region 验证数据
        /// <summary>
        /// 账户不能重复
        /// </summary>
        /// <param name="account">账户值</param>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        public bool ExistAccount(string account, string keyValue)
        {
            var expression = LinqExtensions.True<AppUserEntity>();
            expression = expression.And(t => t.Account == account);
            if (!string.IsNullOrEmpty(keyValue))
            {
                expression = expression.And(t => t.isid != int.Parse(keyValue));
            }
            return this.ERPRepository().IQueryable(expression).Count() == 0 ? true : false;
        }
        #endregion

        #region 提交数据
        /// <summary>
        /// 删除用户
        /// </summary>
        /// <param name="keyValue">主键</param>
        public void RemoveForm(string keyValue)
        {
            this.ERPRepository().Delete(keyValue);
        }
        /// <summary>
        /// 保存用户表单（新增、修改）
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <param name="userEntity">用户实体</param>
        /// <returns></returns>
        public string SaveForm(string keyValue, AppUserEntity userEntity)
        {
            IRepository db = new RepositoryFactory().ERPRepository().BeginTrans();
            try
            {
                #region 基本信息
                if (!string.IsNullOrEmpty(keyValue))
                {
                    userEntity.Modify(keyValue);
                    userEntity.Password = null;
                    db.Update(userEntity);
                }
                else
                {
                    userEntity.Create();
                    keyValue = userEntity.isid.ToString();
                    //userEntity.Secretkey = Md5Helper.MD5(CommonHelper.CreateNo(), 16).ToLower();
                    //userEntity.Password = Md5Helper.MD5(DESEncrypt.Encrypt(Md5Helper.MD5(userEntity.Password, 32).ToLower(), userEntity.Secretkey).ToLower(), 32).ToLower();
                    db.Insert(userEntity);
                    
                }
                #endregion

                #region 默认添加 角色、岗位、职位
                db.Delete<AppUserRelationEntity>(t => t.IsDefault == 1 && t.UserId == userEntity.Account);
                List<AppUserRelationEntity> userRelationEntitys = new List<AppUserRelationEntity>();
                //角色
                //if (!string.IsNullOrEmpty(userEntity.RoleId))
                //{
                //    userRelationEntitys.Add(new AppUserRelationEntity
                //    {
                //        Category = 2,
                //        UserRelationId = Guid.NewGuid().ToString(),
                //        UserId = userEntity.UserId,
                //        ObjectId = userEntity.RoleId,
                //        CreateDate = DateTime.Now,
                //        CreateUserId = OperatorProvider.Provider.Current().UserId,
                //        CreateUserName = OperatorProvider.Provider.Current().UserName,
                //        IsDefault = 1,
                //    });
                //}
                ////岗位
                //if (!string.IsNullOrEmpty(userEntity.DutyId))
                //{
                //    userRelationEntitys.Add(new AppUserRelationEntity
                //    {
                //        Category = 3,
                //        UserRelationId = Guid.NewGuid().ToString(),
                //        UserId = userEntity.UserId,
                //        ObjectId = userEntity.DutyId,
                //        CreateDate = DateTime.Now,
                //        CreateUserId = OperatorProvider.Provider.Current().UserId,
                //        CreateUserName = OperatorProvider.Provider.Current().UserName,
                //        IsDefault = 1,
                //    });
                //}
                ////职位
                //if (!string.IsNullOrEmpty(userEntity.PostId))
                //{
                //    userRelationEntitys.Add(new AppUserRelationEntity
                //    {
                //        Category = 4,
                //        UserRelationId = Guid.NewGuid().ToString(),
                //        UserId = userEntity.UserId,
                //        ObjectId = userEntity.PostId,
                //        CreateDate = DateTime.Now,
                //        CreateUserId = OperatorProvider.Provider.Current().UserId,
                //        CreateUserName = OperatorProvider.Provider.Current().UserName,
                //        IsDefault = 1,
                //    });
                //}
                db.Insert(userRelationEntitys);
                #endregion

                db.Commit();

                return keyValue;
            }
            catch (Exception)
            {
                db.Rollback();
                throw;
            }
        }
        /// <summary>
        /// 修改用户登录密码
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <param name="Password">新密码（MD5 小写）</param>
        public void RevisePassword(string keyValue, string Password)
        {
            AppUserEntity userEntity = new AppUserEntity();
            userEntity.isid = int.Parse(keyValue);
            //userEntity.Secretkey = Md5Helper.MD5(CommonHelper.CreateNo(), 16).ToLower();
            //userEntity.Password = Md5Helper.MD5(DESEncrypt.Encrypt(Password, userEntity.Secretkey).ToLower(), 32).ToLower();
            this.ERPRepository().Update(userEntity);
        }
        /// <summary>
        /// 修改用户状态
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <param name="State">状态：1-启动；0-禁用</param>
        public void UpdateState(string keyValue, int State)
        {
            AppUserEntity userEntity = new AppUserEntity();
            userEntity.Modify(keyValue);
            userEntity.IsLocked = State == 1 ? false : true ;
            this.ERPRepository().Update(userEntity);
        }
        /// <summary>
        /// 修改用户信息
        /// </summary>
        /// <param name="userEntity">实体对象</param>
        public void UpdateEntity(AppUserEntity userEntity)
        {
            this.ERPRepository().Update(userEntity);
        }
        #endregion
    }
}
