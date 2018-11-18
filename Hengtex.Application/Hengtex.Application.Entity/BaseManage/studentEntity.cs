using System;
using Hengtex.Application.Code;

namespace Hengtex.Application.Entity.BaseManage
{
    /// <summary>
    /// �� ��
    /// Copyright (c) 2012-2017 ��̩��֯
    /// �� ������������Ա
    /// �� �ڣ�2017-03-01 09:20
    /// �� ����ѧ����
    /// </summary>
    public class studentEntity : BaseEntity
    {
        #region ʵ���Ա
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string id { get; set; }
        /// <summary>
        /// ����
        /// </summary>
        /// <returns></returns>
        public string name { get; set; }
        /// <summary>
        /// �Ա�
        /// </summary>
        /// <returns></returns>
        public string sex { get; set; }
        #endregion

        #region ��չ����
        /// <summary>
        /// ��������
        /// </summary>
        public override void Create()
        {
            this.id = Guid.NewGuid().ToString();
                                            }
        /// <summary>
        /// �༭����
        /// </summary>
        /// <param name="keyValue"></param>
        public override void Modify(string keyValue)
        {
            this.id = keyValue;
                                            }
        #endregion
    }
}