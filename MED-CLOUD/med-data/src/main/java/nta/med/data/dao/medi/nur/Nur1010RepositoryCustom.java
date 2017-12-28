package nta.med.data.dao.medi.nur;

import java.util.List;

import nta.med.data.model.ihis.nuri.NUR1010Q00fnLoadIlsuInfo;
import nta.med.data.model.ihis.nuri.NUR1010Q00layPatientInfo;
import nta.med.data.model.ihis.nuri.NUR1010U00grdNur1010Info;

/**
 * @author dainguyen.
 */
public interface Nur1010RepositoryCustom {

	public String getNUR6011U01GetNurseInfoUser(String hospCode, Double fkinp1001, String jukyongDate);

	public List<NUR1010Q00layPatientInfo> getNUR1010Q00layPatientInfo(String hospCode, String language, String hoDong);

	public List<NUR1010Q00fnLoadIlsuInfo> getNUR1010Q00fnLoadIlsuInfo(String hospCode, String hoDong);

	public List<NUR1010U00grdNur1010Info> getNUR1010U00grdNur1010Info(String hospCode, Double fkinp1001, Integer startNum, Integer offset);

	public String getNUR1010U00grdNurCheck(String hospCode, String bunho, Double fkinp1001, String jukyongDate);

	public String getNUR1010U00LoadUserName(String hospCode, String userId);

	public String getNUR1001U00BasicQuery1(String hospCode, String jukyongDate, Double fkinp1001);
}

