package nta.med.ext.phr.service.impl;

import java.util.ArrayList;
import java.util.List;

import javax.annotation.Resource;

//import org.dozer.Mapper;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.data.domain.PageRequest;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;

import nta.med.core.domain.phr.PhrBabySleep;
import nta.med.core.glossary.Language;
import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.phr.BabySleepRepository;
import nta.med.data.model.phr.BabySleepInfo;
import nta.med.ext.phr.glossary.ActiveFlag;
import nta.med.ext.phr.model.BabySleepModel;
import nta.med.ext.phr.model.DurationBabySleepModel;
import nta.med.ext.phr.model.DurationTypeBabySleepModel;
import nta.med.ext.phr.service.BabySleepService;
import nta.med.ext.phr.service.MailService;

@Service
@Transactional
//@Transactional(value = DataSources.PHR)
public class BabySleepServiceImpl implements BabySleepService {

	@Resource
	private BabySleepRepository babySleepRepository;

//	@Autowired
//	Mapper mapper;

	@Autowired
	MailService mailService;

//	@Autowired
//	MedApiService medApiService;
	
	@Override
	public List<BabySleepModel> getListBabySleepByProfileId(Long profileId, PageRequest pageRequest) {
		List<BabySleepModel> listBabySleepModel = new ArrayList<BabySleepModel>();
		List<PhrBabySleep> listBabySleep = babySleepRepository.getListBabySleepByProfileId(profileId, pageRequest);
		if(!CollectionUtils.isEmpty(listBabySleep)){
			for (PhrBabySleep phrBabySleep : listBabySleep) {
				BabySleepModel babySleepModel = new BabySleepModel();
				if(phrBabySleep != null){
					BeanUtils.copyProperties(phrBabySleep, babySleepModel, Language.JAPANESE.toString());
				}
				listBabySleepModel.add(babySleepModel);
			}
		}
		return listBabySleepModel;
	}
	
	@Override
	public BabySleepModel getBabySleepDetail(Long profileId, Long babySleepId) {
		BabySleepModel babySleepModel = new BabySleepModel();
		PhrBabySleep babySleep = babySleepRepository.getBabySleepByProfileId(babySleepId, profileId);
		if(babySleep != null){
			BeanUtils.copyProperties(babySleep, babySleepModel, Language.JAPANESE.toString());
		}
		return babySleepModel;
	}
	
	@Override
	public BabySleepModel addBabySleep(Long profileId, BabySleepModel babySleepModel){
		PhrBabySleep babySleep = new PhrBabySleep();
    	BeanUtils.copyProperties(babySleepModel, babySleep, Language.JAPANESE.toString());
    	babySleep.setProfileId(profileId);
    	babySleep = babySleepRepository.save(babySleep);
    	if(babySleep != null){
    		BeanUtils.copyProperties(babySleep, babySleepModel, Language.JAPANESE.toString());
    	}
		return babySleepModel;
	}
	
	@Override
	public BabySleepModel updateBabySleep(Long profileId, Long babySleepId, BabySleepModel babySleepModel) {
		PhrBabySleep babySleep = babySleepRepository.getBabySleepByProfileId(babySleepId, profileId);
		if(babySleep != null){
	    	BeanUtils.copyProperties(babySleepModel, babySleep, Language.JAPANESE.toString());
	    	babySleep.setProfileId(profileId);
	    	babySleep = babySleepRepository.save(babySleep);
	    	if(babySleep != null){
	    		BeanUtils.copyProperties(babySleep, babySleepModel, Language.JAPANESE.toString());
	    	}
		}
		return babySleepModel;
	}
	
	@Override
	public Boolean deleteBabySleep(Long profileId, Long babySleepId) {
		Integer result = babySleepRepository.updateActiveFlg(babySleepId, profileId, ActiveFlag.INACTIVE.toInt());
		if(result != null && result > 0){
			return true;
		}
		return false;
	}

	@Override
	public DurationTypeBabySleepModel getBabySleepByDurationType(Long profileId, Long durationType) {
		DurationTypeBabySleepModel sleepModel = new DurationTypeBabySleepModel();
		sleepModel.setProfileId(profileId);
		List<DurationBabySleepModel> durationBabySleepModels =  new ArrayList<>();
		List<BabySleepInfo> babySleepInfos = babySleepRepository.getBabySleepInfoByprofileIdAndType(profileId, durationType);
		if (!CollectionUtils.isEmpty(babySleepInfos)) {
			for (BabySleepInfo info : babySleepInfos) {
				DurationBabySleepModel item = new DurationBabySleepModel();
				BeanUtils.copyProperties(info, item, Language.JAPANESE.toString());
				durationBabySleepModels.add(item);
			}
			sleepModel.setDurationBabySleepModel(durationBabySleepModels);
		}
		return sleepModel;
	}
}
