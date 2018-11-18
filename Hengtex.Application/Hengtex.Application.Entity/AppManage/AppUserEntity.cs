using System;
using Hengtex.Application.Code;

namespace Hengtex.Application.Entity.AppManage
{
    /// <summary>
    /// 版 本
    /// Copyright (c) 2012-2017 恒泰纺织
    /// 创建人：菠萝绒
    /// 日 期：2015.11.03 10:58
    /// 描 述：用户管理
    /// </summary>
    public class AppUserEntity : BaseEntity
    {
        #region 实体成员
        /// <summary>
        /// isid
        /// </summary>
        /// <returns></returns>
        public int? isid { get; set; }
        /// <summary>
        /// 登录帐号
        /// </summary>
        /// <returns></returns>
        public string Account { get; set; }
        /// <summary>
        /// Novell网帐号(全名,如.Jonny.EDP.CKG.MO)
        /// </summary>
        /// <returns></returns>
        public string NovellAccount { get; set; }
        /// <summary>
        /// Windows Domain Account(如:jonny@ckg.mo)
        /// </summary>
        /// <returns></returns>
        public string DomainName { get; set; }
        /// <summary>
        /// 中文名称
        /// </summary>
        /// <returns></returns>
        public string UserName { get; set; }
        /// <summary>
        /// Address
        /// </summary>
        /// <returns></returns>
        public string Address { get; set; }
        /// <summary>
        /// Tel
        /// </summary>
        /// <returns></returns>
        public string Tel { get; set; }
        /// <summary>
        /// Email
        /// </summary>
        /// <returns></returns>
        public string Email { get; set; }
        /// <summary>
        /// Password
        /// </summary>
        /// <returns></returns>
        public string Password { get; set; }
        /// <summary>
        /// LastLoginTime
        /// </summary>
        /// <returns></returns>
        public DateTime? LastLoginTime { get; set; }
        /// <summary>
        /// LastLogoutTime
        /// </summary>
        /// <returns></returns>
        public DateTime? LastLogoutTime { get; set; }
        /// <summary>
        /// 锁定标志
        /// </summary>
        /// <returns></returns>
        public bool? IsLocked { get; set; }
        /// <summary>
        /// CreateTime
        /// </summary>
        /// <returns></returns>
        public DateTime? CreateTime { get; set; }
        /// <summary>
        /// FlagAdmin
        /// </summary>
        /// <returns></returns>
        public string FlagAdmin { get; set; }
        /// <summary>
        /// FlagOnline
        /// </summary>
        /// <returns></returns>
        public string FlagOnline { get; set; }
        /// <summary>
        /// LoginCounter
        /// </summary>
        /// <returns></returns>
        public int? LoginCounter { get; set; }
        /// <summary>
        /// DataSets
        /// </summary>
        /// <returns></returns>
        public string DataSets { get; set; }
        /// <summary>
        /// 主管ID
        /// </summary>
        /// <returns></returns>
        public string Supervisor { get; set; }
        /// <summary>
        /// 主管姓名
        /// </summary>
        /// <returns></returns>
        public string SupervisorName { get; set; }
        /// <summary>
        /// 职工编号
        /// </summary>
        /// <returns></returns>
        public string EmpNum { get; set; }
        /// <summary>
        /// 用户岗位编号
        /// </summary>
        /// <returns></returns>
        public string StationNum { get; set; }
        /// <summary>
        /// 暂时锁定标志
        /// </summary>
        /// <returns></returns>
        public bool? IsTempLocked { get; set; }
        #endregion

        #region 扩展操作
        /// <summary>
        /// 新增调用
        /// </summary>
        public override void Create()
        {
            this.isid = 0;
        }
        /// <summary>
        /// 编辑调用
        /// </summary>
        /// <param name="keyValue"></param>
        public override void Modify(string keyValue)
        {
            this.isid = int.Parse(keyValue);
        }
        #endregion
    }
}