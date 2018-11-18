using Hengtex.Application.Entity.WeChatManage;
using System.Data.Entity.ModelConfiguration;

namespace Hengtex.Application.Mapping.WeChatManage
{
    /// <summary>
    /// 版 本 1.0
    /// Copyright (c) 2012-2017 恒泰纺织
    /// 创建人：菠萝绒
    /// 日 期：2015.12.23 11:31
    /// 描 述：企业号部门
    /// </summary>
    public class WeChatDeptRelationMap : EntityTypeConfiguration<WeChatDeptRelationEntity>
    {
        public WeChatDeptRelationMap()
        {
            #region 表、主键
            //表
            this.ToTable("WeChat_DeptRelation");
            //主键
            this.HasKey(t => t.DeptId);
            #endregion

            #region 配置关系
            #endregion
        }
    }
}
