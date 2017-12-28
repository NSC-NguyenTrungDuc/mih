package nta.med.ext.cms.service.impl;

import com.fasterxml.jackson.dataformat.xml.XmlMapper;
import com.google.common.collect.Lists;
import nta.med.common.glossary.Lifecyclet;
import nta.med.common.util.Collections;
import nta.med.core.common.async.AsyncExecutor;
import nta.med.core.domain.cms.*;
import nta.med.core.glossary.Language;
import nta.med.core.utils.BeanUtils;
import nta.med.core.utils.CommonUtils;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.cms.*;
import nta.med.data.model.cms.*;
import nta.med.ext.cms.config.Configuration;
import nta.med.ext.cms.glossary.Message;
import nta.med.ext.cms.model.cms.*;
import nta.med.ext.cms.service.SurveyService;
import nta.med.ext.support.glossary.EventMetaStore;
import nta.med.ext.support.proto.BookingModelProto;
import nta.med.ext.support.proto.BookingServiceProto;
import nta.med.ext.support.proto.BookingServiceProto.BookingExaminationRequest;
import nta.med.ext.support.proto.BookingServiceProto.BookingExaminationResponse;
import nta.med.ext.support.proto.BookingServiceProto.GetMisSurveyLinkRequest;
import nta.med.ext.support.proto.BookingServiceProto.GetMisSurveyLinkResponse;
import nta.med.ext.support.proto.PatientServiceProto;
import nta.med.ext.support.service.AbstractRpcExtListener;
import nta.med.ext.support.service.booking.BookingRpcService;
import nta.med.ext.support.service.patient.PatientRpcService;
import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.apache.logging.log4j.util.Strings;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Propagation;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.springframework.util.StringUtils;

import javax.annotation.Resource;
import java.math.BigDecimal;
import java.math.BigInteger;
import java.time.Instant;
import java.time.OffsetDateTime;
import java.time.ZoneOffset;
import java.time.format.DateTimeFormatter;
import java.util.*;
import java.util.concurrent.Future;
import java.util.concurrent.TimeUnit;
import java.util.stream.Collectors;

/**
 * @author dainguyen.
 */
@Service("surveyService")
@Transactional()
public class SurveyServiceImpl implements SurveyService, BookingRpcService.Service {
	
	private static final Log LOGGER = LogFactory.getLog(SurveyServiceImpl.class);

	@Resource
	private CmsSurveyRepository cmsSurveyRepository;

	@Resource
	private CmsSurveyQuestionGroupRepository cmsSurveyQuestionGroupRepository;

	@Resource
	private CmsSurveyPatientRepository cmsSurveyPatientRepository;

	@Resource
	private CmsSurveyQuestionRepository cmsSurveyQuestionRepository;
	
	@Resource
	private CmsQuestionRepository cmsQuestionRepository;

	@Resource
	private CmsAnswerRepository cmsAnswerRepository;

    @Resource
    private PatientRpcService patientRpcService;
	
    @Resource
    private Configuration configuration;

	@Resource
	private AsyncExecutor asyncExecutor;
    
	@Override
	public List<QuestionModel> getListCmsQuestion(String hospCode, QuestionModel model, Integer startIndex,
			Integer pageSize, String column, String dir, boolean isPaging) {
		List<QuestionModel> listModel = new ArrayList<QuestionModel>();
		List<CmsQuestionInfo> listQuestion = cmsQuestionRepository.getListCmsQuestion(hospCode,
				model.getDepartmentCode(), model.getQuestionType(), model.getContent(), startIndex, pageSize, column,
				dir, isPaging);
		if (!CollectionUtils.isEmpty(listQuestion)) {
			for (CmsQuestionInfo info : listQuestion) {
				QuestionModel questionModel = new QuestionModel();
				BeanUtils.copyProperties(info, questionModel, "JA");
				questionModel.setId(info.getId().longValue());
				listModel.add(questionModel);
			}
		}

		return listModel;
	}

	@Override
	public boolean insertQuestionDetail(QuestionDetailModel model) {

		// save cms_question
		CmsQuestion question = new CmsQuestion();
		question.setDepartmentCode(model.getDepartmentCode());
		question.setDepartmentName(model.getDepartmentName());
		question.setQuestionType(model.getQuestionType());
		question.setContent(model.getContent());
		question.setDescription(model.getDescription());
		question.setLimitAnswer(model.getLimitAnswer());

		BigDecimal allowOtherFlg = model.getHasOtherAnswer() ? new BigDecimal(1) : new BigDecimal(0);
		question.setAllowOtherFlg(allowOtherFlg);
		question.setHospCode(model.getHospCode());
		question.setActiveFlg(new BigDecimal(1));
		question.setLocale("JA");

		question = cmsQuestionRepository.save(question);
		if (question == null || question.getId() == null) {
			return false;
		}

		// save cms_answer
		List<SurveyAnswerModel> answerModelList = model.getAnswerList();
		if (!CollectionUtils.isEmpty(answerModelList)) {
			List<CmsAnswer> answerList = new ArrayList<CmsAnswer>();
			for (SurveyAnswerModel answerModel : answerModelList) {
				CmsAnswer answer = new CmsAnswer();
				answer.setContent(answerModel.getContent());
				answer.setCorrectFlg(answerModel.getCorrectFlg());
				answer.setSequence(answerModel.getSequence());
				answer.setCmsQuestionId(question.getId());
				answer.setHospCode(question.getHospCode());
				answer.setLocale(question.getLocale());
				answer.setActiveFlg(new BigDecimal(1));
				answerList.add(answer);
			}

			List<CmsAnswer> savedList = cmsAnswerRepository.save(answerList);
			return !CollectionUtils.isEmpty(savedList);
		}

		return true;
	}

	@Override
	public boolean deleteQuestionList(List<CommonDelModel> delModel, String hospCode) {
		List<Long> questionIdList = new ArrayList<Long>();
		for (CommonDelModel item : delModel) {
			questionIdList.add(item.getId());
		}

		return cmsQuestionRepository.deleteQuestionList(questionIdList, hospCode);
	}

	@Override
	public QuestionDetailModel getCmsQuestionById(Long id, String hospCode) {
		QuestionDetailModel questionDetailModel = new QuestionDetailModel();
		CmsQuestion question = cmsQuestionRepository.findOne(id.longValue());
		if (question != null && hospCode.equals(question.getHospCode())) {
			BeanUtils.copyProperties(question, questionDetailModel, "JA");
			questionDetailModel.setHasOtherAnswer(new BigDecimal(1).compareTo(question.getAllowOtherFlg()) == 0);
		}

		List<SurveyAnswerModel> answerModelList = new ArrayList<SurveyAnswerModel>();
		List<CmsAnswer> answerList = cmsAnswerRepository.findByQuestionId(id, hospCode);
		if (!CollectionUtils.isEmpty(answerList)) {
			for (CmsAnswer cmsAnswer : answerList) {
				SurveyAnswerModel answerModel = new SurveyAnswerModel();
				BeanUtils.copyProperties(cmsAnswer, answerModel, "JA");
				answerModel.setId(BigInteger.valueOf(cmsAnswer.getId()));
				answerModelList.add(answerModel);
			}

		}

		questionDetailModel.setAnswerList(answerModelList);
		return questionDetailModel;
	}

	@Override
	public boolean updateQuestionDetail(QuestionDetailModel model) {
		// Update Question
		CmsQuestion question = new CmsQuestion();
		question.setId(model.getId());
		question.setDepartmentCode(model.getDepartmentCode());
		question.setDepartmentName(model.getDepartmentName());
		question.setQuestionType(model.getQuestionType());
		question.setContent(model.getContent());
		question.setDescription(model.getDescription());
		question.setLimitAnswer(model.getLimitAnswer());

		BigDecimal allowOtherFlg = model.getHasOtherAnswer() ? new BigDecimal(1) : new BigDecimal(0);
		question.setAllowOtherFlg(allowOtherFlg);
		question.setHospCode(model.getHospCode());
		question.setActiveFlg(new BigDecimal(1));
		question.setLocale("JA");

		question = cmsQuestionRepository.save(question);
		if (question == null || question.getId() == null) {
			return false;
		}

		// Update Answer
		List<SurveyAnswerModel> answerModelList = model.getAnswerList();
		if (!CollectionUtils.isEmpty(answerModelList)) {
			List<CmsAnswer> answerList = new ArrayList<CmsAnswer>();
			List<CmsAnswer> record = cmsAnswerRepository.findByQuestionId(model.getId(), model.getHospCode());
			for (CmsAnswer answerRecord : record) {
				answerRecord.setActiveFlg(new BigDecimal(0));
			}
			for (SurveyAnswerModel answerModel : answerModelList) {
				CmsAnswer answer = new CmsAnswer();
				if (answerModel.getId() == null) { // insert
					answer.setContent(answerModel.getContent());
					answer.setCorrectFlg(answerModel.getCorrectFlg());
					answer.setSequence(answerModel.getSequence());
					answer.setCmsQuestionId(question.getId());
					answer.setHospCode(question.getHospCode());
					answer.setLocale(question.getLocale());
					answer.setActiveFlg(new BigDecimal(1));
					answerList.add(answer);
				} else {// update
					answer = cmsAnswerRepository.findOne(answerModel.getId().longValue());
					if (answer != null) {
						answer.setContent(answerModel.getContent());
						answer.setSequence(answerModel.getSequence());
						answer.setCorrectFlg(answerModel.getCorrectFlg());
						answer.setActiveFlg(new BigDecimal(1));
						answerList.add(answer);
					}
				}
			}

			List<CmsAnswer> savedList = cmsAnswerRepository.save(answerList);
			return !CollectionUtils.isEmpty(savedList);
		}

		return true;
	}

	// cms 10
	@Override
	public List<PatientSurveyModel> getListSurveyPatient(String hospCode, PatientSurveyModel model, Integer startIndex,
			Integer pageSize, String column, String dir, boolean isPaging) {
		
		Date fromDate = null;
		Date toDate = null;
		if(!StringUtils.isEmpty(model.getReservationFrom())){
			fromDate = DateUtil.toDate(model.getReservationFrom() + " 00:00:00", DateUtil.PATTERN_SLASH_YYYYMMDD_HH_COLON_MM_SS);
		}
		if(!StringUtils.isEmpty(model.getReservationTo())){
			toDate = DateUtil.toDate(model.getReservationTo() + " 23:59:59", DateUtil.PATTERN_SLASH_YYYYMMDD_HH_COLON_MM_SS);
		}
        
		List<PatientSurveyModel> listModel = new ArrayList<PatientSurveyModel>();
		List<CmsListSurveyInfo> listSurvey = cmsSurveyPatientRepository.getListSurveyPatient(hospCode, model.getDepartmentCode(),
				model.getStatusFlg(), model.getPatientText(), model.getTitle(), startIndex, pageSize, column, dir, isPaging, model.getSearchType(), fromDate, toDate);
		
		if (!CollectionUtils.isEmpty(listSurvey)) {
			for (CmsListSurveyInfo info : listSurvey) {
				PatientSurveyModel surveyModel = new PatientSurveyModel();
				BeanUtils.copyProperties(info, surveyModel, "JA");
				
				if(!StringUtils.isEmpty(model.getReservationFrom()) && !StringUtils.isEmpty(model.getReservationTo())){
					surveyModel.setReservationFrom(model.getReservationFrom());
					surveyModel.setReservationTo(model.getReservationTo());
				}
				
				listModel.add(surveyModel);
			}
		}

		return listModel;
	}

	// cms 13 :get Survey Patient Status BY all Department
	@Override
	public List<SurveyPatientStatusModel> getListSurveyStatus(String hospCode) {
		// default department
		List<DepartmentModel> listDepts = CmsContext.current().getCmsSession().getListDepartment();
		// department have survey
		Map<String, List<CmsSurveyPatientSummary>> listInfo = cmsSurveyPatientRepository.findAnsweredAndWaitingByHospCode(hospCode)
				.stream().collect(Collectors.groupingBy(s -> s.getDepartmentCode()));
		
		return listDepts.stream().map(s -> {
			SurveyPatientStatusModel r = new SurveyPatientStatusModel();			
			if(listInfo.containsKey(s.getDepartmentCode())) {
				BeanUtils.copyProperties(listInfo.get(s.getDepartmentCode()).get(0), r, "JA");	
			}
			BeanUtils.copyProperties(s, r, "JA");
			return r;
		}).collect(Collectors.toList());			
	}

	// cms 14: get Survey Status by Department
	@Override
	public List<SurveyStatusModel> getListSurveybyDepartmentCode(String hospCode, String departmentCode,
			Integer startIndex, Integer pageSize) {
		List<SurveyStatusModel> listModel = new ArrayList<SurveyStatusModel>();
		List<CmsSurveyStatusInfo> listInfo = cmsSurveyPatientRepository.getListSurveybyDepartmentCode(hospCode,
				departmentCode, startIndex, pageSize);

		if (!CollectionUtils.isEmpty(listInfo)) {
			for (CmsSurveyStatusInfo info : listInfo) {
				SurveyStatusModel model = new SurveyStatusModel();
				BeanUtils.copyProperties(info, model, "JA");
				listModel.add(model);
			}
		}

		return listModel;

	}

	@Override
	public int getTotalSurveybyDepartmentCode(String hospCode, String departmentCode) {
		return cmsSurveyPatientRepository.getTotalSurveybyDepartmentCode(hospCode, departmentCode);
	}

	// cms 15 - get survey to edit
	@Override
	public SurveyInfoModel getSurveyById(Long id, String hospCode) {
		// get Survey

		CmsSurvey cmsSurvey = cmsSurveyRepository.getSurveyById(id, hospCode);
		SurveyInfoModel surveyInfoModel = new SurveyInfoModel();
		// get list QuestionGroupbySurvey
		if (cmsSurvey == null) {
			return null;
		} else {
			BeanUtils.copyProperties(cmsSurvey, surveyInfoModel, "JA");

			List<CmsSurveyQuestionGroup> listQuestionGroup = cmsSurveyQuestionGroupRepository
					.findBySurveyIdAndHospCode(BigInteger.valueOf(cmsSurvey.getId()), hospCode);

			for (CmsSurveyQuestionGroup cmsSurveyQuestionGroup : listQuestionGroup) {

				SurveyQuestionGroupModel surveyQuestionGroupModel = new SurveyQuestionGroupModel();
				BeanUtils.copyProperties(cmsSurveyQuestionGroup, surveyQuestionGroupModel, "JA");
				surveyQuestionGroupModel.setId(BigInteger.valueOf(cmsSurveyQuestionGroup.getId()));

				List<CmsSurveyQuestionInfo> listQuestion = cmsSurveyQuestionRepository
						.getQuestionInfo(BigInteger.valueOf(cmsSurveyQuestionGroup.getId()));
				List<SurveyQuestionModel> surveyQuestionModelList = new ArrayList<SurveyQuestionModel>();

				for (CmsSurveyQuestionInfo question : listQuestion) {

					SurveyQuestionModel questionModel = new SurveyQuestionModel();
					BeanUtils.copyProperties(question, questionModel, "JA");
					questionModel.setId(question.getId().longValue());

					List<CmsAnswer> answerList = cmsAnswerRepository.findByQuestionId(question.getId().longValue(), hospCode);

					List<SurveyAnswerModel> listAnswerModel = new ArrayList<SurveyAnswerModel>();
					for (CmsAnswer cmsAnswer : answerList) {
						SurveyAnswerModel surveyAnswerModel = new SurveyAnswerModel();
						BeanUtils.copyProperties(cmsAnswer, surveyAnswerModel, "JA");
						surveyAnswerModel.setId(BigInteger.valueOf(cmsAnswer.getId()));
						listAnswerModel.add(surveyAnswerModel);

					}
					questionModel.setListAnswer(listAnswerModel);
					surveyQuestionModelList.add(questionModel);

				}
				surveyQuestionGroupModel.setListQuestion(surveyQuestionModelList);
				surveyInfoModel.getListquestionGroup().add(surveyQuestionGroupModel);
			}

			return surveyInfoModel;

		}

	}

	// cms 16 -- update survey
	@Override
	public boolean updateSurveyInfoModel(SurveyInfoModel model, Long surveyId) {

		CmsSurvey cmsSurvey = updateSurvey(model, surveyId);
		if (cmsSurvey != null) {
			if(cmsSurvey.getDefaultFlg().equals(BigDecimal.ONE)){
				// update other survey to default is false
				cmsSurveyRepository.deActiveSurvey(cmsSurvey.getId(), cmsSurvey.getDepartmentCode(), model.getHospCode()); 
			}
			List<SurveyQuestionGroupModel> surveyQuestionGroupModelList = model.getListquestionGroup();
			if (!CollectionUtils.isEmpty(surveyQuestionGroupModelList)) {
				List<CmsSurveyQuestionGroup> questionGroupExisted = new ArrayList<CmsSurveyQuestionGroup>();
				for (SurveyQuestionGroupModel questionGroupModel : surveyQuestionGroupModelList) {
					if (questionGroupModel.getId() == null) { // insert
						createSurveyQuestionGroup(model, questionGroupModel, cmsSurvey);
					} else {
						updateSurveyQuestionGroup( model.getHospCode(), questionGroupModel, questionGroupExisted);
					}
				}
				if (!Collections.isEmpty(questionGroupExisted)) {
					cmsSurveyQuestionGroupRepository.save(questionGroupExisted);
				}
				// List<CmsSurveyQuestionGroup> saveQuestionGroupList =
				// cmsSurveyQuestionGroupRepository
				// .save(questionGroupExisted);
				// return !CollectionUtils.isEmpty(saveQuestionGroupList);
			}
			return true;
		} else {
			return false;
		}
	}

	private void createSurveyQuestionGroup(SurveyInfoModel model, SurveyQuestionGroupModel questionGroupModel,
			CmsSurvey cmsSurvey) {
		CmsSurveyQuestionGroup surveyQuestionGroup = new CmsSurveyQuestionGroup();
		// TODO : hospCode
		surveyQuestionGroup.setHospCode(model.getHospCode());
		surveyQuestionGroup.setCmsSurveyId(BigInteger.valueOf(cmsSurvey.getId()));
		surveyQuestionGroup.setTitle(questionGroupModel.getTitle());
		surveyQuestionGroup.setSequence(questionGroupModel.getSequence());
		surveyQuestionGroup.setActiveFlg((new BigDecimal(1)));
		surveyQuestionGroup.setLocale("JA");
		cmsSurveyQuestionGroupRepository.save(surveyQuestionGroup);
		for (SurveyQuestionModel questionModel : questionGroupModel.getListQuestion()) {


			createCmsSurveyQuestion(model.getHospCode(), BigInteger.valueOf(surveyQuestionGroup.getId()),
					BigInteger.valueOf(questionModel.getId()), questionModel.getRequiredFlg(), questionModel.getSequence());
		}
	}
	private CmsSurveyQuestion createCmsSurveyQuestion(String hospCode, BigInteger surveyQuestionGroupId, BigInteger questionId, BigDecimal requiredFlg,int sequence)
	{
		CmsSurveyQuestion cmsSurveyQuestion = new CmsSurveyQuestion();
		// TODO : hospCode
		cmsSurveyQuestion.setHospCode(hospCode);
		cmsSurveyQuestion.setCmsSurveyQuestionGroupId(surveyQuestionGroupId);
		cmsSurveyQuestion.setCmsQuestionId(questionId);
		cmsSurveyQuestion.setActiveFlg(BigDecimal.ONE);
		cmsSurveyQuestion.setRequiredFlg(requiredFlg);
		cmsSurveyQuestion.setSequence(sequence);
		return cmsSurveyQuestionRepository.save(cmsSurveyQuestion);
	}
	private void updateSurveyQuestionGroup(String hospCode, SurveyQuestionGroupModel questionGroupModel,
			List<CmsSurveyQuestionGroup> questionGroupExisted) {
		CmsSurveyQuestionGroup surveyQuestionGroup = cmsSurveyQuestionGroupRepository
				.findOne(questionGroupModel.getId().longValue());

		if (surveyQuestionGroup.getId() != null) {
			surveyQuestionGroup.setTitle(questionGroupModel.getTitle());
			surveyQuestionGroup.setSequence(questionGroupModel.getSequence());
			questionGroupExisted.add(surveyQuestionGroup);
		}

		List<SurveyQuestionModel> surveyQuestionModelList = questionGroupModel.getListQuestion();
		// update for question
		cmsSurveyQuestionRepository.updateActiveFlgByGroupId(questionGroupModel.getId(), hospCode);
		for (SurveyQuestionModel itemQuestion : surveyQuestionModelList) {
			if (questionGroupModel.getId() != null) {
				List<CmsSurveyQuestion> cmsSurveyQuestionList = cmsSurveyQuestionRepository
						.findByCmsQuestionIdAndCmsSurveyQuestionGroupId(BigInteger.valueOf(itemQuestion.getId()),
								questionGroupModel.getId());
				for (CmsSurveyQuestion cmsSurveyQuestion : cmsSurveyQuestionList) {
					cmsSurveyQuestion.setSequence(itemQuestion.getSequence());
					cmsSurveyQuestion.setRequiredFlg(itemQuestion.getRequiredFlg());
					cmsSurveyQuestion.setActiveFlg(BigDecimal.ONE);
					cmsSurveyQuestionRepository.save(cmsSurveyQuestion);
				}
				if(CollectionUtils.isEmpty(cmsSurveyQuestionList))
				{
					createCmsSurveyQuestion(hospCode, BigInteger.valueOf(surveyQuestionGroup.getId()),
							BigInteger.valueOf(itemQuestion.getId()), itemQuestion.getRequiredFlg(), itemQuestion.getSequence());
				}
			}
		}
	}

	// update cmsSurvey by ID
	private CmsSurvey updateSurvey(SurveyInfoModel model, Long surveyId) {
		CmsSurvey cmsSurvey = cmsSurveyRepository.findOne(surveyId);
		if (cmsSurvey != null) {
			cmsSurvey.setTitle(model.getTitle());
			cmsSurvey.setDescription(model.getDescription());
			cmsSurvey.setDefaultFlg(model.getDefaultFlg());

			cmsSurvey.setHospCode(model.getHospCode());
			cmsSurvey.setDepartmentCode(model.getDepartmentCode());
			cmsSurvey.setActiveFlg(new BigDecimal(1));
			cmsSurvey.setDisplayFlg(new BigDecimal(1));
			cmsSurvey.setLocale("JA");
			return cmsSurveyRepository.save(cmsSurvey);
		}
		return null;

	}

	// creat cmsSurvey
	private CmsSurvey createCmsSurvey(SurveyInfoModel model) {
		CmsSurvey cmsSurvey = new CmsSurvey();

		cmsSurvey.setHospCode(model.getHospCode());
		cmsSurvey.setTitle(model.getTitle());
		cmsSurvey.setDescription(model.getDescription());
		cmsSurvey.setDefaultFlg(model.getDefaultFlg());
		cmsSurvey.setDepartmentCode(model.getDepartmentCode());
		cmsSurvey.setActiveFlg(new BigDecimal(1));
		cmsSurvey.setDisplayFlg(new BigDecimal(1));
		cmsSurvey.setLocale("JA");

		return cmsSurveyRepository.save(cmsSurvey);

	}

	// cms 17 - delete survey
	@Override
	public boolean deleteSurvey(BigInteger surveyId, String hospCode) {
		
		return cmsSurveyRepository.deleteSurvey(surveyId, hospCode);
	}
	
	@Override
	public boolean isExistedSurveyRelatedOrSurveyActive(BigInteger surveyId, String hospCode){
		CmsSurvey cmsSurvey = cmsSurveyRepository.findOne(surveyId.longValue());
		boolean isSurveyActive = false;
		if(!hospCode.equals(cmsSurvey.getHospCode())){
			return isSurveyActive;
		}
		if(cmsSurvey != null )
		{
			 isSurveyActive = cmsSurvey.getDefaultFlg().equals(BigDecimal.ONE);
		}
		return isSurveyActive || cmsSurveyPatientRepository.isExistedSurveyRelated(surveyId);
	}

	// cms 18 - creat survey
	@Override
	public boolean createSurveyInfoModel(SurveyInfoModel model) {
		CmsSurvey cmsSurvey = createCmsSurvey(model);
		if (cmsSurvey != null) {
			if(cmsSurvey.getDefaultFlg().equals(BigDecimal.ONE)){
				// update other survey to default is false
				cmsSurveyRepository.deActiveSurvey(cmsSurvey.getId(), cmsSurvey.getDepartmentCode(), model.getHospCode()); 
			}
			List<SurveyQuestionGroupModel> surveyQuestionGroupModelList = model.getListquestionGroup();
			if (!CollectionUtils.isEmpty(surveyQuestionGroupModelList)) {
				List<CmsSurveyQuestionGroup> surveyQuestionGroupList = new ArrayList<CmsSurveyQuestionGroup>();

				for (SurveyQuestionGroupModel questionGroupModel : surveyQuestionGroupModelList) {

					createSurveyQuestionGroup(model, questionGroupModel, cmsSurvey);
				}
				if (!Collections.isEmpty(surveyQuestionGroupList)) {
					cmsSurveyQuestionGroupRepository.save(surveyQuestionGroupList);
				}
			}

			return true;
		} else {
			return false;
		}
	}
	
	// CMS 08
	@Override
	public PatientSurveyModel getPatientSurveyToDoById(Long id, String hospCode) throws Exception {

		LOGGER.info("getPatientSurveyToDoById: surveyId=" + id + ", hospCode=" + hospCode);
		// Step 1: get patient information by id
		PatientSurveyStore patientSurveyStore = new PatientSurveyStore();
		PatientSurveyModel patientSurveyModel = new PatientSurveyModel();
		CmsSurveyPatient surveypatient = cmsSurveyPatientRepository.getSurveyPatientById(id, hospCode);

		if (surveypatient == null) {
			patientSurveyModel.setError(Message.PATIENT_SURVEY_NOT_FOUND.getValue());
			return patientSurveyModel;
		}
		if(BigDecimal.ONE.equals(surveypatient.getStatusFlg())){
			patientSurveyModel.setError(Message.PATIENT_SURVEY_IN_COMPLETE.getValue());
			return patientSurveyModel;
		}
		BeanUtils.copyProperties(surveypatient, patientSurveyModel, "JA");
		patientSurveyModel.setSurveyPatientId(BigInteger.valueOf(surveypatient.getId()));
		BeanUtils.copyProperties(surveypatient, patientSurveyStore, "JA");
		patientSurveyStore.setAnswerDate(DateUtil.toString(surveypatient.getAnswerDate(), DateUtil.PATTERN_YYYY_MM_DD));

		// Step 2: get survey information by id
		SurveyInfoModel surveyModel = new SurveyInfoModel();
		CmsSurvey cmsSurvey = cmsSurveyRepository
				.getSurveyById(Long.valueOf(surveypatient.getCmsSurveyId().toString()), hospCode);

		if (cmsSurvey == null) {
			patientSurveyModel.setError(Message.SURVEY_NOT_FOUND.getValue());
			return patientSurveyModel;
		}
		BeanUtils.copyProperties(cmsSurvey, surveyModel, "JA");
		BeanUtils.copyProperties(cmsSurvey, patientSurveyStore, "JA");

		// Step 3: get group information by survey id
		List<QuestionGroupStore> listQuestionGroupStore = new ArrayList<>();
		List<SurveyQuestionGroupModel> listQuestionGroupsModel = new ArrayList<SurveyQuestionGroupModel>();
		List<CmsSurveyQuestionGroup> listSurveyQuestionGroup = cmsSurveyQuestionGroupRepository
				.findBySurveyIdAndHospCode(BigInteger.valueOf(cmsSurvey.getId()), hospCode);

		if (CollectionUtils.isEmpty(listSurveyQuestionGroup)) {
			patientSurveyModel.setError(Message.SURVEY_QUESTION_GROUP_NOT_FOUND.getValue());
			return patientSurveyModel;
		}

		for (CmsSurveyQuestionGroup surveyQuestionGroup : listSurveyQuestionGroup) {

			// xml model data prepare
			QuestionGroupStore questionGroupStore = new QuestionGroupStore();
			BeanUtils.copyProperties(surveyQuestionGroup, questionGroupStore, "JA");

			SurveyQuestionGroupModel questionGroupModel = new SurveyQuestionGroupModel();
			BeanUtils.copyProperties(surveyQuestionGroup, questionGroupModel, "JA");
			questionGroupModel.setId(BigInteger.valueOf(surveyQuestionGroup.getId()));

			// Step 4: get survey questions in each group by survey question
			// group id
			List<QuestionStore> listSurveyQuestionStore = new ArrayList<>();
			List<SurveyQuestionModel> listSurveyQuestionModel = new ArrayList<SurveyQuestionModel>();
			List<CmsSurveyQuestionInfo> listSurveyQuestion = cmsSurveyQuestionRepository
					.getQuestionInfo(BigInteger.valueOf(surveyQuestionGroup.getId()));

			if (CollectionUtils.isEmpty(listSurveyQuestion)) {
				patientSurveyModel.setError(Message.SURVEY_QUESTION_NOT_FOUND.getValue());
				return patientSurveyModel;
			}

			for (CmsSurveyQuestionInfo surveyQuestion : listSurveyQuestion) {

				// xml model data prepare
				QuestionStore questionStore = new QuestionStore();
				BeanUtils.copyProperties(surveyQuestion, questionStore, "JA");

				// Step 5: get question information by id
				SurveyQuestionModel surveyQuestionModel = new SurveyQuestionModel();
				BeanUtils.copyProperties(surveyQuestion, surveyQuestionModel, "JA");
				surveyQuestionModel.setId(Long.valueOf(surveyQuestion.getId().longValue()));

				// Step 6: get answer information
				List<AnswerStore> listAnswerStoreXml = new ArrayList<>();
				List<SurveyAnswerModel> answerListModelList = new ArrayList<SurveyAnswerModel>();

				List<CmsAnswer> answerList = cmsAnswerRepository.findByQuestionId(surveyQuestion.getId().longValue(), hospCode);

				if (CollectionUtils.isEmpty(answerList)) {
					patientSurveyModel.setError(Message.ANSWER_QUESTION_NOT_FOUND.getValue());
					return patientSurveyModel;
				}

				for (CmsAnswer cmsAnswer : answerList) {
					// xml model data prepare
					AnswerStore answerStore = new AnswerStore();
					BeanUtils.copyProperties(cmsAnswer, answerStore, "JA");

					SurveyAnswerModel answerModel = new SurveyAnswerModel();
					BeanUtils.copyProperties(cmsAnswer, answerModel, "JA");

					answerModel.setId(BigInteger.valueOf(cmsAnswer.getId()));
					answerModel.setContent(cmsAnswer.getContent());
					//answerModel.setIsSelected(cmsAnswer.getActiveFlg());

					// add answer into list
					answerListModelList.add(answerModel);
					listAnswerStoreXml.add(answerStore);
				}
				surveyQuestionModel.setListAnswer(answerListModelList);
				questionStore.setAnswer(listAnswerStoreXml);

				// add question into list
				listSurveyQuestionModel.add(surveyQuestionModel);
				listSurveyQuestionStore.add(questionStore);
			}

			questionGroupModel.setListQuestion(listSurveyQuestionModel);
			questionGroupStore.setQuestion(listSurveyQuestionStore);

			// add question group into list
			listQuestionGroupsModel.add(questionGroupModel);
			listQuestionGroupStore.add(questionGroupStore);
		}
		surveyModel.setListquestionGroup(listQuestionGroupsModel);
		patientSurveyStore.setGroup(listQuestionGroupStore);
		patientSurveyModel.setSurveyInfoModel(surveyModel);

		String result = patientSurveyStore.toXml();
		surveypatient.setResult(result);
		cmsSurveyPatientRepository.save(surveypatient);
		patientSurveyModel.setResult(true);
		return patientSurveyModel;
	}
	
	// CMS 08
	@Override
	public PatientSurveyModel getPatientSurveyToDoByToken(String token) throws Exception {

		LOGGER.info("getPatientSurveyToDoById: token=" + token);
		// Step 1: get patient information by id
		PatientSurveyStore patientSurveyStore = new PatientSurveyStore();
		PatientSurveyModel patientSurveyModel = new PatientSurveyModel();
		CmsSurveyPatient surveypatient = cmsSurveyPatientRepository.getSurveyPatientByToken(token);
		String hospCode = surveypatient.getHospCode();

		if (surveypatient == null) {
			patientSurveyModel.setError(Message.PATIENT_SURVEY_NOT_FOUND.getValue());
			return patientSurveyModel;
		}
		if(BigDecimal.ONE.equals(surveypatient.getStatusFlg())){
			patientSurveyModel.setError(Message.PATIENT_SURVEY_IN_COMPLETE.getValue());
			return patientSurveyModel;
		}
		BeanUtils.copyProperties(surveypatient, patientSurveyModel, "JA");
		patientSurveyModel.setSurveyPatientId(BigInteger.valueOf(surveypatient.getId()));
		BeanUtils.copyProperties(surveypatient, patientSurveyStore, "JA");
		patientSurveyStore.setAnswerDate(DateUtil.toString(surveypatient.getAnswerDate(), DateUtil.PATTERN_YYYY_MM_DD));

		// Step 2: get survey information by id
		SurveyInfoModel surveyModel = new SurveyInfoModel();
		CmsSurvey cmsSurvey = cmsSurveyRepository
				.getSurveyById(Long.valueOf(surveypatient.getCmsSurveyId().toString()), hospCode);

		if (cmsSurvey == null) {
			patientSurveyModel.setError(Message.SURVEY_NOT_FOUND.getValue());
			return patientSurveyModel;
		}
		BeanUtils.copyProperties(cmsSurvey, surveyModel, "JA");
		BeanUtils.copyProperties(cmsSurvey, patientSurveyStore, "JA");

		// Step 3: get group information by survey id
		List<QuestionGroupStore> listQuestionGroupStore = new ArrayList<>();
		List<SurveyQuestionGroupModel> listQuestionGroupsModel = new ArrayList<SurveyQuestionGroupModel>();
		List<CmsSurveyQuestionGroup> listSurveyQuestionGroup = cmsSurveyQuestionGroupRepository
				.findBySurveyIdAndHospCode(BigInteger.valueOf(cmsSurvey.getId()), hospCode);

		if (CollectionUtils.isEmpty(listSurveyQuestionGroup)) {
			patientSurveyModel.setError(Message.SURVEY_QUESTION_GROUP_NOT_FOUND.getValue());
			return patientSurveyModel;
		}

		for (CmsSurveyQuestionGroup surveyQuestionGroup : listSurveyQuestionGroup) {

			// xml model data prepare
			QuestionGroupStore questionGroupStore = new QuestionGroupStore();
			BeanUtils.copyProperties(surveyQuestionGroup, questionGroupStore, "JA");

			SurveyQuestionGroupModel questionGroupModel = new SurveyQuestionGroupModel();
			BeanUtils.copyProperties(surveyQuestionGroup, questionGroupModel, "JA");
			questionGroupModel.setId(BigInteger.valueOf(surveyQuestionGroup.getId()));

			// Step 4: get survey questions in each group by survey question
			// group id
			List<QuestionStore> listSurveyQuestionStore = new ArrayList<>();
			List<SurveyQuestionModel> listSurveyQuestionModel = new ArrayList<SurveyQuestionModel>();
			List<CmsSurveyQuestionInfo> listSurveyQuestion = cmsSurveyQuestionRepository
					.getQuestionInfo(BigInteger.valueOf(surveyQuestionGroup.getId()));

			if (CollectionUtils.isEmpty(listSurveyQuestion)) {
				patientSurveyModel.setError(Message.SURVEY_QUESTION_NOT_FOUND.getValue());
				return patientSurveyModel;
			}

			for (CmsSurveyQuestionInfo surveyQuestion : listSurveyQuestion) {

				// xml model data prepare
				QuestionStore questionStore = new QuestionStore();
				BeanUtils.copyProperties(surveyQuestion, questionStore, "JA");

				// Step 5: get question information by id
				SurveyQuestionModel surveyQuestionModel = new SurveyQuestionModel();
				BeanUtils.copyProperties(surveyQuestion, surveyQuestionModel, "JA");
				surveyQuestionModel.setId(Long.valueOf(surveyQuestion.getId().longValue()));

				// Step 6: get answer information
				List<AnswerStore> listAnswerStoreXml = new ArrayList<>();
				List<SurveyAnswerModel> answerListModelList = new ArrayList<SurveyAnswerModel>();

				List<CmsAnswer> answerList = cmsAnswerRepository.findByQuestionId(surveyQuestion.getId().longValue(), hospCode);

				if (CollectionUtils.isEmpty(answerList)) {
					patientSurveyModel.setError(Message.ANSWER_QUESTION_NOT_FOUND.getValue());
					return patientSurveyModel;
				}

				for (CmsAnswer cmsAnswer : answerList) {
					// xml model data prepare
					AnswerStore answerStore = new AnswerStore();
					BeanUtils.copyProperties(cmsAnswer, answerStore, "JA");

					SurveyAnswerModel answerModel = new SurveyAnswerModel();
					BeanUtils.copyProperties(cmsAnswer, answerModel, "JA");

					answerModel.setId(BigInteger.valueOf(cmsAnswer.getId()));
					answerModel.setContent(cmsAnswer.getContent());
					//answerModel.setIsSelected(cmsAnswer.getActiveFlg());

					// add answer into list
					answerListModelList.add(answerModel);
					listAnswerStoreXml.add(answerStore);
				}
				surveyQuestionModel.setListAnswer(answerListModelList);
				questionStore.setAnswer(listAnswerStoreXml);

				// add question into list
				listSurveyQuestionModel.add(surveyQuestionModel);
				listSurveyQuestionStore.add(questionStore);
			}

			questionGroupModel.setListQuestion(listSurveyQuestionModel);
			questionGroupStore.setQuestion(listSurveyQuestionStore);

			// add question group into list
			listQuestionGroupsModel.add(questionGroupModel);
			listQuestionGroupStore.add(questionGroupStore);
		}
		surveyModel.setListquestionGroup(listQuestionGroupsModel);
		patientSurveyStore.setGroup(listQuestionGroupStore);
		patientSurveyModel.setSurveyInfoModel(surveyModel);

		String result = patientSurveyStore.toXml();
		surveypatient.setResult(result);
		cmsSurveyPatientRepository.save(surveypatient);
		patientSurveyModel.setResult(true);
		return patientSurveyModel;
	}

	// CMS 07
	@Override
	public PatientSurveyStore getPatientSurveyByIdOrPatientCode(Long id, String hospCode, String patientCode) throws Exception {

		LOGGER.info("BEGIN getPatientSurveyById: surveyPatientId=" + id + ", hospCode=" + hospCode);
		PatientSurveyStore patientSurveyStore = new PatientSurveyStore();
		// Step 1: Get result survey of a patient
		CmsSurveyPatient surveypatient = null;
		if(patientCode == null && id != null)
		{
			 surveypatient = cmsSurveyPatientRepository.getSurveyPatientById(id, hospCode);
		}
		else
		{

			List<CmsSurveyPatient> cmsSurveyPatients = cmsSurveyPatientRepository.findByPatientIdAndHospCode(patientCode, hospCode);
			if(!Collections.isEmpty(cmsSurveyPatients))
			{
				surveypatient = cmsSurveyPatients.get(0);
				id = cmsSurveyPatients.get(0).getId();
			}

		}

		if (surveypatient == null) {
			patientSurveyStore.setError(Message.PATIENT_SURVEY_NOT_FOUND.getValue());
			return patientSurveyStore;
		}

		if (!StringUtils.isEmpty(surveypatient.getResult())) {
			LOGGER.info("---- getPatientSurveyById: resultXml=" + surveypatient.getResult());
			// xml to object
			XmlMapper xmlMapper = new XmlMapper();
			patientSurveyStore = xmlMapper.readValue(surveypatient.getResult(), PatientSurveyStore.class);
		}
		BeanUtils.copyProperties(surveypatient, patientSurveyStore, "JA");
		// Step 2: Get related survey by patient code
		List<CmsSurveyPatient> listSurveyPatient = cmsSurveyPatientRepository
				.findByPatientCodeAndStatusFlg(id, surveypatient.getPatientCode(), BigDecimal.ONE);
		List<PatientSurveyModel> listPatientSurveyModel = new ArrayList<>();
		for (CmsSurveyPatient surveyPatient : listSurveyPatient) {
			PatientSurveyModel patientSurvey = new PatientSurveyModel();
			BeanUtils.copyProperties(surveyPatient, patientSurvey, "JA");
			patientSurvey.setSurveyPatientId(BigInteger.valueOf(surveyPatient.getId()));
			listPatientSurveyModel.add(patientSurvey);

		}
		RelationSurveyModel relationSurveyModel = new RelationSurveyModel();
		relationSurveyModel.setRelate_list(listPatientSurveyModel);
		relationSurveyModel.setHasMore(CollectionUtils.isEmpty(listPatientSurveyModel) ? false : true);
		patientSurveyStore.setStatusFlg(surveypatient.getStatusFlg());
		// set related survey
		patientSurveyStore.setRelateSurvey(relationSurveyModel);
		patientSurveyStore.setResult(true);
		LOGGER.info("END getPatientSurveyById");
		return patientSurveyStore;
	}

	// AC02
	@Override
	public boolean getSurveyByDepartmentCode() {
		String hospCode = CmsContext.current().getCmsSession().getHospCode();
		// TODO AC02
		// Step 2
		// List<CreatePatientSurveyInfo> listData =
		// bassAdapter.getSurveyByDepartmentCode(hospCode);
		//
		// //Step 3
		// for (CreatePatientSurveyInfo item : listData) {
		// List<CmsSurvey> record =
		// cmsSurveyRepository.findByDepartmentCode(item.getGwa());
		//
		// //Step 4
		// for (CmsSurvey item1 : record) {
		// List<CmsSurveyPatient> record1 =
		// cmsSurveyPatientRepository.findByPatientId(BigInteger.valueOf(item1.getId()),item.getBunho(),item.getGwa(),hospCode);
		// for (CmsSurveyPatient surveypatient : record1) {
		// if(surveypatient.getId() != null){
		// return true;
		// }else{
		//
		// //Step 5
		// CmsSurveyPatient insertRecord = new CmsSurveyPatient();
		// insertRecord.setCmsSurveyId(BigInteger.valueOf(surveypatient.getId()));
		// insertRecord.setPatientCode(item.getBunho());
		// insertRecord.setPatientName(item.getSuname());
		// insertRecord.setDepartmentCode(item.getGwa());
		// insertRecord.setDepartmentName(item.getGwaName());
		// insertRecord.setStatusFlg(BigDecimal.ZERO);
		// insertRecord.setAccountFlg(BigDecimal.ZERO);
		// insertRecord.setAgreementFlg(BigDecimal.ZERO);
		// insertRecord.setReservationDate(DateUtil.toDate(item.getNaewonDate(),
		// DateUtil.PATTERN_YYMMDD));
		// insertRecord.setReservationTime(item.getJubsuTime());
		// insertRecord.setReservationCode(item.getPkout1001());
		// insertRecord.setHospCode(hospCode);
		//
		// cmsSurveyPatientRepository.save(insertRecord);
		//
		//
		// }
		// }
		// }
		//
		// }
		return true;
	}

	@Override
	public PatientSurveyInfoModel saveSurveyAnswer(PatientSurveyInfoModel model) throws Exception {
		
		LOGGER.info("saveSurveyAnswer: hospCode=" + model.getHospCode() + ", patientCode=" + model.getPatientCode() + ", patient_survey_id=" + model.getId());		
		PatientSurveyInfoModel patientSurveyInfoModel = new PatientSurveyInfoModel();
		String xmlRecord = model.getPatientSurvey().toXml();
		LOGGER.info("xmlRecord=" + xmlRecord);
		CmsSurveyPatient cmsSurveyPatient = cmsSurveyPatientRepository.findOne(Long.valueOf(model.getId()));
		if (cmsSurveyPatient != null) {
			if(BigDecimal.ONE.equals(cmsSurveyPatient.getStatusFlg())){
				model.setError(Message.PATIENT_SURVEY_IN_COMPLETE.getValue());
				return model;
			}
			
			String valid = validateInputDataSurveyAnswer(model);
			if(!StringUtils.isEmpty(valid)){
				model.setError(valid);
				return model;
			}
			
			cmsSurveyPatient.setResult(xmlRecord);
			cmsSurveyPatient.setStatusFlg(BigDecimal.ONE);
			if(model.getAgreementFlg() != null){
				cmsSurveyPatient.setAgreementFlg(model.getAgreementFlg());
			}
			
			// CmsSurveyPatient cmsSurveyPatient =
			// cmsSurveyPatientRepository.findOne(Long.valueOf(model.getId()));
			BeanUtils.copyProperties(cmsSurveyPatient, patientSurveyInfoModel, "JA");
			patientSurveyInfoModel.setId(cmsSurveyPatient.getId().toString());
			patientSurveyInfoModel.setPatientSurvey(model.getPatientSurvey());
			cmsSurveyPatientRepository.save(cmsSurveyPatient);
		}
		return patientSurveyInfoModel;
	}

	private String validateInputDataSurveyAnswer(PatientSurveyInfoModel model) {
		PatientSurveyStore patientSurveyStore = model.getPatientSurvey();
		List<Long> questionGroups;
		List<BigInteger> questionGroupBigIns = null;
		List<Long> questions = null;
		List<BigInteger> questionBigIns;
		List<Long> answers;
		// step 1: get patient survey
		CmsSurveyPatient surveypatient = cmsSurveyPatientRepository.getSurveyPatientById(Long.valueOf(model.getId()), model.getHospCode());
		if (surveypatient == null) {
			return Message.PATIENT_SURVEY_NOT_FOUND.getValue();
		}
		
		// Step 2: get survey information by id
		CmsSurvey cmsSurvey = cmsSurveyRepository
				.getSurveyById(Long.valueOf(surveypatient.getCmsSurveyId().toString()), model.getHospCode());
		if (cmsSurvey == null) {
			return Message.SURVEY_NOT_FOUND.getValue();
		}
		
		// Step 3: get group information by survey id
		List<CmsSurveyQuestionGroup> listSurveyQuestionGroup = cmsSurveyQuestionGroupRepository
				.findBySurveyIdAndHospCode(BigInteger.valueOf(cmsSurvey.getId()), model.getHospCode());
		if (CollectionUtils.isEmpty(listSurveyQuestionGroup)) {
			return Message.SURVEY_QUESTION_GROUP_NOT_FOUND.getValue();
		}
		questionGroups = listSurveyQuestionGroup.stream().map(CmsSurveyQuestionGroup::getId).collect(Collectors.toList());
		if(!CollectionUtils.isEmpty(questionGroups)){
			questionGroupBigIns = Lists.transform(questionGroups, id -> BigInteger.valueOf(id));
		}
		// Step 4: get survey questions in each group by survey question
		List<CmsSurveyQuestion> listSurveyQuestion = cmsSurveyQuestionRepository
				.getListSurveyQuestionByQuestionGroupIds(questionGroupBigIns, model.getHospCode());
		if (CollectionUtils.isEmpty(listSurveyQuestion)) {
			return Message.SURVEY_QUESTION_NOT_FOUND.getValue();
		}
		questionBigIns = listSurveyQuestion.stream().map(CmsSurveyQuestion::getCmsQuestionId).collect(Collectors.toList());
		if(!CollectionUtils.isEmpty(questionBigIns)){
			questions = Lists.transform(questionBigIns, id -> id.longValue());
		}
		// step 5: get answer
		List<CmsAnswer> answerList = cmsAnswerRepository.getListAnswerByQuestionIds(questions, model.getHospCode());
		if (CollectionUtils.isEmpty(answerList)) {
			return Message.ANSWER_QUESTION_NOT_FOUND.getValue();
		}
		answers = answerList.stream().map(CmsAnswer::getId).collect(Collectors.toList());
		
		// validate
		List<Long> inputQuestionGroupIds = patientSurveyStore.getGroup().stream().map(QuestionGroupStore::getId).collect(Collectors.toList());
		if(!questionGroups.containsAll(inputQuestionGroupIds)){
			LOGGER.info("question_group: " + questionGroups);
			LOGGER.info("question_group_input: " + inputQuestionGroupIds);
			return Message.SURVEY_ANSWER_QUESTION_GROUP_NOT_EXIST.getValue();
		}
		for (QuestionGroupStore questionGroupStore : patientSurveyStore.getGroup()) {
			List<BigInteger> inputQuestions = questionGroupStore.getQuestion().stream().map(QuestionStore::getId).collect(Collectors.toList());
			if(!questionBigIns.containsAll(inputQuestions)){
				LOGGER.info("questions: " + questionBigIns);
				LOGGER.info("questions_input: " + inputQuestions);
				return Message.SURVEY_ANSWER_QUESTION_NOT_EXIST.getValue();
			}
			for (QuestionStore questionStore : questionGroupStore.getQuestion()) {
				List<Long> inputAnswers = questionStore.getAnswer().stream().map(AnswerStore::getId).collect(Collectors.toList());
				if(!answers.containsAll(inputAnswers)){
					LOGGER.info("answers: " + answers);
					LOGGER.info("answers_input: " + inputAnswers);
					return Message.SURVEY_ANSWER_ANSWER_NOT_EXIST.getValue();
				}
			}
		}
		return "";
	}

	@Override
	public Boolean setActiveSurvey(Long idSurvey, String hospCode) {
		CmsSurvey cmsSurvey = cmsSurveyRepository.findOne(idSurvey);
		if (cmsSurvey != null && hospCode.equals(cmsSurvey.getHospCode())) {
			cmsSurveyRepository.setActiveSurvey(idSurvey, cmsSurvey.getDepartmentCode(), hospCode);
			cmsSurveyRepository.deActiveSurvey(idSurvey, cmsSurvey.getDepartmentCode(), hospCode);
			return true;
		}
		return false;
	}	

	@Override
	public CmsSurveyPatient insertCmsSurveyPatient(int timeZone, String hospCode, BigInteger surveyId, String patientCode, String patientName, String departmentCode, String departmentName, String sysId, String patientPwd) {

		LOGGER.info("[INSERT_SURVEY_PATIENT] time_zone = " + timeZone);
		CmsSurveyPatient insertRecord = new CmsSurveyPatient();

		ZoneOffset zoneOffset = ZoneOffset.ofHours(timeZone);
		OffsetDateTime checkTime = Instant.now().atOffset(zoneOffset);
		String sTime = checkTime.format(DateTimeFormatter.ofPattern("HHmm"));
		Date currentDate = DateUtil.toDate(checkTime.format(DateTimeFormatter.ofPattern(DateUtil.PATTERN_YYMMDD)), DateUtil.PATTERN_YYMMDD);

		LOGGER.info("[INSERT_SURVEY_PATIENT] reservation_date = " + DateUtil.toString(currentDate, DateUtil.PATTERN_YYMMDD));
		LOGGER.info("[INSERT_SURVEY_PATIENT] reservation_time = " + sTime);

		insertRecord.setCmsSurveyId(surveyId);
		insertRecord.setPatientCode(patientCode);
		insertRecord.setPatientName(patientName);
		insertRecord.setPatientPwd(patientPwd);
		insertRecord.setDepartmentCode(departmentCode);
		insertRecord.setDepartmentName(departmentName);
		insertRecord.setStatusFlg(BigDecimal.ZERO);
		insertRecord.setAccountFlg(BigDecimal.ZERO);
		insertRecord.setAgreementFlg(BigDecimal.ZERO);
		insertRecord.setActiveFlg(BigDecimal.ONE);
		insertRecord.setReservationDate(currentDate);
		insertRecord.setReservationTime(sTime);
		insertRecord.setReservationCode("");
		insertRecord.setHospCode(hospCode);
		insertRecord.setSysId(sysId);

		cmsSurveyPatientRepository.save(insertRecord);
		return insertRecord;
	}

	@Override
	public PatientBasicInfoModel getPatientFromKCCK(String hospCode, String patientCode) {

		PatientServiceProto.GetPatientRequest patientRequest = PatientServiceProto.GetPatientRequest.
				newBuilder().setPatientCode(patientCode).setHospCode(hospCode).build();

		PatientServiceProto.GetPatientResponse patientResponse = patientRpcService.getPatient(patientRequest);
		PatientBasicInfoModel patientBasicInfoModel = new PatientBasicInfoModel();
		if(patientResponse != null && !Strings.isEmpty(patientResponse.getPatientCode())){
			BeanUtils.copyProperties(patientResponse, patientBasicInfoModel, Language.JAPANESE.toString());
		}
		return patientBasicInfoModel;
	}

	@Override
	public CmsSurveyPatient findById(Long id, String hospCode){
		CmsSurveyPatient surveypatient = cmsSurveyPatientRepository.getSurveyPatientById(id, hospCode);
		return surveypatient;
	}

	public boolean changeSurvey(BigInteger cmsSurveyId, Long id, String hospCode){
		int rowUpdated = cmsSurveyPatientRepository.changeSurvey(cmsSurveyId, id, hospCode);
		return rowUpdated > 0;
	}

	@Override
	public BookingExaminationResponse bookExamToExternalSystem(BookingExaminationRequest request) throws Exception {
		// TODO Auto-generated method stub
		return null;
	}
	
	@Override
	@Transactional(propagation = Propagation.REQUIRES_NEW)
	public void createSurveyIfAbsence(BookingModelProto.BookingExamInfo bookingExam, String token) {
		List<CmsSurvey> cmsSurveyListCmsSurvey = cmsSurveyRepository.findByDepartmentCode(bookingExam.getDepartmentCode(), bookingExam.getHospCode());
		if(bookingExam.getReservationCode() == null){
			LOGGER.warn("Reservation Code was null.");
			return;
		}
		
		String reserCode = String.valueOf(CommonUtils.parseDouble(bookingExam.getReservationCode()));
		for (CmsSurvey cmsSurvey : cmsSurveyListCmsSurvey) {
			List<CmsSurveyPatient> cmsSurveyPatientList = cmsSurveyPatientRepository.
					findByPatientIdAndReservationCodeAnDepartmentCode(bookingExam.getPatientCode(), bookingExam.getDepartmentCode(),
							bookingExam.getHospCode(), reserCode);
			
			if (CollectionUtils.isEmpty(cmsSurveyPatientList)) {
				CmsSurveyPatient insertRecord = new CmsSurveyPatient();
				insertRecord.setCmsSurveyId(BigInteger.valueOf(cmsSurvey.getId()));
				insertRecord.setPatientCode(bookingExam.getPatientCode());
				insertRecord.setPatientName(bookingExam.getPatientName());
				insertRecord.setDepartmentCode(bookingExam.getDepartmentCode());
				insertRecord.setDepartmentName(bookingExam.getDepartmentName());
				insertRecord.setPatientPwd(bookingExam.getPatientPwd());
				insertRecord.setStatusFlg(BigDecimal.ZERO);
				insertRecord.setAccountFlg(BigDecimal.ZERO);
				insertRecord.setAgreementFlg(BigDecimal.ZERO);
				insertRecord.setActiveFlg(BigDecimal.ONE);

				if(bookingExam.getReservationDate() != null && bookingExam.getReservationDate().contains("/")){
					insertRecord.setReservationDate(DateUtil.toDate(bookingExam.getReservationDate(), DateUtil.PATTERN_YYMMDD));
				} else {
					insertRecord.setReservationDate(DateUtil.toDate(bookingExam.getReservationDate(), DateUtil.PATTERN_YYMMDD_BLANK));
				}

				insertRecord.setReservationTime(bookingExam.getReservationTime());
				insertRecord.setReservationCode(reserCode);
				insertRecord.setHospCode(bookingExam.getHospCode());				
				insertRecord.setToken(token);				

				cmsSurveyPatientRepository.save(insertRecord);
			}
		}
	}

	@Override
	@Transactional(propagation = Propagation.REQUIRES_NEW)
	public GetMisSurveyLinkResponse getMisSurveyLink(GetMisSurveyLinkRequest request) throws Exception {
		GetMisSurveyLinkResponse.Builder response = GetMisSurveyLinkResponse.newBuilder();
		response.setId(request.getId());

		LOGGER.info("[START] GET MIS SURVEY LINK: PATIENT_CODE = " + request.getPatientCode() + ", DEPARTMENT_CODE = "
				+ request.getDepartmentCode() + ", HOSP_CODE = " + request.getHospCode() + ", RESERVATION_CODE = "
				+ request.getReservationCode());

		Future<?> f = asyncExecutor.execute(request.getHospCode() == null ? 0 : request.getHospCode().hashCode(), () -> {
			LOGGER.info("[START] getMisSurveyLink");
			List<CmsSurveyPatient> cspList = cmsSurveyPatientRepository.findByPatientIdReservationCodeDepartmentCode(
					request.getPatientCode(), request.getDepartmentCode(), request.getHospCode(),request.getReservationCode());

			if(CollectionUtils.isEmpty(cspList)){
				BookingModelProto.BookingExamInfo bookingExam = request.getBookingExamInfo();
				String token = UUID.randomUUID().toString();
				
				this.createSurveyIfAbsence(bookingExam, token);
				
				String surveyLink = configuration.getMisSurveyLink() + token;
				response.setResult("1");
				response.setSurveyLink(surveyLink);
			} else {
				String token = UUID.randomUUID().toString();
				CmsSurveyPatient csp = cspList.get(0);
				csp.setToken(token);
				cmsSurveyPatientRepository.save(csp);
				String surveyLink = configuration.getMisSurveyLink() + token;
				response.setResult("1");
				response.setSurveyLink(surveyLink);
			}
			LOGGER.info("[END] getMisSurveyLink");
		});

		f.get(30, TimeUnit.SECONDS);

		LOGGER.info("[END] GET MIS SURVEY LINK: " + response.getSurveyLink());
		return response.build();
	}

	@Override
	public CmsSurveyPatient getSurveyPatientByToken(String token) {
		CmsSurveyPatient surveypatient = cmsSurveyPatientRepository.getSurveyPatientByToken(token);
		return surveypatient;
	}

	public static class ListenerImpl extends AbstractRpcExtListener<BookingServiceProto.BookingEvent> {

		@Resource
		private BookingRpcService bookingRpcService;

		@Resource
		private AsyncExecutor asyncExecutor;
		
		@Resource
		private SurveyService surveyService;

		protected ListenerImpl() {
			super(BookingServiceProto.BookingEvent.class);
		}

		@Override
		public EventMetaStore meta() {
			return EventMetaStore.BOOKING;
		}
		
		@Resource
		private  CmsSurveyRepository cmsSurveyRepository;
		
		@Resource
		private CmsSurveyPatientRepository cmsSurveyPatientRepository;
	
		@Override
		public void handleEvent(BookingServiceProto.BookingEvent event) throws Exception {
			LOGGER.info("Survey Listener: "+ (event != null ? event.getId() : ""));
			BookingModelProto.BookingExamInfo bookingExam = event.getBookingExam();
			
			if(bookingExam == null){
				LOGGER.info("Booking exam info was null !");
				return;
			}
						

			Future<?> f = asyncExecutor.execute(bookingExam.getHospCode() == null ? 0 : bookingExam.getHospCode().hashCode(), () -> {											
				LOGGER.info("START handle BookingEvent: "+ (event != null ? event.getId() : ""));
				surveyService.createSurveyIfAbsence(bookingExam, null);
				LOGGER.info("END handle BookingEvent: "+ (event != null ? event.getId() : ""));
			});
			f.get(30, TimeUnit.SECONDS);
		}

		@Override
		public Collection<BookingServiceProto.BookingEvent> invokeSubscribe(long eventId) throws Exception {
			BookingServiceProto.SubscribeBookingEventRequest request = BookingServiceProto.SubscribeBookingEventRequest
					.newBuilder().setEventId(eventId).build();
			BookingServiceProto.SubscribeBookingEventResponse response = bookingRpcService.subscribeBooking(request);
			if (response != null
					&& BookingServiceProto.SubscribeBookingEventResponse.Result.SUCCESS.equals(response.getResult())) {
				if (isVerbose())
					LOGGER.info("{} was successfully subscribed");
				return response.getEventsList();
			}
			return java.util.Collections.emptyList();
		}
	}
	
}
