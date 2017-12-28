package nta.med.ext.phr.service;

import java.math.BigDecimal;
import java.math.BigInteger;
import java.text.ParseException;
import java.util.List;

import nta.med.ext.phr.exception.EntityNotFoundException;
import nta.med.ext.phr.model.AccountInfo;
import nta.med.ext.phr.model.AccountPicture;
import nta.med.ext.phr.model.BabyTimeLine;
import nta.med.ext.phr.model.KcckAccountModel;
import nta.med.ext.phr.model.PatientClinicModel;
import nta.med.ext.phr.model.ProfileBaby;
import nta.med.ext.phr.model.ProfileScreen;
import nta.med.ext.phr.model.ProfileStandard;
import nta.med.ext.phr.model.StandardHomePage;
import nta.med.ext.phr.model.UserChildInfo;

public interface ProfileService {

	public List<ProfileScreen> getProfileByToken(BigDecimal babyFlg, Long userId);

	public AccountPicture updatePictureProfileUrl(Long id, String url, Long userId) throws EntityNotFoundException;

	public ProfileBaby getBabyProfileByProfileId(Long id);

	public ProfileBaby addBabyProfile(ProfileBaby profileModel, Long userId, String udid);

	public ProfileBaby editBabyProfile(Long profileId, ProfileBaby profileModel);

	public ProfileStandard updateStandardProfile(ProfileStandard profileModel);

	public Boolean deleteStandardProfile(Long profileId);

	public boolean updateActiveProfile(Long inputProfileId);

	public ProfileStandard getStandardProfileById(Long id);
	
	public ProfileStandard getStandardProfileByIdMbs(Long id);

	public BabyTimeLine getTimelineBabyProfileByLastestDay(Long profileId, Integer limit);

	public StandardHomePage getStandardHomepageByProfileId(Long idProfile, Long userId) throws ParseException;

	public ProfileStandard addStandardProfile(ProfileStandard profileStandard, Long userId);

	public Boolean activeProfile(Long requestActiveProfileId, String udid,int type);
	
	public Boolean activeAccountClinic(Long currentProfileId, Long requestActiveClinicAccountId);
	
	public PatientClinicModel addAccountClinic(Long profileId, KcckAccountModel model);

	public boolean isValidUidStandard(Long profileId, String udid);

	public boolean isValidUidBaby(Long profileId, String udid);
	
	public AccountInfo getAccountInfo(Long accountId) throws EntityNotFoundException;
	
	public List<UserChildInfo> getUserChildInfo(Long accountId) throws EntityNotFoundException;
	
	public UserChildInfo getUserChildByChildId(BigInteger childId) throws EntityNotFoundException;
	
}
