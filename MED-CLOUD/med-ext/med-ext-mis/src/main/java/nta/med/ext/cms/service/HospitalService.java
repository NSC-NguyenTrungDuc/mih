package nta.med.ext.cms.service;

import java.util.List;

import nta.med.ext.cms.model.KcckUserModel;
import nta.med.ext.cms.model.cms.DashboardModel;
import nta.med.ext.cms.model.cms.HospitalInfoModel;
import nta.med.ext.cms.model.cms.LoginResponseModel;
import nta.med.ext.cms.model.cms.PatientSurveyModel;
import nta.med.ext.cms.model.cms.PhrAccountModel;

public interface HospitalService {

	public List<HospitalInfoModel> getListHospitalModel(String hospCode);
	
	public DashboardModel findAnsweredAndWaitingByHospCode(String hospCode, Integer type,Integer startIndex, Integer pageSize, boolean isPaging);

	public List<PatientSurveyModel> getListSurveyPatient(String hospCode, PatientSurveyModel model, Integer startIndex, Integer pageSize, String column, String dir, boolean isPaging);
	
	public PhrAccountModel getPhrAccountModel(Long surveyPatientId, String hospCode);

	public LoginResponseModel checkLogin(KcckUserModel model) throws Exception;
	
	public HospitalInfoModel searchHospitalByHospCode(String hospCode);
}
