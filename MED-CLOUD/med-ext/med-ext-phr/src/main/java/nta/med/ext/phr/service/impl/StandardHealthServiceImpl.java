package nta.med.ext.phr.service.impl;

import java.math.BigDecimal;
import java.math.RoundingMode;
import java.util.ArrayList;
import java.util.List;

import javax.annotation.Resource;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.data.domain.PageRequest;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;

import nta.med.core.domain.phr.PhrStandardHealth;
import nta.med.core.domain.phr.PhrStandardHealthBfp;
import nta.med.core.domain.phr.PhrStandardHealthBmi;
import nta.med.core.domain.phr.PhrStandardHealthHeight;
import nta.med.core.domain.phr.PhrStandardHealthWeight;
import nta.med.core.glossary.Language;
import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.phr.StandardHealthBfpRepository;
import nta.med.data.dao.phr.StandardHealthBmiRepository;
import nta.med.data.dao.phr.StandardHealthHeightRepository;
import nta.med.data.dao.phr.StandardHealthRepository;
import nta.med.data.dao.phr.StandardHealthWeightRepository;
import nta.med.data.model.phr.HealthBfpInfo;
import nta.med.data.model.phr.HealthBmiInfo;
import nta.med.data.model.phr.HealthHeightInfo;
import nta.med.data.model.phr.HealthWeightInfo;
import nta.med.ext.phr.glossary.ActiveFlag;
import nta.med.ext.phr.glossary.HealthType;
import nta.med.ext.phr.glossary.Message;
import nta.med.ext.phr.model.BmiModel;
import nta.med.ext.phr.model.DurationTypeStandardHealthModel;
import nta.med.ext.phr.model.HealthDataModel;
import nta.med.ext.phr.model.HealthInfoBaseOnTypeModel;
import nta.med.ext.phr.model.HeightModel;
import nta.med.ext.phr.model.PercFatModel;
import nta.med.ext.phr.model.StandardHealthModel;
import nta.med.ext.phr.model.WeightModel;
import nta.med.ext.phr.service.MailService;
import nta.med.ext.phr.service.StandardHealthService;

@Service
@Transactional
//@Transactional(value = DataSources.PHR)
public class StandardHealthServiceImpl implements StandardHealthService {

	@Resource
	private StandardHealthRepository standardHealthRepository;
	@Resource
	private StandardHealthHeightRepository standardHealthHeightRepository;
	@Resource
	private StandardHealthWeightRepository standardHealthWeightRepository;
	@Resource
	private StandardHealthBmiRepository standardHealthBmiRepository;
	@Resource
	private StandardHealthBfpRepository standardHealthBfpRepository;

//	@Autowired
//	Mapper mapper;

	@Autowired
	MailService mailService;

//	@Autowired
//	MedApiService medApiService;
	
	@Override
	public List<StandardHealthModel> getListStandardHealthByProfileId(Long profileId, PageRequest pageRequest) {
		List<StandardHealthModel> listStandardHealthModel = new ArrayList<StandardHealthModel>();
		List<PhrStandardHealth> listStandardHealth = standardHealthRepository.getHealthByProfileId(profileId, pageRequest);
		if(!CollectionUtils.isEmpty(listStandardHealth)){
			for (PhrStandardHealth phrStandardHealth : listStandardHealth) {

				if(phrStandardHealth != null){
					StandardHealthModel standardHealthModel = new StandardHealthModel();
					if(phrStandardHealth.getHeight() != null &&  phrStandardHealth.getWeight() != null){
							BigDecimal weight = phrStandardHealth.getWeight();
							BigDecimal height = phrStandardHealth.getHeight();
							height = height.multiply(height);
							BigDecimal bmi = weight.divide(height, 2, RoundingMode.HALF_UP);
							standardHealthModel.setBmi(bmi);
					}
					BeanUtils.copyProperties(phrStandardHealth, standardHealthModel, Language.JAPANESE.toString());
					listStandardHealthModel.add(standardHealthModel);
				}

			}
		}
		return listStandardHealthModel;
	}
	
	@Override
	public StandardHealthModel getStandardHealthDetail(Long profileId, String healthTypeId, Long healthId) {
		
		if(HealthType.HEIGHT.getValue().equals(healthTypeId)){
			PhrStandardHealthHeight standardHealthHeight = standardHealthHeightRepository.getHealthHeightByProfileId(healthId, profileId);
			if(standardHealthHeight != null){
				StandardHealthModel standardHealthModel = new StandardHealthModel();
				BeanUtils.copyProperties(standardHealthHeight, standardHealthModel, Language.JAPANESE.toString());
				return standardHealthModel;
			}
		}
		
		if(HealthType.WEIGHT.getValue().equals(healthTypeId)){
			PhrStandardHealthWeight standardHealthWeight = standardHealthWeightRepository.getHealthWeightByProfileId(healthId, profileId);
			if(standardHealthWeight != null){
				StandardHealthModel standardHealthModel = new StandardHealthModel();
				BeanUtils.copyProperties(standardHealthWeight, standardHealthModel, Language.JAPANESE.toString());
				return standardHealthModel;
			}
		}
		
		if(HealthType.BMI.getValue().equals(healthTypeId)){
			PhrStandardHealthBmi standardHealthBmi = standardHealthBmiRepository.getHealthBmiByProfileId(healthId, profileId);
			if(standardHealthBmi != null){
				StandardHealthModel standardHealthModel = new StandardHealthModel();
				BeanUtils.copyProperties(standardHealthBmi, standardHealthModel, Language.JAPANESE.toString());
				return standardHealthModel;
			}
		}
		
		if(HealthType.BFP.getValue().equals(healthTypeId)){
			PhrStandardHealthBfp standardHealthBfp = standardHealthBfpRepository.getHealthBfpByProfileId(healthId, profileId);
			if(standardHealthBfp != null){
				StandardHealthModel standardHealthModel = new StandardHealthModel();
				BeanUtils.copyProperties(standardHealthBfp, standardHealthModel, Language.JAPANESE.toString());
				return standardHealthModel;
			}
		}
		
		return new StandardHealthModel();
	}
	public StandardHealthModel addStandardHealth(StandardHealthModel standardHealthModel, Long profileId)
	{
		if (standardHealthModel.getDatetimeRecord() == null) {
			standardHealthModel.setMessage(Message.DATETIME_RECORD_REQUIRED.getValue());
			return standardHealthModel;
		}
		if(standardHealthModel.getHeight() != null)
		{
			PhrStandardHealthHeight standardHealthHeight = new PhrStandardHealthHeight();
			BeanUtils.copyProperties(standardHealthModel, standardHealthHeight, Language.JAPANESE.toString());
			standardHealthHeight.setProfileId(profileId);
			standardHealthHeightRepository.save(standardHealthHeight);
			BeanUtils.copyProperties(standardHealthHeight, standardHealthModel, Language.JAPANESE.toString());
			return standardHealthModel;
		}

		if(standardHealthModel.getHeight() != null)
		{
			PhrStandardHealthHeight standardHealthHeight = new PhrStandardHealthHeight();
			BeanUtils.copyProperties(standardHealthModel, standardHealthHeight, Language.JAPANESE.toString());
			standardHealthHeight.setProfileId(profileId);
			standardHealthHeightRepository.save(standardHealthHeight);
			BeanUtils.copyProperties(standardHealthHeight, standardHealthModel, Language.JAPANESE.toString());
			return standardHealthModel;
		}


		return standardHealthModel;
	}
	// SH03 + SH04
	@Override
	public StandardHealthModel updateStandardHealthByType(StandardHealthModel standardHealthModel, String healthType, Long profileId) {
		if (standardHealthModel.getDatetimeRecord() == null) {
			standardHealthModel.setMessage(Message.DATETIME_RECORD_REQUIRED.getValue());
			return standardHealthModel;
		}
		if(HealthType.HEIGHT.getValue().equals(healthType)){
			if(standardHealthModel.getHeight() == null){
				standardHealthModel.setMessage(Message.HEALTH_HEIGHT_REQUIRED.getValue());
				return standardHealthModel;
			}
			PhrStandardHealthHeight standardHealthHeight = new PhrStandardHealthHeight(); 
			if(standardHealthModel.getId() != null){
				standardHealthHeight = standardHealthHeightRepository.getHealthHeightByProfileId(standardHealthModel.getId(), profileId);
				if(standardHealthHeight == null){
					standardHealthModel.setMessage(Message.HEALTH_NOT_FOUND.getValue());
					return standardHealthModel;
				}
			}
			BeanUtils.copyProperties(standardHealthModel, standardHealthHeight, Language.JAPANESE.toString());
			standardHealthHeight.setProfileId(profileId);
			standardHealthHeightRepository.save(standardHealthHeight);
			BeanUtils.copyProperties(standardHealthHeight, standardHealthModel, Language.JAPANESE.toString());
			return standardHealthModel;
		}
		
		if(HealthType.WEIGHT.getValue().equals(healthType)){
			if(standardHealthModel.getWeight() == null){
				standardHealthModel.setMessage(Message.HEALTH_WEIGHT_REQUIRED.getValue());
				return standardHealthModel;
			}
			if(standardHealthModel.getPercFat() == null){
				standardHealthModel.setMessage(Message.HEALTH_PERC_FAT_REQUIRED.getValue());
				return standardHealthModel;
			}
			PhrStandardHealthWeight standardHealthWeight = new PhrStandardHealthWeight(); 
			if(standardHealthModel.getId() != null){
				standardHealthWeight = standardHealthWeightRepository.getHealthWeightByProfileId(standardHealthModel.getId(), profileId);
				if(standardHealthWeight == null){
					standardHealthModel.setMessage(Message.HEALTH_NOT_FOUND.getValue());
					return standardHealthModel;
				}
			} else {
				// insert bfp
				PhrStandardHealthBfp standardHealthBfp = new PhrStandardHealthBfp();
				BeanUtils.copyProperties(standardHealthModel, standardHealthBfp, Language.JAPANESE.toString());
				standardHealthBfp.setProfileId(profileId);
				standardHealthBfpRepository.save(standardHealthBfp);
			}
			BeanUtils.copyProperties(standardHealthModel, standardHealthWeight, Language.JAPANESE.toString());
			standardHealthWeight.setProfileId(profileId);
			standardHealthWeightRepository.save(standardHealthWeight);
			BeanUtils.copyProperties(standardHealthWeight, standardHealthModel, Language.JAPANESE.toString());
			return standardHealthModel;
		}		
		
		if(HealthType.BMI.getValue().equals(healthType)){
			if(standardHealthModel.getBmi() == null){
				standardHealthModel.setMessage(Message.HEALTH_BMI_REQUIRED.getValue());
				return standardHealthModel;
			}
			PhrStandardHealthBmi standardHealthBmi = new PhrStandardHealthBmi(); 
			if(standardHealthModel.getId() != null){
				standardHealthBmi = standardHealthBmiRepository.getHealthBmiByProfileId(standardHealthModel.getId(), profileId);
				if(standardHealthBmi == null){
					standardHealthModel.setMessage(Message.HEALTH_NOT_FOUND.getValue());
					return standardHealthModel;
				}
			}
			BeanUtils.copyProperties(standardHealthModel, standardHealthBmi, Language.JAPANESE.toString());
			standardHealthBmi.setProfileId(profileId);
			standardHealthBmiRepository.save(standardHealthBmi);
			BeanUtils.copyProperties(standardHealthBmi, standardHealthModel, Language.JAPANESE.toString());
			return standardHealthModel;
		} if(HealthType.BFP.getValue().equals(healthType) && standardHealthModel.getId() != null){
			if(standardHealthModel.getPercFat() == null){
				standardHealthModel.setMessage(Message.HEALTH_PERC_FAT_REQUIRED.getValue());
				return standardHealthModel;
			}
			// update bfp
			PhrStandardHealthBfp standardHealthBfp = new PhrStandardHealthBfp(); 
			if(standardHealthModel.getId() != null){
				standardHealthBfp = standardHealthBfpRepository.getHealthBfpByProfileId(standardHealthModel.getId(), profileId);
				if(standardHealthBfp == null){
					standardHealthModel.setMessage(Message.HEALTH_NOT_FOUND.getValue());
					return standardHealthModel;
				}
			}
			BeanUtils.copyProperties(standardHealthModel, standardHealthBfp, Language.JAPANESE.toString());
			standardHealthBfp.setProfileId(profileId);
			standardHealthBfpRepository.save(standardHealthBfp);
			BeanUtils.copyProperties(standardHealthBfp, standardHealthModel, Language.JAPANESE.toString());
			return standardHealthModel;
		} else {
			standardHealthModel.setMessage(Message.TEMP_TYPE_NOT_EXIST.getValue());
		}
		return standardHealthModel;
	}
	
	@Override
	public Boolean deleteStandardHealth(Long profileId, String healthTypeId, Long healthId) {
		Integer result =0;
		if(HealthType.HEIGHT.getValue().equals(healthTypeId)){
			result = standardHealthHeightRepository.updateActiveFlg(healthId, profileId, ActiveFlag.INACTIVE.toInt());
		}
		if(HealthType.WEIGHT.getValue().equals(healthTypeId)){
			result = standardHealthWeightRepository.updateActiveFlg(healthId, profileId, ActiveFlag.INACTIVE.toInt());
		} 
		if(HealthType.BMI.getValue().equals(healthTypeId)){
			result = standardHealthBmiRepository.updateActiveFlg(healthId, profileId, ActiveFlag.INACTIVE.toInt());
		} 
		if(HealthType.BFP.getValue().equals(healthTypeId)){
			result = standardHealthBfpRepository.updateActiveFlg(healthId, profileId, ActiveFlag.INACTIVE.toInt());
		} 
		if(result != null && result > 0){
			return true;
		}
		return false;
	}

	@Override
	public HealthInfoBaseOnTypeModel getHealthInfoBaseOnTypeModel(Long profileId, String healthType, PageRequest pageRequest) {
		HealthInfoBaseOnTypeModel healthInfo = new HealthInfoBaseOnTypeModel();
		healthInfo.setProfileId(profileId);
		healthInfo.setType(healthType);
		List<HealthDataModel> healthDatas =  new ArrayList<HealthDataModel>();
		switch (healthType) {
		case "01":
			List<PhrStandardHealthHeight> healthHeights = standardHealthHeightRepository.getPhrStandardHealthHeightByprofileId(profileId, pageRequest);
			if(!CollectionUtils.isEmpty(healthHeights)){
				for(PhrStandardHealthHeight item : healthHeights){
					HealthDataModel healthData = new HealthDataModel();
					BeanUtils.copyProperties(item, healthData, Language.JAPANESE.toString());
					healthDatas.add(healthData);
				}
			}
			healthInfo.setHealthInfo(healthDatas);
			break;
		case "02":
			List<PhrStandardHealthWeight> healthWeights = standardHealthWeightRepository.getPhrStandardHealthWeightByprofileId(profileId, pageRequest);
			if(!CollectionUtils.isEmpty(healthWeights)){
				for(PhrStandardHealthWeight item : healthWeights){
					HealthDataModel healthData = new HealthDataModel();
					BeanUtils.copyProperties(item, healthData, Language.JAPANESE.toString());
					healthDatas.add(healthData);
				}
			}
			healthInfo.setHealthInfo(healthDatas);
			break;
		case "03":
			List<PhrStandardHealthBmi> healthBmis = standardHealthBmiRepository.getPhrStandardHealthBmiByprofileId(profileId, pageRequest);
			if(!CollectionUtils.isEmpty(healthBmis)){
				for(PhrStandardHealthBmi item : healthBmis){
					HealthDataModel healthData = new HealthDataModel();
					BeanUtils.copyProperties(item, healthData, Language.JAPANESE.toString());
					healthDatas.add(healthData);
				}
			}
			healthInfo.setHealthInfo(healthDatas);
			break;
		case "04":
			List<PhrStandardHealthBfp> healthBfps = standardHealthBfpRepository.getPhrStandardHealthBfpByprofileId(profileId, pageRequest);
			if(!CollectionUtils.isEmpty(healthBfps)){
				for(PhrStandardHealthBfp item : healthBfps){
					HealthDataModel healthData = new HealthDataModel();
					BeanUtils.copyProperties(item, healthData, Language.JAPANESE.toString());
					healthDatas.add(healthData);
				}
			}
			healthInfo.setHealthInfo(healthDatas);
			break;
		default:
			break;
		}
		return healthInfo;
	}
	
	
	
	@Override
	public DurationTypeStandardHealthModel getStandardHealthInfo(Long profileId, String healthTypeId, Long durationType) {
		
		DurationTypeStandardHealthModel healthInfo = new DurationTypeStandardHealthModel();
		healthInfo.setProfileId(profileId.toString());
		List<HeightModel> standardHeightInfos = new ArrayList<>();
		List<WeightModel> standardWeightInfos = new ArrayList<>();
		List<BmiModel> standardBmiInfos = new ArrayList<>();
		List<PercFatModel> standardPercFatInfos = new ArrayList<>();
		
		if (HealthType.HEIGHT.getValue().equals(healthTypeId) || HealthType.HEALTH_ALL.getValue().equals(healthTypeId)) {
			List<HealthHeightInfo> standardHealthHeights = standardHealthHeightRepository
					.getPhrStandardHealthHeightByprofileIdAndType(profileId, durationType);
			if (!CollectionUtils.isEmpty(standardHealthHeights)) {
				for (HealthHeightInfo info : standardHealthHeights) {
					HeightModel item = new HeightModel();
					BeanUtils.copyProperties(info, item, Language.JAPANESE.toString());
					item.setHealthId(info.getId().toString());
					standardHeightInfos.add(item);
				}
			}
			healthInfo.setHeightInfo(standardHeightInfos);
		}
		if (HealthType.WEIGHT.getValue().equals(healthTypeId) || HealthType.HEALTH_ALL.getValue().equals(healthTypeId)) {
			List<HealthWeightInfo> standardHealthWeights = standardHealthWeightRepository
					.getPhrStandardHealthWeightByprofileIdAndType(profileId, durationType);
			if (!CollectionUtils.isEmpty(standardHealthWeights)) {
				for (HealthWeightInfo info : standardHealthWeights) {
					WeightModel item = new WeightModel();
					BeanUtils.copyProperties(info, item, Language.JAPANESE.toString());
					item.setHealthId(info.getId().toString());
					standardWeightInfos.add(item);
				}
			}
			healthInfo.setWeightInfo(standardWeightInfos);
		}
		if (HealthType.BMI.getValue().equals(healthTypeId) || HealthType.HEALTH_ALL.getValue().equals(healthTypeId)) {
			List<HealthBmiInfo> standardHealthBmis = standardHealthBmiRepository
					.getPhrStandardHealthBmiByprofileIdAndType(profileId, durationType);
			if (!CollectionUtils.isEmpty(standardHealthBmis)) {
				for (HealthBmiInfo info : standardHealthBmis) {
					BmiModel item = new BmiModel();
					BeanUtils.copyProperties(info, item, Language.JAPANESE.toString());
					item.setHealthId(info.getId().toString());
					standardBmiInfos.add(item);
				}
			}
			healthInfo.setBmiInfo(standardBmiInfos);
		}
		if (HealthType.BFP.getValue().equals(healthTypeId) || HealthType.HEALTH_ALL.getValue().equals(healthTypeId)) {
			List<HealthBfpInfo> standardHealthPercFats = standardHealthBfpRepository
					.getPhrStandardHealthBfpByprofileIdAndType(profileId, durationType);
			if (!CollectionUtils.isEmpty(standardHealthPercFats)) {
				for (HealthBfpInfo info : standardHealthPercFats) {
					PercFatModel item = new PercFatModel();
					BeanUtils.copyProperties(info, item, Language.JAPANESE.toString());
					item.setHealthId(info.getId().toString());
					standardPercFatInfos.add(item);
				}
			}
			healthInfo.setPercFatInfo(standardPercFatInfos);
		}
		return healthInfo;
	}

	@Override
	public List<StandardHealthModel> addStandardHealthListByType(List<StandardHealthModel> standardHealthModels, Long profileId) {
		List<StandardHealthModel> listStandardHealth = new ArrayList<>();

		List<PhrStandardHealthHeight> standardHealthHeights= new ArrayList<>();
		List<PhrStandardHealthWeight> standardHealthWeights= new ArrayList<>();
		List<PhrStandardHealthBmi> standardHealthBmis= new ArrayList<>();
		List<PhrStandardHealthBfp> standardHealthBfps= new ArrayList<>();
		for (StandardHealthModel standardHealthModel : standardHealthModels) {
			if(HealthType.HEIGHT.getValue().equals(standardHealthModel.getHealthType())){
				PhrStandardHealthHeight standardHealthHeight = new PhrStandardHealthHeight(); 
				BeanUtils.copyProperties(standardHealthModel, standardHealthHeight, Language.JAPANESE.toString());
				standardHealthHeight.setProfileId(profileId);
				standardHealthHeights.add(standardHealthHeight);
			}
			if(HealthType.WEIGHT.getValue().equals(standardHealthModel.getHealthType())){
				PhrStandardHealthWeight standardHealthWeight = new PhrStandardHealthWeight(); 
				BeanUtils.copyProperties(standardHealthModel, standardHealthWeight, Language.JAPANESE.toString());
				standardHealthWeight.setProfileId(profileId);
				standardHealthWeights.add(standardHealthWeight);
			}		
			if(HealthType.BMI.getValue().equals(standardHealthModel.getHealthType())){
				PhrStandardHealthBmi standardHealthBmi = new PhrStandardHealthBmi(); 
				BeanUtils.copyProperties(standardHealthModel, standardHealthBmi, Language.JAPANESE.toString());
				standardHealthBmi.setProfileId(profileId);
				standardHealthBmis.add(standardHealthBmi);
			} 
			if(HealthType.BFP.getValue().equals(standardHealthModel.getHealthType())){
				PhrStandardHealthBfp standardHealthBfp = new PhrStandardHealthBfp(); 
				BeanUtils.copyProperties(standardHealthModel, standardHealthBfp, Language.JAPANESE.toString());
				standardHealthBfp.setProfileId(profileId);
				standardHealthBfps.add(standardHealthBfp);
			}
		}
		
		// save data
		if(!CollectionUtils.isEmpty(standardHealthHeights)){
			standardHealthHeights = standardHealthHeightRepository.save(standardHealthHeights);
			for (PhrStandardHealthHeight standardHealthHeight : standardHealthHeights) {
				StandardHealthModel standardHealthModel = new StandardHealthModel();
				BeanUtils.copyProperties(standardHealthHeight, standardHealthModel, Language.JAPANESE.toString());
				listStandardHealth.add(standardHealthModel);
			}
		}
		if(!CollectionUtils.isEmpty(standardHealthWeights)){
			standardHealthWeights = standardHealthWeightRepository.save(standardHealthWeights);
			for (PhrStandardHealthWeight standardHealthWeight : standardHealthWeights) {
				StandardHealthModel standardHealthModel = new StandardHealthModel();
				BeanUtils.copyProperties(standardHealthWeight, standardHealthModel, Language.JAPANESE.toString());
				listStandardHealth.add(standardHealthModel);
			}
		}
		if(!CollectionUtils.isEmpty(standardHealthBmis)){
			standardHealthBmis = standardHealthBmiRepository.save(standardHealthBmis);
			for (PhrStandardHealthBmi standardHealthBmi : standardHealthBmis) {
				StandardHealthModel standardHealthModel = new StandardHealthModel();
				BeanUtils.copyProperties(standardHealthBmi, standardHealthModel, Language.JAPANESE.toString());
				listStandardHealth.add(standardHealthModel);
			}
		}
		if(!CollectionUtils.isEmpty(standardHealthBfps)){
			standardHealthBfps = standardHealthBfpRepository.save(standardHealthBfps);
			for (PhrStandardHealthBfp standardHealthBfp : standardHealthBfps) {
				StandardHealthModel standardHealthModel = new StandardHealthModel();
				BeanUtils.copyProperties(standardHealthBfp, standardHealthModel, Language.JAPANESE.toString());
				listStandardHealth.add(standardHealthModel);
			}
		}
		return listStandardHealth;
	}
}
