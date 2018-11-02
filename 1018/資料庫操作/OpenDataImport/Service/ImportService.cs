using OpenDataImport.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using System.Text;

namespace OpenDataImport.Service
{
    public class EFImportService
    {
        private Repository.OpenDataRepository _repository;
        public EFImportService()
        {
            _repository = new Repository.OpenDataRepository();

        }
        public List<OpenData> FindOpenDataFromXml()
        {
            List<OpenData> result = new List<OpenData>();

            string baseDir = Directory.GetCurrentDirectory();


            var xml = XElement.Load(System.IO.Path.Combine(baseDir, "App_Data/datagovtw_dataset_20181005.xml"));


            //XNamespace gml = @"http://www.opengis.net/gml/3.2";
            //XNamespace twed = @"http://twed.wra.gov.tw/twedml/opendata";
            var nodes = xml.Descendants("node").ToList();


            result = nodes
                .Where(x => !x.IsEmpty).ToList()
                .Select(node =>
                {
                    OpenData item = new OpenData();
                    item.id = int.Parse(getValue(node, "id"));
                    item.服務分類 = getValue(node, "服務分類");
                    item.資料集名稱 = getValue(node, "資料集名稱");                    
                    item.主要欄位說明 = getValue(node, "主要欄位說明");
                    return item;
                }).ToList();
            return result;

        }


        public List<OpenData> FindOpenDataFromDb(string name)
        {
            return _repository.SelectAll(name);



        }
        public void ImportToDb(List<OpenData> openDatas) {
            Repository.OpenDataRepository Repository = new Repository.OpenDataRepository();
            openDatas.ForEach(item =>
            {
                Repository.Insert(item);
            });
        }
        private  string getValue(XElement node, string propertyName)
        {
            return node.Element(propertyName)?.Value?.Trim();

        }

    }
}
