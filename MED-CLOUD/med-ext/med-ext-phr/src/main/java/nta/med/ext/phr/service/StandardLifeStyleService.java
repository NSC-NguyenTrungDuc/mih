package nta.med.ext.phr.service;

import java.util.List;

import org.springframework.data.domain.PageRequest;

import nta.med.ext.phr.model.StandardLifeStyleModel;

public interface StandardLifeStyleService {

	public List<StandardLifeStyleModel> getLimitStandardLifeStyle(Long profileId, PageRequest pageRequest);

	public StandardLifeStyleModel getDetailStandardLifeStyle(Long profileId, Long standardLifeStyleId);

	public StandardLifeStyleModel addStandardLifeStyle(StandardLifeStyleModel standardLifeStyleModel);

	public StandardLifeStyleModel updateStandardLifeStyle(StandardLifeStyleModel standardLifeStyleModel);

	public Boolean deleteStandardLifeStyle(Long standardLifeStyleId);

	public List<StandardLifeStyleModel> getStandardLifeStyleByDurationType(Long profileId, Long durationType);

	public List<StandardLifeStyleModel> addStandardLifeStyleList(List<StandardLifeStyleModel> standardLifeStyleModels, Long profileId);
}
