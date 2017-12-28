package nta.med.ext.phr.service;

import java.util.List;

import org.springframework.data.domain.PageRequest;

import nta.med.ext.phr.model.DurationTypeStandardHealthModel;
import nta.med.ext.phr.model.HealthInfoBaseOnTypeModel;
import nta.med.ext.phr.model.StandardHealthModel;

public interface StandardHealthService {
	
	public List<StandardHealthModel> getListStandardHealthByProfileId(Long profileId, PageRequest pageRequest);

	public StandardHealthModel getStandardHealthDetail(Long profileId, String healthTypeId, Long healthId);

	public StandardHealthModel updateStandardHealthByType(StandardHealthModel standardHealthModel, String healthType, Long profileId);

	public Boolean deleteStandardHealth(Long profileId, String healthTypeId, Long healthId);
	
	public HealthInfoBaseOnTypeModel getHealthInfoBaseOnTypeModel(Long profileId, String healthType, PageRequest pageRequest);
	
	public DurationTypeStandardHealthModel getStandardHealthInfo(Long profileId, String healthTypeId, Long durationType);

	public List<StandardHealthModel> addStandardHealthListByType(List<StandardHealthModel> standardHealthModels, Long profileId);
}
