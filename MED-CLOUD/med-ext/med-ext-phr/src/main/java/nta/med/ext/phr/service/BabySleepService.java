package nta.med.ext.phr.service;

import java.util.List;

import org.springframework.data.domain.PageRequest;

import nta.med.ext.phr.model.BabySleepModel;
import nta.med.ext.phr.model.DurationTypeBabySleepModel;

public interface BabySleepService {
	
	public List<BabySleepModel> getListBabySleepByProfileId(Long profileId, PageRequest pageRequest);

	public BabySleepModel getBabySleepDetail(Long profileId, Long babySleepId);

	public BabySleepModel addBabySleep(Long profileId, BabySleepModel babySleepModel);

	public BabySleepModel updateBabySleep(Long profileId, Long babySleepId, BabySleepModel babySleepModel);

	public Boolean deleteBabySleep(Long profileId, Long babySleepId);

	public DurationTypeBabySleepModel getBabySleepByDurationType(Long profileId, Long durationType);
}
