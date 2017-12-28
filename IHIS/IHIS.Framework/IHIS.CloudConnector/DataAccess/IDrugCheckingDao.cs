using System;
using System.Collections.Generic;
using System.Text;
using IHIS.CloudConnector.DataAccess.Entities;

namespace IHIS.CloudConnector.DataAccess
{
    public interface IDrugCheckingDao : IDao
    {
        bool TableExists(string tableName);

        int Insert(DrugChecking drug);

        int Insert(List<DrugChecking> lst, bool isTemTable);

        int Truncate(bool isTemTable);

        int Truncate();

        int CopyData();
    }
}
