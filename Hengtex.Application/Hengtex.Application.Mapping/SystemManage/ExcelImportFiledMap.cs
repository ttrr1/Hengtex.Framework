using Hengtex.Application.Entity.SystemManage;
using System.Data.Entity.ModelConfiguration;

namespace Hengtex.Application.Mapping.SystemManage
{
    /// <summary>
    /// �� ��
    /// Copyright (c) 2012-2017 ��̩��֯
    /// �� ������������Ա
    /// �� �ڣ�2017-03-31 15:17
    /// �� ����Excel����ģ���
    /// </summary>
    public class ExcelImportFiledMap : EntityTypeConfiguration<ExcelImportFiledEntity>
    {
        public ExcelImportFiledMap()
        {
            #region ������
            //��
            this.ToTable("Base_ExcelImportFiled");
            //����
            this.HasKey(t => t.F_Id);
            #endregion

            #region ���ù�ϵ
            #endregion
        }
    }
}
