using System;
using System.Collections.Generic;
using System.Text;
using IHIS.CloudConnector.DataAccess.Entities;

namespace IHIS.CloudConnector.DataAccess
{
    public interface IDrugDosageNormalDao : IDao
    {
        bool TableExists(string tableName);

        int Insert(DrugDosageNormal drug);

        int Truncate();

        int Insert(List<DrugDosageNormal> lst, bool isTemTable);

        int Truncate(bool isTemTable);

        int CopyData();
    }
}
