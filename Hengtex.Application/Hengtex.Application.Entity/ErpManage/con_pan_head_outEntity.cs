using System;
using System.ComponentModel.DataAnnotations.Schema;
using Hengtex.Application.Code;

namespace Hengtex.Application.Entity.ErpManage
{
    /// <summary>
    /// �� ��
    /// Copyright (c) 2012-2017 ��̩��֯
    /// �� ������������Ա
    /// �� �ڣ�2018-05-24 17:23
    /// �� ����con_pan_head_out
    /// </summary>
    public class con_pan_head_outEntity : BaseEntity
    {
        #region ʵ���Ա
        /// <summary>
        /// ID
        /// </summary>
        /// <returns></returns>
        [Column("PHO_ID")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? pho_id { get; set; }
        /// <summary>
        /// �Ǽ�ʱ��
        /// </summary>
        /// <returns></returns>
        [Column("PHO_DATETIME")]
        public DateTime? pho_datetime { get; set; }
        /// <summary>
        /// pho_Num
        /// </summary>
        /// <returns></returns>
        [Column("PHO_NUM")]
        public string pho_Num { get; set; }
        /// <summary>
        /// ��ͷID
        /// </summary>
        /// <returns></returns>
        [Column("PHO_PANNUM")]
        public string pho_panNum { get; set; }
        /// <summary>
        /// ��ͷ��
        /// </summary>
        /// <returns></returns>
        [Column("PHO_PANNO")]
        public string pho_panno { get; set; }
        /// <summary>
        /// ��ͷ����
        /// </summary>
        /// <returns></returns>
        [Column("PHO_TYPE")]
        public string pho_type { get; set; }
        /// <summary>
        /// �ƻ���ϸ���
        /// </summary>
        /// <returns></returns>
        [Column("PHO_PLANDETAIL")]
        public string pho_planDetail { get; set; }
        /// <summary>
        /// ����ID
        /// </summary>
        /// <returns></returns>
        [Column("PHO_PROCEDUREID")]
        public string pho_procedureID { get; set; }
        /// <summary>
        /// ��������
        /// </summary>
        /// <returns></returns>
        [Column("PHO_PROCEDURENAME")]
        public string pho_procedureName { get; set; }
        /// <summary>
        /// ����
        /// </summary>
        /// <returns></returns>
        [Column("PHO_BATCH")]
        public string pho_batch { get; set; }
        /// <summary>
        /// Ʒ��
        /// </summary>
        /// <returns></returns>
        [Column("PHO_PINHAO")]
        public string pho_pinhao { get; set; }
        /// <summary>
        /// ��ɫ
        /// </summary>
        /// <returns></returns>
        [Column("PHO_COLOR")]
        public string pho_color { get; set; }
        /// <summary>
        /// ����
        /// </summary>
        /// <returns></returns>
        [Column("PHO_LENGTHWARP")]
        public decimal? pho_lengthWarp { get; set; }
        /// <summary>
        /// �ͻ�����
        /// </summary>
        /// <returns></returns>
        [Column("PHO_CUSTNUM")]
        public string pho_custNum { get; set; }
        /// <summary>
        /// �ͻ�����
        /// </summary>
        /// <returns></returns>
        [Column("PHO_CUSTNAME")]
        public string pho_custName { get; set; }
        /// <summary>
        /// ����
        /// </summary>
        /// <returns></returns>
        [Column("PHO_COUNT")]
        public decimal? pho_count { get; set; }
        /// <summary>
        /// ��ͷ����
        /// </summary>
        /// <returns></returns>
        [Column("PHO_COUNT_PAN")]
        public int? pho_count_pan { get; set; }
        /// <summary>
        /// ��������
        /// </summary>
        /// <returns></returns>
        [Column("PHO_LENGTH")]
        public decimal? pho_length { get; set; }
        /// <summary>
        /// ����
        /// </summary>
        /// <returns></returns>
        [Column("PHO_CLASSID")]
        public string pho_classId { get; set; }
        /// <summary>
        /// ����
        /// </summary>
        /// <returns></returns>
        [Column("PHO_CLASS")]
        public string pho_class { get; set; }
        /// <summary>
        /// ����Ա���
        /// </summary>
        /// <returns></returns>
        [Column("PHO_EMPNO")]
        public string pho_empNo { get; set; }
        /// <summary>
        /// ����Ա����
        /// </summary>
        /// <returns></returns>
        [Column("PHO_NAME")]
        public string pho_name { get; set; }
        /// <summary>
        /// ��ͷ����
        /// </summary>
        /// <returns></returns>
        [Column("PHO_WEIGHT")]
        public decimal? pho_weight { get; set; }
        /// <summary>
        /// ��˿����
        /// </summary>
        /// <returns></returns>
        [Column("PHO_WEIGHT_WASTE")]
        public decimal? pho_weight_waste { get; set; }
        /// <summary>
        /// ��������
        /// </summary>
        /// <returns></returns>
        [Column("PHO_MACHINEID_WARP")]
        public string pho_machineID_warp { get; set; }
        /// <summary>
        /// ������
        /// </summary>
        /// <returns></returns>
        [Column("PHO_MACHINENAME_WARP")]
        public string pho_machineName_warp { get; set; }
        /// <summary>
        /// ��λ��
        /// </summary>
        /// <returns></returns>
        [Column("PHO_NO_POS")]
        public string pho_no_pos { get; set; }
        /// <summary>
        /// ��λ����
        /// </summary>
        /// <returns></returns>
        [Column("PHO_NAME_POS")]
        public string pho_name_pos { get; set; }
        /// <summary>
        /// ��ע
        /// </summary>
        /// <returns></returns>
        [Column("PHO_REMARKS")]
        public string pho_remarks { get; set; }
        /// <summary>
        /// ��λ��
        /// </summary>
        /// <returns></returns>
        [Column("PHO_STATUS")]
        public string pho_status { get; set; }
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
            this.pho_Num = Guid.NewGuid().ToString();
                                            }
        /// <summary>
        /// �༭����
        /// </summary>
        /// <param name="keyValue"></param>
        public override void Modify(string keyValue)
        {
            this.pho_Num = keyValue;
                                            }
        #endregion
    }
}