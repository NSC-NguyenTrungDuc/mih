package nta.med.ext.cms.service.impl;

import java.math.BigDecimal;
import java.math.BigInteger;
import java.security.MessageDigest;
import java.security.NoSuchAlgorithmException;
import java.util.ArrayList;
import java.util.List;
import java.util.Map;
import java.util.UUID;
import java.util.stream.Collectors;

import javax.annotation.Resource;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;

import nta.med.core.domain.cms.CmsHospitalInfo;
import nta.med.core.domain.cms.CmsSurveyPatient;
import nta.med.core.glossary.Language;
import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.cms.CmsHospitalInfoRepository;
import nta.med.data.dao.cms.CmsSurveyPatientRepository;
import nta.med.data.model.cms.CmsHospitalInfoInfo;
import nta.med.data.model.cms.CmsSurveyPatientInfo;
import nta.med.data.model.cms.CmsSurveyPatientSummary;
import nta.med.ext.cms.caching.TokenManager;
import nta.med.ext.cms.model.KcckUserModel;
import nta.med.ext.cms.model.cms.CmsContext;
import nta.med.ext.cms.model.cms.CmsSession;
import nta.med.ext.cms.model.cms.DashboardModel;
import nta.med.ext.cms.model.cms.DepartmentModel;
import nta.med.ext.cms.model.cms.HospitalInfoModel;
import nta.med.ext.cms.model.cms.LoginResponseModel;
import nta.med.ext.cms.model.cms.PatientSurveyModel;
import nta.med.ext.cms.model.cms.PhrAccountModel;
import nta.med.ext.cms.model.cms.SurveyPatientStatusModel;
import nta.med.ext.cms.service.HospitalService;
import nta.med.ext.support.proto.HospitalModelProto;
import nta.med.ext.support.proto.HospitalServiceProto;
import nta.med.ext.support.service.hospital.HospitalRpcService;
import nta.med.ext.support.service.system.SystemRpcService;

@Service("cmsHospitalInfoService")
@Transactional
public class HospitalServiceImpl implements HospitalService {

	@Resource
	private CmsHospitalInfoRepository cmsHospitalInfoRepository;

	@Resource
	private CmsSurveyPatientRepository cmsSurveyPatientRepository;

	@Autowired
	private TokenManager<CmsSession> cache;

	@Resource
	private SystemRpcService systemRpcService;
	@Resource
	private HospitalRpcService hospitalRpcService;

	@Override
	public List<HospitalInfoModel> getListHospitalModel(String hospCode) {
		List<HospitalInfoModel> listModel = new ArrayList<HospitalInfoModel>();
		List<CmsHospitalInfoInfo> hospitalinfo = cmsHospitalInfoRepository.getListCmsHospitalInfo(hospCode);
		if (!CollectionUtils.isEmpty(hospitalinfo)) {
			for (CmsHospitalInfoInfo info : hospitalinfo) {
				HospitalInfoModel hospitalInfoModel = new HospitalInfoModel();
				BeanUtils.copyProperties(info, hospitalInfoModel, "JA");
				listModel.add(hospitalInfoModel);
			}
		}

		return listModel;
	}

	// show status SurveyPAtient --Department , Hospital
	@Override
	public DashboardModel findAnsweredAndWaitingByHospCode(String hospCode, Integer type,Integer startIndex,Integer pageSize, boolean isPaging) {

		DashboardModel cmsDashBoardModel = new DashboardModel();
		Map<String, List<CmsSurveyPatientSummary>> listInfo = cmsSurveyPatientRepository.findAnsweredAndWaitingByHospCode(hospCode,
				type,startIndex,pageSize, isPaging).stream().collect(Collectors.groupingBy(s -> s.getDepartmentCode()));
		
		List<SurveyPatientStatusModel> listModel = new ArrayList<SurveyPatientStatusModel>();
		List<DepartmentModel> depts = CmsContext.current().getCmsSession().getListDepartment();		
		
		BigDecimal totalAnswer = new BigDecimal(0);
		BigDecimal totalWaiting = new BigDecimal(0);

		for(DepartmentModel info : depts) {
			SurveyPatientStatusModel model = new SurveyPatientStatusModel();
			BeanUtils.copyProperties(info, model, "JA");
			if(listInfo.containsKey(info.getDepartmentCode())) {
				CmsSurveyPatientSummary sumary =  listInfo.get(info.getDepartmentCode()).get(0);
				BeanUtils.copyProperties(sumary, model, "JA");
				totalAnswer = totalAnswer.add(sumary.getTotalAnswered());
				totalWaiting = totalWaiting.add(sumary.getTotalWaiting());					
			}				
			listModel.add(model);
		}
		//java paging
		if(isPaging){
			List<SurveyPatientStatusModel> deparments = new ArrayList<SurveyPatientStatusModel>();
			deparments = listModel.stream()
			  .skip((startIndex - 1) * pageSize)
			  .limit(pageSize)
			  .collect(Collectors.toCollection(ArrayList::new));
			cmsDashBoardModel.setDepartmentList(deparments);
		} else {
			cmsDashBoardModel.setDepartmentList(listModel);
		}
		cmsDashBoardModel.setTotalHospAnswered(totalAnswer);
		cmsDashBoardModel.setTotalHospWaiting(totalWaiting);
		cmsDashBoardModel.setType(type);
		return cmsDashBoardModel;
	}

	// search survey patient -- patientCode, patientName, DepartmentCode
	public List<PatientSurveyModel> getListSurveyPatient(String hospCode, PatientSurveyModel model, Integer startIndex,
			Integer pageSize, String column, String dir, boolean isPaging) {
		List<PatientSurveyModel> listSurverPatientModel = new ArrayList<PatientSurveyModel>();
		List<CmsSurveyPatientInfo> listSurveyPatientInfo = cmsSurveyPatientRepository.getListSurveyPatientInfo(hospCode,
				model.getDepartmentCode(), model.getSearch(),model.getStatusFlg(),startIndex, pageSize, column, dir, isPaging);
		if (!CollectionUtils.isEmpty(listSurveyPatientInfo)) {
			for (CmsSurveyPatientInfo info : listSurveyPatientInfo) {
				PatientSurveyModel surveyPatientModel = new PatientSurveyModel();
				surveyPatientModel.setSurveyPatientId(info.getId());
				BeanUtils.copyProperties(info, surveyPatientModel, "JA");
				listSurverPatientModel.add(surveyPatientModel);
			}
		}

		return listSurverPatientModel;
	}

	// cms 19 -- Export PHR Account
	@Override
	public PhrAccountModel getPhrAccountModel(Long surveyPatientId, String hospCode) {
		PhrAccountModel phrAccountModel = new PhrAccountModel();
		CmsSurveyPatient cmsSurveyPatient = cmsSurveyPatientRepository.getSurveyPatientById(surveyPatientId, hospCode);

		if (cmsSurveyPatient != null) {
			BeanUtils.copyProperties(cmsSurveyPatient, phrAccountModel, "JA");
		}
		return phrAccountModel;
	}

	@Override
	public LoginResponseModel checkLogin(KcckUserModel model) throws NoSuchAlgorithmException {

		MessageDigest m = MessageDigest.getInstance("MD5");
		m.update(model.getPassword().getBytes(), 0, model.getPassword().length());
		String encryptPassWord = new BigInteger(1, m.digest()).toString(16);
		//boolean login = systemRpcService.authenticate(model.getHospCode(), model.getUserName(), encryptPassWord);
		HospitalServiceProto.VefiryAccountRequest.Builder verifyAccountRequest = HospitalServiceProto.VefiryAccountRequest.newBuilder();
		verifyAccountRequest.setHospCode(model.getHospCode());
		verifyAccountRequest.setLoginId(model.getUserName());
		verifyAccountRequest.setPassword(encryptPassWord);
		verifyAccountRequest.setAccountType(HospitalServiceProto.VefiryAccountRequest.AccountType.MIS);
		
		HospitalServiceProto.VefiryAccountResponse verifyAccountResponse = hospitalRpcService.vefiryAccount(verifyAccountRequest.build());
		boolean login = verifyAccountResponse != null && verifyAccountResponse.getResult();
		if (login) {
			CmsHospitalInfo hospInfo = cmsHospitalInfoRepository.findByHospCode(model.getHospCode());
			CmsSession cmsSession = new CmsSession();
			if (hospInfo != null && hospInfo.getLocale() != null) {

				cmsSession.setToken(UUID.randomUUID().toString());
				cmsSession.setHospCode(model.getHospCode());
				cmsSession.setUserName(model.getUserName());
				cmsSession.setFullName(model.getUserName());
				cmsSession.setLocale(hospInfo.getLocale());
				cmsSession.setTimeZone(hospInfo.getTimeZone());
			}

			cache.put(cmsSession.getToken(), cmsSession);

			HospitalServiceProto.GetDepartmentRequest.Builder departmentRequest = HospitalServiceProto.GetDepartmentRequest
					.newBuilder();
			departmentRequest.setHospCode(model.getHospCode());
			HospitalServiceProto.GetDepartmentResponse departmentResponse = hospitalRpcService
					.getDepartment(departmentRequest.build());

			List<DepartmentModel> departmentModels = new ArrayList<>();
			for (HospitalModelProto.Department department : departmentResponse.getDeptsList()) {
				DepartmentModel departmentModel = new DepartmentModel();
				BeanUtils.copyProperties(department, departmentModel, Language.JAPANESE.toString());
				departmentModels.add(departmentModel);
			}

			// systemAdapter.findDepartmentList(cmsSession.getHospCode());
			LoginResponseModel rp = new LoginResponseModel();
			rp.setToken(cmsSession.getToken());
			rp.setFullName(cmsSession.getFullName());
			rp.setDepartmentList(departmentModels);
			cmsSession.setListDepartment(departmentModels);
			return rp;
		}

		return null;
	}

	@Override
	public HospitalInfoModel searchHospitalByHospCode(String hospCode) {
		HospitalServiceProto.SearchHospitalInfoByHospCodeRequest request = HospitalServiceProto.SearchHospitalInfoByHospCodeRequest
				.newBuilder()
				.setHospCode(hospCode)
				.build();
		HospitalInfoModel item = new HospitalInfoModel();
		HospitalServiceProto.SearchHospitalInfoByHospCodeResponse response = hospitalRpcService.searchHospitalInfoByHospCode(request);
		if(response != null){
			HospitalModelProto.HospitalInfomation hospInfo = response.getHospInfo();
			if(hospInfo != null){
				BeanUtils.copyProperties(hospInfo, item, Language.JAPANESE.toString());
			}
		}
		return item;
	}
}
