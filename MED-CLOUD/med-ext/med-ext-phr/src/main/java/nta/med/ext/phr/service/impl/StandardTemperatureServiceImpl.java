package nta.med.ext.phr.service.impl;

import java.util.ArrayList;
import java.util.List;

import javax.annotation.Resource;

import nta.med.ext.phr.model.*;
import org.springframework.data.domain.PageRequest;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;

import nta.med.core.domain.phr.PhrStandardFitnessDistance;
import nta.med.core.domain.phr.PhrStandardFitnessStep;
import nta.med.core.domain.phr.PhrStandardTempBp;
import nta.med.core.domain.phr.PhrStandardTempBreath;
import nta.med.core.domain.phr.PhrStandardTempHeartrate;
import nta.med.core.domain.phr.PhrStandardTempTemperature;
import nta.med.core.glossary.Language;
import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.phr.StandardFitnessDistanceRepository;
import nta.med.data.dao.phr.StandardFitnessStepRepository;
import nta.med.data.dao.phr.StandardTempBpRepository;
import nta.med.data.dao.phr.StandardTempBreathRepository;
import nta.med.data.dao.phr.StandardTempHeartrateRepository;
import nta.med.data.dao.phr.StandardTempTemperatureRepository;
import nta.med.data.dao.phr.StandardTemperatureRepository;
import nta.med.data.model.phr.StandardFitnessDistanceInfo;
import nta.med.data.model.phr.StandardFitnessStepInfo;
import nta.med.data.model.phr.StandardTempBpInfo;
import nta.med.data.model.phr.StandardTempBreathInfo;
import nta.med.data.model.phr.StandardTempHeartrateInfo;
import nta.med.data.model.phr.StandardTempTemperatureInfo;
import nta.med.ext.phr.glossary.ActiveFlag;
import nta.med.ext.phr.glossary.FitnessType;
import nta.med.ext.phr.glossary.Message;
import nta.med.ext.phr.glossary.TemperatureType;
import nta.med.ext.phr.service.StandardTemperatureService;

@Service
@Transactional
//@Transactional(value = DataSources.PHR)
public class StandardTemperatureServiceImpl implements StandardTemperatureService{

	@Resource
	private StandardTemperatureRepository standardTemperatureRepository; 
	
	@Resource
	private StandardTempTemperatureRepository standardTempTemperatureRepository; 
	
	@Resource
	private StandardTempHeartrateRepository standardTempHeartrateRepository; 
	
	@Resource
	private StandardTempBreathRepository standardTempBreathRepository; 
	
	@Resource
	private StandardTempBpRepository standardTempBpRepository; 
	
	@Resource
	private StandardFitnessStepRepository standardFitnessStepRepository;
	
	@Resource
	private StandardFitnessDistanceRepository standardFitnessDistanceRepository;
	
	// temperature implement
	// ST01
	@Override
	public TemperatureInfoBaseOnTypeModel getTemperatureLimitBaseOnTypeModel(Long profileId, String temperatureType, PageRequest pageRequest) {
		TemperatureInfoBaseOnTypeModel temperatureInfo = new TemperatureInfoBaseOnTypeModel();
		temperatureInfo.setProfileId(profileId);
		temperatureInfo.setType(temperatureType);
		List<StandardTemperatureModel> standardTemperatureModels =  new ArrayList<StandardTemperatureModel>();
		if(TemperatureType.TEMP_TEMPERATURE.getValue().equals(temperatureType)){
			List<PhrStandardTempTemperature> standardTempTemperatures = standardTempTemperatureRepository.getStandardTempTemperatureByprofileId(profileId, pageRequest);
			if(!CollectionUtils.isEmpty(standardTempTemperatures)){
				for(PhrStandardTempTemperature item : standardTempTemperatures){
					StandardTemperatureModel standardTemperatureModel = new StandardTemperatureModel();
					BeanUtils.copyProperties(item, standardTemperatureModel, Language.JAPANESE.toString());
					standardTemperatureModels.add(standardTemperatureModel);
				}
				temperatureInfo.setStandardTemperatureModel(standardTemperatureModels);
			}
		} else if(TemperatureType.TEMP_HEARTRATE.getValue().equals(temperatureType)){
			List<PhrStandardTempHeartrate> standardTempHeartrates = standardTempHeartrateRepository.getStandardTempHeartrateByprofileId(profileId, pageRequest);
			if(!CollectionUtils.isEmpty(standardTempHeartrates)){
				for(PhrStandardTempHeartrate item : standardTempHeartrates){
					StandardTemperatureModel standardTemperatureModel = new StandardTemperatureModel();
					BeanUtils.copyProperties(item, standardTemperatureModel, Language.JAPANESE.toString());
					standardTemperatureModels.add(standardTemperatureModel);
				}
				temperatureInfo.setStandardTemperatureModel(standardTemperatureModels);
			}
		} else if(TemperatureType.TEMP_BREATH.getValue().equals(temperatureType)){
			List<PhrStandardTempBreath> standardTempBreaths = standardTempBreathRepository.getStandardTempBreathByprofileId(profileId, pageRequest);
			if(!CollectionUtils.isEmpty(standardTempBreaths)){
				for(PhrStandardTempBreath item : standardTempBreaths){
					StandardTemperatureModel standardTemperatureModel = new StandardTemperatureModel();
					BeanUtils.copyProperties(item, standardTemperatureModel, Language.JAPANESE.toString());
					standardTemperatureModels.add(standardTemperatureModel);
				}
				temperatureInfo.setStandardTemperatureModel(standardTemperatureModels);
			}
		} else if(TemperatureType.TEMP_BP.getValue().equals(temperatureType)){
			List<PhrStandardTempBp> standardTempBps = standardTempBpRepository.getStandardTempBpByprofileId(profileId, pageRequest);
			if(!CollectionUtils.isEmpty(standardTempBps)){
				for(PhrStandardTempBp item : standardTempBps){
					StandardTemperatureModel standardTemperatureModel = new StandardTemperatureModel();
					BeanUtils.copyProperties(item, standardTemperatureModel, Language.JAPANESE.toString());
					standardTemperatureModels.add(standardTemperatureModel);
				}
				temperatureInfo.setStandardTemperatureModel(standardTemperatureModels);
			}
		} else {
			temperatureInfo.setMessage(Message.TEMP_TYPE_NOT_EXIST.getValue());
		}
		
		return temperatureInfo;
	}
	
	// ST02
	@Override
	public StandardTemperatureModel getTemperatureDetailByTypeModel(Long profileId, String temperatureType, Long temperatureId) {
		StandardTemperatureModel standardTemperatureModel = new StandardTemperatureModel();
		if(TemperatureType.TEMP_TEMPERATURE.getValue().equals(temperatureType)){
			PhrStandardTempTemperature standardTempTemperature = standardTempTemperatureRepository.getStandardTempTemperatureByIdAndProfileIdAndActiveFlg(temperatureId, profileId);
			if(standardTempTemperature != null){
				BeanUtils.copyProperties(standardTempTemperature, standardTemperatureModel, Language.JAPANESE.toString());
				return standardTemperatureModel;
			} else {
				standardTemperatureModel.setMessage(Message.TEMP_NOT_FOUND.getValue());
				return standardTemperatureModel;
			}
		} else if(TemperatureType.TEMP_HEARTRATE.getValue().equals(temperatureType)){
			PhrStandardTempHeartrate standardTempHeartrate = standardTempHeartrateRepository.getStandardTempHeartrateByIdAndProfileIdAndActiveFlg(temperatureId, profileId);
			if(standardTempHeartrate != null){
				BeanUtils.copyProperties(standardTempHeartrate, standardTemperatureModel, Language.JAPANESE.toString());
				return standardTemperatureModel;
			} else {
				standardTemperatureModel.setMessage(Message.TEMP_NOT_FOUND.getValue());
				return standardTemperatureModel;
			}
		} else if(TemperatureType.TEMP_BREATH.getValue().equals(temperatureType)){
			PhrStandardTempBreath standardTempBreath = standardTempBreathRepository.getStandardTempBreathByIdAndProfileIdAndActiveFlg(temperatureId, profileId);
			if(standardTempBreath != null){
				BeanUtils.copyProperties(standardTempBreath, standardTemperatureModel, Language.JAPANESE.toString());
				return standardTemperatureModel;
			} else {
				standardTemperatureModel.setMessage(Message.TEMP_NOT_FOUND.getValue());
				return standardTemperatureModel;
			}
		} else if(TemperatureType.TEMP_BP.getValue().equals(temperatureType)){
			PhrStandardTempBp standardTempBp = standardTempBpRepository.getStandardTempBpByIdAndProfileIdAndActiveFlg(temperatureId, profileId);
			if(standardTempBp != null){
				BeanUtils.copyProperties(standardTempBp, standardTemperatureModel, Language.JAPANESE.toString());
				return standardTemperatureModel;
			} else {
				standardTemperatureModel.setMessage(Message.TEMP_NOT_FOUND.getValue());
				return standardTemperatureModel;
			}
		} else {
			standardTemperatureModel.setMessage(Message.TEMP_TYPE_NOT_EXIST.getValue());
		}
		
		return standardTemperatureModel;
	}
	
	// ST03 + ST04
	@Override
	public StandardTemperatureModel updateStandardTempByType(StandardTemperatureModel standardTemperatureModel, String temperatureType, Long profileId) {
		if (standardTemperatureModel.getDateMeasure() == null) {
			standardTemperatureModel.setMessage(Message.DATETIME_RECORD_REQUIRED.getValue());
			return standardTemperatureModel;
		}
		if(TemperatureType.TEMP_TEMPERATURE.getValue().equals(temperatureType)){
			if(standardTemperatureModel.getTemperature() == null){
				standardTemperatureModel.setMessage(Message.TEMP_TEMPERATURE_REQUIRED.getValue());
				return standardTemperatureModel;
			}
			PhrStandardTempTemperature standardTempTemperature = new PhrStandardTempTemperature(); 
			if(standardTemperatureModel.getId() != null){
				standardTempTemperature = standardTempTemperatureRepository.getStandardTempTemperatureByIdAndProfileIdAndActiveFlg(standardTemperatureModel.getId(), profileId);
				if(standardTempTemperature == null){
					standardTemperatureModel.setMessage(Message.TEMP_NOT_FOUND.getValue());
					return standardTemperatureModel;
				}
			}
			BeanUtils.copyProperties(standardTemperatureModel, standardTempTemperature, Language.JAPANESE.toString());
			standardTempTemperature.setProfileId(profileId);
			standardTempTemperatureRepository.save(standardTempTemperature);
			BeanUtils.copyProperties(standardTempTemperature, standardTemperatureModel, Language.JAPANESE.toString());
			return standardTemperatureModel;
		}	
		
		if(TemperatureType.TEMP_HEARTRATE.getValue().equals(temperatureType)){
			if(standardTemperatureModel.getHeartrate() == null){
				standardTemperatureModel.setMessage(Message.TEMP_HEARTRATE_REQUIRED.getValue());
				return standardTemperatureModel;
			}
			PhrStandardTempHeartrate standardTempHeartrate = new PhrStandardTempHeartrate(); 
			if(standardTemperatureModel.getId() != null){
				standardTempHeartrate = standardTempHeartrateRepository.getStandardTempHeartrateByIdAndProfileIdAndActiveFlg(standardTemperatureModel.getId(), profileId);
				if(standardTempHeartrate == null){
					standardTemperatureModel.setMessage(Message.TEMP_NOT_FOUND.getValue());
					return standardTemperatureModel;
				}
			}
			BeanUtils.copyProperties(standardTemperatureModel, standardTempHeartrate, Language.JAPANESE.toString());
			standardTempHeartrate.setProfileId(profileId);
			standardTempHeartrateRepository.save(standardTempHeartrate);
			BeanUtils.copyProperties(standardTempHeartrate, standardTemperatureModel, Language.JAPANESE.toString());
			return standardTemperatureModel;
		}		
		
		if(TemperatureType.TEMP_BREATH.getValue().equals(temperatureType)){
			if(standardTemperatureModel.getBreath() == null){
				standardTemperatureModel.setMessage(Message.TEMP_BREATH_REQUIRED.getValue());
				return standardTemperatureModel;
			}
			PhrStandardTempBreath standardTempBreath = new PhrStandardTempBreath(); 
			if(standardTemperatureModel.getId() != null){
				standardTempBreath = standardTempBreathRepository.getStandardTempBreathByIdAndProfileIdAndActiveFlg(standardTemperatureModel.getId(), profileId);
				if(standardTempBreath == null){
					standardTemperatureModel.setMessage(Message.TEMP_NOT_FOUND.getValue());
					return standardTemperatureModel;
				}
			}
			BeanUtils.copyProperties(standardTemperatureModel, standardTempBreath, Language.JAPANESE.toString());
			standardTempBreath.setProfileId(profileId);
			standardTempBreathRepository.save(standardTempBreath);
			BeanUtils.copyProperties(standardTempBreath, standardTemperatureModel, Language.JAPANESE.toString());
			return standardTemperatureModel;
		}
		
		if(TemperatureType.TEMP_BP.getValue().equals(temperatureType)){
			if(standardTemperatureModel.getBpFrom() == null || standardTemperatureModel.getBpTo() == null){
				standardTemperatureModel.setMessage(Message.TEMP_BP_REQUIRED.getValue());
				return standardTemperatureModel;
			}
			PhrStandardTempBp standardTempBp = new PhrStandardTempBp(); 
			if(standardTemperatureModel.getId() != null){
				standardTempBp = standardTempBpRepository.getStandardTempBpByIdAndProfileIdAndActiveFlg(standardTemperatureModel.getId(), profileId);
				if(standardTempBp == null){
					standardTemperatureModel.setMessage(Message.TEMP_NOT_FOUND.getValue());
					return standardTemperatureModel;
				}
			}
			BeanUtils.copyProperties(standardTemperatureModel, standardTempBp, Language.JAPANESE.toString());
			standardTempBp.setProfileId(profileId);
			standardTempBpRepository.save(standardTempBp);
			BeanUtils.copyProperties(standardTempBp, standardTemperatureModel, Language.JAPANESE.toString());
			return standardTemperatureModel;
		} else {
			standardTemperatureModel.setMessage(Message.TEMP_TYPE_NOT_EXIST.getValue());
		}
		return standardTemperatureModel;
	}
	
	// ST05
	@Override
	public StandardTemperatureModel deleteStandardTempByTemperatureType(Long profileId, String temperatureType, Long temperatureId) {
		StandardTemperatureModel standardTemperatureModel = new StandardTemperatureModel();
		if(TemperatureType.TEMP_TEMPERATURE.getValue().equals(temperatureType)){
			PhrStandardTempTemperature standardTempTemperature = standardTempTemperatureRepository.getStandardTempTemperatureByIdAndProfileId(temperatureId, profileId);
			if(standardTempTemperature != null){
				if(ActiveFlag.ACTIVE.toInt() == standardTempTemperature.getActiveFlg()){
					standardTempTemperature.setActiveFlg(ActiveFlag.INACTIVE.toInt());
					standardTempTemperatureRepository.save(standardTempTemperature);
				} else {
					standardTemperatureModel.setMessage(Message.TEMP_TEMPERATURE_DELETED.getValue());
				}
				return standardTemperatureModel;
			} else {
				standardTemperatureModel.setMessage(Message.TEMP_NOT_FOUND.getValue());
				return standardTemperatureModel;
			}
		} else if(TemperatureType.TEMP_HEARTRATE.getValue().equals(temperatureType)){
			PhrStandardTempHeartrate standardTempHeartrate = standardTempHeartrateRepository.getStandardTempHeartrateByIdAndProfileId(temperatureId, profileId);
			if(standardTempHeartrate != null){
				if(ActiveFlag.ACTIVE.toInt() == standardTempHeartrate.getActiveFlg()){
					standardTempHeartrate.setActiveFlg(ActiveFlag.INACTIVE.toInt());
					standardTempHeartrateRepository.save(standardTempHeartrate);
				} else {
					standardTemperatureModel.setMessage(Message.TEMP_HEARTRATE_DELETED.getValue());
				}
				return standardTemperatureModel;
			} else {
				standardTemperatureModel.setMessage(Message.TEMP_NOT_FOUND.getValue());
				return standardTemperatureModel;
			}
		} else if(TemperatureType.TEMP_BREATH.getValue().equals(temperatureType)){
			PhrStandardTempBreath standardTempBreath = standardTempBreathRepository.getStandardTempBreathByIdAndProfileId(temperatureId, profileId);
			if(standardTempBreath != null){
				if(ActiveFlag.ACTIVE.toInt() == standardTempBreath.getActiveFlg()){
					standardTempBreath.setActiveFlg(ActiveFlag.INACTIVE.toInt());
					standardTempBreathRepository.save(standardTempBreath);
				} else {
					standardTemperatureModel.setMessage(Message.TEMP_BREATH_DELETED.getValue());
				}
				return standardTemperatureModel;
			} else {
				standardTemperatureModel.setMessage(Message.TEMP_NOT_FOUND.getValue());
				return standardTemperatureModel;
			}
		} else if(TemperatureType.TEMP_BP.getValue().equals(temperatureType)){
			PhrStandardTempBp standardTempBp = standardTempBpRepository.getStandardTempBpByIdAndProfileId(temperatureId, profileId);
			if(standardTempBp != null){
				if(ActiveFlag.ACTIVE.toInt() == standardTempBp.getActiveFlg()){
					standardTempBp.setActiveFlg(ActiveFlag.INACTIVE.toInt());
					standardTempBpRepository.save(standardTempBp);
				} else {
					standardTemperatureModel.setMessage(Message.TEMP_BP_DELETED.getValue());
				}
				return standardTemperatureModel;
			} else {
				standardTemperatureModel.setMessage(Message.TEMP_NOT_FOUND.getValue());
				return standardTemperatureModel;
			}
		} else {
			standardTemperatureModel.setMessage(Message.TEMP_TYPE_NOT_EXIST.getValue());
		}
		
		return standardTemperatureModel;
	}
	
	// ST10
	@Override
	public DurationTypeStandardTempModel getStandardTempInfoByDurationType(Long profileId, String temperatureType, Long durationType) {
		boolean invalidTempType = true;
		DurationTypeStandardTempModel tempModel = new DurationTypeStandardTempModel();
		tempModel.setProfileId(profileId);
		tempModel.setType(temperatureType);
		List<StandardTempTemperatureModel> standardTempTemperatureModels = new ArrayList<>();
		List<StandardTempHeartRateChartViewModel> standardTempHeartrateModels = new ArrayList<>();
		List<StandardTempBreathModel> standardTempBreathModels = new ArrayList<>();
		List<StandardTempBpChartViewModel> standardTempBpModels = new ArrayList<>();
		
		if(TemperatureType.TEMP_TEMPERATURE.getValue().equals(temperatureType) || TemperatureType.TEMP_ALL.getValue().equals(temperatureType)){
			invalidTempType = false;
			List<StandardTempTemperatureInfo> standardTempTemperatureInfos = standardTempTemperatureRepository.getStandardTempTemperatureInfoByprofileIdAndDurationType(profileId, durationType);
			if (!CollectionUtils.isEmpty(standardTempTemperatureInfos)) {
				for (StandardTempTemperatureInfo info : standardTempTemperatureInfos) {
					StandardTempTemperatureModel item = new StandardTempTemperatureModel();
					BeanUtils.copyProperties(info, item, Language.JAPANESE.toString());
					item.setId(info.getId().longValue());
					standardTempTemperatureModels.add(item);
				}
				tempModel.setStandardTempTemperatureModel(standardTempTemperatureModels);
			}
		} 
		if (TemperatureType.TEMP_HEARTRATE.getValue().equals(temperatureType) || TemperatureType.TEMP_ALL.getValue().equals(temperatureType)) {
			invalidTempType = false;
			List<StandardTempHeartrateInfo> standardTempHeartrateInfos = standardTempHeartrateRepository.getStandardTempHeartrateInfoByprofileIdAndDurationType(profileId, durationType);
			if (!CollectionUtils.isEmpty(standardTempHeartrateInfos)) {
				for (StandardTempHeartrateInfo info : standardTempHeartrateInfos) {
					StandardTempHeartRateChartViewModel item = new StandardTempHeartRateChartViewModel();
					BeanUtils.copyProperties(info, item, Language.JAPANESE.toString());
					item.setId(info.getId().longValue());
					standardTempHeartrateModels.add(item);
				}
				tempModel.setStandardTempHeartrateModel(standardTempHeartrateModels);
			}
		}  
		if (TemperatureType.TEMP_BREATH.getValue().equals(temperatureType) || TemperatureType.TEMP_ALL.getValue().equals(temperatureType)) {
			invalidTempType = false;
			List<StandardTempBreathInfo> standardTempBreathInfos = standardTempBreathRepository.getStandardTempBreathInfoByprofileIdAndDurationType(profileId, durationType);
			if (!CollectionUtils.isEmpty(standardTempBreathInfos)) {
				for (StandardTempBreathInfo info : standardTempBreathInfos) {
					StandardTempBreathModel item = new StandardTempBreathModel();
					BeanUtils.copyProperties(info, item, Language.JAPANESE.toString());
					item.setId(info.getId().longValue());
					standardTempBreathModels.add(item);
				}
				tempModel.setStandardTempBreathModel(standardTempBreathModels);
			}
		}
		if (TemperatureType.TEMP_BP.getValue().equals(temperatureType) || TemperatureType.TEMP_ALL.getValue().equals(temperatureType)) {
			invalidTempType = false;
			List<StandardTempBpInfo> standardTempBpInfos = standardTempBpRepository.getStandardTempBpInfoByprofileIdAndDurationType(profileId, durationType);
			if (!CollectionUtils.isEmpty(standardTempBpInfos)) {
				for (StandardTempBpInfo info : standardTempBpInfos) {
					StandardTempBpChartViewModel item = new StandardTempBpChartViewModel();
					BeanUtils.copyProperties(info, item, Language.JAPANESE.toString());
					item.setId(info.getId().longValue());
					standardTempBpModels.add(item);
				}
				tempModel.setStandardTempBpModel(standardTempBpModels);
			}
		}
		if(invalidTempType){
			tempModel.setMessage(Message.TEMP_TYPE_NOT_EXIST.getValue());
		}
		return tempModel;
	}

	// Fitness implement
	// SFN01
	@Override
	public FitnessInfoBaseOnTypeModel getStandardFitnessInfoBaseOnTypeModel(Long profileId, String fitnessType, PageRequest pageRequest) {

		FitnessInfoBaseOnTypeModel fitnessInfo = new FitnessInfoBaseOnTypeModel();
		fitnessInfo.setProfileId(profileId);
		fitnessInfo.setType(fitnessType);
		List<StandardFitnessModel> standardFitnessModels =  new ArrayList<StandardFitnessModel>();
		if(FitnessType.FITNESS_STEPS.getValue().equals(fitnessType)){
			List<PhrStandardFitnessStep> standardFitnessSteps = standardFitnessStepRepository.getStandardFitnessStepByprofileId(profileId, pageRequest);
			if(!CollectionUtils.isEmpty(standardFitnessSteps)){
				for(PhrStandardFitnessStep item : standardFitnessSteps){
					StandardFitnessModel standardFitnessModel = new StandardFitnessModel();
					BeanUtils.copyProperties(item, standardFitnessModel, Language.JAPANESE.toString());
					standardFitnessModels.add(standardFitnessModel);
				}
				fitnessInfo.setStandardFitnessModel(standardFitnessModels);
			}
			return fitnessInfo;
		} else if(FitnessType.FITNESS_DISTANCE.getValue().equals(fitnessType)){
			List<PhrStandardFitnessDistance> standardFitnessDistances = standardFitnessDistanceRepository.getStandardFitnessDistanceByprofileId(profileId, pageRequest);
			if(!CollectionUtils.isEmpty(standardFitnessDistances)){
				for(PhrStandardFitnessDistance item : standardFitnessDistances){
					StandardFitnessModel standardFitnessModel = new StandardFitnessModel();
					BeanUtils.copyProperties(item, standardFitnessModel, Language.JAPANESE.toString());
					standardFitnessModels.add(standardFitnessModel);
				}
				fitnessInfo.setStandardFitnessModel(standardFitnessModels);
			}
			return fitnessInfo;
		}
		fitnessInfo.setMessage(Message.FITNESS_TYPE_NOT_EXIST.getValue());
		return fitnessInfo;
	}
	
	// SFN02
	@Override
	public StandardFitnessModel getStandardFitnessDetailsByTypeModel(Long profileId, String fitnessType, Long fitnessId) {
		StandardFitnessModel standardFitnessModel = new StandardFitnessModel();
		if(FitnessType.FITNESS_STEPS.getValue().equals(fitnessType)){
			PhrStandardFitnessStep standardFitnessStep = new PhrStandardFitnessStep(); 
			List<PhrStandardFitnessStep> standardFitnessSteps = standardFitnessStepRepository.getStandardFitnessStepByIdAndProfileIdAndActiveFlg(fitnessId, profileId);
			if(CollectionUtils.isEmpty(standardFitnessSteps)){
				standardFitnessModel.setMessage(Message.FITNESS_ID_NOT_FOUND.getValue());
				return standardFitnessModel;
			}
			standardFitnessStep = standardFitnessSteps.get(0);
			BeanUtils.copyProperties(standardFitnessStep, standardFitnessModel, Language.JAPANESE.toString());
			return standardFitnessModel;
		} else if(FitnessType.FITNESS_DISTANCE.getValue().equals(fitnessType)){
			PhrStandardFitnessDistance standardFitnessDistance = new PhrStandardFitnessDistance(); 
			List<PhrStandardFitnessDistance> standardFitnessDistances = standardFitnessDistanceRepository.getStandardFitnessDistanceByIdAndProfileIdAndActiveFlg(fitnessId, profileId);
			if(CollectionUtils.isEmpty(standardFitnessDistances)){
				standardFitnessModel.setMessage(Message.FITNESS_ID_NOT_FOUND.getValue());
				return standardFitnessModel;
			}
			standardFitnessDistance = standardFitnessDistances.get(0);
			BeanUtils.copyProperties(standardFitnessDistance, standardFitnessModel, Language.JAPANESE.toString());
			return standardFitnessModel;
		} else {
			standardFitnessModel.setMessage(Message.FITNESS_TYPE_NOT_EXIST.getValue());
		}
		return standardFitnessModel;
	}
		
	// SFN03
	@Override
	public StandardFitnessModel updateStandardFitnessByType(StandardFitnessModel standardFitnessModel, String fitnessType, Long profileId) {
		if(standardFitnessModel.getDatetimeRecord() == null){
			standardFitnessModel.setMessage(Message.DATETIME_RECORD_REQUIRED.getValue());
			return standardFitnessModel;
		}
		if(FitnessType.FITNESS_STEPS.getValue().equals(fitnessType)){
			if(standardFitnessModel.getStepsCount() == null){
				standardFitnessModel.setMessage(Message.FITNESS_STEPS_REQUIRED.getValue());
				return standardFitnessModel;
			}
			PhrStandardFitnessStep standardFitnessStep = new PhrStandardFitnessStep(); 
			if(standardFitnessModel.getId() != null){
				List<PhrStandardFitnessStep> standardFitnessSteps = standardFitnessStepRepository.getStandardFitnessStepByIdAndProfileIdAndActiveFlg(standardFitnessModel.getId(), profileId);
				if(CollectionUtils.isEmpty(standardFitnessSteps)){
					standardFitnessModel.setMessage(Message.FITNESS_ID_NOT_FOUND.getValue());
					return standardFitnessModel;
				}
				standardFitnessStep = standardFitnessSteps.get(0);
			}
			BeanUtils.copyProperties(standardFitnessModel, standardFitnessStep, Language.JAPANESE.toString());
			standardFitnessStep.setProfileId(profileId);
			standardFitnessStepRepository.save(standardFitnessStep);
			BeanUtils.copyProperties(standardFitnessStep, standardFitnessModel, Language.JAPANESE.toString());
			return standardFitnessModel;
		} else if(FitnessType.FITNESS_DISTANCE.getValue().equals(fitnessType)){
			if(standardFitnessModel.getWalkRunDistance() == null){
				standardFitnessModel.setMessage(Message.FITNESS_DISTANCE_REQUIRED.getValue());
				return standardFitnessModel;
			}
			PhrStandardFitnessDistance standardFitnessDistance = new PhrStandardFitnessDistance(); 
			if(standardFitnessModel.getId() != null){
				List<PhrStandardFitnessDistance> standardFitnessDistances = standardFitnessDistanceRepository.getStandardFitnessDistanceByIdAndProfileIdAndActiveFlg(standardFitnessModel.getId(), profileId);
				if(CollectionUtils.isEmpty(standardFitnessDistances)){
					standardFitnessModel.setMessage(Message.FITNESS_ID_NOT_FOUND.getValue());
					return standardFitnessModel;
				}
				standardFitnessDistance = standardFitnessDistances.get(0);
			}
			BeanUtils.copyProperties(standardFitnessModel, standardFitnessDistance, Language.JAPANESE.toString());
			standardFitnessDistance.setProfileId(profileId);
			standardFitnessDistanceRepository.save(standardFitnessDistance);
			BeanUtils.copyProperties(standardFitnessDistance, standardFitnessModel, Language.JAPANESE.toString());
			return standardFitnessModel;
		} else {
			standardFitnessModel.setMessage(Message.FITNESS_TYPE_NOT_EXIST.getValue());
		}
		return standardFitnessModel;
	}
	
	// SFN05
	@Override
	public StandardFitnessModel deleteStandardFitnessByType(Long fitnessId, String fitnessType, Long profileId) {
		StandardFitnessModel standardFitnessModel = new StandardFitnessModel();
		if(FitnessType.FITNESS_STEPS.getValue().equals(fitnessType)){
			PhrStandardFitnessStep standardFitnessStep = new PhrStandardFitnessStep(); 
			List<PhrStandardFitnessStep> standardFitnessSteps = standardFitnessStepRepository.getStandardFitnessStepByIdAndProfileId(fitnessId, profileId);
			if(CollectionUtils.isEmpty(standardFitnessSteps)){
				standardFitnessModel.setMessage(Message.FITNESS_ID_NOT_FOUND.getValue());
				return standardFitnessModel;
			}
			standardFitnessStep = standardFitnessSteps.get(0);
			if(ActiveFlag.ACTIVE.toInt() == standardFitnessStep.getActiveFlg()){
				standardFitnessStep.setActiveFlg(ActiveFlag.INACTIVE.toInt());
				standardFitnessStepRepository.save(standardFitnessStep);
				BeanUtils.copyProperties(standardFitnessStep, standardFitnessModel, Language.JAPANESE.toString());
				return standardFitnessModel;
			}
			standardFitnessModel.setMessage(Message.FITNESS_STEPS_DELETED.getValue());
			return standardFitnessModel;
		} else if(FitnessType.FITNESS_DISTANCE.getValue().equals(fitnessType)){
			PhrStandardFitnessDistance standardFitnessDistance = new PhrStandardFitnessDistance(); 
			List<PhrStandardFitnessDistance> standardFitnessDistances = standardFitnessDistanceRepository.getStandardFitnessDistanceByIdAndProfileId(fitnessId, profileId);
			if(CollectionUtils.isEmpty(standardFitnessDistances)){
				standardFitnessModel.setMessage(Message.FITNESS_ID_NOT_FOUND.getValue());
				return standardFitnessModel;
			}
			standardFitnessDistance = standardFitnessDistances.get(0);
			if(ActiveFlag.ACTIVE.toInt() == standardFitnessDistance.getActiveFlg()){
				standardFitnessDistance.setActiveFlg(ActiveFlag.INACTIVE.toInt());
				standardFitnessDistanceRepository.save(standardFitnessDistance);
				BeanUtils.copyProperties(standardFitnessDistance, standardFitnessModel, Language.JAPANESE.toString());
				return standardFitnessModel;
			}
			standardFitnessModel.setMessage(Message.FITNESS_DISTANCE_DELETED.getValue());
			return standardFitnessModel;
		} else {
			standardFitnessModel.setMessage(Message.FITNESS_TYPE_NOT_EXIST.getValue());
		}
		return standardFitnessModel;
	}

	// SFN10
	@Override
	public DurationTypeStandardFitnessModel getStandardFitnessInfoByDurationType(Long profileId, String fitnessType, Long durationType) {
		boolean invalidTempType = true;
		DurationTypeStandardFitnessModel fitnessModel = new DurationTypeStandardFitnessModel();
		fitnessModel.setProfileId(profileId);
		fitnessModel.setType(fitnessType);
		List<StandardFitnessStepModel> standardFitnessStepModels = new ArrayList<>();
		List<StandardFitnessDistanceModel> standardFitnessDistanceModels = new ArrayList<>();
		
		if(FitnessType.FITNESS_STEPS.getValue().equals(fitnessType) || FitnessType.FITNESS_ALL.getValue().equals(fitnessType)){
			invalidTempType = false;
			List<StandardFitnessStepInfo> standardFitnessStepInfos = standardFitnessStepRepository.getStandardFitnessStepInfoByprofileIdAndDurationType(profileId, durationType);
			if (!CollectionUtils.isEmpty(standardFitnessStepInfos)) {
				for (StandardFitnessStepInfo info : standardFitnessStepInfos) {
					StandardFitnessStepModel item = new StandardFitnessStepModel();
					BeanUtils.copyProperties(info, item, Language.JAPANESE.toString());
					standardFitnessStepModels.add(item);
				}
				fitnessModel.setStandardFitnessStepModel(standardFitnessStepModels);
			}
		} 
		if (FitnessType.FITNESS_DISTANCE.getValue().equals(fitnessType) || FitnessType.FITNESS_ALL.getValue().equals(fitnessType)) {
			invalidTempType = false;
			List<StandardFitnessDistanceInfo> standardFitnessDistanceInfos = standardFitnessDistanceRepository.getStandardFitnessDistanceInfoByprofileIdAndDurationType(profileId, durationType);
			if (!CollectionUtils.isEmpty(standardFitnessDistanceInfos)) {
				for (StandardFitnessDistanceInfo info : standardFitnessDistanceInfos) {
					StandardFitnessDistanceModel item = new StandardFitnessDistanceModel();
					BeanUtils.copyProperties(info, item, Language.JAPANESE.toString());
					standardFitnessDistanceModels.add(item);
				}
				fitnessModel.setStandardFitnessDistanceModel(standardFitnessDistanceModels);
			}
		} 
		if(invalidTempType) {
			fitnessModel.setMessage(Message.FITNESS_TYPE_NOT_EXIST.getValue());
		}
		return fitnessModel;
	}

	@Override
	public List<StandardTemperatureModel> addStandardTemperatureListByType(List<StandardTemperatureModel> standardTemperatureModels, String temperatureType, Long profileId) {

		List<StandardTemperatureModel> listStandardTemperature = new ArrayList<>();

		List<PhrStandardTempTemperature> standardTempTemperatures = new ArrayList<>();
		List<PhrStandardTempHeartrate> standardTempHeartrates = new ArrayList<>();
		List<PhrStandardTempBreath> standardTempBreaths = new ArrayList<>();
		List<PhrStandardTempBp> standardTempBps = new ArrayList<>();
		for (StandardTemperatureModel standardTemperatureModel : standardTemperatureModels) {
			if(TemperatureType.TEMP_TEMPERATURE.getValue().equals(temperatureType)){
				PhrStandardTempTemperature standardTempTemperature = new PhrStandardTempTemperature(); 
				BeanUtils.copyProperties(standardTemperatureModel, standardTempTemperature, Language.JAPANESE.toString());
				standardTempTemperature.setProfileId(profileId);
				standardTempTemperatures.add(standardTempTemperature);
			}	
			
			if(TemperatureType.TEMP_HEARTRATE.getValue().equals(temperatureType)){
				PhrStandardTempHeartrate standardTempHeartrate = new PhrStandardTempHeartrate(); 
				BeanUtils.copyProperties(standardTemperatureModel, standardTempHeartrate, Language.JAPANESE.toString());
				standardTempHeartrate.setProfileId(profileId);
				standardTempHeartrates.add(standardTempHeartrate);
			}		
			
			if(TemperatureType.TEMP_BREATH.getValue().equals(temperatureType)){
				PhrStandardTempBreath standardTempBreath = new PhrStandardTempBreath(); 
				BeanUtils.copyProperties(standardTemperatureModel, standardTempBreath, Language.JAPANESE.toString());
				standardTempBreath.setProfileId(profileId);
				standardTempBreaths.add(standardTempBreath);
			}
			
			if(TemperatureType.TEMP_BP.getValue().equals(temperatureType)){
				PhrStandardTempBp standardTempBp = new PhrStandardTempBp(); 
				BeanUtils.copyProperties(standardTemperatureModel, standardTempBp, Language.JAPANESE.toString());
				standardTempBp.setProfileId(profileId);
				standardTempBps.add(standardTempBp);
			}
		}

		// save data
		if (!CollectionUtils.isEmpty(standardTempTemperatures)) {
			standardTempTemperatures = standardTempTemperatureRepository.save(standardTempTemperatures);
			for (PhrStandardTempTemperature standardTempTemperature : standardTempTemperatures) {
				StandardTemperatureModel standardTemperatureModel = new StandardTemperatureModel();
				BeanUtils.copyProperties(standardTempTemperature, standardTemperatureModel, Language.JAPANESE.toString());
				listStandardTemperature.add(standardTemperatureModel);
			}
		}
		if (!CollectionUtils.isEmpty(standardTempHeartrates)) {
			standardTempHeartrates = standardTempHeartrateRepository.save(standardTempHeartrates);
			for (PhrStandardTempHeartrate standardTempHeartrate : standardTempHeartrates) {
				StandardTemperatureModel standardTemperatureModel = new StandardTemperatureModel();
				BeanUtils.copyProperties(standardTempHeartrate, standardTemperatureModel, Language.JAPANESE.toString());
				listStandardTemperature.add(standardTemperatureModel);
			}
		}
		if (!CollectionUtils.isEmpty(standardTempBreaths)) {
			standardTempBreaths = standardTempBreathRepository.save(standardTempBreaths);
			for (PhrStandardTempBreath standardTempBreath : standardTempBreaths) {
				StandardTemperatureModel standardTemperatureModel = new StandardTemperatureModel();
				BeanUtils.copyProperties(standardTempBreath, standardTemperatureModel, Language.JAPANESE.toString());
				listStandardTemperature.add(standardTemperatureModel);
			}
		}
		if (!CollectionUtils.isEmpty(standardTempBps)) {
			standardTempBps = standardTempBpRepository.save(standardTempBps);
			for (PhrStandardTempBp standardTempBp : standardTempBps) {
				StandardTemperatureModel standardTemperatureModel = new StandardTemperatureModel();
				BeanUtils.copyProperties(standardTempBp, standardTemperatureModel, Language.JAPANESE.toString());
				listStandardTemperature.add(standardTemperatureModel);
			}
		}
		return listStandardTemperature;
	}

	@Override
	public List<StandardFitnessModel> addFitnessListByType(List<StandardFitnessModel> standardFitnessModels, String fitnessType, Long profileId) {
		List<StandardFitnessModel> listStandardFitnessModel = new ArrayList<>();
		List<PhrStandardFitnessStep> standardFitnessSteps = new ArrayList<>();
		List<PhrStandardFitnessDistance> standardFitnessDistances = new ArrayList<>();
		for (StandardFitnessModel standardFitnessModel : standardFitnessModels) {
			if(FitnessType.FITNESS_STEPS.getValue().equals(fitnessType)){
				PhrStandardFitnessStep standardFitnessStep = new PhrStandardFitnessStep(); 
				BeanUtils.copyProperties(standardFitnessModel, standardFitnessStep, Language.JAPANESE.toString());
				standardFitnessStep.setProfileId(profileId);
				standardFitnessSteps.add(standardFitnessStep);
			} 
			
			if(FitnessType.FITNESS_DISTANCE.getValue().equals(fitnessType)){
				PhrStandardFitnessDistance standardFitnessDistance = new PhrStandardFitnessDistance(); 
				BeanUtils.copyProperties(standardFitnessModel, standardFitnessDistance, Language.JAPANESE.toString());
				standardFitnessDistance.setProfileId(profileId);
				standardFitnessDistances.add(standardFitnessDistance);				
			}
		}
		if(!CollectionUtils.isEmpty(standardFitnessSteps)){
			standardFitnessSteps = standardFitnessStepRepository.save(standardFitnessSteps);
			for (PhrStandardFitnessStep standardFitnessStep : standardFitnessSteps) {
				StandardFitnessModel standardFitnessModel = new StandardFitnessModel();
				BeanUtils.copyProperties(standardFitnessStep, standardFitnessModel, Language.JAPANESE.toString());
				listStandardFitnessModel.add(standardFitnessModel);
			}
		}
		if(!CollectionUtils.isEmpty(standardFitnessDistances)){
			standardFitnessDistances = standardFitnessDistanceRepository.save(standardFitnessDistances);
			for (PhrStandardFitnessDistance standardFitnessDistance : standardFitnessDistances) {
				StandardFitnessModel standardFitnessModel = new StandardFitnessModel();
				BeanUtils.copyProperties(standardFitnessDistance, standardFitnessModel, Language.JAPANESE.toString());
				listStandardFitnessModel.add(standardFitnessModel);
			}
		}
		return listStandardFitnessModel;
	}
}
