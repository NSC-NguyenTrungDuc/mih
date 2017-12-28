package nta.med.ext.phr.service.impl;

import java.util.ArrayList;
import java.util.List;

import javax.annotation.Resource;

import org.springframework.data.domain.PageRequest;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;

import nta.med.core.domain.phr.PhrBabyDiaper;
import nta.med.core.glossary.Language;
import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.phr.BabyDiaperRepository;
import nta.med.ext.phr.glossary.ActiveFlag;
import nta.med.ext.phr.model.BabyDiaperModel;
import nta.med.ext.phr.service.BabyDiaperService;

@Service
@Transactional
//@Transactional(value = DataSources.PHR)
public class BabyDiaperServiceImpl implements BabyDiaperService{

	@Resource
	private BabyDiaperRepository babyDiaperRepository;
	
	@Override
	public List<BabyDiaperModel> getLimitBabyDiaper(Long profileId, PageRequest pageRequest) {
		List<BabyDiaperModel> listBabyDiaperModel = new ArrayList<BabyDiaperModel>();
		List<PhrBabyDiaper> listPhrBabyDiaper = babyDiaperRepository.getLimitBabyDiaper(profileId, pageRequest);
		for (PhrBabyDiaper babyDiaper : listPhrBabyDiaper) {
			BabyDiaperModel babyDiaperModel = new BabyDiaperModel();
			BeanUtils.copyProperties(babyDiaper, babyDiaperModel, Language.JAPANESE.toString());
			listBabyDiaperModel.add(babyDiaperModel);
		}
		
		return listBabyDiaperModel;
	}

	@Override
	public BabyDiaperModel getDetailBabyDiaper(Long profileId, Long babyDiaperId) {
		PhrBabyDiaper phrBabyDiaper = babyDiaperRepository.findOne(babyDiaperId);
		if(phrBabyDiaper == null || !phrBabyDiaper.getProfileId().equals(profileId) || phrBabyDiaper.getActiveFlg() == ActiveFlag.INACTIVE.toInt()){
			return null;
		}
		
		BabyDiaperModel babyDiaperModel = new BabyDiaperModel();
		BeanUtils.copyProperties(phrBabyDiaper, babyDiaperModel, Language.JAPANESE.toString());
		
		return babyDiaperModel;
	}

	@Override
	public BabyDiaperModel addBabyDiaper(BabyDiaperModel babyDiaperModel) {
		PhrBabyDiaper phrBabyDiaper = new PhrBabyDiaper();
		BeanUtils.copyProperties(babyDiaperModel, phrBabyDiaper, Language.JAPANESE.toString());
		babyDiaperRepository.save(phrBabyDiaper);
		BeanUtils.copyProperties(phrBabyDiaper, babyDiaperModel, Language.JAPANESE.toString());
		
		return babyDiaperModel;
	}

	@Override
	public BabyDiaperModel updateBabyDiaper(BabyDiaperModel babyDiaperModel) {
		PhrBabyDiaper phrBabyDiaper = babyDiaperRepository.findOne(babyDiaperModel.getId());
		if(phrBabyDiaper == null || phrBabyDiaper.getActiveFlg() == ActiveFlag.INACTIVE.toInt()){
			return null;
		}
		
		BeanUtils.copyProperties(babyDiaperModel, phrBabyDiaper, Language.JAPANESE.toString());
		babyDiaperRepository.save(phrBabyDiaper);
		BeanUtils.copyProperties(phrBabyDiaper, babyDiaperModel, Language.JAPANESE.toString());
		
		return babyDiaperModel;
	}

	@Override
	public Boolean deleteBabyDiaper(Long babyDiaperId) {
		Boolean isDeleted = true;
		PhrBabyDiaper phrBabyDiaper = babyDiaperRepository.findOne(babyDiaperId);
		if(phrBabyDiaper != null && phrBabyDiaper.getActiveFlg() == ActiveFlag.ACTIVE.toInt()){
			phrBabyDiaper.setActiveFlg(ActiveFlag.INACTIVE.toInt());
			babyDiaperRepository.save(phrBabyDiaper);
		}else {
			isDeleted = false;
		}
		
		return isDeleted;
	}

}
