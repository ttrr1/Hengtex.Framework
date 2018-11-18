using System;
using System.ComponentModel.DataAnnotations.Schema;
using Hengtex.Application.Code;

namespace Hengtex.Application.Entity.BaseManage
{
    /// <summary>
    /// �� ��
    /// Copyright (c) 2012-2017 ��̩��֯
    /// �� ������������Ա
    /// �� �ڣ�2018-01-19 15:26
    /// �� ����con_workshop_turnover
    /// </summary>
    public class con_workshop_turnoverEntity : BaseEntity
    {
        #region ʵ���Ա
        /// <summary>
        /// ID
        /// </summary>
        /// <returns></returns>
        [Column("WT_ID")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? wt_id { get; set; }
        /// <summary>
        /// ���ݺ�
        /// </summary>
        /// <returns></returns>
        [Column("WT_NUM")]
        public string wt_num { get; set; }
        /// <summary>
        /// ��˱�ʶ
        /// </summary>
        /// <returns></returns>
        [Column("WT_REVIEW")]
        public string wt_review { get; set; }
        /// <summary>
        /// ����ʶ
        /// </summary>
        /// <returns></returns>
        [Column("WT_STOCKIN")]
        public string wt_stockin { get; set; }
        /// <summary>
        /// ��������
        /// </summary>
        /// <returns></returns>
        [Column("WT_INSPECTTYPE")]
        public string wt_inspectType { get; set; }
        /// <summary>
        /// ��������
        /// </summary>
        /// <returns></returns>
        [Column("WT_DS")]
        public string wt_ds { get; set; }
        /// <summary>
        /// ����
        /// </summary>
        /// <returns></returns>
        [Column("WT_DATE")]
        public DateTime? wt_date { get; set; }
        /// <summary>
        /// ��ˮ��
        /// </summary>
        /// <returns></returns>
        [Column("WT_SNUM")]
        public string wt_sNum { get; set; }
        /// <summary>
        /// �������ű���
        /// </summary>
        /// <returns></returns>
        [Column("WT_OUTDEPARTNUM")]
        public string wt_outDepartNum { get; set; }
        /// <summary>
        /// ������������
        /// </summary>
        /// <returns></returns>
        [Column("WT_OUTDEPARTNAME")]
        public string wt_outDepartName { get; set; }
        /// <summary>
        /// ���벿�ű���
        /// </summary>
        /// <returns></returns>
        [Column("WT_INDEPARTNUM")]
        public string wt_inDepartNum { get; set; }
        /// <summary>
        /// ���벿������
        /// </summary>
        /// <returns></returns>
        [Column("WT_INDEPARTNAME")]
        public string wt_inDepartName { get; set; }
        /// <summary>
        /// ����
        /// </summary>
        /// <returns></returns>
        [Column("WT_COUNT")]
        public decimal? wt_count { get; set; }
        /// <summary>
        /// ���˱�־
        /// </summary>
        /// <returns></returns>
        [Column("WT_FLAGACCOUNT")]
        public string wt_flagAccount { get; set; }
        /// <summary>
        /// �ɱ����˱�־
        /// </summary>
        /// <returns></returns>
        [Column("WT_FLAGCOSTACCOUNT")]
        public string wt_flagCostAccount { get; set; }
        /// <summary>
        /// ��ע
        /// </summary>
        /// <returns></returns>
        [Column("WT_REMARKS")]
        public string wt_remarks { get; set; }
        /// <summary>
        /// ����ʱ��
        /// </summary>
        /// <returns></returns>
        [Column("CREATIONDATE")]
        public DateTime? CreationDate { get; set; }
        /// <summary>
        /// ������
        /// </summary>
        /// <returns></returns>
        [Column("CREATEDBY")]
        public string CreatedBy { get; set; }
        /// <summary>
        /// CreatedByNum
        /// </summary>
        /// <returns></returns>
        [Column("CREATEDBYNUM")]
        public string CreatedByNum { get; set; }
        /// <summary>
        /// ����޸�ʱ��
        /// </summary>
        /// <returns></returns>
        [Column("LASTUPDATEDATE")]
        public DateTime? LastUpdateDate { get; set; }
        /// <summary>
        /// ����޸���
        /// </summary>
        /// <returns></returns>
        [Column("LASTUPDATEDBY")]
        public string LastUpdatedBy { get; set; }
        /// <summary>
        /// �����
        /// </summary>
        /// <returns></returns>
        [Column("APPUSER")]
        public string AppUser { get; set; }
        /// <summary>
        /// ���ʱ��
        /// </summary>
        /// <returns></returns>
        [Column("APPDATE")]
        public DateTime? AppDate { get; set; }
        /// <summary>
        /// ��˱�־
        /// </summary>
        /// <returns></returns>
        [Column("FLAGAPP")]
        public bool FlagApp { get; set; }
        /// <summary>
        /// ɾ����
        /// </summary>
        /// <returns></returns>
        [Column("DELMAN")]
        public string DelMan { get; set; }
        /// <summary>
        /// ɾ��ʱ��
        /// </summary>
        /// <returns></returns>
        [Column("DELDATE")]
        public DateTime? DelDate { get; set; }
        /// <summary>
        /// ɾ����־
        /// </summary>
        /// <returns></returns>
        [Column("FLAGDELETE")]
        public bool FlagDelete { get; set; }
        #endregion

        #region ��չ����
        /// <summary>
        /// ��������
        /// </summary>
        public override void Create()
        {
            this.wt_num = Guid.NewGuid().ToString();
                                            }
        /// <summary>
        /// �༭����
        /// </summary>
        /// <param name="keyValue"></param>
        public override void Modify(string keyValue)
        {
            this.wt_num = keyValue;
                                            }
        #endregion
    }
}