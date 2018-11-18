using System;
using System.ComponentModel.DataAnnotations.Schema;
using Hengtex.Application.Code;

namespace Hengtex.Application.Entity.ErpManage
{
    /// <summary>
    /// �� ��
    /// Copyright (c) 2012-2017 ��̩��֯
    /// �� ������������Ա
    /// �� �ڣ�2018-02-05 18:06
    /// �� ����doc_con_pan_head
    /// </summary>
    public class doc_con_pan_headEntity : BaseEntity
    {
        #region ʵ���Ա
        /// <summary>
        /// ID
        /// </summary>
        /// <returns></returns>
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? dcph_id { get; set; }
        /// <summary>
        /// ��ͷ����
        /// </summary>
        /// <returns></returns>
        public string dcph_type { get; set; }
        /// <summary>
        /// ��ͷ���
        /// </summary>
        /// <returns></returns>
        public string dcph_num { get; set; }
        /// <summary>
        /// �������ű���
        /// </summary>
        /// <returns></returns>
        public string dcph_departNum { get; set; }
        /// <summary>
        /// ������������
        /// </summary>
        /// <returns></returns>
        public string dcph_departName { get; set; }
        /// <summary>
        /// ��ͷ��
        /// </summary>
        /// <returns></returns>
        public string dcph_no { get; set; }
        /// <summary>
        /// ����
        /// </summary>
        /// <returns></returns>
        public decimal? dcph_weight { get; set; }
        /// <summary>
        /// ���Ƿ�
        /// </summary>
        /// <returns></returns>
        public string dcph_symbol { get; set; }
        /// <summary>
        /// ����ʱ��
        /// </summary>
        /// <returns></returns>
        public DateTime? dcph_dateIn { get; set; }
        /// <summary>
        /// ״̬
        /// </summary>
        /// <returns></returns>
        public string dcph_status { get; set; }
        /// <summary>
        /// �ڳ�λ��
        /// </summary>
        /// <returns></returns>
        public string dcph_position { get; set; }
        /// <summary>
        /// �ڳ�λ��
        /// </summary>
        /// <returns></returns>
        public string dcph_positionName { get; set; }
        /// <summary>
        /// �ڳ�λ��
        /// </summary>
        /// <returns></returns>
        public string dcph_positionNew { get; set; }
        /// <summary>
        /// �ڳ�λ��
        /// </summary>
        /// <returns></returns>
        public string dcph_positionNameNew { get; set; }
        /// <summary>
        /// �ڳ�λ��
        /// </summary>
        /// <returns></returns>
        public string dcph_batch { get; set; }
        /// <summary>
        /// �¹����̨��
        /// </summary>
        /// <returns></returns>
        public string dcph_fcltNumWarp { get; set; }
        /// <summary>
        /// �¹����̨����
        /// </summary>
        /// <returns></returns>
        public string dcph_fcltNameWarp { get; set; }
        /// <summary>
        /// �¹����̨��
        /// </summary>
        /// <returns></returns>
        public string dcph_fcltNumNext { get; set; }
        /// <summary>
        /// �¹����̨����
        /// </summary>
        /// <returns></returns>
        public string dcph_fcltNameNext { get; set; }
        /// <summary>
        /// ����
        /// </summary>
        /// <returns></returns>
        public string dcph_taskNum { get; set; }
        /// <summary>
        /// ��ע
        /// </summary>
        /// <returns></returns>
        public string dcph_remark { get; set; }
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
            //this.dcph_num = Guid.NewGuid().ToString();
                                            }
        /// <summary>
        /// �༭����
        /// </summary>
        /// <param name="keyValue"></param>
        public override void Modify(string keyValue)
        {
            this.dcph_num = keyValue;
                                            }
        #endregion
    }
}