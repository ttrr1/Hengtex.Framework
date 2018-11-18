﻿namespace Hengtex.Application.IService.AppManage
{
    using Hengtex.Application.Entity.AppManage;
    using System;
    using System.Collections.Generic;

    public interface App_ProjectIService
    {
        App_ProjectEntity GetEntity(string keyValue);
        IEnumerable<App_ProjectEntity> GetList(string queryJson);
        void RemoveForm(string keyValue);
        void SaveForm(string keyValue, App_ProjectEntity entity, List<App_TemplatesEntity> entryList);
    }
}

