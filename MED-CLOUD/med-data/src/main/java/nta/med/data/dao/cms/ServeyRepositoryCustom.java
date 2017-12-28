package nta.med.data.dao.cms;

import java.util.List;

import nta.med.data.model.cms.CmsSurveyInfo;

/**
 * @author DEV-TiepNM
 */
public interface ServeyRepositoryCustom {
	public List<CmsSurveyInfo> getListSurveyPatient(String hospCode, String reserationDate, String departmentCode, String surveyStatus, String patientName, String title,Integer startIndex, Integer pageSize);
}
