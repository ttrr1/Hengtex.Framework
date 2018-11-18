using Hengtex.Application.Entity.MessageManage;
using Hengtex.Application.IService.MessageManage;
using Hengtex.Application.Service.MessageManage;
using System.Collections.Generic;

namespace Hengtex.Application.Busines.MessageManage
{
    /// <summary>
    /// 版 本 V6.1
    /// Copyright (c) 2012-2017 恒泰纺织
    /// 创建人：陈彬彬
    /// 日 期：2015.11.25 16:12
    /// 描 述：用户管理
    /// </summary>
    public class IMUserBLL
    {
        private IMsgUserService service = new IMUserService();
        /// <summary>
        /// 用户列表
        /// </summary>
        /// <returns></returns>
        public IEnumerable<IMUserModel> GetList(string OrganizeId)
        {
            return service.GetList(OrganizeId);
        }
    }
}
