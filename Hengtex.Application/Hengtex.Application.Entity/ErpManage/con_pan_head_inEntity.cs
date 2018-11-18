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
    public class con_pan_head_inEntity : BaseEntity
    {
        #region ʵ���Ա
        /// <summary>
        /// ID
        /// </summary>
        /// <returns></returns>
        [Column("PHI_ID")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? phi_id { get; set; }
        /// <summary>
        /// �Ǽ�ʱ��
        /// </summary>
        /// <returns></returns>
        [Column("PHI_DATETIME")]
        public DateTime? phi_datetime { get; set; }
        /// <summary>
        /// ��ͷID
        /// </summary>
        /// <returns></returns>
        [Column("PHI_TASKNUM")]
        public string phi_taskNum { get; set; }
        /// <summary>
        /// ��ͷID
        /// </summary>
        /// <returns></returns>
        [Column("PHI_NUM")]
        public string phi_Num { get; set; }
        /// <summary>
        /// ��ͷID
        /// </summary>
        /// <returns></returns>
        [Column("PHI_PANNUM")]
        public string phi_panNum { get; set; }
        /// <summary>
        /// ��ͷ��
        /// </summary>
        /// <returns></returns>
        [Column("PHI_PANNO")]
        public string phi_panno { get; set; }
        /// <summary>
        /// ��ͷ����
        /// </summary>
        /// <returns></returns>
        [Column("PHI_TYPE")]
        public string phi_type { get; set; }
        /// <summary>
        /// �ƻ���ϸ���
        /// </summary>
        /// <returns></returns>
        [Column("PHI_PLANDETAIL")]
        public string phi_planDetail { get; set; }
        /// <summary>
        /// ����ID
        /// </summary>
        /// <returns></returns>
        [Column("PHI_PROCEDUREID")]
        public string phi_procedureID { get; set; }
        /// <summary>
        /// ��������
        /// </summary>
        /// <returns></returns>
        [Column("PHI_PROCEDURENAME")]
        public string phi_procedureName { get; set; }
        /// <summary>
        /// ����
        /// </summary>
        /// <returns></returns>
        [Column("PHI_BATCH")]
        public string phi_batch { get; set; }
        /// <summary>
        /// Ʒ��
        /// </summary>
        /// <returns></returns>
        [Column("PHI_PINHAO")]
        public string phi_pinhao { get; set; }
        /// <summary>
        /// ��ɫ
        /// </summary>
        /// <returns></returns>
        [Column("PHI_COLOR")]
        public string phi_color { get; set; }
        /// <summary>
        /// ����
        /// </summary>
        /// <returns></returns>
        [Column("PHI_LENGTHWARP")]
        public decimal? phi_lengthWarp { get; set; }
        /// <summary>
        /// �ͻ�����
        /// </summary>
        /// <returns></returns>
        [Column("PHI_CUSTNUM")]
        public string phi_custNum { get; set; }
        /// <summary>
        /// �ͻ�����
        /// </summary>
        /// <returns></returns>
        [Column("PHI_CUSTNAME")]
        public string phi_custName { get; set; }
        /// <summary>
        /// ����
        /// </summary>
        /// <returns></returns>
        [Column("PHI_COUNT")]
        public decimal? phi_count { get; set; }
        /// <summary>
        /// ��ͷ����
        /// </summary>
        /// <returns></returns>
        [Column("PHI_COUNT_PAN")]
        public int? phi_count_pan { get; set; }
        /// <summary>
        /// ��������
        /// </summary>
        /// <returns></returns>
        [Column("PHI_LENGTH")]
        public decimal? phi_length { get; set; }
        /// <summary>
        /// ����
        /// </summary>
        /// <returns></returns>
        [Column("PHI_CLASSID")]
        public string phi_classId { get; set; }
        /// <summary>
        /// ����
        /// </summary>
        /// <returns></returns>
        [Column("PHI_CLASS")]
        public string phi_class { get; set; }
        /// <summary>
        /// ����Ա���
        /// </summary>
        /// <returns></returns>
        [Column("PHI_EMPNO")]
        public string phi_empNo { get; set; }
        /// <summary>
        /// ����Ա����
        /// </summary>
        /// <returns></returns>
        [Column("PHI_NAME")]
        public string phi_name { get; set; }
        /// <summary>
        /// ����Ա���
        /// </summary>
        /// <returns></returns>
        [Column("PHI_EMPNO2")]
        public string phi_empNo2 { get; set; }
        /// <summary>
        /// ����Ա����
        /// </summary>
        /// <returns></returns>
        [Column("PHI_NAME2")]
        public string phi_name2 { get; set; }
        /// <summary>
        /// ����Ա���
        /// </summary>
        /// <returns></returns>
        [Column("PHI_EMPNO3")]
        public string phi_empNo3 { get; set; }
        /// <summary>
        /// ����Ա����
        /// </summary>
        /// <returns></returns>
        [Column("PHI_NAME3")]
        public string phi_name3 { get; set; }
        /// <summary>
        /// ��ͷ����
        /// </summary>
        /// <returns></returns>
        [Column("PHI_WEIGHT")]
        public decimal? phi_weight { get; set; }
        /// <summary>
        /// ��˿����
        /// </summary>
        /// <returns></returns>
        [Column("PHI_WEIGHT_WASTE")]
        public decimal? phi_weight_waste { get; set; }
        /// <summary>
        /// ��������
        /// </summary>
        /// <returns></returns>
        [Column("PHI_MACHINEID_WARP")]
        public string phi_machineID_warp { get; set; }
        /// <summary>
        /// ������
        /// </summary>
        /// <returns></returns>
        [Column("PHI_MACHINENAME_WARP")]
        public string phi_machineName_warp { get; set; }
        /// <summary>
        /// ��λ��
        /// </summary>
        /// <returns></returns>
        [Column("PHI_NO_POS")]
        public string phi_no_pos { get; set; }
        /// <summary>
        /// ��λ����
        /// </summary>
        /// <returns></returns>
        [Column("PHI_NAME_POS")]
        public string phi_name_pos { get; set; }
        /// <summary>
        /// ��ע
        /// </summary>
        /// <returns></returns>
        [Column("PHI_REMARKS")]
        public string phi_remarks { get; set; }
        /// <summary>
        /// ��λ��
        /// </summary>
        /// <returns></returns>
        [Column("PHI_STATUS")]
        public string phi_status { get; set; }
        /// <summary>
        /// �쳣ԭ��
        /// </summary>
        /// <returns></returns>
        [Column("PHI_ERRINFO")]
        public string phi_errinfo { get; set; }
        /// <summary>
        /// ��ͷID
        /// </summary>
        /// <returns></returns>
        [Column("PHI_TASKNUMNEXT")]
        public string phi_taskNumNext { get; set; }
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
            this.phi_Num = Guid.NewGuid().ToString();
                                            }
        /// <summary>
        /// �༭����
        /// </summary>
        /// <param name="keyValue"></param>
        public override void Modify(string keyValue)
        {
            this.phi_Num = keyValue;
                                            }
        #endregion
    }
}