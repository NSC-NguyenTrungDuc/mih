package nta.med.ext.phr.service.impl;

import java.util.ArrayList;
import java.util.List;

import javax.annotation.Resource;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.data.domain.PageRequest;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;

import nta.med.core.domain.phr.PhrAccountClinic;
import nta.med.core.domain.phr.PhrStandardProgress;
import nta.med.core.glossary.Language;
import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.phr.AccountClinicRepository;
import nta.med.data.dao.phr.StandardProgressRepository;
import nta.med.ext.phr.glossary.ActiveFlag;
import nta.med.ext.phr.model.EmrRecordModel;
import nta.med.ext.phr.model.StandardProgressDetailModel;
import nta.med.ext.phr.model.StandardProgressModel;
import nta.med.ext.phr.service.MailService;
import nta.med.ext.phr.service.StandardProgressService;
import nta.med.ext.support.proto.SystemServiceProto;
import nta.med.ext.support.service.system.SystemRpcService;

@Service
@Transactional
//@Transactional(value = DataSources.PHR)
public class StandardProgressServiceImpl implements StandardProgressService {

	@Resource
	private StandardProgressRepository standardProgressRepository;

//	@Autowired
//	Mapper mapper;

	@Autowired
	MailService mailService;

//	@Autowired
//	MedApiService medApiService;
	
	@Autowired
	AccountClinicRepository accountClinicRepository;
	
//	@Resource
//	private EmrAdapter emrAdapter;
	
	@Resource
	private SystemRpcService systemRpcService;
	
	@Override
	public List<StandardProgressModel> getListStandardProgressByProfileId(Long profileId, PageRequest pageRequest) {
		List<StandardProgressModel> listStandardProgressModel = new ArrayList<StandardProgressModel>();
		List<PhrStandardProgress> listStandardProgress = standardProgressRepository.getListProgressByProfileId(profileId, pageRequest);
		if(!CollectionUtils.isEmpty(listStandardProgress)){
			for (PhrStandardProgress phrStandardProgress : listStandardProgress) {
				StandardProgressModel standardProgressModel = new StandardProgressModel();
				if(phrStandardProgress != null){
					BeanUtils.copyProperties(phrStandardProgress, standardProgressModel, Language.JAPANESE.toString());
				}
				listStandardProgressModel.add(standardProgressModel);
			}
		}
		return listStandardProgressModel;
	}
	
	@Override
	public StandardProgressDetailModel getStandardProgressDetail(Long profileId) {
		StandardProgressDetailModel standardProgressModel = new StandardProgressDetailModel();
		List<PhrAccountClinic> listPhrAccountClinic = accountClinicRepository.findActiveAccountByProfileId(profileId);
		
		if(!CollectionUtils.isEmpty(listPhrAccountClinic)){
			PhrAccountClinic phrAccountClinic = listPhrAccountClinic.get(0);
			standardProgressModel.setHospCode(phrAccountClinic.getHospCode());
			standardProgressModel.setPatientCode(phrAccountClinic.getPatientCode());
			standardProgressModel.setHospName(phrAccountClinic.getHospName());
			EmrRecordModel emrModel = findEmrRecordByPatientCodeAndHospCode(phrAccountClinic.getPatientCode(), phrAccountClinic.getHospCode());	
			if(emrModel != null){
				standardProgressModel.setContent(emrModel.getContent());
				standardProgressModel.setVersion(emrModel.getVersion());
			}
		}
		return standardProgressModel;
	}
	
	private EmrRecordModel findEmrRecordByPatientCodeAndHospCode(String patientCode, String hospCode) {
		SystemServiceProto.GetEmrDataRequest.Builder emrRequest = SystemServiceProto.GetEmrDataRequest.newBuilder();
		emrRequest.setHospCode(hospCode);
		emrRequest.setPatientCode(patientCode);
    	
		SystemServiceProto.GetEmrDataResponse emrResponse = systemRpcService.getEmrData(emrRequest.build());
		return emrResponse == null ? null : new EmrRecordModel(emrResponse.getContent(), emrResponse.getVersion());
	}
	
	@Override
	public StandardProgressModel addStandardProgress(Long profileId, StandardProgressModel standardProgressModel){
		PhrStandardProgress standardProgress = new PhrStandardProgress();
    	BeanUtils.copyProperties(standardProgressModel, standardProgress, Language.JAPANESE.toString());
    	standardProgress.setProfileId(profileId);
    	standardProgress = standardProgressRepository.save(standardProgress);
    	if(standardProgress != null){
    		BeanUtils.copyProperties(standardProgress, standardProgressModel, Language.JAPANESE.toString());
    	}
		return standardProgressModel;
	}
	
	@Override
	public StandardProgressModel updateStandardProgress(Long profileId, Long progressId, StandardProgressModel standardProgressModel) {
		PhrStandardProgress standardProgress = standardProgressRepository.getProgressByProfileId(progressId, profileId);
		if(standardProgress != null){
	    	BeanUtils.copyProperties(standardProgressModel, standardProgress, Language.JAPANESE.toString());
	    	standardProgress.setProfileId(profileId);
	    	standardProgress = standardProgressRepository.save(standardProgress);
	    	if(standardProgress != null){
	    		BeanUtils.copyProperties(standardProgress, standardProgressModel, Language.JAPANESE.toString());
	    	}
		}
		return standardProgressModel;
	}
	
	@Override
	public Boolean deleteStandardProgress(Long profileId, Long progressId) {
		Integer result = standardProgressRepository.updateActiveFlg(progressId, profileId, ActiveFlag.INACTIVE.toInt());
		if(result != null && result > 0){
			return true;
		}
		return false;
	}
}
