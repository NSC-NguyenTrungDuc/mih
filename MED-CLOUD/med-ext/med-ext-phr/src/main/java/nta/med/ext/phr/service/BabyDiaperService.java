package nta.med.ext.phr.service;

import java.util.List;

import org.springframework.data.domain.PageRequest;

import nta.med.ext.phr.model.BabyDiaperModel;

public interface BabyDiaperService {

	public List<BabyDiaperModel> getLimitBabyDiaper(Long profileId, PageRequest pageRequest);

	public BabyDiaperModel getDetailBabyDiaper(Long profileId, Long babyDiaperId);

	public BabyDiaperModel addBabyDiaper(BabyDiaperModel babyDiaperModel);

	public BabyDiaperModel updateBabyDiaper(BabyDiaperModel babyDiaperModel);

	public Boolean deleteBabyDiaper(Long babyDiaperId);
}
