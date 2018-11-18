using System;
using Hengtex.Application.Code;

namespace Hengtex.Application.Entity.SystemManage
{
    /// <summary>
    /// �� ��
    /// Copyright (c) 2012-2017 ��̩��֯
    /// �� ������������Ա
    /// �� �ڣ�2018-02-03 17:07
    /// �� ����tb_CommonDataDict
    /// </summary>
    public class tb_CommonDataDictEntity : BaseEntity
    {
        #region ʵ���Ա
        /// <summary>
        /// ISID
        /// </summary>
        /// <returns></returns>
        public int? ISID { get; set; }
        /// <summary>
        /// DataType
        /// </summary>
        /// <returns></returns>
        public int? DataType { get; set; }
        /// <summary>
        /// DataCode
        /// </summary>
        /// <returns></returns>
        public string DataCode { get; set; }
        /// <summary>
        /// NativeName
        /// </summary>
        /// <returns></returns>
        public string NativeName { get; set; }
        /// <summary>
        /// EnglishName
        /// </summary>
        /// <returns></returns>
        public string EnglishName { get; set; }
        /// <summary>
        /// CreationDate
        /// </summary>
        /// <returns></returns>
        public DateTime? CreationDate { get; set; }
        /// <summary>
        /// CreatedBy
        /// </summary>
        /// <returns></returns>
        public string CreatedBy { get; set; }
        /// <summary>
        /// LastUpdateDate
        /// </summary>
        /// <returns></returns>
        public DateTime? LastUpdateDate { get; set; }
        /// <summary>
        /// LastUpdatedBy
        /// </summary>
        /// <returns></returns>
        public string LastUpdatedBy { get; set; }
        #endregion

        #region ��չ����
        /// <summary>
        /// ��������
        /// </summary>
        public override void Create()
        {
            this.ISID = 0;
                                            }
        /// <summary>
        /// �༭����
        /// </summary>
        /// <param name="keyValue"></param>
        public override void Modify(string keyValue)
        {
            this.ISID = int.Parse(keyValue);
                                            }
        #endregion
    }
}