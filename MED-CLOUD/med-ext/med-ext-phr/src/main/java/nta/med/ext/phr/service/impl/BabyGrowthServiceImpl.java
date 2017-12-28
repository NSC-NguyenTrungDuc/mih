package nta.med.ext.phr.service.impl;

import java.util.ArrayList;
import java.util.List;

import javax.annotation.Resource;

import org.springframework.data.domain.PageRequest;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.springframework.util.StringUtils;

import nta.med.core.domain.phr.PhrBabyGrowthHeight;
import nta.med.core.domain.phr.PhrBabyGrowthWeight;
import nta.med.core.glossary.Language;
import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.phr.BabyGrowthHeightRepository;
import nta.med.data.dao.phr.BabyGrowthWeightRepository;
import nta.med.data.model.phr.BabyGrowthHeightInfo;
import nta.med.data.model.phr.BabyGrowthWeightInfo;
import nta.med.ext.phr.glossary.ActiveFlag;
import nta.med.ext.phr.glossary.GrowthType;
import nta.med.ext.phr.glossary.Message;
import nta.med.ext.phr.model.BabyGrowthHeightModel;
import nta.med.ext.phr.model.BabyGrowthHeightWeightModel;
import nta.med.ext.phr.model.BabyGrowthWeightModel;
import nta.med.ext.phr.model.DurationTypeBabyGrowthModel;
import nta.med.ext.phr.model.GrowthInfoBaseOnTypeModel;
import nta.med.ext.phr.service.BabyGrowthService;

@Service
@Transactional
//@Transactional(value = DataSources.PHR)
public class BabyGrowthServiceImpl implements BabyGrowthService{
	
	@Resource
	private BabyGrowthHeightRepository babyGrowthHeightRepository;
	
	@Resource
	private BabyGrowthWeightRepository babyGrowthWeightRepository;
	
	@Override
	public BabyGrowthHeightWeightModel updateBabyGrowthByType(BabyGrowthHeightWeightModel babyGrowthModel, String growthType, Long profileId) {
		if(babyGrowthModel.getTimeMeasure() == null){
			babyGrowthModel.setMessage(Message.DATETIME_RECORD_REQUIRED.getValue());
			return babyGrowthModel;
		}
		if(GrowthType.GROWTH_HEIGHT.getValue().equals(growthType)){
			if(StringUtils.isEmpty(babyGrowthModel.getHeight())){
				babyGrowthModel.setMessage(Message.GROWTH_HEIGHT_REQUIRED.getValue());
				return babyGrowthModel;
			}
			PhrBabyGrowthHeight babyGrowthHeight = new PhrBabyGrowthHeight(); 
			if(babyGrowthModel.getId() != null){
				babyGrowthHeight = babyGrowthHeightRepository.getBabyGrowthHeightByIdAndProfileIdAndActiveFlg(babyGrowthModel.getId(), profileId);
				if(babyGrowthHeight == null){
					babyGrowthModel.setMessage(Message.TEMP_NOT_FOUND.getValue());
					return babyGrowthModel;
				}
			}
			BeanUtils.copyProperties(babyGrowthModel, babyGrowthHeight, Language.JAPANESE.toString());
			babyGrowthHeight.setProfileId(profileId);
			babyGrowthHeightRepository.save(babyGrowthHeight);
			BeanUtils.copyProperties(babyGrowthHeight, babyGrowthModel, Language.JAPANESE.toString());
			return babyGrowthModel;
		} else if(GrowthType.GROWTH_WEIGHT.getValue().equals(growthType)){
			if(StringUtils.isEmpty(babyGrowthModel.getWeight())){
				babyGrowthModel.setMessage(Message.GROWTH_WEIGHT_REQUIRED.getValue());
				return babyGrowthModel;
			}
			PhrBabyGrowthWeight babyGrowthWeight = new PhrBabyGrowthWeight(); 
			if(babyGrowthModel.getId() != null){
				babyGrowthWeight = babyGrowthWeightRepository.getBabyGrowthWeightByIdAndProfileIdAndActiveFlg(babyGrowthModel.getId(), profileId);
				if(babyGrowthWeight == null){
					babyGrowthModel.setMessage(Message.TEMP_NOT_FOUND.getValue());
					return babyGrowthModel;
				}
			}
			BeanUtils.copyProperties(babyGrowthModel, babyGrowthWeight, Language.JAPANESE.toString());
			babyGrowthWeight.setProfileId(profileId);
			babyGrowthWeightRepository.save(babyGrowthWeight);
			BeanUtils.copyProperties(babyGrowthWeight, babyGrowthModel, Language.JAPANESE.toString());
			return babyGrowthModel;
		} else {
			babyGrowthModel.setMessage(Message.GROWTH_TYPE_NOT_EXIST.getValue());
		}
		return babyGrowthModel;
	}

	@Override
	public BabyGrowthHeightWeightModel deleteBabyGrowthByType(Long profileId, String growthType, Long growthId) {
		BabyGrowthHeightWeightModel growthModel = new BabyGrowthHeightWeightModel();
		if(GrowthType.GROWTH_HEIGHT.getValue().equals(growthType)){
			PhrBabyGrowthHeight babyGrowthHeight = babyGrowthHeightRepository.getBabyGrowthHeightByIdAndProfileId(growthId, profileId);
			if(babyGrowthHeight != null){
				if(ActiveFlag.ACTIVE.toInt() == babyGrowthHeight.getActiveFlg()){
					babyGrowthHeight.setActiveFlg(ActiveFlag.INACTIVE.toInt());
					babyGrowthHeightRepository.save(babyGrowthHeight);
				} else {
					growthModel.setMessage(Message.GROWTH_HEIGHT_DELETED.getValue());
				}
				return growthModel;
			} else {
				growthModel.setMessage(Message.GROWTH_ID_NOT_FOUND.getValue());
				return growthModel;
			}
		} else if(GrowthType.GROWTH_WEIGHT.getValue().equals(growthType)){
			PhrBabyGrowthWeight babyGrowthWeight = babyGrowthWeightRepository.getBabyGrowthWeightByIdAndProfileId(growthId, profileId);
			if(babyGrowthWeight != null){
				if(ActiveFlag.ACTIVE.toInt() == babyGrowthWeight.getActiveFlg()){
					babyGrowthWeight.setActiveFlg(ActiveFlag.INACTIVE.toInt());
					babyGrowthWeightRepository.save(babyGrowthWeight);
				} else {
					growthModel.setMessage(Message.GROWTH_WEIGHT_DELETED.getValue());
				}
				return growthModel;
			} else {
				growthModel.setMessage(Message.GROWTH_ID_NOT_FOUND.getValue());
				return growthModel;
			}
		} else {
			growthModel.setMessage(Message.GROWTH_TYPE_NOT_EXIST.getValue());
		}
		
		return growthModel;
	}

	@Override
	public GrowthInfoBaseOnTypeModel getListBabyGrowthByType(Long profileId, String growthType, PageRequest pageRequest) {
		GrowthInfoBaseOnTypeModel growthInfo = new GrowthInfoBaseOnTypeModel();
		growthInfo.setProfileId(profileId);
		growthInfo.setType(growthType);
		List<BabyGrowthHeightWeightModel> growthModels =  new ArrayList<BabyGrowthHeightWeightModel>();
		if(GrowthType.GROWTH_HEIGHT.getValue().equals(growthType)){
			List<PhrBabyGrowthHeight> babyGrowthHeights = babyGrowthHeightRepository.getBabyGrowthHeightByprofileId(profileId, pageRequest);
			if(!CollectionUtils.isEmpty(babyGrowthHeights)){
				for(PhrBabyGrowthHeight item : babyGrowthHeights){
					BabyGrowthHeightWeightModel babyGrowthHeightModel = new BabyGrowthHeightWeightModel();
					BeanUtils.copyProperties(item, babyGrowthHeightModel, Language.JAPANESE.toString());
					growthModels.add(babyGrowthHeightModel);
				}
				growthInfo.setGrowthModel(growthModels);
			}
		} else if(GrowthType.GROWTH_WEIGHT.getValue().equals(growthType)){
			List<PhrBabyGrowthWeight> babyGrowthWeights = babyGrowthWeightRepository.getBabyGrowthWeightByprofileId(profileId, pageRequest);
			if(!CollectionUtils.isEmpty(babyGrowthWeights)){
				for(PhrBabyGrowthWeight item : babyGrowthWeights){
					BabyGrowthHeightWeightModel babyGrowthWeightModel = new BabyGrowthHeightWeightModel();
					BeanUtils.copyProperties(item, babyGrowthWeightModel, Language.JAPANESE.toString());
					growthModels.add(babyGrowthWeightModel);
				}
				growthInfo.setGrowthModel(growthModels);
			}
		} else {
			growthInfo.setMessage(Message.GROWTH_TYPE_NOT_EXIST.getValue());
		}
		
		return growthInfo;
	}

	@Override
	public BabyGrowthHeightWeightModel getDetailsBabyGrowthByType(Long profileId, String growthType, Long growthId) {
		BabyGrowthHeightWeightModel babyGrowModel = new BabyGrowthHeightWeightModel();
		if(GrowthType.GROWTH_HEIGHT.getValue().equals(growthType)){
			PhrBabyGrowthHeight babyGrowthHeight = babyGrowthHeightRepository.getBabyGrowthHeightByIdAndProfileIdAndActiveFlg(growthId, profileId);
			if(babyGrowthHeight != null){
				BeanUtils.copyProperties(babyGrowthHeight, babyGrowModel, Language.JAPANESE.toString());
				return babyGrowModel;
			} else {
				babyGrowModel.setMessage(Message.GROWTH_ID_NOT_FOUND.getValue());
				return babyGrowModel;
			}
		} else if(GrowthType.GROWTH_WEIGHT.getValue().equals(growthType)){
			PhrBabyGrowthWeight babyGrowthWeight = babyGrowthWeightRepository.getBabyGrowthWeightByIdAndProfileIdAndActiveFlg(growthId, profileId);
			if(babyGrowthWeight != null){
				BeanUtils.copyProperties(babyGrowthWeight, babyGrowModel, Language.JAPANESE.toString());
				return babyGrowModel;
			} else {
				babyGrowModel.setMessage(Message.GROWTH_ID_NOT_FOUND.getValue());
				return babyGrowModel;
			}
		} else {
			babyGrowModel.setMessage(Message.TEMP_TYPE_NOT_EXIST.getValue());
		}
		
		return babyGrowModel;
	}

	@Override
	public DurationTypeBabyGrowthModel getBabyGrowthInfoByDurationType(Long profileId, String growthType, Long durationType) {
		boolean invalidTempType = true;
		DurationTypeBabyGrowthModel growthModel = new DurationTypeBabyGrowthModel();
		growthModel.setProfileId(profileId);
		growthModel.setType(growthType);
		List<BabyGrowthHeightModel> babyGrowthHeightModels = new ArrayList<>();
		List<BabyGrowthWeightModel> babyGrowthWeightModels = new ArrayList<>();
		
		if(GrowthType.GROWTH_HEIGHT.getValue().equals(growthType) || GrowthType.GROWTH_ALL.getValue().equals(growthType)){
			invalidTempType = false;
			List<BabyGrowthHeightInfo> babyGrowthHeightInfos = babyGrowthHeightRepository.getBabyGrowthHeightInfoByprofileIdAndDurationType(profileId, durationType);
			if (!CollectionUtils.isEmpty(babyGrowthHeightInfos)) {
				for (BabyGrowthHeightInfo info : babyGrowthHeightInfos) {
					BabyGrowthHeightModel item = new BabyGrowthHeightModel();
					BeanUtils.copyProperties(info, item, Language.JAPANESE.toString());
					babyGrowthHeightModels.add(item);
				}
				growthModel.setBabyGrowthHeightModel(babyGrowthHeightModels);
			}
		} 
		if (GrowthType.GROWTH_WEIGHT.getValue().equals(growthType) || GrowthType.GROWTH_ALL.getValue().equals(growthType)) {
			invalidTempType = false;
			List<BabyGrowthWeightInfo> babyGrowthWeightInfos = babyGrowthWeightRepository.getBabyGrowthWeightInfoByprofileIdAndDurationType(profileId, durationType);
			if (!CollectionUtils.isEmpty(babyGrowthWeightInfos)) {
				for (BabyGrowthWeightInfo info : babyGrowthWeightInfos) {
					BabyGrowthWeightModel item = new BabyGrowthWeightModel();
					BeanUtils.copyProperties(info, item, Language.JAPANESE.toString());
					babyGrowthWeightModels.add(item);
				}
				growthModel.setBabyGrowthWeightModel(babyGrowthWeightModels);
			}
		} 
		if(invalidTempType) {
			growthModel.setMessage(Message.FITNESS_TYPE_NOT_EXIST.getValue());
		}
		return growthModel;
	}

	@Override
	public List<BabyGrowthHeightWeightModel> addBabyGrowthListByType(List<BabyGrowthHeightWeightModel> babyGrowthHeightWeightModels, String growthType, Long profileId) {
		List<BabyGrowthHeightWeightModel> listBabyGrowthHeightWeight = new ArrayList<>();

		List<PhrBabyGrowthHeight> babyGrowthHeights = new ArrayList<>();
		List<PhrBabyGrowthWeight> babyGrowthWeights = new ArrayList<>();
		for (BabyGrowthHeightWeightModel babyGrowthModel : babyGrowthHeightWeightModels) {
			if(GrowthType.GROWTH_HEIGHT.getValue().equals(growthType)){
				PhrBabyGrowthHeight babyGrowthHeight = new PhrBabyGrowthHeight(); 
				BeanUtils.copyProperties(babyGrowthModel, babyGrowthHeight, Language.JAPANESE.toString());
				babyGrowthHeight.setProfileId(profileId);
				babyGrowthHeights.add(babyGrowthHeight);
			} 
			
			if(GrowthType.GROWTH_WEIGHT.getValue().equals(growthType)){
				PhrBabyGrowthWeight babyGrowthWeight = new PhrBabyGrowthWeight(); 
				BeanUtils.copyProperties(babyGrowthModel, babyGrowthWeight, Language.JAPANESE.toString());
				babyGrowthWeight.setProfileId(profileId);
				babyGrowthWeights.add(babyGrowthWeight);
			} 
		}

		// save data
		if (!CollectionUtils.isEmpty(babyGrowthHeights)) {
			babyGrowthHeights = babyGrowthHeightRepository.save(babyGrowthHeights);
			for (PhrBabyGrowthHeight babyGrowthHeight : babyGrowthHeights) {
				BabyGrowthHeightWeightModel babyGrowthHeightWeightModel = new BabyGrowthHeightWeightModel();
				BeanUtils.copyProperties(babyGrowthHeight, babyGrowthHeightWeightModel, Language.JAPANESE.toString());
				listBabyGrowthHeightWeight.add(babyGrowthHeightWeightModel);
			}
		}
		if (!CollectionUtils.isEmpty(babyGrowthWeights)) {
			babyGrowthWeights = babyGrowthWeightRepository.save(babyGrowthWeights);
			for (PhrBabyGrowthWeight babyGrowthWeight : babyGrowthWeights) {
				BabyGrowthHeightWeightModel babyGrowthWeightWeightModel = new BabyGrowthHeightWeightModel();
				BeanUtils.copyProperties(babyGrowthWeight, babyGrowthWeightWeightModel, Language.JAPANESE.toString());
				listBabyGrowthHeightWeight.add(babyGrowthWeightWeightModel);
			}
		}
		return listBabyGrowthHeightWeight;
	}
}
