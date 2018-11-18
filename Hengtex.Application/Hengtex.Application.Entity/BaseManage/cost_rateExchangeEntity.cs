using System;
using Hengtex.Application.Code;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hengtex.Application.Entity.BaseManage
{
    /// <summary>
    /// �� ��
    /// Copyright (c) 2012-2017 ��̩��֯
    /// �� ������������Ա
    /// �� �ڣ�2018-01-19 14:56
    /// �� ����cost_rateExchange
    /// </summary>
    public class cost_rateExchangeEntity : BaseEntity
    {
        #region ʵ���Ա
        /// <summary>
        /// ID
        /// </summary>
        /// <returns></returns>
         [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? re_id { get; set; }
        /// <summary>
        /// ���ڱ�־
        /// </summary>
        /// <returns></returns>
        public bool? re_flagExport { get; set; }
        /// <summary>
        /// ����
        /// </summary>
        /// <returns></returns>
        public string re_currency { get; set; }
        /// <summary>
        /// ����
        /// </summary>
        /// <returns></returns>
        public decimal? re_rate { get; set; }
        /// <summary>
        /// ��ע
        /// </summary>
        /// <returns></returns>
        public string re_remarks { get; set; }
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
            this.re_id =0;
                                            }
        /// <summary>
        /// �༭����
        /// </summary>
        /// <param name="keyValue"></param>
        public override void Modify(string keyValue)
        {
            this.re_id = int.Parse(keyValue);
                                            }
        #endregion
    }
}