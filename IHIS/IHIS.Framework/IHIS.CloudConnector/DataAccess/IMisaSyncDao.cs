using System;
using System.Collections.Generic;
using System.Text;
using IHIS.CloudConnector.DataAccess.Entities;

namespace IHIS.CloudConnector.DataAccess
{
    public interface IMisaSyncDao :IDao
    {
        List<PatientMisa> GetPatientMisa(DateTime currentDate);

        List<BookingMisa> GetBookingMisa(DateTime currentDate);

    }
}
