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
    public class con_workshop_turnover_detailEntity : BaseEntity
    {
        #region ʵ���Ա
        /// <summary>
        /// ID
        /// </summary>
        /// <returns></returns>
        [Column("WTD_ID")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? wtd_id { get; set; }
        /// <summary>
        /// ���ݺ�
        /// </summary>
        /// <returns></returns>
        [Column("WTD_NUM")]
        public string wtd_num { get; set; }
        /// <summary>
        /// ���
        /// </summary>
        /// <returns></returns>
        [Column("WTD_WS")]
        public string wtd_ws { get; set; }
        /// <summary>
        /// ԭ�ϱ���
        /// </summary>
        /// <returns></returns>
        [Column("WTD_BATCHCODE")]
        public string wtd_batchCode { get; set; }
        /// <summary>
        /// ����
        /// </summary>
        /// <returns></returns>
        [Column("WTD_BATCH")]
        public string wtd_batch { get; set; }
        /// <summary>
        /// ԭ������
        /// </summary>
        /// <returns></returns>
        [Column("WTD_NAME")]
        public string wtd_name { get; set; }
        /// <summary>
        /// ���
        /// </summary>
        /// <returns></returns>
        [Column("WTD_SPEC")]
        public string wtd_spec { get; set; }
        /// <summary>
        /// �ͺ�
        /// </summary>
        /// <returns></returns>
        [Column("WTD_TYPE")]
        public string wtd_type { get; set; }
        /// <summary>
        /// ��ɫ
        /// </summary>
        /// <returns></returns>
        [Column("WTD_COLOR")]
        public string wtd_color { get; set; }
        /// <summary>
        /// ����
        /// </summary>
        /// <returns></returns>
        [Column("WTD_FROM")]
        public string wtd_from { get; set; }
        /// <summary>
        /// ������λ
        /// </summary>
        /// <returns></returns>
        [Column("WTD_UNIT")]
        public string wtd_unit { get; set; }
        /// <summary>
        /// ����
        /// </summary>
        /// <returns></returns>
        [Column("WTD_COUNT")]
        public decimal? wtd_count { get; set; }
        /// <summary>
        /// ����
        /// </summary>
        /// <returns></returns>
        [Column("WTD_UNITPRICE")]
        public decimal? wtd_unitPrice { get; set; }
        /// <summary>
        /// ���
        /// </summary>
        /// <returns></returns>
        [Column("WTD_AMOUNT")]
        public decimal? wtd_amount { get; set; }
        /// <summary>
        /// �ɱ�����
        /// </summary>
        /// <returns></returns>
        [Column("WTD_UNITPRICECOST")]
        public decimal? wtd_unitPriceCost { get; set; }
        /// <summary>
        /// �ɱ����
        /// </summary>
        /// <returns></returns>
        [Column("WTD_AMOUNTCOST")]
        public decimal? wtd_amountCost { get; set; }
        /// <summary>
        /// ��ע
        /// </summary>
        /// <returns></returns>
        [Column("WTD_REMARKS")]
        public string wtd_remarks { get; set; }
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
            this.wtd_id = 0;
                                            }
        /// <summary>
        /// �༭����
        /// </summary>
        /// <param name="keyValue"></param>
        public override void Modify(string keyValue)
        {
            this.wtd_id = int.Parse(keyValue);
                                            }
        #endregion
    }
}