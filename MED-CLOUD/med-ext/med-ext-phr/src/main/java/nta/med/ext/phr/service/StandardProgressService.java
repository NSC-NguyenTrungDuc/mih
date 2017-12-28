package nta.med.ext.phr.service;

import java.util.List;

import org.springframework.data.domain.PageRequest;

import nta.med.ext.phr.model.StandardProgressDetailModel;
import nta.med.ext.phr.model.StandardProgressModel;

public interface StandardProgressService {
	
	public List<StandardProgressModel> getListStandardProgressByProfileId(Long profileId, PageRequest pageRequest);

	public StandardProgressDetailModel getStandardProgressDetail(Long profileId);

	public StandardProgressModel addStandardProgress(Long profileId, StandardProgressModel standardProgressModel);

	public StandardProgressModel updateStandardProgress(Long profileId, Long progressId, StandardProgressModel standardProgressModel);

	public Boolean deleteStandardProgress(Long profileId, Long progressId);
}
