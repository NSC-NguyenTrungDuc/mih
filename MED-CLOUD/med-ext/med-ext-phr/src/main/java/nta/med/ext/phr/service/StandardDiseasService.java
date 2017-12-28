package nta.med.ext.phr.service;

import java.util.List;

import org.springframework.data.domain.PageRequest;

import nta.med.ext.phr.model.StandardDiseasModel;

public interface StandardDiseasService {

	public List<StandardDiseasModel> getLimitStandardDiseas(Long profileId, PageRequest pageRequest);

	public StandardDiseasModel getDetailStandardDiseas(Long profileId, Long standardDiseasId);

	public StandardDiseasModel addStandardDiseas(StandardDiseasModel standardDiseasModel);

	public StandardDiseasModel updateStandardDiseas(StandardDiseasModel standardDiseasModel);

	public Boolean deleteStandardDiseas(Long standardDiseasId);
}
