package nta.med.data.dao.medi.nur;

import java.util.Date;
import java.util.List;

import nta.med.data.model.ihis.nuri.NUR4005U01GrdNUR4005Info;

/**
 * @author dainguyen.
 */
public interface Nur4005RepositoryCustom {

	public String callFnNurPlanEndDate(String hospCode, Double fknur4001, Date fDate);

	public List<NUR4005U01GrdNUR4005Info> getNUR4005U01GrdNUR4005Info(String hospCode, Double fknur4001);
}
