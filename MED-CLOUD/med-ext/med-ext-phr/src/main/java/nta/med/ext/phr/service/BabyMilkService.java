package nta.med.ext.phr.service;

import java.util.List;

import org.springframework.data.domain.PageRequest;

import nta.med.ext.phr.model.BabyMilkModel;

public interface BabyMilkService {
	
	public List<BabyMilkModel> getListBabyMilkByProfileId(Long profileId, PageRequest pageRequest);

	public BabyMilkModel getBabyMilkDetail(Long profileId, Long babyMilkId);

	public BabyMilkModel addBabyMilk(Long profileId, BabyMilkModel babyMilkModel);

	public BabyMilkModel updateBabyMilk(Long profileId, Long babyMilkId, BabyMilkModel babyMilkModel);

	public Boolean deleteBabyMilk(Long profileId, Long babyMilkId);
}
