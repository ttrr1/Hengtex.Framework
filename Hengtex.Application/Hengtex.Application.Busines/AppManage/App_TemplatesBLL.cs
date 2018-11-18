namespace Hengtex.Application.Busines.AppManage
{
    using Hengtex.Application.Entity.AppManage;
    using Hengtex.Application.IService.AppManage;
    using Hengtex.Application.Service.AppManage;
    using System;
    using System.Collections.Generic;

    public class App_TemplatesBLL
    {
        private App_TemplatesIService service = new App_TemplatesService();

        public App_TemplatesEntity GetEntity(string keyValue)
        {
            return this.service.GetEntity(keyValue);
        }

        public IEnumerable<App_TemplatesEntity> GetList(string queryJson)
        {
            return this.service.GetList(queryJson);
        }

        public void RemoveForm(string keyValue)
        {
            try
            {
                this.service.RemoveForm(keyValue);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void SaveForm(string keyValue, App_TemplatesEntity entity)
        {
            try
            {
                this.service.SaveForm(keyValue, entity);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}

