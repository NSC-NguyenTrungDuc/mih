package nta.med.ext.phr.service;

import java.util.List;

import org.springframework.data.domain.PageRequest;

import nta.med.ext.phr.model.BabyFoodModel;
import nta.med.ext.phr.model.DurationTypeBabyFoodModel;

public interface BabyFoodService {
	
	public List<BabyFoodModel> getListBabyFoodByProfileId(Long profileId, PageRequest pageRequest);

	public BabyFoodModel getBabyFoodDetail(Long profileId, Long babyFoodId);

	public BabyFoodModel addBabyFood(Long profileId, BabyFoodModel babyFoodModel);

	public BabyFoodModel updateBabyFood(Long profileId, Long babyFoodId, BabyFoodModel babyFoodModel);

	public Boolean deleteBabyFood(Long profileId, Long babyFoodId);

	public DurationTypeBabyFoodModel getBabyFoodByDurationType(Long profileId, Long durationType);
}
