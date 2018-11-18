using Hengtex.Data.Repository;
using Hengtex.Util;
using Hengtex.Util.WebControl;
using Hengtex.Util.Extension;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
using Hengtex.Data;
using Hengtex.Application.Entity.ErpManage;
using Hengtex.Application.IService.ErpManage;
using System;

namespace Hengtex.Application.Service.ErpManage
{
    /// <summary>
    /// 版 本
    /// Copyright (c) 2012-2017 恒泰纺织
    /// 创建人：熊斌
    /// 日 期：2015.11.4 14:31
    /// 描 述：字典表
    /// </summary>
    public class tb_CommonDataDictService : RepositoryFactory<tb_CommonDataDictEntity>, Itb_CommonDataDictService
    {
        public IEnumerable<tb_CommonDataDictEntity> GetList(int dataType)
        {
            string sql = "SELECT * FROM tb_CommonDataDict WHERE 1=1 AND DataType="+dataType +" order by DataType,DataCode";
            return this.ERPRepository().FindList(sql);

        }
    }
}