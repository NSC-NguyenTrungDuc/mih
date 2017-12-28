package nta.med.data.dao.medi.nur;

import java.util.List;

import nta.med.data.model.ihis.nuri.NUR9001U00grdNur9001Info;

/**
 * @author dainguyen.
 */
public interface Nur9001RepositoryCustom {

	public List<NUR9001U00grdNur9001Info> getNUR9001U00grdNur9001Info(String hospCode, String fromDate, String toDate, String bunho, Double fkinp1001, Integer startNum, Integer offset);

	public String getNUR9001U00Nur9001dataCheck(String hospCode, Double pknur9001);
}

