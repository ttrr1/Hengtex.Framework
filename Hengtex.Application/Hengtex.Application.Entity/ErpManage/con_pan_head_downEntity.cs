using System;
using System.ComponentModel.DataAnnotations.Schema;
using Hengtex.Application.Code;

namespace Hengtex.Application.Entity.ErpManage
{
    /// <summary>
    /// �� ��
    /// Copyright (c) 2012-2017 ��̩��֯
    /// �� ������������Ա
    /// �� �ڣ�2018-05-24 17:24
    /// �� ����con_pan_head_down
    /// </summary>
    public class con_pan_head_downEntity : BaseEntity
    {
        #region ʵ���Ա
        /// <summary>
        /// ID
        /// </summary>
        /// <returns></returns>
        [Column("PHD_ID")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? phd_id { get; set; }
        /// <summary>
        /// ���ݺ�
        /// </summary>
        /// <returns></returns>
        [Column("PHD_NUM")]
        public string phd_num { get; set; }
        /// <summary>
        /// �Ǽ�ʱ��
        /// </summary>
        /// <returns></returns>
        [Column("PHD_DATETIME")]
        public DateTime? phd_datetime { get; set; }
        /// <summary>
        /// ��ͷID
        /// </summary>
        /// <returns></returns>
        [Column("PHD_PANNUM")]
        public string phd_panNum { get; set; }
        /// <summary>
        /// ��ͷ��
        /// </summary>
        /// <returns></returns>
        [Column("PHD_PANNO")]
        public string phd_panno { get; set; }
        /// <summary>
        /// ��ͷ����
        /// </summary>
        /// <returns></returns>
        [Column("PHD_TYPE")]
        public string phd_type { get; set; }
        /// <summary>
        /// �ƻ���ϸ���
        /// </summary>
        /// <returns></returns>
        [Column("PHD_PLANDETAIL")]
        public string phd_planDetail { get; set; }
        /// <summary>
        /// ����ID
        /// </summary>
        /// <returns></returns>
        [Column("PHD_PROCEDUREID")]
        public string phd_procedureID { get; set; }
        /// <summary>
        /// ��������
        /// </summary>
        /// <returns></returns>
        [Column("PHD_PROCEDURENAME")]
        public string phd_procedureName { get; set; }
        /// <summary>
        /// ����
        /// </summary>
        /// <returns></returns>
        [Column("PHD_BATCH")]
        public string phd_batch { get; set; }
        /// <summary>
        /// Ʒ��
        /// </summary>
        /// <returns></returns>
        [Column("PHD_PINHAO")]
        public string phd_pinhao { get; set; }
        /// <summary>
        /// ��ɫ
        /// </summary>
        /// <returns></returns>
        [Column("PHD_COLOR")]
        public string phd_color { get; set; }
        /// <summary>
        /// ����
        /// </summary>
        /// <returns></returns>
        [Column("PHD_LENGTHWARP")]
        public decimal? phd_lengthWarp { get; set; }
        /// <summary>
        /// �ͻ�����
        /// </summary>
        /// <returns></returns>
        [Column("PHD_CUSTNUM")]
        public string phd_custNum { get; set; }
        /// <summary>
        /// �ͻ�����
        /// </summary>
        /// <returns></returns>
        [Column("PHD_CUSTNAME")]
        public string phd_custName { get; set; }
        /// <summary>
        /// ����
        /// </summary>
        /// <returns></returns>
        [Column("PHD_COUNT")]
        public decimal? phd_count { get; set; }
        /// <summary>
        /// ��ͷ����
        /// </summary>
        /// <returns></returns>
        [Column("PHD_COUNT_PAN")]
        public int? phd_count_pan { get; set; }
        /// <summary>
        /// ����
        /// </summary>
        /// <returns></returns>
        [Column("PHD_CLASSID")]
        public string phd_classId { get; set; }
        /// <summary>
        /// ����
        /// </summary>
        /// <returns></returns>
        [Column("PHD_CLASS")]
        public string phd_class { get; set; }
        /// <summary>
        /// ����Ա���
        /// </summary>
        /// <returns></returns>
        [Column("PHD_EMPNO")]
        public string phd_empNo { get; set; }
        /// <summary>
        /// ����Ա����
        /// </summary>
        /// <returns></returns>
        [Column("PHD_NAME")]
        public string phd_name { get; set; }
        /// <summary>
        /// ��ͷ����
        /// </summary>
        /// <returns></returns>
        [Column("PHD_WEIGHT")]
        public decimal? phd_weight { get; set; }
        /// <summary>
        /// ��ͷʣ��
        /// </summary>
        /// <returns></returns>
        [Column("PHD_WEIGHT_REMAIN")]
        public decimal? phd_weight_remain { get; set; }
        /// <summary>
        /// ֯������
        /// </summary>
        /// <returns></returns>
        [Column("PHD_MACHINEID_CON")]
        public string phd_machineID_con { get; set; }
        /// <summary>
        /// ֯������
        /// </summary>
        /// <returns></returns>
        [Column("PHD_MACHINENAME_CON")]
        public string phd_machineName_con { get; set; }
        /// <summary>
        /// ��λ��
        /// </summary>
        /// <returns></returns>
        [Column("PHD_NO_POS")]
        public string phd_no_pos { get; set; }
        /// <summary>
        /// ��λ����
        /// </summary>
        /// <returns></returns>
        [Column("PHD_NAME_POS")]
        public string phd_name_pos { get; set; }
        /// <summary>
        /// ��ע
        /// </summary>
        /// <returns></returns>
        [Column("PHD_REMARKS")]
        public string phd_remarks { get; set; }
        /// <summary>
        /// ��λ��
        /// </summary>
        /// <returns></returns>
        [Column("PHD_STATUS")]
        public string phd_status { get; set; }
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
            this.phd_num = Guid.NewGuid().ToString();
                                            }
        /// <summary>
        /// �༭����
        /// </summary>
        /// <param name="keyValue"></param>
        public override void Modify(string keyValue)
        {
            this.phd_num = keyValue;
                                            }
        #endregion
    }
}