package nta.med.ext.phr.service;

import java.util.List;

import org.springframework.data.domain.PageRequest;

import nta.med.ext.phr.model.BabyGrowthHeightWeightModel;
import nta.med.ext.phr.model.DurationTypeBabyGrowthModel;
import nta.med.ext.phr.model.GrowthInfoBaseOnTypeModel;

public interface BabyGrowthService {

	public BabyGrowthHeightWeightModel updateBabyGrowthByType(BabyGrowthHeightWeightModel babyGrowthHeightWeightModel, String growthType, Long profileId);

	public BabyGrowthHeightWeightModel deleteBabyGrowthByType(Long profileId, String growthType, Long growthId);

	public GrowthInfoBaseOnTypeModel getListBabyGrowthByType(Long profileId, String growthType, PageRequest pageRequest);

	public BabyGrowthHeightWeightModel getDetailsBabyGrowthByType(Long profileId, String growthType, Long growthId);

	public DurationTypeBabyGrowthModel getBabyGrowthInfoByDurationType(Long profileId, String growthType, Long durationType);

	public List<BabyGrowthHeightWeightModel> addBabyGrowthListByType(List<BabyGrowthHeightWeightModel> babyGrowthHeightWeightModels, String growthType, Long profileId);
}
