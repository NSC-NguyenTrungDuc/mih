package nta.med.ext.phr.service.impl;

import java.math.BigDecimal;
import java.math.BigInteger;
import java.util.ArrayList;
import java.util.Arrays;
import java.util.List;

import javax.annotation.Resource;

import nta.med.ext.phr.misc.EncryptionUtils;
import nta.med.ext.support.proto.PatientServiceProto;
import nta.med.ext.support.service.patient.PatientRpcService;
import org.apache.commons.lang.RandomStringUtils;
import org.apache.logging.log4j.LogManager;
import org.apache.logging.log4j.Logger;
import org.apache.logging.log4j.util.Strings;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;

import com.restfb.DefaultFacebookClient;
import com.restfb.FacebookClient;
import com.restfb.types.User;

import nta.med.core.common.annotation.TokenIgnore;
import nta.med.core.domain.phr.PhrAccount;
import nta.med.core.domain.phr.PhrProfile;
import nta.med.core.glossary.Language;
import nta.med.core.utils.BeanUtils;
import nta.med.core.utils.CommonUtils;
import nta.med.data.dao.phr.AccountClinicRepository;
import nta.med.data.dao.phr.PhrAccountRepository;
import nta.med.data.dao.phr.ProfileRepository;
import nta.med.data.model.phr.AccountClinicInfo;
import nta.med.ext.phr.caching.TokenManager;
import nta.med.ext.phr.glossary.AccountStatus;
import nta.med.ext.phr.glossary.AccountType;
import nta.med.ext.phr.glossary.ActiveFlag;
import nta.med.ext.phr.glossary.Constant;
import nta.med.ext.phr.glossary.LoginType;
import nta.med.ext.phr.glossary.ProfileMode;
import nta.med.ext.phr.glossary.Type;
import nta.med.ext.phr.misc.TokenUtils;
import nta.med.ext.phr.model.AccountClinicKcckModel;
import nta.med.ext.phr.model.AccountClinicModel;
import nta.med.ext.phr.model.PhrAccountModel;
import nta.med.ext.phr.model.ProfileModel;
import nta.med.ext.phr.model.SocialAccountModel;
import nta.med.ext.phr.model.UserInfo;
import nta.med.ext.phr.service.AccountClinicService;
import nta.med.ext.phr.service.MailService;
import nta.med.ext.phr.service.PhrAccountService;

@Service("phrAccountService")
@Transactional
// @Transactional(value = DataSources.PHR)
public class PhrAccountServiceImpl implements PhrAccountService {

	@Resource
	private PhrAccountRepository phrAccountRepository;

	@Resource
	private ProfileRepository profileRepository;

	@Resource
	AccountClinicRepository accountClinicRepository;

	@Autowired
	MailService mailService;

	@Autowired
	AccountClinicService accountClinicService;

	@Autowired
	PatientRpcService patientRpcService;

	@Autowired
	TokenManager<UserInfo> cache;

	private static final Logger LOGGER = LogManager.getLogger(PhrAccountServiceImpl.class);

	@Override
	@TokenIgnore
	public List<PhrAccountModel> findAll() {
		List<PhrAccount> listPhrAccount = phrAccountRepository.findAll();
		List<PhrAccountModel> listPhrAccountModel = new ArrayList<>();
		for (PhrAccount phrAccount : listPhrAccount) {

			PhrAccountModel accountDTO = new PhrAccountModel();
			accountDTO.setId(phrAccount.getId());
			accountDTO.setEmail(phrAccount.getEmail());
			listPhrAccountModel.add(accountDTO);
		}

		return listPhrAccountModel;
	}

	@Override
	public PhrAccountModel findById(Long id) {
		PhrAccountModel account = new PhrAccountModel();
		PhrAccount phrAccount = phrAccountRepository.findOne(id);

		if (phrAccount != null && phrAccount.getActiveFlg() == ActiveFlag.ACTIVE.toInt()) {
			BeanUtils.copyProperties(phrAccount, account, Language.JAPANESE.toString());
		}

		return account;
	}

	@Override
	public PhrAccountModel findByEmail(String email) {

		PhrAccountModel account = new PhrAccountModel();
		List<PhrAccount> lstphrAccount = phrAccountRepository.findByEmail(email);
		if (lstphrAccount != null && lstphrAccount.get(0).getActiveFlg() == ActiveFlag.ACTIVE.toInt()) {
			BeanUtils.copyProperties(lstphrAccount.get(0), account, Language.JAPANESE.toString());
		}

		return account;
	}

	@Override
	public PhrAccountModel addAccount(PhrAccountModel accountModel, String udid, boolean isAaddAccountClinic)
			throws Exception {
		LOGGER.info("addAccount: " + accountModel.toString());
		List<PhrAccount> accounts = phrAccountRepository.findByEmail(accountModel.getEmail());
		if (!CollectionUtils.isEmpty(accounts)) {
			PhrAccount account = accounts.get(0);
			List<PhrProfile> phrProfiles = profileRepository.getActiveProfileByAccountIdAndFamilyMemberType(account.getId(), Constant.PERSONAL_FAMILY);
			if(!CollectionUtils.isEmpty(phrProfiles))
			{
				PhrProfile profileModel = convertDataToProfile(accountModel, phrProfiles);

				syncAccount(accountModel.getHospcode(), account, profileModel);
			}

			return accountModel;
		}
		PhrAccount account = new PhrAccount();
		BeanUtils.copyProperties(accountModel, account, Language.JAPANESE.toString());
		account.setStatus(BigDecimal.valueOf(AccountStatus.DEACTIVE.getValue()));
		account.setType(Type.FIRST_LOGIN.getValue());
		account.setLoginType(LoginType.NORMAL.getValue());
		if (!Strings.isEmpty(accountModel.getPassword())) {
			account.setPassword(EncryptionUtils.cryptWithMD5(accountModel.getPassword()));
		} else {
			account.setPassword(EncryptionUtils.cryptWithMD5(RandomStringUtils.random(8, true, true)));
		}

		phrAccountRepository.save(account);

		PhrProfile profile = insertPersonalProfile(accountModel, account, udid);
		ProfileModel profileModel = new ProfileModel();
		BeanUtils.copyProperties(profile, profileModel, Language.JAPANESE.toString());
		String token = TokenUtils.generateToken();
		cache.put(token, new UserInfo(account.getId(), account.getEmail(), account.getPassword(), profile.getId(),
				Arrays.asList(profile.getId())));

		PhrAccountModel phrAccountModel = new PhrAccountModel();
		BeanUtils.copyProperties(account, phrAccountModel, Language.JAPANESE.toString());

		syncAccount(accountModel.getHospcode(), account, profile);

		// AccountClinicServiceImpl accountClinicServiceImp= new
		// AccountClinicServiceImpl();
		if (isAaddAccountClinic) {
			AccountClinicModel accountClinicModel = new AccountClinicModel();
			accountClinicModel.setProfileId(profile.getId());
			accountClinicModel.setHospCode(accountModel.getHospcode());
			;
			accountClinicModel.setHospName(accountModel.getHospname());
			accountClinicModel.setActiveClinicAccountFlg(0);
			accountClinicModel.setUsername(null);
			accountClinicService.addAccountClinic(accountClinicModel);
		}

		phrAccountModel.setToken(token);
		return phrAccountModel;
	}

	private PhrProfile convertDataToProfile(PhrAccountModel accountModel, List<PhrProfile> phrProfiles) {
		PhrProfile profileModel = new PhrProfile();
		BeanUtils.copyProperties(phrProfiles.get(0), profileModel, Language.JAPANESE.toString());
		if(accountModel.getProfile() != null  && !Strings.isEmpty(accountModel.getProfile().getPhone()))
        {
            profileModel.setPhone(accountModel.getProfile().getPhone());
        }

		if(accountModel.getProfile() != null  && !Strings.isEmpty(accountModel.getProfile().getFullName()))
        {
            profileModel.setFullName(accountModel.getProfile().getFullName());
        }
		if(accountModel.getProfile() != null  && !Strings.isEmpty(accountModel.getProfile().getFullNameKana()))
        {
            profileModel.setFullNameKana(accountModel.getProfile().getFullNameKana());
        }

		if(accountModel.getProfile() != null  && !Strings.isEmpty(accountModel.getProfile().getBirthday()))
        {
            profileModel.setBirthday(accountModel.getProfile().getBirthday());
        }
		return profileModel;
	}

	private void syncAccount(String hospCode, PhrAccount account, PhrProfile profile) {
		PatientServiceProto.SyncAccountRequest.Builder syncAccountRequest = PatientServiceProto.SyncAccountRequest
				.newBuilder();
		PatientServiceProto.UserEvent.Builder userEvent = PatientServiceProto.UserEvent.newBuilder();
		userEvent.setAction(PatientServiceProto.UserEvent.Action.REGISTER);
		BeanUtils.copyProperties(account, userEvent, Language.JAPANESE.toString());
		userEvent.setName(profile.getFullName());
		userEvent.setPhoneNumber(profile.getPhone() == null ? "" : profile.getPhone());
		userEvent.setDob(profile.getBirthday() == null ? "" : profile.getBirthday());
		userEvent.setSex(profile.getGender() == null ? "" : profile.getGender());
		userEvent.setFacebookId(account.getFacebookId() == null ? "" : String.valueOf(account.getFacebookId()));
		if (!Strings.isEmpty(hospCode)) {
			userEvent.setHospitalCode(hospCode);
		}
		userEvent.setNameFurigana(profile.getFullNameKana());
		syncAccountRequest.setUserEvent(userEvent);
		try {
			patientRpcService.syncAccount(syncAccountRequest.build());
		} catch (Exception e) {
			LOGGER.error("Error when sync account data", e);
		}
	}

	@Override
	public void syncAccountToOtherSystem(PatientServiceProto.UserEvent userEvent) {

	}

	public PhrProfile insertPersonalProfile(PhrAccountModel accountModel, PhrAccount account, String udId) {
		PhrProfile profile = new PhrProfile();
		BeanUtils.copyProperties(accountModel.getProfile(), profile, Language.JAPANESE.toString());
		profile.setAccount(account);
		profile.setFamilyMemberType(Constant.PERSONAL_FAMILY);
		profile.setBabyFlg(Constant.BABY_FLG_INACTIVE);
		profile.setLocale(Constant.JA_LOCALE);
		profile.setActiveProfileFlg(Constant.PROFILE_FLG_ACTIVE);
		profile.setUdid(udId);
		// profile.setGender(accountModel.getGender() == null ? "" :
		// accountModel.getGender());
		if (profile.getFullNameKana() == null) {
			profile.setFullNameKana("");
		}
		if (profile.getRelationship() == null) {
			profile.setRelationship("");
		}
		if (profile.getGender() == null) {
			profile.setGender("");
		}
		profileRepository.save(profile);
		return profile;
	}

	@Override
	public PhrAccountModel verifyAccount(Long accountId, Long profileId) throws Exception {
		// change account status and password
		PhrAccount account = phrAccountRepository.findByIdAndActiveFlg(accountId, ActiveFlag.ACTIVE.toInt());
		String newPassword = RandomStringUtils.random(8, true, true);
		account.setStatus(BigDecimal.valueOf(AccountStatus.ACTIVE.getValue()));
		account.setPassword(EncryptionUtils.cryptWithMD5(newPassword));

		phrAccountRepository.save(account);

		// // create new ACCOUNT_CLINIC if not exits
		// List<PhrAccountClinic> listAccountClinic =
		// accountClinicRepository.findByProfileIdIgnoreCommonAccount(profileId,
		// Constant.PREFIX_USER_NAME);
		// if (listAccountClinic.isEmpty()) {
		// PhrAccountClinic accountClinic = new PhrAccountClinic();
		//
		// accountClinic.setHospCode(Constant.HOSP_CODE_DEFAULT);
		// accountClinic.setHospName(Constant.HOSP_NAME_DEFAULT);
		// accountClinic.setProfileId(profileId);
		// accountClinicRepository.save(accountClinic);
		// accountClinic.setUsername(Constant.PREFIX_USER_NAME +
		// accountClinic.getId());
		// accountClinicRepository.save(accountClinic);
		//
		// //medApiService.createOUT0101(accountClinic.getUsername());
		// }

		PhrAccountModel accountModel = new PhrAccountModel();
		BeanUtils.copyProperties(account, accountModel, Language.JAPANESE.toString());
		ProfileModel profileModel = getProfileModelDefault(accountId);
		accountModel.setNewPassword(newPassword);
		accountModel.setProfile(profileModel);

		return accountModel;
	}

	@Override
	public boolean verifyAccount(Long accountId) throws Exception {
		// change account status and password
		try {
			PhrAccount account = phrAccountRepository.findByIdAndActiveFlg(accountId, ActiveFlag.ACTIVE.toInt());
			account.setStatus(BigDecimal.valueOf(AccountStatus.ACTIVE.getValue()));
			phrAccountRepository.save(account);
			return true;
		} catch (Exception e) {
			System.out.println(e.toString());
			return false;
		}

		//

	}

	@Override
	public Boolean processLogout(String token, Long accountId) {
		if (accountId == null) {
			return false;
		}
		cache.invalidate(token);

		return true;
	}

	@Override
	@TokenIgnore
	public PhrAccountModel generateToken(String patientCode, String hospCode) throws Exception {
		List<AccountClinicInfo> accountClinicInfos = accountClinicRepository.getAccountClinic(patientCode, hospCode);
		PhrAccountModel phrAccountModel = new PhrAccountModel();
		if (!CollectionUtils.isEmpty(accountClinicInfos)) {
			String token = TokenUtils.generateToken();
			List<Long> profileIds = profileRepository.getProfileIds(accountClinicInfos.get(0).getId().longValue());
			if (!CollectionUtils.isEmpty(profileIds)) {
				cache.put(token, new UserInfo(accountClinicInfos.get(0).getId().longValue(), "", "",
						Long.valueOf(accountClinicInfos.get(0).getProfileId()), profileIds));
			}

			phrAccountModel.setMasterProfileId(Long.valueOf(accountClinicInfos.get(0).getProfileId()));
			phrAccountModel.setToken(token);

		}
		return phrAccountModel;
	}

	@Override
	@TokenIgnore
	public PhrAccountModel login(PhrAccountModel accountModel) throws Exception {

		ProfileModel profileModel = new ProfileModel();
		PhrAccount account = getAccountByEmailAndPwd(accountModel.getEmail(), accountModel.getPassword());
		if (account != null && account.getId() != null && LoginType.NORMAL.getValue().equals(account.getLoginType())) {
			Long accountId = account.getId();
			if (account.getStatus() != null
					&& account.getStatus().equals(BigDecimal.valueOf(AccountStatus.DEACTIVE.getValue()))
					&& account.getType() == AccountType.NEW_REGISTER.getValue()) {
				// not verify yet
				accountModel.setResultIsVerify(true);
				return accountModel;
			} else if (account.getStatus() != null
					&& account.getStatus().equals(BigDecimal.valueOf(AccountStatus.ACTIVE.getValue()))
					&& (account.getType() == AccountType.NEW_REGISTER.getValue()
							|| account.getType() == AccountType.RESET_PASSWORD.getValue())) {
				// Call API change password: AC05
				accountModel.setResultIsChangePass(true);
				profileModel = getProfileModelDefault(accountId);
			} else if (account.getStatus() != null
					&& account.getStatus().equals(BigDecimal.valueOf(AccountStatus.ACTIVE.getValue()))
					&& account.getType() == AccountType.CLIENT_REQUEST.getValue()) {
				// generate and update token
				// updateTokenByAccountId(accountId);
				// get profile for response
				profileModel = getProfileModelDefault(accountId);

			}
			// set token for response
			String token = TokenUtils.generateToken();
			accountModel.setToken(token);
			List<Long> profileIds = profileRepository.getProfileIds(account.getId());
			if (!CollectionUtils.isEmpty(profileIds)) {
				cache.put(token, new UserInfo(accountId, account.getEmail(), account.getPassword(),
						profileModel.getId(), profileIds));
			}
			setStandOrBabyProfileId(accountModel, accountId);
			BeanUtils.copyProperties(account, accountModel, Language.JAPANESE.toString());
			// accountModel.setProfile(profileModel);
			accountModel.setGender(profileModel.getGender());
			accountModel.setPhone(profileModel.getPhone());
			// get standard profile
			// PhrProfile standardProfile = getByAccountIdAndBabyFlag(accountId,
			// Constant.BABY_FLG_INACTIVE);
			// if(StringUtils.isEmpty(standardProfile.getUdid())){
			// standardProfile.setUdid(accountModel.getUdid());
			// }
			//// if(standardProfile.getSyncFlg() == null){
			//// standardProfile.setSyncFlg(Constant.SYNC_FLG_ACTIVE);
			//// }
			// accountModel.setStandardUdid(standardProfile.getUdid());
			// accountModel.setStandardSyncFlg(standardProfile.getSyncFlg());
			// // get baby profile
			// PhrProfile babyProfile = getByAccountIdAndBabyFlag(accountId,
			// Constant.BABY_FLG_ACTIVE);
			// accountModel.setBabySyncFlg(babyProfile.getSyncFlg());
			// accountModel.setBabyUdid(babyProfile.getUdid());
			// get master profile
			Long masterProfileId = getMasterProfileId(accountId, Constant.PERSONAL_FAMILY);
			accountModel.setMasterProfileId(masterProfileId);
		}
		return accountModel;
	}

	private Long getMasterProfileId(Long accountId, String familyMemberType) {
		List<PhrProfile> profiles = profileRepository.getActiveProfileByAccountIdAndFamilyMemberType(accountId,
				familyMemberType);
		if (!CollectionUtils.isEmpty(profiles)) {
			return profiles.get(0).getId();
		}
		return null;
	}

	private void setStandOrBabyProfileId(PhrAccountModel accountModel, Long accountId) {
		LOGGER.info("PHR!!!BEGIN!!!PhrAccountServiceImpl.setStandOrBabyProfileId!!!");
		List<PhrProfile> profileModels = profileRepository.getProfilesByAccountIdAndActiveProfiles(accountId);
		for (PhrProfile profile : profileModels) {
			if (profile.getBabyFlg().equals(ProfileMode.BABY.getValue())) {
				accountModel.setBabyProfileId(profile.getId());
			} else if (profile.getBabyFlg().equals(ProfileMode.STANDARD.getValue())) {
				accountModel.setStandardProfileId(profile.getId());
			}
		}
		LOGGER.info("PHR!!!END!!!PhrAccountServiceImpl.setStandOrBabyProfileId!!!");
	}

	@Override
	public PhrAccountModel changePassword(String token, PhrAccountModel accountModel, Long userId)  {
		LOGGER.info("PHR!! PhrAccountServiceImpl.changePassword!!!" + accountModel.toString());
		PhrAccount account = phrAccountRepository.findByIdAndActiveFlg(userId, ActiveFlag.ACTIVE.toInt());
		if (account != null && account.getId() != null && account.getPassword().equals(EncryptionUtils.cryptWithMD5(accountModel.getPassword()))
				&& LoginType.NORMAL.getValue().equals(account.getLoginType())) {
			LOGGER.info("PHR!! PhrAccountServiceImpl.changePassword!!! accountId=" + account.getId() + ", loginType=" + account.getLoginType());
			account.setPassword(EncryptionUtils.cryptWithMD5(accountModel.getNewPassword()));
			account.setType(AccountType.CLIENT_REQUEST.getValue());
			account = phrAccountRepository.save(account);
			// update new token
			accountModel.setToken(token);
			BeanUtils.copyProperties(account, accountModel, Language.JAPANESE.toString());
			// set profile
			setStandOrBabyProfileId(accountModel, account.getId());
			accountModel.setPassword(accountModel.getNewPassword());


			syncAccountForUpdatePassword(accountModel, PatientServiceProto.UserEvent.Action.CHANGE_PASS);


		}
		LOGGER.info("PHR!! PhrAccountServiceImpl.changePassword!!!" + accountModel.toString());
		return accountModel;
	}

	@Override
	public PhrAccountModel forgotPasswordMbs(PhrAccountModel accountModel) throws Exception {
		LOGGER.info("PHR!! PhrAccountServiceImpl.updateInformation!!!" + accountModel.toString());
		String email = accountModel.getEmail();
		List<PhrAccount> listAccount = phrAccountRepository.findByEmail(email);
		if (CollectionUtils.isEmpty(listAccount)) {
			return null;
		}
		for(PhrAccount account : listAccount)
		{
			if(account.getFacebookId() == null)
			{
				account.setEmail(email);
				account.setPassword(EncryptionUtils.cryptWithMD5(accountModel.getPassword()));
				PhrAccount result = phrAccountRepository.save(account);
				accountModel.setId(result.getId());
				syncAccountForUpdatePassword(accountModel,PatientServiceProto.UserEvent.Action.FOGOT_PASS);
			}
			
		}	
		LOGGER.info("PHR!! PhrAccountServiceImpl.change pass!!!" + accountModel.toString());
		return accountModel;
	}
	
	
	private void syncAccountForUpdatePassword(PhrAccountModel account, PatientServiceProto.UserEvent.Action action) {
		PatientServiceProto.SyncAccountRequest.Builder syncAccountRequest = PatientServiceProto.SyncAccountRequest
				.newBuilder();
		PatientServiceProto.UserEvent.Builder userEvent = PatientServiceProto.UserEvent.newBuilder();
		userEvent.setAction(action);
		userEvent.setEmail(account.getEmail());	
		userEvent.setPassword(account.getPassword());
		syncAccountRequest.setUserEvent(userEvent);
		try {
			patientRpcService.syncAccount(syncAccountRequest.build());
		} catch (Exception e) {
			LOGGER.error("Error when sync account data", e);
		}
	}
	
	@Override
	public PhrAccountModel updateInformation(String token, PhrAccountModel accountModel, Long userId) throws Exception {
		LOGGER.info("PHR!! PhrAccountServiceImpl.updateInformation!!!" + accountModel.toString());
		PhrAccount account = phrAccountRepository.findByIdAndActiveFlg(userId, ActiveFlag.ACTIVE.toInt());
		String passwordLoginMBS = EncryptionUtils.cryptWithMD5(accountModel.getPassword());
		if (account != null && account.getId() != null && (account.getFacebookId()!=null || account.getPassword().equals(passwordLoginMBS))) {
			LOGGER.info("PHR!! PhrAccountServiceImpl.updateInformation!!! accountId=" + account.getId() + ", loginType="
					+ account.getLoginType());
			account.setPassword(accountModel.getNewPassword());
			account.setType(AccountType.CLIENT_REQUEST.getValue());
			account.setEmail(accountModel.getEmail());
			PhrProfile profile = profileRepository.findByIdAndActiveFlg(accountModel.getMasterProfileId(), 1);
			profile.setFullName(accountModel.getName());
			profile.setFullNameKana(accountModel.getNameFurigana());
			profile.setPhone(accountModel.getPhoneNumber());
			profile.setGender(accountModel.getGender());
			profileRepository.save(profile); // Update profile information
			account = phrAccountRepository.save(account); // Update account
			// update new token
			accountModel.setToken(token);
			BeanUtils.copyProperties(account, accountModel, Language.JAPANESE.toString());
			// set profile
			setStandOrBabyProfileId(accountModel, account.getId());
			String facebookId = null;
			if (account.getFacebookId() != null)
				facebookId = String.valueOf(account.getFacebookId());
			syncAccountForChangePassword(accountModel, facebookId);
		}
		LOGGER.info("PHR!! PhrAccountServiceImpl.updateInformation!!!" + accountModel.toString());
		return accountModel;

	}

	private void syncAccountForChangePassword(PhrAccountModel account, String facebookId) {
		PatientServiceProto.SyncAccountRequest.Builder syncAccountRequest = PatientServiceProto.SyncAccountRequest
				.newBuilder();
		PatientServiceProto.UserEvent.Builder userEvent = PatientServiceProto.UserEvent.newBuilder();
		userEvent.setAction(PatientServiceProto.UserEvent.Action.UPDATE_INFOMATION);
		BeanUtils.copyProperties(account, userEvent, Language.JAPANESE.toString());
		userEvent.setEmail(account.getEmail());
		userEvent.setName(account.getName());
		userEvent.setNameFurigana(account.getNameFurigana());
		userEvent.setPhoneNumber(account.getPhoneNumber());
		userEvent.setSex(account.getGender());
		userEvent.setPassword(account.getNewPassword());
		userEvent.setFacebookId(facebookId == null ? "" : facebookId);
		userEvent.setHospitalCode(account.getHospcode() == null ? "" : account.getHospcode());
		syncAccountRequest.setUserEvent(userEvent);
		try {
			patientRpcService.syncAccount(syncAccountRequest.build());
		} catch (Exception e) {
			LOGGER.error("Error when sync account data", e);
		}
	}

	@Override
	public PhrAccountModel changeStandardBackground(PhrAccountModel accountModel, Long accountId) throws Exception {

		PhrAccount account = phrAccountRepository.findByIdAndActiveFlg(accountId, ActiveFlag.ACTIVE.toInt());
		if (account != null && accountModel.getStandardBackgroundUrl() != null) {
			account.setStandardBackgroundUrl(accountModel.getStandardBackgroundUrl());
			account = phrAccountRepository.save(account);
			if (account != null) {
				BeanUtils.copyProperties(account, accountModel, Language.JAPANESE.toString());
			}
		}
		return accountModel;
	}

	@Override
	public PhrAccountModel processForgotPassword(String email) throws Exception {
		// check exist email
		List<PhrAccount> listAccount = phrAccountRepository.getAccountByEmail(email);
		if (CollectionUtils.isEmpty(listAccount)) {
			return null;
		}

		// update account type = 2
		PhrAccount account = listAccount.get(0);
		account.setType(AccountType.RESET_PASSWORD.getValue());
		phrAccountRepository.save(account);
		// update token
		String newToken = TokenUtils.generateToken();
		PhrAccountModel accountModel = new PhrAccountModel();
		BeanUtils.copyProperties(account, accountModel, Language.JAPANESE.toString());
		accountModel.setToken(newToken);

		ProfileModel profileModel = getProfileModelDefault(account.getId());
		accountModel.setProfile(profileModel);

		List<Long> profileIds = profileRepository.getProfileIds(account.getId());

		if (!CollectionUtils.isEmpty(profileIds)) {
			cache.put(newToken, new UserInfo(account.getId(), account.getEmail(), account.getPassword(),
					profileModel.getId(), profileIds));
		}
		return accountModel;

	}

	private ProfileModel getProfileModelDefault(Long accountId) {
		ProfileModel profileModel = new ProfileModel();
		List<PhrProfile> listProfile = profileRepository.getByAccountId(accountId);
		if (!CollectionUtils.isEmpty(listProfile)) {
			PhrProfile profile = listProfile.get(0);
			if (profile != null) {
				BeanUtils.copyProperties(profile, profileModel, Language.JAPANESE.toString());
			}
		}
		return profileModel;
	}

	private PhrAccount getAccountByEmailAndPwd(String email, String password) {
		List<PhrAccount> listAccount = phrAccountRepository.findByEmail(email);
		if (listAccount != null && listAccount.size() > 0) {
			if (listAccount.get(0).getPassword().equals(EncryptionUtils.cryptWithMD5(password)))
				return listAccount.get(0);
		}
		return new PhrAccount();
	}

	@Override
	public PhrAccountModel changeBabyBackground(PhrAccountModel accountModel, Long accountId) throws Exception {
		PhrAccount account = phrAccountRepository.findByIdAndActiveFlg(accountId, ActiveFlag.ACTIVE.toInt());
		if (account != null && accountModel.getBabyBackgroundUrl() != null) {
			account.setBabyBackgroundUrl(accountModel.getBabyBackgroundUrl());
			account = phrAccountRepository.save(account);
			if (account != null) {
				BeanUtils.copyProperties(account, accountModel, Language.JAPANESE.toString());
			}
		}
		return accountModel;
	}

	public PhrAccountModel getAccount(String token) {
		UserInfo userInfo = cache.get(token);
		PhrAccountModel phrAccountModel = new PhrAccountModel();
		phrAccountModel.setId(userInfo.getUserId());
		phrAccountModel.setEmail(userInfo.getUserName());
		return phrAccountModel;
	}

	@Override
	@TokenIgnore
	public List<AccountClinicKcckModel> verifyAccountFromKcck(PhrAccountModel accountModel) throws Exception {

		List<AccountClinicKcckModel> listResult = new ArrayList<AccountClinicKcckModel>();
		PhrAccount account = getAccountByEmailAndPwd(accountModel.getEmail(), accountModel.getPassword());
		if (account != null && account.getId() != null) {
			List<AccountClinicInfo> listPhrAccountClinic = accountClinicRepository.getAccountClinic(account.getId());
			for (AccountClinicInfo phrAccountClinic : listPhrAccountClinic) {
				AccountClinicKcckModel accountClinicModel = new AccountClinicKcckModel();
				BeanUtils.copyProperties(phrAccountClinic, accountClinicModel, Language.JAPANESE.toString());
				listResult.add(accountClinicModel);
			}
			return listResult;
		}
		return null;
	}

	@Override
	public PhrAccountModel registerUseFacebook(SocialAccountModel socialAccountModel, String udid) throws Exception {
		PhrAccountModel accountModel = new PhrAccountModel();
		List<PhrAccount> accounts = phrAccountRepository.getAccountByFacebookId(socialAccountModel.getFacebookId());
		if (!CollectionUtils.isEmpty(accounts)) {

			PhrAccount account = accounts.get(0);
			List<PhrProfile> phrProfiles = profileRepository.getActiveProfileByAccountIdAndFamilyMemberType(account.getId(), Constant.PERSONAL_FAMILY);
			if(!CollectionUtils.isEmpty(phrProfiles))
			{
				//PhrProfile profile = phrProfiles.get(0);
				PhrProfile profileModel = convertDataToProfile(accountModel, phrProfiles);
				PhrAccount accountItem = new PhrAccount();
				BeanUtils.copyProperties(account, accountItem, Language.JAPANESE.toString());
				if(!Strings.isEmpty(socialAccountModel.getEmail()))
				{
					accountItem.setEmail(socialAccountModel.getEmail());
				}

				syncAccount(socialAccountModel.getHospCode(), accountItem, profileModel);
			}

			return accountModel;
		}
		PhrAccount account = new PhrAccount();
		BeanUtils.copyProperties(socialAccountModel, account, Language.JAPANESE.toString());
		account.setStatus(BigDecimal.valueOf(AccountStatus.ACTIVE.getValue()));
		account.setType(Type.FIRST_LOGIN.getValue());
		account.setLoginType(LoginType.FACE_BOOK.getValue());
		phrAccountRepository.save(account);

		PhrProfile profile = insertFacebookProfile(socialAccountModel, account, udid);
		ProfileModel profileModel = new ProfileModel();
		BeanUtils.copyProperties(profile, profileModel, Language.JAPANESE.toString());
		String token = TokenUtils.generateToken();
		cache.put(token, new UserInfo(account.getId(), account.getEmail(), account.getPassword(), profile.getId(),
				Arrays.asList(profile.getId())));

		BeanUtils.copyProperties(account, accountModel, Language.JAPANESE.toString());
		accountModel.setToken(token);
		accountModel.setProfile(profileModel);
		if(!Strings.isEmpty(socialAccountModel.getPhone()))
		{
			profile.setPhone(socialAccountModel.getPhone());
		}
		syncAccount(socialAccountModel.getHospCode(), account, profile);
		return accountModel;
	}

	@SuppressWarnings("deprecation")
	@Override
	@TokenIgnore
	public PhrAccountModel loginUseFacebook(SocialAccountModel socialAccountModel) throws Exception {
		PhrAccountModel accountModel = new PhrAccountModel();
		// get face_book info
		FacebookClient facebookClient = new DefaultFacebookClient(socialAccountModel.getAccessToken());
		User user = facebookClient.fetchObject("me", User.class);
		// check face_book id
		PhrAccount account = getAccountByFacebookId(BigInteger.valueOf(CommonUtils.parseLong(user.getId())));
		if (account.getId() == null) {
			return accountModel;
		}
		// get profile
		ProfileModel profileModel = getProfileModelDefault(account.getId());
		// set token for response
		String token = TokenUtils.generateToken();
		List<Long> profileIds = profileRepository.getProfileIds(account.getId());
		if (!CollectionUtils.isEmpty(profileIds)) {
			cache.put(token, new UserInfo(account.getId(), account.getEmail(), account.getPassword(),
					profileModel.getId(), profileIds));
		}
		// set standard or baby profile
		setStandOrBabyProfileId(accountModel, account.getId());

		BeanUtils.copyProperties(account, accountModel, Language.JAPANESE.toString());
		accountModel.setGender(profileModel.getGender());
		accountModel.setToken(token);
		accountModel.setProfile(profileModel);
		// // get standard profile
		// PhrProfile standardProfile =
		// getByAccountIdAndBabyFlag(account.getId(),
		// Constant.BABY_FLG_INACTIVE);
		// if(StringUtils.isEmpty(standardProfile.getUdid())){
		// standardProfile.setUdid(accountModel.getUdid());
		// }
		//// if(standardProfile.getSyncFlg() == null){
		//// standardProfile.setSyncFlg(Constant.SYNC_FLG_ACTIVE);
		//// }
		// accountModel.setStandardUdid(standardProfile.getUdid());
		// accountModel.setStandardSyncFlg(standardProfile.getSyncFlg());
		// // get baby profile
		// PhrProfile babyProfile = getByAccountIdAndBabyFlag(account.getId(),
		// Constant.BABY_FLG_ACTIVE);
		// accountModel.setBabySyncFlg(babyProfile.getSyncFlg());
		// accountModel.setBabyUdid(babyProfile.getUdid());
		// get master profile
		Long masterProfileId = getMasterProfileId(account.getId(), Constant.PERSONAL_FAMILY);
		accountModel.setMasterProfileId(masterProfileId);
		return accountModel;
	}

	private PhrAccount getAccountByFacebookId(BigInteger facebookId) {
		List<PhrAccount> listAccount = phrAccountRepository.getAccountByFacebookId(facebookId);
		if (listAccount != null && listAccount.size() > 0) {
			return listAccount.get(0);

		}
		return new PhrAccount();
	}

	public PhrProfile insertFacebookProfile(SocialAccountModel accountModel, PhrAccount account, String udid) {
		PhrProfile profile = new PhrProfile();
		BeanUtils.copyProperties(accountModel, profile, Language.JAPANESE.toString());
		profile.setFullName(accountModel.getName());
		profile.setGender(accountModel.getGender());
		profile.setPictureProfileUrl(accountModel.getProfile_image_url());
		profile.setAccount(account);
		profile.setFamilyMemberType(Constant.PERSONAL_FAMILY);
		profile.setBabyFlg(Constant.BABY_FLG_INACTIVE);
		profile.setLocale(Constant.JA_LOCALE);
		profile.setActiveProfileFlg(Constant.PROFILE_FLG_ACTIVE);
		profile.setFullNameKana(accountModel.getName());
		profile.setRelationship(Constant.PHR);
		// profile.setSyncFlg(Constant.SYNC_FLG_ACTIVE);
		profile.setUdid(udid);
		profileRepository.save(profile);
		return profile;
	}

	@Override
	public PhrAccountModel changeStatusAgreement(Long accountId) {
		PhrAccountModel accountModel = new PhrAccountModel();
		PhrAccount account = phrAccountRepository.getAccountByIdAndType(accountId);
		if (account != null) {
			account.setType(Type.NORMAL_ACTIVE.getValue());
			account.setActiveFlg(ActiveFlag.ACTIVE.toInt());
			phrAccountRepository.save(account);
			BeanUtils.copyProperties(account, accountModel, Language.JAPANESE.toString());
		}
		return accountModel;
	}

	private PhrProfile getByAccountIdAndBabyFlag(Long accountId, BigDecimal babyFlag) {
		List<PhrProfile> profiles = profileRepository.getActiveProfileByAccountIdAndBabyFlag(accountId, babyFlag);
		if (!CollectionUtils.isEmpty(profiles)) {
			return profiles.get(0);
		}
		return new PhrProfile();
	}

	@Override
	public Integer addAccountClinic(PhrAccountModel accountModel) {
		// TODO Auto-generated method stub
		Long profileId = accountModel.getMasterProfileId();
		String username = accountModel.getPatientcode();
		String hospCode = accountModel.getHospcode();
		String hospName = accountModel.getHospname();
		String patientCode = accountModel.getPatientcode();
		String sysId = accountModel.getBabyUdid();
		return accountClinicRepository.addPhrAccountClinic(profileId, username, hospCode, hospName, patientCode, sysId);
	}

	@Override
	public Integer updatePatientCodeByProfileIdHopsCode(Long profileId, String hospCode, String patientCode)
			throws Exception {

		Integer resultUpdate = accountClinicRepository.updatePatientCode(patientCode, profileId, hospCode);
		return resultUpdate;
	}

	

}
