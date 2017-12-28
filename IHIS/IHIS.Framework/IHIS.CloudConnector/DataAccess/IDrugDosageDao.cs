using System;
using System.Collections.Generic;
using System.Text;
using IHIS.CloudConnector.DataAccess.Entities;
using System.Data;

namespace IHIS.CloudConnector.DataAccess
{
    public interface IDrugDosageDao : IDao
    {
        bool TableExists(string tableName);

        int Insert(DrugDosage drug);

        int Truncate();

        int Insert(List<DrugDosage> lst, bool isTemTable);

        int Truncate(bool isTemTable);

        int CopyData();

        DataTable CheckDosage(DataTable grdOrder);
    }
}
