using OpenDataImport.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OpenDataImport.Service
{
    class EFImpotService
    {

        public List<OpenData>FindOpenDataFromDb(string name)
        {
            var EFrepository = new EFRepository();
            return EFrepository.SelectALL(name);

        }

    }
}
