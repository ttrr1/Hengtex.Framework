using System;
using System.ComponentModel.DataAnnotations.Schema;
using Hengtex.Application.Code;

namespace Hengtex.Application.Entity.ErpManage
{
    /// <summary>
    /// �� ��
    /// Copyright (c) 2012-2017 ��̩��֯
    /// �� ������������Ա
    /// �� �ڣ�2018-05-22 15:57
    /// �� ����con_pan_head_up
    /// </summary>
    public class con_pan_head_empsEntity : BaseEntity
    {
        #region ʵ���Ա
        /// <summary>
        /// ID
        /// </summary>
        /// <returns></returns>
        [Column("PHE_ID")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? phe_id { get; set; }
        /// <summary>
        /// ���ݺ�
        /// </summary>
        /// <returns></returns>
        [Column("PHE_NUM")]
        public string phe_num { get; set; }
        /// <summary>
        /// ����Ա���
        /// </summary>
        /// <returns></returns>
        [Column("PHE_EMPNO")]
        public string phe_empNo { get; set; }
        /// <summary>
        /// ����Ա����
        /// </summary>
        /// <returns></returns>
        [Column("PHE_NAME")]
        public string phe_name { get; set; }
        /// <summary>
        /// ��ע
        /// </summary>
        /// <returns></returns>
        [Column("PHE_REMARKS")]
        public string phe_remarks { get; set; }
        #endregion

        #region ��չ����
        /// <summary>
        /// ��������
        /// </summary>
        public override void Create()
        {
            this.phe_id = 0;
                                            }
        /// <summary>
        /// �༭����
        /// </summary>
        /// <param name="keyValue"></param>
        public override void Modify(string keyValue)
        {
            this.phe_id = int.Parse(keyValue);
                                            }
        #endregion
    }
}