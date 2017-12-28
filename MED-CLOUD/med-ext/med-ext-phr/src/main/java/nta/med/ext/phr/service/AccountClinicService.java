package nta.med.ext.phr.service;

import java.util.List;

import nta.med.ext.phr.model.AccountClinicModel;

public interface AccountClinicService {

	public List<AccountClinicModel> getListAccountClinic(Long profileId);
	
	public List<AccountClinicModel> getListAccountClinicMbs(Long profileId);
	
	public List<AccountClinicModel> getListAccountClinicIgnoreCommonAccount(Long profileId);
	
	public AccountClinicModel addAccountClinic(AccountClinicModel accountClinicModel);
	
	public AccountClinicModel updateAccountClinic(AccountClinicModel accountClinicModel);
	
	public Boolean deleteAccountClinic(Long accountId, Long profileId);
	
	public Boolean isExistUsername(String username);
}
