using System;
using System.Collections.Generic;
using System.Text;
using IHIS.CloudConnector.DataAccess.Entities;

namespace IHIS.CloudConnector.DataAccess
{
    public interface IDrugDosageStandardDao : IDao
    {
        bool TableExists(string tableName);

        int Insert(DrugDosageStandard drug);

        int Truncate();

        int Insert(List<DrugDosageStandard> lst, bool isTemTable);

        int Truncate(bool isTemTable);

        int CopyData();
    }
}
