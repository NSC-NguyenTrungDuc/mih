package nta.med.ext.phr.service;

import java.util.List;

import org.springframework.data.domain.PageRequest;

import nta.med.ext.phr.model.DurationTypeStandardFoodModel;
import nta.med.ext.phr.model.FoodInfoBaseOnTypeModel;
import nta.med.ext.phr.model.StandardFoodModel;

public interface StandardFoodMenuService {
	
	public FoodInfoBaseOnTypeModel getStandardFoodByType(Long profileId, String foodType, PageRequest pageRequest);
	
	public StandardFoodModel getDetailStandardFoodMenuByType(Long id, String foodType, Long profileId);
	
	public StandardFoodModel deleteStandardFoodByFoodType (Long profileId, String foodType, Long durationType);

	public StandardFoodModel updateStandardFoodByFoodType(StandardFoodModel standardFoodModel, String foodType, Long profileId);
	
	public DurationTypeStandardFoodModel getStandardFoodInfoByDurationType(Long profileId, String foodType, Long durationType);
	
	public List<StandardFoodModel> addStandardFoodListByFoodType(List<StandardFoodModel> standardFoodModels, String foodType, Long profileId);
}
