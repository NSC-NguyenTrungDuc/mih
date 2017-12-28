package nta.med.ext.phr.service;

import java.util.List;

import org.springframework.data.domain.PageRequest;

import nta.med.ext.phr.model.FitnessInfoBaseOnTypeModel;
import nta.med.ext.phr.model.DurationTypeStandardFitnessModel;
import nta.med.ext.phr.model.StandardFitnessModel;
import nta.med.ext.phr.model.StandardTemperatureModel;
import nta.med.ext.phr.model.DurationTypeStandardTempModel;
import nta.med.ext.phr.model.TemperatureInfoBaseOnTypeModel;

public interface StandardTemperatureService {
	
	// temperature interface
	public TemperatureInfoBaseOnTypeModel getTemperatureLimitBaseOnTypeModel(Long profileId, String temperatureType, PageRequest pageRequest);

	public StandardTemperatureModel getTemperatureDetailByTypeModel(Long profileId, String temperatureType, Long temperatureId);
	
	public StandardTemperatureModel updateStandardTempByType(StandardTemperatureModel standardTemperatureModel, String temperatureType, Long profileId);

	public StandardTemperatureModel deleteStandardTempByTemperatureType(Long profileId, String temperatureType, Long temperatureId);

	public DurationTypeStandardTempModel getStandardTempInfoByDurationType(Long profileId, String temperatureType, Long durationType);
	
	// fitness interface
	public FitnessInfoBaseOnTypeModel getStandardFitnessInfoBaseOnTypeModel(Long profileId, String fitnessType, PageRequest pageRequest);

	public StandardFitnessModel getStandardFitnessDetailsByTypeModel(Long profileId, String fitnessType, Long fitnessId);
	
	public StandardFitnessModel updateStandardFitnessByType(StandardFitnessModel standardFitnessModel, String fitnessType, Long profileId);

	public StandardFitnessModel deleteStandardFitnessByType(Long fitnessId, String fitnessType, Long profileId);

	public DurationTypeStandardFitnessModel getStandardFitnessInfoByDurationType(Long profileId, String fitnessType, Long durationType);

	public List<StandardTemperatureModel> addStandardTemperatureListByType(List<StandardTemperatureModel> standardTemperatureModels, String temperatureType, Long profileId);

	public List<StandardFitnessModel> addFitnessListByType(List<StandardFitnessModel> standardFitnessModels, String fitnessType, Long profileId);
}
