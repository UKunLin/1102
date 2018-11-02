using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using OpenDataImport.Models;


namespace OpenDataImport.Database
{
    class OpenDataDbContext:DbContext
    {

        public string ConnectionString {
            get
            {
                return @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\yukun\OneDrive\桌面\軟體工程\1026work\1018\資料庫操作\OpenDataImport\App_Data\Database.mdf;Integrated Security=True";
                //return @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + YC.Shared.Utils.GetDataPath() + @"OpenData.mdf;Integrated Security=True";
                //return @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename="+ Directory.GetCurrentDirectory() + @"\App_Data\nodeDB.mdf;Integrated Security=True";
            }
        }

        public DbSet<OpenData> OpenData { get; set; }

        public OpenDataDbContext() : base(){ }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            optionsBuilder.UseSqlServer(ConnectionString);
            base.OnConfiguring(optionsBuilder);


        }


        

    }
}
