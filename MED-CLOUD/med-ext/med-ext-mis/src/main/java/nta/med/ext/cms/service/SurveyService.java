package nta.med.ext.cms.service;

import java.math.BigInteger;
import java.util.List;

import org.springframework.data.repository.query.Param;

import nta.med.core.domain.cms.CmsSurveyPatient;
import nta.med.ext.cms.model.cms.CommonDelModel;
import nta.med.ext.cms.model.cms.PatientBasicInfoModel;
import nta.med.ext.cms.model.cms.PatientSurveyInfoModel;
import nta.med.ext.cms.model.cms.PatientSurveyModel;
import nta.med.ext.cms.model.cms.PatientSurveyStore;
import nta.med.ext.cms.model.cms.QuestionDetailModel;
import nta.med.ext.cms.model.cms.QuestionModel;
import nta.med.ext.cms.model.cms.SurveyInfoModel;
import nta.med.ext.cms.model.cms.SurveyPatientStatusModel;
import nta.med.ext.cms.model.cms.SurveyStatusModel;
import nta.med.ext.support.proto.BookingModelProto;

/**
 * @author dainguyen.
 */
public interface SurveyService {

	/**
	 * getListCmsQuestion
	 * 
	 * @param hospCode
	 * @param model
	 * @param startIndex
	 * @param pageSize
	 * @return
	 */
	// public List<SurveyModel> findAllServery();
	public List<QuestionModel> getListCmsQuestion(String hospCode, QuestionModel model, Integer startIndex,
			Integer pageSize, String column, String dir, boolean isPaging);

	/**
	 * getCmsQuestionById
	 * 
	 * @param id
	 * @return
	 */
	public QuestionDetailModel getCmsQuestionById(Long id, String hospCode);

	/**
	 * insertQuestionDetail
	 * 
	 * @param model
	 * @return
	 */
	public boolean insertQuestionDetail(QuestionDetailModel model);

	// CMS 09
	public PatientSurveyInfoModel saveSurveyAnswer(PatientSurveyInfoModel model) throws Exception;

	public List<SurveyStatusModel> getListSurveybyDepartmentCode(String hospCode, String departmentCode,
			Integer startIndex, Integer pageSize);

	public SurveyInfoModel getSurveyById(Long id, String hospCode);

	public boolean createSurveyInfoModel(SurveyInfoModel model);

	public boolean updateSurveyInfoModel(SurveyInfoModel model, Long surveyId);

	public boolean deleteSurvey(BigInteger surveyId, String hospCode);

	/**
	 * deleteQuestionList
	 * 
	 * @param delModel
	 * @return
	 */
	public boolean deleteQuestionList(List<CommonDelModel> delModel, String hospCode);

	/**
	 * updateQuestionDetail
	 * 
	 * @param model
	 * @return
	 */
	public boolean updateQuestionDetail(QuestionDetailModel model);

	/**
	 * getPatientSurveyById
	 * 
	 * @param id
	 */
	public PatientSurveyStore getPatientSurveyByIdOrPatientCode(Long id, String hospCode, String patientCode) throws Exception;

	/**
	 * getListSurveyStatus
	 * 
	 * @param hospCode
	 * @return
	 */
	public List<SurveyPatientStatusModel> getListSurveyStatus(String hospCode);

	public List<PatientSurveyModel> getListSurveyPatient(String hospCode, PatientSurveyModel model, Integer startIndex,
			Integer pageSize, String column, String dir, boolean isPaging);

	public PatientSurveyModel getPatientSurveyToDoById(Long patientSurveyId, String hospCode) throws Exception;
	
	public PatientSurveyModel getPatientSurveyToDoByToken(String token) throws Exception;

	public boolean getSurveyByDepartmentCode();

	public Boolean setActiveSurvey(Long idSurvey, String hospCode);

	public int getTotalSurveybyDepartmentCode(String hospCode, String departmentCode);

	public boolean isExistedSurveyRelatedOrSurveyActive(BigInteger surveyId, String hospCode);
	
	public CmsSurveyPatient insertCmsSurveyPatient(int timeZone, String hospCode, BigInteger surveyId, String patientCode, String patientName, String departmentCode, String departmentName, String sysId, String patientPwd);
	
	public PatientBasicInfoModel getPatientFromKCCK(String hospCode, String patientCode);
	
	public CmsSurveyPatient findById(Long id, String hospCode);
	
	public boolean changeSurvey(BigInteger cmsSurveyId, Long id, String hospCode);
	
	public CmsSurveyPatient getSurveyPatientByToken(String token);
	
	public void createSurveyIfAbsence(BookingModelProto.BookingExamInfo bookingExam, String token);
}
