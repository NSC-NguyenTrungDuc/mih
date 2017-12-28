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

import nta.med.core.domain.phr.PhrBabyFood;
import nta.med.core.glossary.Language;
import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.phr.BabyFoodRepository;
import nta.med.data.model.phr.BabyFoodInfo;
import nta.med.data.model.phr.BabySleepInfo;
import nta.med.ext.phr.glossary.ActiveFlag;
import nta.med.ext.phr.model.BabyFoodModel;
import nta.med.ext.phr.model.DurationBabyFoodModel;
import nta.med.ext.phr.model.DurationBabySleepModel;
import nta.med.ext.phr.model.DurationTypeBabyFoodModel;
import nta.med.ext.phr.model.DurationTypeBabySleepModel;
import nta.med.ext.phr.service.BabyFoodService;
//import nta.med.ext.phr.service.MailService;
//import nta.med.ext.phr.service.MedApiService;

@Service
@Transactional
//@Transactional(value = DataSources.PHR)
public class BabyFoodServiceImpl implements BabyFoodService {

	@Resource
	private BabyFoodRepository babyFoodRepository;

//	@Autowired
//	Mapper mapper;

//	@Autowired
//	MailService mailService;

//	@Autowired
//	MedApiService medApiService;
	
	@Override
	public List<BabyFoodModel> getListBabyFoodByProfileId(Long profileId, PageRequest pageRequest) {
		List<BabyFoodModel> listBabyFoodModel = new ArrayList<BabyFoodModel>();
		List<PhrBabyFood> listBabyFood = babyFoodRepository.getListBabyFoodByProfileId(profileId, pageRequest);
		if(!CollectionUtils.isEmpty(listBabyFood)){
			for (PhrBabyFood phrBabyFood : listBabyFood) {
				BabyFoodModel babyFoodModel = new BabyFoodModel();
				if(phrBabyFood != null){
					BeanUtils.copyProperties(phrBabyFood, babyFoodModel, Language.JAPANESE.toString());
				}
				listBabyFoodModel.add(babyFoodModel);
			}
		}
		return listBabyFoodModel;
	}
	
	@Override
	public BabyFoodModel getBabyFoodDetail(Long profileId, Long babyFoodId) {
		BabyFoodModel babyFoodModel = new BabyFoodModel();
		PhrBabyFood babyFood = babyFoodRepository.getBabyFoodByProfileId(babyFoodId, profileId);
		if(babyFood != null){
			BeanUtils.copyProperties(babyFood, babyFoodModel, Language.JAPANESE.toString());
		}
		return babyFoodModel;
	}
	
	@Override
	public BabyFoodModel addBabyFood(Long profileId, BabyFoodModel babyFoodModel){
		PhrBabyFood babyFood = new PhrBabyFood();
    	BeanUtils.copyProperties(babyFoodModel, babyFood, Language.JAPANESE.toString());
    	babyFood.setProfileId(profileId);
    	babyFood = babyFoodRepository.save(babyFood);
    	if(babyFood != null){
    		BeanUtils.copyProperties(babyFood, babyFoodModel, Language.JAPANESE.toString());
    	}
		return babyFoodModel;
	}
	
	@Override
	public BabyFoodModel updateBabyFood(Long profileId, Long babyFoodId, BabyFoodModel babyFoodModel) {
		PhrBabyFood babyFood = babyFoodRepository.getBabyFoodByProfileId(babyFoodId, profileId);
		if(babyFood != null){
	    	BeanUtils.copyProperties(babyFoodModel, babyFood, Language.JAPANESE.toString());
	    	babyFood.setProfileId(profileId);
	    	babyFood = babyFoodRepository.save(babyFood);
	    	if(babyFood != null){
	    		BeanUtils.copyProperties(babyFood, babyFoodModel, Language.JAPANESE.toString());
	    	}
		}
		return babyFoodModel;
	}
	
	@Override
	public Boolean deleteBabyFood(Long profileId, Long babyFoodId) {
		Integer result = babyFoodRepository.updateActiveFlg(babyFoodId, profileId, ActiveFlag.INACTIVE.toInt());
		if(result != null && result > 0){
			return true;
		}
		return false;
	}

	@Override
	public DurationTypeBabyFoodModel getBabyFoodByDurationType(Long profileId, Long durationType) {
		DurationTypeBabyFoodModel foodModel = new DurationTypeBabyFoodModel();
		foodModel.setProfileId(profileId);
		List<DurationBabyFoodModel> durationBabyFoodModels =  new ArrayList<>();
		List<BabyFoodInfo> babyFoodInfos = babyFoodRepository.getBabyFoodByDurationType(profileId, durationType);
		if (!CollectionUtils.isEmpty(babyFoodInfos)) {
			for (BabyFoodInfo info : babyFoodInfos) {
				DurationBabyFoodModel item = new DurationBabyFoodModel();
				BeanUtils.copyProperties(info, item, Language.JAPANESE.toString());
				durationBabyFoodModels.add(item);
			}
			foodModel.setDurationBabyFoodModel(durationBabyFoodModels);
		}
		return foodModel;
	}
}
