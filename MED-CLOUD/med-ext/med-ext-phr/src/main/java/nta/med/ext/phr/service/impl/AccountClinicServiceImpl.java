package nta.med.ext.phr.service.impl;

import java.util.ArrayList;
import java.util.List;

import javax.annotation.Resource;

import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;

import nta.med.core.domain.phr.PhrAccountClinic;
import nta.med.core.glossary.Language;
import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.phr.AccountClinicRepository;
import nta.med.ext.phr.glossary.ActiveFlag;
import nta.med.ext.phr.glossary.Constant;
import nta.med.ext.phr.model.AccountClinicModel;
import nta.med.ext.phr.service.AccountClinicService;

@Service
@Transactional
//@Transactional(value = DataSources.PHR)
public class AccountClinicServiceImpl implements AccountClinicService{

	@Resource
	AccountClinicRepository accountClinicRepository;
	
	@Override
	public List<AccountClinicModel> getListAccountClinic(Long profileId) {
		List<AccountClinicModel> listAccountClinicModel = new ArrayList<AccountClinicModel>();
		List<PhrAccountClinic> listPhrAccountClinic = accountClinicRepository.findByProfileId(profileId);
		for (PhrAccountClinic phrAccountClinic : listPhrAccountClinic) {
			AccountClinicModel accountClinicModel = new AccountClinicModel();
			BeanUtils.copyProperties(phrAccountClinic, accountClinicModel, Language.JAPANESE.toString());
			listAccountClinicModel.add(accountClinicModel);
		}
		
		return listAccountClinicModel;
	}
	
	@Override
	public List<AccountClinicModel> getListAccountClinicMbs(Long profileId) {
		List<AccountClinicModel> listAccountClinicModel = new ArrayList<AccountClinicModel>();
		List<PhrAccountClinic> listPhrAccountClinic = accountClinicRepository.findByProfileIdMbs(profileId);
		for (PhrAccountClinic phrAccountClinic : listPhrAccountClinic) {
			AccountClinicModel accountClinicModel = new AccountClinicModel();
			BeanUtils.copyProperties(phrAccountClinic, accountClinicModel, Language.JAPANESE.toString());
			listAccountClinicModel.add(accountClinicModel);
		}
		
		return listAccountClinicModel;
	}
	
	@Override
	public List<AccountClinicModel> getListAccountClinicIgnoreCommonAccount(Long profileId) {
		List<AccountClinicModel> listAccountClinicModel = new ArrayList<AccountClinicModel>();
		List<PhrAccountClinic> listPhrAccountClinic = accountClinicRepository.findByProfileIdIgnoreCommonAccount(profileId, Constant.PREFIX_USER_NAME);
		for (PhrAccountClinic phrAccountClinic : listPhrAccountClinic) {
			AccountClinicModel accountClinicModel = new AccountClinicModel();
			BeanUtils.copyProperties(phrAccountClinic, accountClinicModel, Language.JAPANESE.toString());
			listAccountClinicModel.add(accountClinicModel);
		}
		
		return listAccountClinicModel;
	}

	@Override
	public AccountClinicModel addAccountClinic(AccountClinicModel accountClinicModel) {
		if(isExistUsername(accountClinicModel.getUsername())){
			return null;
		}

		PhrAccountClinic phrAccountClinic = new PhrAccountClinic();
		BeanUtils.copyProperties(accountClinicModel, phrAccountClinic, Language.JAPANESE.toString());
		phrAccountClinic.setSysId("mbs");
		phrAccountClinic.setUpdId("mbs");
		phrAccountClinic.setActiveFlg(0);
		phrAccountClinic.setActiveClinicAccountFlg(0);
		phrAccountClinic = accountClinicRepository.save(phrAccountClinic);
		BeanUtils.copyProperties(phrAccountClinic, accountClinicModel, Language.JAPANESE.toString());

		
		return accountClinicModel;
	}
	
	@Override
	public AccountClinicModel updateAccountClinic(AccountClinicModel accountClinicModel) {
		PhrAccountClinic phrAccountClinic = accountClinicRepository.findOne(accountClinicModel.getId());
		if(phrAccountClinic == null || phrAccountClinic.getActiveFlg() == ActiveFlag.INACTIVE.toInt()){
			return null;
		}
		
		// update when change userName only
		if(!phrAccountClinic.getUsername().equals(accountClinicModel.getUsername())){
			if(isExistUsername(accountClinicModel.getUsername())){
				return null;
			}
			
			phrAccountClinic.setUsername(accountClinicModel.getUsername());
			accountClinicRepository.save(phrAccountClinic);
		}
		
		return accountClinicModel;
	}
	
	@Override
	public Boolean deleteAccountClinic(Long accountId, Long profileId) {
		Boolean isDeleted = true;
		PhrAccountClinic phrAccountClinic = accountClinicRepository.findOne(accountId);
		if(phrAccountClinic != null 
				&& phrAccountClinic.getActiveFlg() == ActiveFlag.ACTIVE.toInt() 
				//&& phrAccountClinic.getActiveClinicAccountFlg() != ActiveFlag.ACTIVE.toInt() 
				&& phrAccountClinic.getProfileId().equals(profileId)){
			
			phrAccountClinic.setActiveFlg(ActiveFlag.INACTIVE.toInt());
			accountClinicRepository.save(phrAccountClinic);
		} else {
			isDeleted = false;
		}
		
		return isDeleted;
	}

	@Override
	public Boolean isExistUsername(String username) {
		List<PhrAccountClinic> listAccountClinic = accountClinicRepository.findByUsername(username);
		if(CollectionUtils.isEmpty(listAccountClinic)){
			return false;
		}
		
		return true;
	}
	
}
