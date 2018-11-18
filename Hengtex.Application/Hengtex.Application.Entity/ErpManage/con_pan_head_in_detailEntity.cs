using System;
using System.ComponentModel.DataAnnotations.Schema;
using Hengtex.Application.Code;

namespace Hengtex.Application.Entity.ErpManage
{
    /// <summary>
    /// �� ��
    /// Copyright (c) 2012-2017 ��̩��֯
    /// �� ������������Ա
    /// �� �ڣ�2018-05-24 17:21
    /// �� ����con_pan_head_in
    /// </summary>
    public class con_pan_head_in_detailEntity : BaseEntity
    {
        #region ʵ���Ա
        /// <summary>
        /// ID
        /// </summary>
        /// <returns></returns>
        [Column("PHID_ID")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? phid_id { get; set; }
        /// <summary>
        /// ��ͷ���
        /// </summary>
        /// <returns></returns>
        [Column("PHID_NUM")]
        public string phid_num { get; set; }
        /// <summary>
        /// ��ͷ���
        /// </summary>
        /// <returns></returns>
        [Column("PHID_PANNUM")]
        public string phid_panNum { get; set; }
        /// <summary>
        /// ԭ�ϱ���
        /// </summary>
        /// <returns></returns>
        [Column("PHID_NUMMATERIAL")]
        public string phid_numMaterial { get; set; }
        /// <summary>
        /// ԭ������
        /// </summary>
        /// <returns></returns>
        [Column("PHID_BATCHMATERIAL")]
        public string phid_batchMaterial { get; set; }
        /// <summary>
        /// ԭ������
        /// </summary>
        /// <returns></returns>
        [Column("PHID_AMEMATERIAL")]
        public string phid_ameMaterial { get; set; }
        /// <summary>
        /// ԭ�Ϲ��
        /// </summary>
        /// <returns></returns>
        [Column("PHID_SPECMATERIAL")]
        public string phid_specMaterial { get; set; }
        /// <summary>
        /// ԭ�ϲ���
        /// </summary>
        /// <returns></returns>
        [Column("PHID_WHEREMATERIAL")]
        public string phid_whereMaterial { get; set; }
        /// <summary>
        /// ԭ����ɫ
        /// </summary>
        /// <returns></returns>
        [Column("PHID_COLORMATERIAL")]
        public string phid_colorMaterial { get; set; }
        /// <summary>
        /// ԭ�ϵ���
        /// </summary>
        /// <returns></returns>
        [Column("PHID_PRICE")]
        public decimal? phid_price { get; set; }
        /// <summary>
        /// �ϻ�����
        /// </summary>
        /// <returns></returns>
        [Column("PHID_COUNT")]
        public decimal? phid_count { get; set; }
        /// <summary>
        /// ʣ������
        /// </summary>
        /// <returns></returns>
        [Column("PHID_COUNT_REMAIN")]
        public decimal? phid_count_remain { get; set; }
        /// <summary>
        /// �˿�����
        /// </summary>
        /// <returns></returns>
        [Column("PHID_COUNT_RETURN")]
        public decimal? phid_count_return { get; set; }
        /// <summary>
        /// ��ע
        /// </summary>
        /// <returns></returns>
        [Column("PHID_REMARKS")]
        public string phid_remarks { get; set; }
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
        /// ��λ���
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
        public string FlagApp { get; set; }
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
        public string FlagDelete { get; set; }
        #endregion

        #region ��չ����
        /// <summary>
        /// ��������
        /// </summary>
        public override void Create()
        {
            this.phid_id = 0;
                                            }
        /// <summary>
        /// �༭����
        /// </summary>
        /// <param name="keyValue"></param>
        public override void Modify(string keyValue)
        {
            this.phid_id = int.Parse(keyValue);
                                            }
        #endregion
    }
}