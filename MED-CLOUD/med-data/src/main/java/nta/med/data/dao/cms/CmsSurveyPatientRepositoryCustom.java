package nta.med.data.dao.cms;

import java.math.BigDecimal;
import java.math.BigInteger;
import java.util.Date;
import java.util.List;

import nta.med.data.model.cms.CmsListSurveyInfo;
import nta.med.data.model.cms.CmsSurveyPatientInfo;
import nta.med.data.model.cms.CmsSurveyPatientSummary;
import nta.med.data.model.cms.CmsSurveyRelatedInfo;
import nta.med.data.model.cms.CmsSurveyStatusInfo;


public interface CmsSurveyPatientRepositoryCustom {
	//cms11
	public List<CmsSurveyPatientSummary> findAnsweredAndWaitingByHospCode(String hospCode,Integer type,Integer startIndex, Integer pageSize, boolean isPaging);
	//cms12
	public List<CmsSurveyPatientInfo> getListSurveyPatientInfo(String hospCode, String departmentCode, String search,BigDecimal statusFlg, Integer startIndex, Integer pageSize, String column, String dir, boolean isPaging);
	//cms 13
	public List<CmsSurveyPatientSummary> findAnsweredAndWaitingByHospCode(String hospCode);

	public List<CmsSurveyRelatedInfo> getSurveypatientRelated(String patientCode);
	
	//cms 14
	public List<CmsSurveyStatusInfo> getListSurveybyDepartmentCode(String hospCode, String departmentCode,Integer startIndex, Integer pageSize);

	//cms 10
	public List<CmsListSurveyInfo> getListSurveyPatient(String hospCode, String departmentCode, BigDecimal statusFlg, String patient, String title, Integer startIndex, Integer pageSize, String column, String dir, boolean isPaging, Integer searchType, Date fromDate, Date toDate);
	
	public int getTotalSurveybyDepartmentCode(String hospCode, String departmentCode);
	
	public boolean isExistedSurveyRelated(BigInteger surveyId);
}
