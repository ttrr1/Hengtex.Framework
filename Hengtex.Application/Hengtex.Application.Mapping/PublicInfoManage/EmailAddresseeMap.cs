using Hengtex.Application.Entity.PublicInfoManage;
using System.Data.Entity.ModelConfiguration;

namespace Hengtex.Application.Mapping.PublicInfoManage
{
    /// <summary>
    /// 版 本 1.0
    /// Copyright (c) 2012-2017 恒泰纺织
    /// 创建人：菠萝绒
    /// 日 期：2015.12.8 11:31
    /// 描 述：邮件收件人
    /// </summary>
    public class EmailAddresseeMap : EntityTypeConfiguration<EmailAddresseeEntity>
    {
        public EmailAddresseeMap()
        {
            #region 表、主键
            //表
            this.ToTable("Email_Addressee");
            //主键
            this.HasKey(t => t.AddresseeId);
            #endregion

            #region 配置关系
            #endregion
        }
    }
}
