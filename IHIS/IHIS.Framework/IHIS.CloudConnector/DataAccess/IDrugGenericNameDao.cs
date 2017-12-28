using System;
using System.Collections.Generic;
using System.Text;
using IHIS.CloudConnector.DataAccess.Entities;

namespace IHIS.CloudConnector.DataAccess
{
    public interface IDrugGenericNameDao : IDao
    {
        bool TableExists(string tableName);

        int Insert(DrugGenericName drug);

        int Truncate();

        int Insert(List<DrugGenericName> lst, bool isTemTable);

        int Truncate(bool isTemTable);

        int CopyData();
    }
}
