using System;
using Hengtex.Application.Code;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hengtex.Application.Entity.ErpManage
{
    /// <summary>
    /// �� ��
    /// Copyright (c) 2012-2017 ��̩��֯
    /// �� ����lvh
    /// �� �ڣ�2018-02-10 10:17
    /// �� ����doc_con_pan_position
    /// </summary>
    public class doc_con_pan_positionEntity : BaseEntity
    {
        #region ʵ���Ա
        /// <summary>
        /// ID
        /// </summary>
        /// <returns></returns>
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? dcpp_id { get; set; }
        /// <summary>
        /// ��λ����
        /// </summary>
        /// <returns></returns>
        public string dcpp_kind { get; set; }
        /// <summary>
        /// ��λ����
        /// </summary>
        /// <returns></returns>
        public string dcpp_type { get; set; }
        /// <summary>
        /// ��λ���
        /// </summary>
        /// <returns></returns>
        public string dcpp_num { get; set; }
        /// <summary>
        /// ���ڲ��ű���
        /// </summary>
        /// <returns></returns>
        public string dcpp_departNum { get; set; }
        /// <summary>
        /// ���ڲ�������
        /// </summary>
        /// <returns></returns>
        public string dcpp_departName { get; set; }
        /// <summary>
        /// ��λ��
        /// </summary>
        /// <returns></returns>
        public string dcpp_no { get; set; }
        /// <summary>
        /// ��λ����
        /// </summary>
        /// <returns></returns>
        public string dcpp_name { get; set; }
        /// <summary>
        /// λ������
        /// </summary>
        /// <returns></returns>
        public string dcpp_position { get; set; }
        /// <summary>
        /// ���Ƿ�
        /// </summary>
        /// <returns></returns>
        public string dcpp_symbol { get; set; }
        /// <summary>
        /// ״̬
        /// </summary>
        /// <returns></returns>
        public string dcpp_status { get; set; }
        /// <summary>
        /// ��ע
        /// </summary>
        /// <returns></returns>
        public string dcpp_remark { get; set; }
        /// <summary>
        /// ����ʱ��
        /// </summary>
        /// <returns></returns>
        public DateTime? CreationDate { get; set; }
        /// <summary>
        /// ������
        /// </summary>
        /// <returns></returns>
        public string CreatedBy { get; set; }
        /// <summary>
        /// ����޸�ʱ��
        /// </summary>
        /// <returns></returns>
        public DateTime? LastUpdateDate { get; set; }
        /// <summary>
        /// ����޸���
        /// </summary>
        /// <returns></returns>
        public string LastUpdatedBy { get; set; }
        /// <summary>
        /// �����
        /// </summary>
        /// <returns></returns>
        public string AppUser { get; set; }
        /// <summary>
        /// ���ʱ��
        /// </summary>
        /// <returns></returns>
        public DateTime? AppDate { get; set; }
        /// <summary>
        /// ��˱�־
        /// </summary>
        /// <returns></returns>
        public bool? FlagApp { get; set; }
        /// <summary>
        /// ɾ����
        /// </summary>
        /// <returns></returns>
        public string DelMan { get; set; }
        /// <summary>
        /// ɾ��ʱ��
        /// </summary>
        /// <returns></returns>
        public DateTime? DelDate { get; set; }
        /// <summary>
        /// ɾ����־
        /// </summary>
        /// <returns></returns>
        public bool? FlagDelete { get; set; }
        #endregion

        #region ��չ����
        /// <summary>
        /// ��������
        /// </summary>
        public override void Create()
        {
            this.dcpp_num = Guid.NewGuid().ToString();
                                            }
        /// <summary>
        /// �༭����
        /// </summary>
        /// <param name="keyValue"></param>
        public override void Modify(string keyValue)
        {
            this.dcpp_num = keyValue;
                                            }
        #endregion
    }
}