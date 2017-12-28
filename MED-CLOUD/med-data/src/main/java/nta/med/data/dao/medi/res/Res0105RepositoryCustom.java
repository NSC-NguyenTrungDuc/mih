package nta.med.data.dao.medi.res;

import java.util.List;

import nta.med.data.model.ihis.nuro.NuroRES1001U00DoctorReservationDateListItemInfo;

/**
 * @author dainguyen.
 */
public interface Res0105RepositoryCustom {
	public List<NuroRES1001U00DoctorReservationDateListItemInfo> getNuroRES1001U00DoctorReservationDateList (String hospitalCode, String doctorCode, String startDate, String endDate);
}

