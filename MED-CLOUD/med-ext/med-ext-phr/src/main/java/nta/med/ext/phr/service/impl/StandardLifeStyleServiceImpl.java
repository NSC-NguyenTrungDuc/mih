package nta.med.ext.phr.service.impl;

import java.util.ArrayList;
import java.util.List;

import javax.annotation.Resource;

import org.springframework.data.domain.PageRequest;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;

import nta.med.core.domain.phr.PhrStandardLifeStyle;
import nta.med.core.glossary.Language;
import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.phr.StandardLifeStyleRepository;
import nta.med.data.model.phr.StandardLifeStyleInfo;
import nta.med.ext.phr.glossary.ActiveFlag;
import nta.med.ext.phr.model.StandardLifeStyleModel;
import nta.med.ext.phr.service.StandardLifeStyleService;

@Service
@Transactional
//@Transactional(value = DataSources.PHR)
public class StandardLifeStyleServiceImpl implements StandardLifeStyleService{
	
	@Resource
	private StandardLifeStyleRepository standardLifeStyleRepository;
	
	@Override
	public List<StandardLifeStyleModel> getLimitStandardLifeStyle(Long profileId, PageRequest pageRequest) {
		List<StandardLifeStyleModel> listStandardLifeStyleModel = new ArrayList<StandardLifeStyleModel>();
		List<PhrStandardLifeStyle> listPhrStandardLifeStyle = standardLifeStyleRepository.getLimitStandardLifeStyle(profileId, pageRequest);
		for (PhrStandardLifeStyle lifeStyle : listPhrStandardLifeStyle) {
			StandardLifeStyleModel lifeStyleModel = new StandardLifeStyleModel();
			BeanUtils.copyProperties(lifeStyle, lifeStyleModel, Language.JAPANESE.toString());
			listStandardLifeStyleModel.add(lifeStyleModel);
		}
		
		return listStandardLifeStyleModel;
	}

	@Override
	public StandardLifeStyleModel getDetailStandardLifeStyle(Long profileId, Long standardLifeStyleId) {
		PhrStandardLifeStyle lifeStyle = standardLifeStyleRepository.findOne(standardLifeStyleId);
		if(lifeStyle == null || !lifeStyle.getProfileId().equals(profileId) || lifeStyle.getActiveFlg() == ActiveFlag.INACTIVE.toInt()){
			return null;
		}
		
		StandardLifeStyleModel lifeStyleModel = new StandardLifeStyleModel();
		BeanUtils.copyProperties(lifeStyle, lifeStyleModel, Language.JAPANESE.toString());
		
		return lifeStyleModel;
	}

	@Override
	public StandardLifeStyleModel addStandardLifeStyle(StandardLifeStyleModel standardLifeStyleModel) {
		PhrStandardLifeStyle phrStandardLifeStyle = new PhrStandardLifeStyle();
		BeanUtils.copyProperties(standardLifeStyleModel, phrStandardLifeStyle, Language.JAPANESE.toString());
		standardLifeStyleRepository.save(phrStandardLifeStyle);
		BeanUtils.copyProperties(phrStandardLifeStyle, standardLifeStyleModel, Language.JAPANESE.toString());
		
		return standardLifeStyleModel;
	}

	@Override
	public StandardLifeStyleModel updateStandardLifeStyle(StandardLifeStyleModel standardLifeStyleModel) {
		PhrStandardLifeStyle phrStandardLifeStyle = standardLifeStyleRepository.findOne(standardLifeStyleModel.getId());
		if(phrStandardLifeStyle == null || phrStandardLifeStyle.getActiveFlg() == ActiveFlag.INACTIVE.toInt()){
			return null;
		}
		
		BeanUtils.copyProperties(standardLifeStyleModel, phrStandardLifeStyle, Language.JAPANESE.toString());
		standardLifeStyleRepository.save(phrStandardLifeStyle);
		BeanUtils.copyProperties(phrStandardLifeStyle, standardLifeStyleModel, Language.JAPANESE.toString());
		
		return standardLifeStyleModel;
	}

	@Override
	public Boolean deleteStandardLifeStyle(Long standardLifeStyleId) {
		Boolean isDeleted = true;
		PhrStandardLifeStyle phrStandardLifeStyle = standardLifeStyleRepository.findOne(standardLifeStyleId);
		if(phrStandardLifeStyle != null && phrStandardLifeStyle.getActiveFlg() == ActiveFlag.ACTIVE.toInt()){
			phrStandardLifeStyle.setActiveFlg(ActiveFlag.INACTIVE.toInt());
			standardLifeStyleRepository.save(phrStandardLifeStyle);
		} else {
			isDeleted = false;
		}
		
		return isDeleted;
	}

	@Override
	public List<StandardLifeStyleModel> getStandardLifeStyleByDurationType(Long profileId, Long durationType) {
		List<StandardLifeStyleModel> standardLifeStyleModels =  new ArrayList<>();
		List<StandardLifeStyleInfo> standardLifeStyleInfos = standardLifeStyleRepository.getStandardLifeStyleByDurationType(profileId, durationType);
		if (!CollectionUtils.isEmpty(standardLifeStyleInfos)) {
			for (StandardLifeStyleInfo info : standardLifeStyleInfos) {
				StandardLifeStyleModel item = new StandardLifeStyleModel();
				BeanUtils.copyProperties(info, item, Language.JAPANESE.toString());
				item.setId(info.getId().longValue());
				item.setProfileId(info.getProfileId().longValue());
				item.setTotalHourSleep(info.getTotalHourSleep().intValueExact());
				standardLifeStyleModels.add(item);
			}
		}
		return standardLifeStyleModels;
	}

	@Override
	public List<StandardLifeStyleModel> addStandardLifeStyleList(List<StandardLifeStyleModel> standardLifeStyleModels, Long profileId) {
		List<StandardLifeStyleModel> listStandardLifeStyle = new ArrayList<>();
		List<PhrStandardLifeStyle> standardLifeStyles = new ArrayList<>();
		for (StandardLifeStyleModel standardLifeStyleModel : standardLifeStyleModels) {
			PhrStandardLifeStyle phrStandardLifeStyle = new PhrStandardLifeStyle();
			BeanUtils.copyProperties(standardLifeStyleModel, phrStandardLifeStyle, Language.JAPANESE.toString());
			phrStandardLifeStyle.setProfileId(profileId);
			standardLifeStyles.add(phrStandardLifeStyle);
		}
		if(!CollectionUtils.isEmpty(standardLifeStyles)){
			standardLifeStyles = standardLifeStyleRepository.save(standardLifeStyles);
			for (PhrStandardLifeStyle phrStandardLifeStyle : standardLifeStyles) {
				StandardLifeStyleModel standardLifeStyleModel = new StandardLifeStyleModel();
				BeanUtils.copyProperties(phrStandardLifeStyle, standardLifeStyleModel, Language.JAPANESE.toString());
				listStandardLifeStyle.add(standardLifeStyleModel);
			}
		}
		return listStandardLifeStyle;
	}
	
}
