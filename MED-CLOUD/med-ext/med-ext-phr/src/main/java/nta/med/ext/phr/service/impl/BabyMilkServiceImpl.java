package nta.med.ext.phr.service.impl;

import java.util.ArrayList;
import java.util.List;

import javax.annotation.Resource;

import org.springframework.data.domain.PageRequest;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;

import nta.med.core.domain.phr.PhrBabyMilk;
import nta.med.core.glossary.Language;
import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.phr.BabyMilkRepository;
import nta.med.ext.phr.glossary.ActiveFlag;
import nta.med.ext.phr.model.BabyMilkModel;
import nta.med.ext.phr.service.BabyMilkService;

@Service
@Transactional
//@Transactional(value = DataSources.PHR)
public class BabyMilkServiceImpl implements BabyMilkService {

	@Resource
	private BabyMilkRepository babyMilkRepository;

//	@Autowired
//	Mapper mapper;

//	@Autowired
//	MailService mailService;

//	@Autowired
//	MedApiService medApiService;
	
	@Override
	public List<BabyMilkModel> getListBabyMilkByProfileId(Long profileId, PageRequest pageRequest) {
		List<BabyMilkModel> listBabyMilkModel = new ArrayList<BabyMilkModel>();
		List<PhrBabyMilk> listBabyMilk = babyMilkRepository.getListBabyMilkByProfileId(profileId, pageRequest);
		if(!CollectionUtils.isEmpty(listBabyMilk)){
			for (PhrBabyMilk phrBabyMilk : listBabyMilk) {
				BabyMilkModel babyMilkModel = new BabyMilkModel();
				if(phrBabyMilk != null){
					BeanUtils.copyProperties(phrBabyMilk, babyMilkModel, Language.JAPANESE.toString());
				}
				listBabyMilkModel.add(babyMilkModel);
			}
		}
		return listBabyMilkModel;
	}
	
	@Override
	public BabyMilkModel getBabyMilkDetail(Long profileId, Long babyMilkId) {
		BabyMilkModel babyMilkModel = new BabyMilkModel();
		PhrBabyMilk babyMilk = babyMilkRepository.getBabyMilkByProfileId(babyMilkId, profileId);
		if(babyMilk != null){
			BeanUtils.copyProperties(babyMilk, babyMilkModel, Language.JAPANESE.toString());
		}
		return babyMilkModel;
	}
	
	@Override
	public BabyMilkModel addBabyMilk(Long profileId, BabyMilkModel babyMilkModel){
		PhrBabyMilk babyMilk = new PhrBabyMilk();
    	BeanUtils.copyProperties(babyMilkModel, babyMilk, Language.JAPANESE.toString());
    	babyMilk.setProfileId(profileId);
    	babyMilk = babyMilkRepository.save(babyMilk);
    	if(babyMilk != null){
    		BeanUtils.copyProperties(babyMilk, babyMilkModel, Language.JAPANESE.toString());
    	}
		return babyMilkModel;
	}
	
	@Override
	public BabyMilkModel updateBabyMilk(Long profileId, Long babyMilkId, BabyMilkModel babyMilkModel) {
		PhrBabyMilk babyMilk = babyMilkRepository.getBabyMilkByProfileId(babyMilkId, profileId);
		if(babyMilk != null){
	    	BeanUtils.copyProperties(babyMilkModel, babyMilk, Language.JAPANESE.toString());
	    	babyMilk.setProfileId(profileId);
	    	babyMilk = babyMilkRepository.save(babyMilk);
	    	if(babyMilk != null){
	    		BeanUtils.copyProperties(babyMilk, babyMilkModel, Language.JAPANESE.toString());
	    	}
		}
		return babyMilkModel;
	}
	
	@Override
	public Boolean deleteBabyMilk(Long profileId, Long babyMilkId) {
		Integer result = babyMilkRepository.updateActiveFlg(babyMilkId, profileId, ActiveFlag.INACTIVE.toInt());
		if(result != null && result > 0){
			return true;
		}
		return false;
	}
}
