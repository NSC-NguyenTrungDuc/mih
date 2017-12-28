using System;
using System.Collections.Generic;
using System.Text;
using IHIS.CloudConnector.DataAccess.Entities;
using System.Data;

namespace IHIS.CloudConnector.DataAccess
{
    public interface IDrugInteractionDao : IDao
    {
        bool TableExists(string tableName);

        int Insert(DrugInteraction drug);

        int Truncate();

        int Insert(List<DrugInteraction> lst, bool isTemTable);

        int Truncate(bool isTemTable);

        int CopyData();

        DataTable CheckInteraction(DataTable grdOrderOld, DataTable grdOrderNew);
    }
}
