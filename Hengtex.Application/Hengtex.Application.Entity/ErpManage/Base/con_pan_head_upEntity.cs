using System;
using System.ComponentModel.DataAnnotations.Schema;
using Hengtex.Application.Code;
using System.Collections.Generic;

namespace Hengtex.Application.Entity.ErpManage
{
    /// <summary>
    /// �� ��
    /// Copyright (c) 2012-2017 ��̩��֯
    /// �� ������������Ա
    /// �� �ڣ�2018-05-22 15:57
    /// �� ����con_pan_head_up
    /// </summary>
    public class con_pan_head_upEntity : BaseEntity
    {
        #region ʵ���Ա
        /// <summary>
        /// ID
        /// </summary>
        /// <returns></returns>
        [Column("PHU_ID")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? phu_id { get; set; }
        /// <summary>
        /// ���ݺ�
        /// </summary>
        /// <returns></returns>
        [Column("PHU_NUM")]
        public string phu_num { get; set; }
        /// <summary>
        /// �Ǽ�ʱ��
        /// </summary>
        /// <returns></returns>
        [Column("PHU_DATETIME")]
        public DateTime? phu_datetime { get; set; }
        /// <summary>
        /// ��ͷID
        /// </summary>
        /// <returns></returns>
        [Column("PHU_PANNUM")]
        public string phu_panNum { get; set; }
        /// <summary>
        /// ��ͷ��
        /// </summary>
        /// <returns></returns>
        [Column("PHU_PANNO")]
        public string phu_panno { get; set; }
        /// <summary>
        /// ��ͷ����
        /// </summary>
        /// <returns></returns>
        [Column("PHU_TYPE")]
        public string phu_type { get; set; }
        /// <summary>
        /// �ƻ���ϸ���
        /// </summary>
        /// <returns></returns>
        [Column("PHU_PLANDETAIL")]
        public string phu_planDetail { get; set; }
        /// <summary>
        /// ����ID
        /// </summary>
        /// <returns></returns>
        [Column("PHU_PROCEDUREID")]
        public string phu_procedureID { get; set; }
        /// <summary>
        /// ��������
        /// </summary>
        /// <returns></returns>
        [Column("PHU_PROCEDURENAME")]
        public string phu_procedureName { get; set; }
        /// <summary>
        /// ����
        /// </summary>
        /// <returns></returns>
        [Column("PHU_BATCH")]
        public string phu_batch { get; set; }
        /// <summary>
        /// Ʒ��
        /// </summary>
        /// <returns></returns>
        [Column("PHU_PINHAO")]
        public string phu_pinhao { get; set; }
        /// <summary>
        /// ��ɫ
        /// </summary>
        /// <returns></returns>
        [Column("PHU_COLOR")]
        public string phu_color { get; set; }
        /// <summary>
        /// ����
        /// </summary>
        /// <returns></returns>
        [Column("PHU_LENGTHWARP")]
        public decimal? phu_lengthWarp { get; set; }
        /// <summary>
        /// �ͻ�����
        /// </summary>
        /// <returns></returns>
        [Column("PHU_CUSTNUM")]
        public string phu_custNum { get; set; }
        /// <summary>
        /// �ͻ�����
        /// </summary>
        /// <returns></returns>
        [Column("PHU_CUSTNAME")]
        public string phu_custName { get; set; }
        /// <summary>
        /// ����
        /// </summary>
        /// <returns></returns>
        [Column("PHU_COUNT")]
        public decimal? phu_count { get; set; }
        /// <summary>
        /// ��ͷ����
        /// </summary>
        /// <returns></returns>
        [Column("PHU_COUNT_PAN")]
        public int? phu_count_pan { get; set; }
        /// <summary>
        /// ����
        /// </summary>
        /// <returns></returns>
        [Column("PHU_CLASSID")]
        public string phu_classId { get; set; }
        /// <summary>
        /// ����
        /// </summary>
        /// <returns></returns>
        [Column("PHU_CLASS")]
        public string phu_class { get; set; }
        /// <summary>
        /// ����Ա���
        /// </summary>
        /// <returns></returns>
        [Column("PHU_EMPNO")]
        public string phu_empNo { get; set; }
        /// <summary>
        /// ����Ա����
        /// </summary>
        /// <returns></returns>
        [Column("PHU_NAME")]
        public string phu_name { get; set; }
        /// <summary>
        /// ��ͷ����
        /// </summary>
        /// <returns></returns>
        [Column("PHU_WEIGHT")]
        public decimal? phu_weight { get; set; }
        /// <summary>
        /// ��ͷʣ��
        /// </summary>
        /// <returns></returns>
        [Column("PHU_WEIGHT_REMAIN")]
        public decimal? phu_weight_remain { get; set; }
        /// <summary>
        /// ֯������
        /// </summary>
        /// <returns></returns>
        [Column("PHU_MACHINEID_CON")]
        public string phu_machineID_con { get; set; }
        /// <summary>
        /// ֯������
        /// </summary>
        /// <returns></returns>
        [Column("PHU_MACHINENAME_CON")]
        public string phu_machineName_con { get; set; }
        /// <summary>
        /// ��λ��
        /// </summary>
        /// <returns></returns>
        [Column("PHU_NO_POS")]
        public string phu_no_pos { get; set; }
        /// <summary>
        /// ��λ����
        /// </summary>
        /// <returns></returns>
        [Column("PHU_NAME_POS")]
        public string phu_name_pos { get; set; }
        /// <summary>
        /// ��ע
        /// </summary>
        /// <returns></returns>
        [Column("PHU_REMARKS")]
        public string phu_remarks { get; set; }
        /// <summary>
        /// ��λ��
        /// </summary>
        /// <returns></returns>
        [Column("PHU_STATUS")]
        public string phu_status { get; set; }
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

        /// <summary>
        /// ��ϸ����
        /// </summary>
        /// <returns></returns>
        //[Column("emps")]
        [NotMapped]
        public List<con_pan_head_empsEntity> emps { get; set; }

        #endregion

        #region ��չ����
        /// <summary>
        /// ��������
        /// </summary>
        public override void Create()
        {
           // this.phu_num = DateTime.Now.ToString("MM-dd-HH-MM_sss");
            //phu_id = 0;
        }
        /// <summary>
        /// �༭����
        /// </summary>
        /// <param name="keyValue"></param>
        public override void Modify(string keyValue)
        {
            this.phu_num = keyValue;
            //this.phu_id = int.Parse(keyValue);
                                            }
        #endregion
    }
}