namespace Hengtex.Application.Mapping.AppManage
{
    using Hengtex.Application.Entity.AppManage;
    using System;
    using System.Data.Entity.ModelConfiguration;

    public class App_ProjectMap : EntityTypeConfiguration<App_ProjectEntity>
    {
        public App_ProjectMap()
        {
            base.ToTable("App_Project");
            base.HasKey<string>(t => t.F_Id);
        }
    }
}

