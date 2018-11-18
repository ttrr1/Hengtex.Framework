namespace Hengtex.Application.Busines.AppManage
{
    using Hengtex.Application.Entity.AppManage;
    using Hengtex.Application.IService.AppManage;
    using Hengtex.Application.Service.AppManage;
    using System;
    using System.Collections.Generic;

    public class App_ProjectBLL
    {
        private App_ProjectIService service = new App_ProjectService();

        public App_ProjectEntity GetEntity(string keyValue)
        {
            return this.service.GetEntity(keyValue);
        }

        public IEnumerable<App_ProjectEntity> GetList(string queryJson)
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

        public void SaveForm(string keyValue, App_ProjectEntity entity, List<App_TemplatesEntity> entryList)
        {
            try
            {
                this.service.SaveForm(keyValue, entity, entryList);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}

