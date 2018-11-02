using OpenDataImport.Database;
using System;
using System.Collections.Generic;
using System.Text;
using OpenDataImport.Models;
using System.Linq;

namespace OpenDataImport.Repository
{
    class EFOpenDataRepository
    {

        private OpenDataDbContext openDataDbCotext { get; set; }

        public EFOpenDataRepository() {
            openDataDbCotext = new OpenDataDbContext();
        }

        public List<OpenData> SelectAll(string name) {
            var result = new List<OpenData>();
            var query = openDataDbCotext.OpenData.AsEnumerable();
            if (!string.IsNullOrEmpty(name))
            {
                query = query.Where(x => x.服務分類 == name);


            }
            return query.ToList();

        }

        public void Insert(OpenData item) {
            openDataDbCotext.OpenData.Add(item);
            openDataDbCotext.SaveChanges();

        }

        public void Update(OpenData item) {
            var exist = openDataDbCotext.OpenData.Where(x => x.id == item.id).SingleOrDefault();
            if (exist == null)
                return;
            exist.主要欄位說明 = item.主要欄位說明;
            exist.服務分類 = item.服務分類;
            exist.資料集名稱 = item.資料集名稱;
            openDataDbCotext.SaveChanges();


        }
    }
}
