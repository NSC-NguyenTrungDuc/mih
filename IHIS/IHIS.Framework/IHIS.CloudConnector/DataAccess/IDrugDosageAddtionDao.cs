using System;
using System.Collections.Generic;
using System.Text;
using IHIS.CloudConnector.DataAccess.Entities;

namespace IHIS.CloudConnector.DataAccess
{
    public interface IDrugDosageAddtionDao : IDao
    {
        bool TableExists(string tableName);

        int Insert(DrugDosageAddtion drug);

        int Truncate();

        int Insert(List<DrugDosageAddtion> lst, bool isTemTable);

        int Truncate(bool isTemTable);

        int CopyData();
    }
}
