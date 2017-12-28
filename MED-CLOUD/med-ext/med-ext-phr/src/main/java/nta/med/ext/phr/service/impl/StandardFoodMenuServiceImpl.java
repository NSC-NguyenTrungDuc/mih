package nta.med.ext.phr.service.impl;

import java.util.ArrayList;
import java.util.List;

import javax.annotation.Resource;

import org.springframework.data.domain.PageRequest;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;

import nta.med.core.domain.phr.PhrStandardFoodCalory;
import nta.med.core.domain.phr.PhrStandardFoodCarbohydrate;
import nta.med.core.domain.phr.PhrStandardFoodTotalFat;
import nta.med.core.glossary.Language;
import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.phr.StandardFoodCaloryRepository;
import nta.med.data.dao.phr.StandardFoodCarbohydrateRepository;
import nta.med.data.dao.phr.StandardFoodMenuRepository;
import nta.med.data.dao.phr.StandardFoodTotalFatRepository;
import nta.med.data.model.phr.StandardFoodCaloriesInfo;
import nta.med.data.model.phr.StandardFoodCarbohydrateInfo;
import nta.med.data.model.phr.StandardFoodTotalFatInfo;
import nta.med.ext.phr.glossary.ActiveFlag;
import nta.med.ext.phr.glossary.FoodType;
import nta.med.ext.phr.glossary.Message;
import nta.med.ext.phr.model.CaloriesModel;
import nta.med.ext.phr.model.CarbohydrateModel;
import nta.med.ext.phr.model.DurationTypeStandardFoodModel;
import nta.med.ext.phr.model.FoodInfoBaseOnTypeModel;
import nta.med.ext.phr.model.StandardFoodModel;
import nta.med.ext.phr.model.TotalFatModel;
import nta.med.ext.phr.service.StandardFoodMenuService;


@Service
@Transactional
//@Transactional(value = DataSources.PHR)	
public class StandardFoodMenuServiceImpl implements StandardFoodMenuService{
	@Resource
	private StandardFoodMenuRepository standardFoodMenuRepository;
	
	@Resource
	private StandardFoodCaloryRepository standardFoodCaloryRepository;
	
	@Resource
	private StandardFoodCarbohydrateRepository standardFoodCarbohydrateRepository;
	
	@Resource
	private StandardFoodTotalFatRepository standardFoodTotalFatRepository;
	
	//SF01
	@Override
	public FoodInfoBaseOnTypeModel getStandardFoodByType(Long profileId, String foodType, PageRequest pageRequest) {
		FoodInfoBaseOnTypeModel foodInfoBaseOnTypeModel = new FoodInfoBaseOnTypeModel();
		foodInfoBaseOnTypeModel.setProfileId(profileId);
		foodInfoBaseOnTypeModel.setType(foodType);
		List<StandardFoodModel> standardFoodModels =  new ArrayList<>();
		if(FoodType.FOOD_CALORIES.getValue().equals(foodType)){
			List<PhrStandardFoodCalory> listPhrStandardFoodCalory = standardFoodCaloryRepository.getLimitStandardFoodCalory(profileId, pageRequest);
			if(!CollectionUtils.isEmpty(listPhrStandardFoodCalory)){
				for(PhrStandardFoodCalory item : listPhrStandardFoodCalory){
					StandardFoodModel standardFoodModel = new StandardFoodModel();
					BeanUtils.copyProperties(item, standardFoodModel, Language.JAPANESE.toString());
					standardFoodModels.add(standardFoodModel);
				}
				foodInfoBaseOnTypeModel.setStandardFoodModel(standardFoodModels);
			}
			return foodInfoBaseOnTypeModel;
		}
		
		if(FoodType.FOOD_CARBOHYDRATE.getValue().equals(foodType)){
			List<PhrStandardFoodCarbohydrate> listPhrStandardFoodCarbohydrate = standardFoodCarbohydrateRepository.getLimitStandardFoodCarbohydrate(profileId, pageRequest);
			if(!CollectionUtils.isEmpty(listPhrStandardFoodCarbohydrate)){
				for(PhrStandardFoodCarbohydrate item : listPhrStandardFoodCarbohydrate){
					StandardFoodModel standardFoodModel = new StandardFoodModel();
					BeanUtils.copyProperties(item, standardFoodModel, Language.JAPANESE.toString());
					standardFoodModels.add(standardFoodModel);
				}
				foodInfoBaseOnTypeModel.setStandardFoodModel(standardFoodModels);
			}
			return foodInfoBaseOnTypeModel;
		}
		
		if(FoodType.FOOD_TOTAL_FAT.getValue().equals(foodType)){
			List<PhrStandardFoodTotalFat> listPhrStandardFoodTotalFat = standardFoodTotalFatRepository.getLimitStandardFoodTotalFat(profileId, pageRequest);
			if(!CollectionUtils.isEmpty(listPhrStandardFoodTotalFat)){
				for(PhrStandardFoodTotalFat item : listPhrStandardFoodTotalFat){
					StandardFoodModel standardFoodModel = new StandardFoodModel();
					BeanUtils.copyProperties(item, standardFoodModel, Language.JAPANESE.toString());
					standardFoodModels.add(standardFoodModel);
				}
				foodInfoBaseOnTypeModel.setStandardFoodModel(standardFoodModels);
			}
			return foodInfoBaseOnTypeModel;
		}
	
		foodInfoBaseOnTypeModel.setMessage(Message.FOOD_TYPE_NOT_EXIST.getValue());
		return foodInfoBaseOnTypeModel;
	}
	
	//SF02
	@Override
	public StandardFoodModel getDetailStandardFoodMenuByType(Long profileId, String foodType, Long id) {
		StandardFoodModel standardFoodModel = new StandardFoodModel();
		if(FoodType.FOOD_CALORIES.getValue().equals(foodType)){
			PhrStandardFoodCalory standardFoodCalory = standardFoodCaloryRepository.getDetailStandardFoodCaloryByIdAndProfileIdAndActiveFlg(profileId, id);
			if(standardFoodCalory != null){
				BeanUtils.copyProperties(standardFoodCalory, standardFoodModel, Language.JAPANESE.toString());
				return standardFoodModel;
			} else {
				standardFoodModel.setMessage(Message.FOOD_NOT_FOUND.getValue());
				return standardFoodModel;
			}
		}
		
		if(FoodType.FOOD_CARBOHYDRATE.getValue().equals(foodType)){
			PhrStandardFoodCarbohydrate standardFoodCarbohydrate = standardFoodCarbohydrateRepository.getDetailStandardFoodCarbohydrateByIdAndProfileIdAndActiveFlg(profileId, id);
			if(standardFoodCarbohydrate != null){
				BeanUtils.copyProperties(standardFoodCarbohydrate, standardFoodModel, Language.JAPANESE.toString());
				return standardFoodModel;
			} else {
				standardFoodModel.setMessage(Message.FOOD_NOT_FOUND.getValue());
				return standardFoodModel;
			}
		}
		
		if(FoodType.FOOD_TOTAL_FAT.getValue().equals(foodType)){

			PhrStandardFoodTotalFat standardFoodTotalFat = standardFoodTotalFatRepository.getDetailStandardFoodTotalFatByIdAndProfileIdAndActiveFlg(profileId, id);
			if(standardFoodTotalFat != null){
				BeanUtils.copyProperties(standardFoodTotalFat, standardFoodModel, Language.JAPANESE.toString());
				return standardFoodModel;
			} else {
				standardFoodModel.setMessage(Message.FOOD_NOT_FOUND.getValue());
				return standardFoodModel;
			}
		}
		
		standardFoodModel.setMessage(Message.FOOD_TYPE_NOT_EXIST.getValue());
		return standardFoodModel;
	}
	
	//SF03 + SF04
	@Override
	public StandardFoodModel updateStandardFoodByFoodType(StandardFoodModel standardFoodModel, String foodType, Long profileId){
		if (standardFoodModel.getEatingTime() == null) {
			standardFoodModel.setMessage(Message.FOOD_EATING_TIME_REQUIRED.getValue());
			return standardFoodModel;
		}
		if(FoodType.FOOD_CALORIES.getValue().equals(foodType)){
			if (standardFoodModel.getKcal() == null) {
				standardFoodModel.setMessage(Message.FOOD_KCAL_REQUIRED.getValue());
				return standardFoodModel;
			}
			PhrStandardFoodCalory standardFoodCalory = new PhrStandardFoodCalory();
			if(standardFoodModel.getId() != null){
				standardFoodCalory = standardFoodCaloryRepository.getDetailStandardFoodCaloryByIdAndProfileIdAndActiveFlg(profileId, standardFoodModel.getId());
				if(standardFoodCalory == null){
					standardFoodModel.setMessage(Message.FOOD_NOT_FOUND.getValue());
					return standardFoodModel;
				}
			}
			BeanUtils.copyProperties(standardFoodModel, standardFoodCalory, Language.JAPANESE.toString());
			standardFoodCalory.setProfileId(profileId);
			standardFoodCaloryRepository.save(standardFoodCalory);
			BeanUtils.copyProperties(standardFoodCalory, standardFoodModel, Language.JAPANESE.toString());
			return standardFoodModel;
		}	
		
		if(FoodType.FOOD_CARBOHYDRATE.getValue().equals(foodType)){
			if (standardFoodModel.getCarbohydrate() == null) {
				standardFoodModel.setMessage(Message.FOOD_CARBOHYDRATE_REQUIRED.getValue());
				return standardFoodModel;
			}
			PhrStandardFoodCarbohydrate standardFoodCarbohydrate = new PhrStandardFoodCarbohydrate();
			if(standardFoodModel.getId() != null){
				standardFoodCarbohydrate = standardFoodCarbohydrateRepository.getDetailStandardFoodCarbohydrateByIdAndProfileIdAndActiveFlg(profileId, standardFoodModel.getId());
				if(standardFoodCarbohydrate == null){
					standardFoodModel.setMessage(Message.FOOD_NOT_FOUND.getValue());
					return standardFoodModel;
				}
			}
			BeanUtils.copyProperties(standardFoodModel, standardFoodCarbohydrate, Language.JAPANESE.toString());
			standardFoodCarbohydrate.setProfileId(profileId);
			standardFoodCarbohydrateRepository.save(standardFoodCarbohydrate);
			BeanUtils.copyProperties(standardFoodCarbohydrate, standardFoodModel, Language.JAPANESE.toString());
			return standardFoodModel;
		}		
		
		if(FoodType.FOOD_TOTAL_FAT.getValue().equals(foodType)){
			if (standardFoodModel.getTotalFat() == null) {
				standardFoodModel.setMessage(Message.FOOD_TOTAL_FAT_REQUIRED.getValue());
				return standardFoodModel;
			}
			PhrStandardFoodTotalFat standardFoodTotalFat = new PhrStandardFoodTotalFat();
			if(standardFoodModel.getId() != null){
				standardFoodTotalFat = standardFoodTotalFatRepository.getDetailStandardFoodTotalFatByIdAndProfileIdAndActiveFlg(profileId, standardFoodModel.getId());
				if(standardFoodTotalFat == null){
					standardFoodModel.setMessage(Message.FOOD_NOT_FOUND.getValue());
					return standardFoodModel;
				}
			}
			BeanUtils.copyProperties(standardFoodModel, standardFoodTotalFat, Language.JAPANESE.toString());
			standardFoodTotalFat.setProfileId(profileId);
			standardFoodTotalFatRepository.save(standardFoodTotalFat);
			BeanUtils.copyProperties(standardFoodTotalFat, standardFoodModel, Language.JAPANESE.toString());
			return standardFoodModel;
		}
		standardFoodModel.setMessage(Message.FOOD_TYPE_NOT_EXIST.getValue());
		return standardFoodModel;
	}
	
	//SF05
	@Override
	public StandardFoodModel deleteStandardFoodByFoodType (Long profileId, String foodType, Long foodId) {
		StandardFoodModel standardFoodModel = new StandardFoodModel();
		if(FoodType.FOOD_CALORIES.getValue().equals(foodType)){
			PhrStandardFoodCalory standardFoodCalory = standardFoodCaloryRepository.getDetailStandardFoodCaloryByIdAndProfileId(profileId, foodId);
			if(standardFoodCalory != null){
				if(ActiveFlag.ACTIVE.toInt() == standardFoodCalory.getActiveFlg()){
					standardFoodCalory.setActiveFlg(ActiveFlag.INACTIVE.toInt());
					standardFoodCaloryRepository.save(standardFoodCalory);
				} else {
					standardFoodModel.setMessage(Message.FOOD_CALORY_DELETED.getValue());
				}
				return standardFoodModel;
			} else {
				standardFoodModel.setMessage(Message.FOOD_NOT_FOUND.getValue());
				return standardFoodModel;
			}
		}
		if(FoodType.FOOD_CARBOHYDRATE.getValue().equals(foodType)){
			PhrStandardFoodCarbohydrate standardFoodCarbohydrate = standardFoodCarbohydrateRepository.getDetailStandardFoodCarbohydrateByIdAndProfileId(profileId, foodId);
			if(standardFoodCarbohydrate != null){
				if(ActiveFlag.ACTIVE.toInt() == standardFoodCarbohydrate.getActiveFlg()){
					standardFoodCarbohydrate.setActiveFlg(ActiveFlag.INACTIVE.toInt());
					standardFoodCarbohydrateRepository.save(standardFoodCarbohydrate);
				} else {
					standardFoodModel.setMessage(Message.FOOD_CARBOHYDRATE_DELETED.getValue());
				}
				return standardFoodModel;
			} else {
				standardFoodModel.setMessage(Message.FOOD_NOT_FOUND.getValue());
				return standardFoodModel;
			}
		}
		if(FoodType.FOOD_TOTAL_FAT.getValue().equals(foodType)){
			PhrStandardFoodTotalFat standardFoodTotalFat = standardFoodTotalFatRepository.getDetailStandardFoodTotalFatByIdAndProfileId(profileId, foodId);
			if(standardFoodTotalFat != null){
				if(ActiveFlag.ACTIVE.toInt() == standardFoodTotalFat.getActiveFlg()){
					standardFoodTotalFat.setActiveFlg(ActiveFlag.INACTIVE.toInt());
					standardFoodTotalFatRepository.save(standardFoodTotalFat);
				} else {
					standardFoodModel.setMessage(Message.FOOD_TOTAL_FAT_DELETED.getValue());
				}
				return standardFoodModel;
			} else {
				standardFoodModel.setMessage(Message.FOOD_NOT_FOUND.getValue());
				return standardFoodModel;
			}
		}
		
		standardFoodModel.setMessage(Message.FOOD_TYPE_NOT_EXIST.getValue());
		return standardFoodModel;
	}
	
	
	//SF10
	@Override
	public DurationTypeStandardFoodModel getStandardFoodInfoByDurationType(Long profileId, String foodType, Long durationType) {
		boolean invalidTempType = true;
		DurationTypeStandardFoodModel foodModel = new DurationTypeStandardFoodModel();
		foodModel.setProfileId(profileId);
		foodModel.setType(foodType);
		List<CaloriesModel> caloriesModels =  new ArrayList<>();
		List<CarbohydrateModel> carbohydrateModels =  new ArrayList<>();
		List<TotalFatModel> totalFatModels =  new ArrayList<>();
		if (FoodType.FOOD_CALORIES.getValue().equals(foodType) || FoodType.FOOD_ALL.getValue().equals(foodType)  ) {
			invalidTempType = false;
			List<StandardFoodCaloriesInfo> standardFoodCalories = standardFoodCaloryRepository.getPhrStandardFoodCaloryByprofileIdAndType(profileId, durationType);
			if (!CollectionUtils.isEmpty(standardFoodCalories)) {
				for (StandardFoodCaloriesInfo info : standardFoodCalories) {
					CaloriesModel item = new CaloriesModel();
					BeanUtils.copyProperties(info, item, Language.JAPANESE.toString());
					caloriesModels.add(item);
					
				}
				foodModel.setCaloriesInfo(caloriesModels);
			}
		} 
		if (FoodType.FOOD_CARBOHYDRATE.getValue().equals(foodType) || FoodType.FOOD_ALL.getValue().equals(foodType)  ) {
			invalidTempType = false;
			List<StandardFoodCarbohydrateInfo> standardFoodCarbohydrate = standardFoodCarbohydrateRepository
					.getPhrStandardFoodCarbohydrateByprofileIdAndType(profileId, durationType);
			if (!CollectionUtils.isEmpty(standardFoodCarbohydrate)) {
				for (StandardFoodCarbohydrateInfo info : standardFoodCarbohydrate) {
					CarbohydrateModel item = new CarbohydrateModel();
					BeanUtils.copyProperties(info, item, Language.JAPANESE.toString());
					carbohydrateModels.add(item);
					
				}
				foodModel.setCarbohydrateInfo(carbohydrateModels);
			}
		} 
		if (FoodType.FOOD_TOTAL_FAT.getValue().equals(foodType) || FoodType.FOOD_ALL.getValue().equals(foodType)  ) {
			invalidTempType = false;
			List<StandardFoodTotalFatInfo> standardFoodTotalFat = standardFoodTotalFatRepository
					.getPhrStandardFoodTotalFatByprofileIdAndType(profileId, durationType);
			if (!CollectionUtils.isEmpty(standardFoodTotalFat)) {
				for (StandardFoodTotalFatInfo info : standardFoodTotalFat) {
					TotalFatModel item = new TotalFatModel();
					BeanUtils.copyProperties(info, item, Language.JAPANESE.toString());
					totalFatModels.add(item);
				}
				foodModel.setTotalFatInfo(totalFatModels);
			}
		} 
		if(invalidTempType) {
			foodModel.setMessage(Message.FOOD_TYPE_NOT_EXIST.getValue());
		}
		return foodModel;
	}

	@Override
	public List<StandardFoodModel> addStandardFoodListByFoodType(List<StandardFoodModel> standardFoodModels, String foodType, Long profileId) {
		List<StandardFoodModel> listStandardFood = new ArrayList<>();
		List<PhrStandardFoodCalory> standardFoodCalories = new ArrayList<>();
		List<PhrStandardFoodCarbohydrate> standardFoodCarbohydrates = new ArrayList<>();
		List<PhrStandardFoodTotalFat> standardFoodTotalFats = new ArrayList<>();
		for (StandardFoodModel standardFoodModel : standardFoodModels) {
			if(FoodType.FOOD_CALORIES.getValue().equals(foodType)){
				PhrStandardFoodCalory standardFoodCalory = new PhrStandardFoodCalory();
				BeanUtils.copyProperties(standardFoodModel, standardFoodCalory, Language.JAPANESE.toString());
				standardFoodCalory.setProfileId(profileId);
				standardFoodCalories.add(standardFoodCalory);
			}	
			if(FoodType.FOOD_CARBOHYDRATE.getValue().equals(foodType)){
				PhrStandardFoodCarbohydrate standardFoodCarbohydrate = new PhrStandardFoodCarbohydrate();
				BeanUtils.copyProperties(standardFoodModel, standardFoodCarbohydrate, Language.JAPANESE.toString());
				standardFoodCarbohydrate.setProfileId(profileId);
				standardFoodCarbohydrates.add(standardFoodCarbohydrate);
			}		
			if(FoodType.FOOD_TOTAL_FAT.getValue().equals(foodType)){
				PhrStandardFoodTotalFat standardFoodTotalFat = new PhrStandardFoodTotalFat();
				BeanUtils.copyProperties(standardFoodModel, standardFoodTotalFat, Language.JAPANESE.toString());
				standardFoodTotalFat.setProfileId(profileId);
				standardFoodTotalFats.add(standardFoodTotalFat);
			}
		}
		if(!CollectionUtils.isEmpty(standardFoodCalories)){
			standardFoodCalories = standardFoodCaloryRepository.save(standardFoodCalories);
			for (PhrStandardFoodCalory standardFoodCalory : standardFoodCalories) {
				StandardFoodModel standardFoodModel = new StandardFoodModel();
				BeanUtils.copyProperties(standardFoodCalory, standardFoodModel, Language.JAPANESE.toString());
				listStandardFood.add(standardFoodModel);
			}
		}
		if(!CollectionUtils.isEmpty(standardFoodCarbohydrates)){
			standardFoodCarbohydrates = standardFoodCarbohydrateRepository.save(standardFoodCarbohydrates);
			for (PhrStandardFoodCarbohydrate standardFoodCarbohydrate : standardFoodCarbohydrates) {
				StandardFoodModel standardFoodModel = new StandardFoodModel();
				BeanUtils.copyProperties(standardFoodCarbohydrate, standardFoodModel, Language.JAPANESE.toString());
				listStandardFood.add(standardFoodModel);
			}
		}
		if(!CollectionUtils.isEmpty(standardFoodTotalFats)){
			standardFoodTotalFats = standardFoodTotalFatRepository.save(standardFoodTotalFats);
			for (PhrStandardFoodTotalFat standardFoodTotalFat : standardFoodTotalFats) {
				StandardFoodModel standardFoodModel = new StandardFoodModel();
				BeanUtils.copyProperties(standardFoodTotalFat, standardFoodModel, Language.JAPANESE.toString());
				listStandardFood.add(standardFoodModel);
			}
		}
		return listStandardFood;
	}
}

