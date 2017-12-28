using System;
using System.Collections.Generic;
using System.Text;
using IHIS.CloudConnector.DataAccess.Entities;

namespace IHIS.CloudConnector.DataAccess
{
    public interface IDrugKinkiDiseaseDao : IDao
    {
        bool TableExists(string tableName);

        int Insert(DrugKinkiDisease drug);

        int Insert(List<DrugKinkiDisease> lst, bool isTemTable);

        int Truncate();

        int Truncate(bool isTemTable);

        int CopyData();
    }
}
