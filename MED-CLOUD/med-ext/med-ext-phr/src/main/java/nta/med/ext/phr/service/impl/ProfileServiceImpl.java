package nta.med.ext.phr.service.impl;

import java.math.BigDecimal;
import java.math.BigInteger;
import java.math.RoundingMode;
import java.sql.Timestamp;
import java.text.ParseException;
import java.util.ArrayList;
import java.util.Calendar;
import java.util.Collections;
import java.util.Date;
import java.util.HashMap;
import java.util.List;
import java.util.Map;

import javax.annotation.Resource;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.springframework.util.StringUtils;

import nta.med.core.domain.phr.PhrAccount;
import nta.med.core.domain.phr.PhrAccountClinic;
import nta.med.core.domain.phr.PhrBabyDiaper;
import nta.med.core.domain.phr.PhrBabyFood;
import nta.med.core.domain.phr.PhrBabyGrowthHeight;
import nta.med.core.domain.phr.PhrBabyGrowthWeight;
import nta.med.core.domain.phr.PhrBabyMilk;
import nta.med.core.domain.phr.PhrBabySleep;
import nta.med.core.domain.phr.PhrMedicine;
import nta.med.core.domain.phr.PhrProfile;
import nta.med.core.domain.phr.PhrStandardHealth;
import nta.med.core.domain.phr.PhrStandardHealthBfp;
import nta.med.core.domain.phr.PhrStandardHealthBmi;
import nta.med.core.domain.phr.PhrStandardHealthHeight;
import nta.med.core.domain.phr.PhrStandardHealthWeight;
import nta.med.core.domain.phr.PhrStandardLifeStyle;
import nta.med.core.domain.phr.PhrStandardTempBp;
import nta.med.core.domain.phr.PhrStandardTempBreath;
import nta.med.core.domain.phr.PhrStandardTempHeartrate;
import nta.med.core.domain.phr.PhrStandardTempTemperature;
import nta.med.core.domain.phr.PhrStandardTemperature;
import nta.med.core.domain.phr.TimeLineDate;
import nta.med.core.glossary.Language;
import nta.med.core.utils.BeanUtils;
import nta.med.core.utils.CommonUtils;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.phr.AccountClinicRepository;
import nta.med.data.dao.phr.BabyDiaperRepository;
import nta.med.data.dao.phr.BabyFoodRepository;
import nta.med.data.dao.phr.BabyGrowthHeightRepository;
import nta.med.data.dao.phr.BabyGrowthRepository;
import nta.med.data.dao.phr.BabyGrowthWeightRepository;
import nta.med.data.dao.phr.BabyMilkRepository;
import nta.med.data.dao.phr.BabySleepRepository;
import nta.med.data.dao.phr.MedicineRepository;
import nta.med.data.dao.phr.PhrAccountRepository;
import nta.med.data.dao.phr.ProfileRepository;
import nta.med.data.dao.phr.StandardFitnessDistanceRepository;
import nta.med.data.dao.phr.StandardFitnessStepRepository;
import nta.med.data.dao.phr.StandardFoodCaloryRepository;
import nta.med.data.dao.phr.StandardFoodCarbohydrateRepository;
import nta.med.data.dao.phr.StandardFoodMenuRepository;
import nta.med.data.dao.phr.StandardFoodTotalFatRepository;
import nta.med.data.dao.phr.StandardHealthBfpRepository;
import nta.med.data.dao.phr.StandardHealthBmiRepository;
import nta.med.data.dao.phr.StandardHealthHeightRepository;
import nta.med.data.dao.phr.StandardHealthRepository;
import nta.med.data.dao.phr.StandardHealthWeightRepository;
import nta.med.data.dao.phr.StandardLifeStyleRepository;
import nta.med.data.dao.phr.StandardTempBpRepository;
import nta.med.data.dao.phr.StandardTempBreathRepository;
import nta.med.data.dao.phr.StandardTempHeartrateRepository;
import nta.med.data.dao.phr.StandardTempTemperatureRepository;
import nta.med.data.dao.phr.StandardTemperatureRepository;
import nta.med.data.dao.phr.impl.ProfileRepositoryImpl;
import nta.med.ext.phr.exception.EntityNotFoundException;
import nta.med.ext.phr.glossary.AccountClinicConstant;
import nta.med.ext.phr.glossary.ActiveFlag;
import nta.med.ext.phr.glossary.Constant;
import nta.med.ext.phr.glossary.Message;
import nta.med.ext.phr.glossary.ProfileMode;
import nta.med.ext.phr.model.AccountClinicModel;
import nta.med.ext.phr.model.AccountInfo;
import nta.med.ext.phr.model.AccountPicture;
import nta.med.ext.phr.model.BabyDiaperModel;
import nta.med.ext.phr.model.BabyFoodModel;
import nta.med.ext.phr.model.BabyGrowthHeightModel;
import nta.med.ext.phr.model.BabyGrowthWeightModel;
import nta.med.ext.phr.model.BabyMilkModel;
import nta.med.ext.phr.model.BabySleepModel;
import nta.med.ext.phr.model.BabyTimeLine;
import nta.med.ext.phr.model.BabyTimeLineDate;
import nta.med.ext.phr.model.BmiModel;
import nta.med.ext.phr.model.CaloriesModel;
import nta.med.ext.phr.model.CarbohydrateModel;
import nta.med.ext.phr.model.HeightModel;
import nta.med.ext.phr.model.KcckAccountModel;
import nta.med.ext.phr.model.MedicineModel;
import nta.med.ext.phr.model.PatientClinicModel;
import nta.med.ext.phr.model.PatientModel;
import nta.med.ext.phr.model.PercFatModel;
import nta.med.ext.phr.model.ProfileBaby;
import nta.med.ext.phr.model.ProfileScreen;
import nta.med.ext.phr.model.ProfileStandard;
import nta.med.ext.phr.model.StandardFitnessDistanceModel;
import nta.med.ext.phr.model.StandardFitnessStepModel;
import nta.med.ext.phr.model.StandardHomePage;
import nta.med.ext.phr.model.StandardLifeDataStyleNoteModel;
import nta.med.ext.phr.model.StandardTempBpModel;
import nta.med.ext.phr.model.StandardTempBreathModel;
import nta.med.ext.phr.model.StandardTempHeartrateModel;
import nta.med.ext.phr.model.StandardTempTemperatureModel;
import nta.med.ext.phr.model.TotalFatModel;
import nta.med.ext.phr.model.UserChildInfo;
import nta.med.ext.phr.model.WeightModel;
import nta.med.ext.phr.service.AccountClinicService;
import nta.med.ext.phr.service.ProfileService;
import nta.med.ext.support.proto.PatientServiceProto;
import nta.med.ext.support.service.patient.PatientRpcService;
import nta.mss.info.AccountInfoDto;
import nta.mss.info.UserChildDto;

@Service
@Transactional
//@Transactional(value = DataSources.PHR)	
public class ProfileServiceImpl implements ProfileService {

    @Resource
    private ProfileRepository profileRepository;
    
    @Resource
    private PhrAccountRepository phrAccountRepository;

    @Resource
    private BabyMilkRepository babyMilkRepository;
    
    @Resource
    private BabyFoodRepository babyFoodRepository;
    
    @Resource
    private BabyDiaperRepository babyDiaperRepository;
    
    @Resource
    private MedicineRepository medicineRepository;
    
    @Resource
    private BabySleepRepository babySleepRepository;
    
    @Resource
    private BabyGrowthRepository babyGrowthRepository;
    
    @Resource
    private BabyGrowthHeightRepository babyGrowthHeightRepository;
    
    @Resource
    private BabyGrowthWeightRepository babyGrowthWeightRepository;
    
    @Resource
	AccountClinicRepository accountClinicRepository;
    
    @Resource
	StandardHealthRepository standardHealthRepository;
    
    @Resource
	StandardFoodMenuRepository standardFoodRepository;
    
    @Resource
    StandardTemperatureRepository standardTemperatureRepository;
    
    @Resource
    StandardLifeStyleRepository standardLifeStyleRepository;
    
    @Resource
	StandardHealthHeightRepository standardHealthHeightRepository;
    
    @Resource
	StandardHealthWeightRepository standardHealthWeightRepository;
    
    @Resource
	StandardHealthBmiRepository standardHealthBmiRepository;
    
    @Resource
	StandardHealthBfpRepository standardHealthBfpRepository;
    
    @Resource
	StandardFoodCaloryRepository standardFoodCaloryRepository;
    
    @Resource
    StandardFoodCarbohydrateRepository standardFoodCarbohydrateRepository;
    
    @Resource
    StandardFoodTotalFatRepository standardFoodTotalFatRepository;

	@Resource
	private PatientRpcService patientRpcService;
	
	@Resource
	private StandardTempTemperatureRepository standardTempTemperatureRepository;
	
	@Resource
	private StandardTempHeartrateRepository standardTempHeartrateRepository;

	@Resource
	private StandardTempBreathRepository standardTempBreathRepository;

	@Resource
	private StandardTempBpRepository standardTempBpRepository;
	
	@Resource
	private StandardFitnessStepRepository standardFitnessStepRepository;
	
	@Resource
	private StandardFitnessDistanceRepository standardFitnessDistanceRepository;
	
	@Resource
    private ProfileRepositoryImpl profileRepositoryImpl;
    
//    @Autowired
//    Mapper mapper;

//	@Autowired
//	MedApiService medApiService;
	
	@Autowired
	AccountClinicService accountClinicService;

//	@Resource
//	private SystemAdapter systemAdapter;
	
	@Override
	public List<ProfileScreen> getProfileByToken(BigDecimal babyFlg, Long userId) {
		List<PhrProfile> listProfiles = profileRepository.getProfileByToken(userId, babyFlg);
		List<ProfileScreen> listProfileModel = new ArrayList<>();
		if(!CollectionUtils.isEmpty(listProfiles)){
			for(PhrProfile item : listProfiles){
				ProfileScreen info = new ProfileScreen();
				BeanUtils.copyProperties(item, info, Language.JAPANESE.toString());
				if(!StringUtils.isEmpty(item.getFamilyMemberType())
						&& Constant.PERSONAL_FAMILY.equals(item.getFamilyMemberType())){
					info.setMasterFlg(ActiveFlag.ACTIVE.toInt());
				} else {
					info.setMasterFlg(ActiveFlag.INACTIVE.toInt());
				}
				listProfileModel.add(info);
			}
		}
		return listProfileModel;
	}
	
    @Override
    public AccountPicture updatePictureProfileUrl(Long id, String url, Long userId) throws EntityNotFoundException{
        PhrProfile profile = profileRepository.findByIdAndActiveFlg(id, ActiveFlag.ACTIVE.toInt());
        if(profile != null){
            profile.setPictureProfileUrl(url);
            profileRepository.save(profile);
			AccountPicture accountPicture = new AccountPicture();
			BeanUtils.copyProperties(profile, accountPicture, Language.JAPANESE.toString());
			accountPicture.setAccountId(userId);
            return accountPicture;
        }
        else{
            throw new EntityNotFoundException(Message.MESSAGE_PROFILE_NOT_FOUND.getValue());
        }

    }
    
    @Override
    public ProfileBaby getBabyProfileByProfileId(Long id) {
		ProfileBaby profileBaby = new ProfileBaby();
    	PhrProfile profile = profileRepository.findByIdAndActiveFlg(id, ActiveFlag.ACTIVE.toInt());
    	if(profile != null){
    		BeanUtils.copyProperties(profile, profileBaby, Language.JAPANESE.toString());
    		profileBaby.setAccountId(profile.getAccount().getId());
    		if(!StringUtils.isEmpty(profile.getBirthday())){
        		int age = CommonUtils.getAge(DateUtil.toDate(profile.getBirthday(), DateUtil.PATTERN_YYMMDD));
        		profileBaby.setAge(new BigDecimal(age));
    		}
    		// set height model
    		BabyGrowthHeightModel babyGrowthHeightModel = new BabyGrowthHeightModel();
    		PhrBabyGrowthHeight babyGrowthHeight = getBabyGrowthHeightByProfileId(id);
    		if(babyGrowthHeight != null && babyGrowthHeight.getId() != null){
        		BeanUtils.copyProperties(babyGrowthHeight, babyGrowthHeightModel, Language.JAPANESE.toString());
        		babyGrowthHeightModel.setId(BigInteger.valueOf(babyGrowthHeight.getId()));
        		profileBaby.setBabyGrowthHeightModel(babyGrowthHeightModel);
    		}
    		// set weight model
    		BabyGrowthWeightModel babyGrowthWeightModel = new BabyGrowthWeightModel();
    		PhrBabyGrowthWeight babyGrowthWeight = getBabyGrowthWeightByProfileId(id);
    		if(babyGrowthWeight != null && babyGrowthWeight.getId() != null){
    			BeanUtils.copyProperties(babyGrowthWeight, babyGrowthWeightModel, Language.JAPANESE.toString());
    			babyGrowthWeightModel.setId(BigInteger.valueOf(babyGrowthWeight.getId()));
        		profileBaby.setBabyGrowthWeightModel(babyGrowthWeightModel);
    		}
    	}
    	return profileBaby;
    }
    
    @Override
    public ProfileBaby addBabyProfile(ProfileBaby profileBaby, Long userId, String udid) {
		if(userId != null)
		{
			PhrAccount account = phrAccountRepository.findByIdAndActiveFlg(userId, ActiveFlag.ACTIVE.toInt());
			PhrProfile profile = insertBabyProfile(profileBaby, account, udid);
			if(profile != null){
				BeanUtils.copyProperties(profile, profileBaby, Language.JAPANESE.toString());
	    		profileBaby.setAccountId(account.getId());
	    		if(!StringUtils.isEmpty(profile.getBirthday())){
		    		int age = CommonUtils.getAge(DateUtil.toDate(profile.getBirthday(), DateUtil.PATTERN_YYMMDD));
		    		profileBaby.setAge(new BigDecimal(age));
	    		}
				// insert baby growth height
				PhrBabyGrowthHeight babyGrowthHeight = insertBabyGrowthHeight(profileBaby.getBabyGrowthHeightModel(), profile.getId());
				BabyGrowthHeightModel babyGrowthHeightModel = new BabyGrowthHeightModel();
				BeanUtils.copyProperties(babyGrowthHeight, babyGrowthHeightModel, Language.JAPANESE.toString());
	    		babyGrowthHeightModel.setId(BigInteger.valueOf(babyGrowthHeight.getId()));
	    		profileBaby.setBabyGrowthHeightModel(babyGrowthHeightModel);
				// insert baby growth weight
				PhrBabyGrowthWeight babyGrowthWeight = insertBabyGrowthWeight(profileBaby.getBabyGrowthWeightModel(), profile.getId());
				BabyGrowthWeightModel babyGrowthWeightModel = new BabyGrowthWeightModel();
				BeanUtils.copyProperties(babyGrowthWeight, babyGrowthWeightModel, Language.JAPANESE.toString());
				babyGrowthWeightModel.setId(BigInteger.valueOf(babyGrowthWeight.getId()));
	    		profileBaby.setBabyGrowthWeightModel(babyGrowthWeightModel);
			}
		}
    	return profileBaby;
    }

    @Override
    public ProfileBaby editBabyProfile( Long profileId, ProfileBaby profileBaby){
    	PhrProfile profile = updateProfile(profileId, profileBaby);
    	if(profile.getId() == null){
    		return null;
    	}
		BeanUtils.copyProperties(profile, profileBaby, Language.JAPANESE.toString());
		// update baby growth height
    	BabyGrowthHeightModel babyGrowthHeightModel = profileBaby.getBabyGrowthHeightModel();
		PhrBabyGrowthHeight babyGrowthHeight = updateBabyGrowthHeight(profileId, babyGrowthHeightModel);
		if(babyGrowthHeight != null && babyGrowthHeight.getId() != null){
			BeanUtils.copyProperties(babyGrowthHeight, babyGrowthHeightModel, Language.JAPANESE.toString());
			babyGrowthHeightModel.setId(BigInteger.valueOf(babyGrowthHeight.getId()));
			profileBaby.setBabyGrowthHeightModel(babyGrowthHeightModel);
		}
		// update baby growth weight
    	BabyGrowthWeightModel babyGrowthWeightModel = profileBaby.getBabyGrowthWeightModel();
		PhrBabyGrowthWeight babyGrowthWeight = updateBabyGrowthWeight(profileId, babyGrowthWeightModel);
		if(babyGrowthWeight != null && babyGrowthWeight.getId() != null){
			BeanUtils.copyProperties(babyGrowthWeight, babyGrowthWeightModel, Language.JAPANESE.toString());
			babyGrowthWeightModel.setId(BigInteger.valueOf(babyGrowthWeight.getId()));
			profileBaby.setBabyGrowthWeightModel(babyGrowthWeightModel);
		}
    	return profileBaby;
    }
    
    @Override
    public boolean updateActiveProfile( Long inputProfileId){
    	
    	PhrProfile phrProfile = profileRepository.findOne(inputProfileId);
    	if(phrProfile == null){
    		return false;
    	}
    	
    	boolean deletable = phrProfile.getActiveProfileFlg().equals(Constant.PROFILE_FLG_INACTIVE) 
    			&& phrProfile.getActiveFlg().equals(ActiveFlag.ACTIVE.toInt());
    	
    	if(deletable){
    		Integer result = profileRepository.updateActiveFlg(inputProfileId, ActiveFlag.INACTIVE.toInt());
    		if(result > 0){
    			return true;
    		}
    	}
    	
		return false;
    }
    
    @Override
	public ProfileStandard updateStandardProfile(ProfileStandard profileStandard){
		PhrProfile phrProfile = profileRepository.findOne(profileStandard.getId());
		if(phrProfile == null || phrProfile.getActiveFlg().equals(ActiveFlag.INACTIVE.toInt())){
			return null;
		}

		BeanUtils.copyProperties(profileStandard, phrProfile, Language.JAPANESE.toString());
		
		if(phrProfile.getFullNameKana() == null){
			phrProfile.setFullNameKana("");
		}
		profileRepository.save(phrProfile);
		
		// Save list account account
		List<AccountClinicModel> listAccountClinicModel = profileStandard.getListAccountClinic();
//		if(!CollectionUtils.isEmpty(listAccountClinicModel)){
//			for (AccountClinicModel accountClinicModel : listAccountClinicModel) {
//				accountClinicModel.setProfileId(phrProfile.getId());
//
//				if(accountClinicModel.getId() == null){
//					accountClinicService.addAccountClinic(accountClinicModel);
//				} else {
//					accountClinicService.updateAccountClinic(accountClinicModel);
//				}
//			}
//
//			listAccountClinicModel = accountClinicService.getListAccountClinicIgnoreCommonAccount(phrProfile.getId());
//		}


		BeanUtils.copyProperties(phrProfile, profileStandard, Language.JAPANESE.toString());
		profileStandard.setListAccountClinic(listAccountClinicModel);
		
		return profileStandard;
	}
    
    //common ----------------------------------------
    private PhrProfile insertBabyProfile(ProfileBaby profileBaby, PhrAccount account, String udid) {
    	List<PhrProfile> profiles = profileRepository.getByAccountIdAndBabyFlag(account.getId(), Constant.BABY_FLG_ACTIVE);
    	
		PhrProfile profile = new PhrProfile();
		BeanUtils.copyProperties(profileBaby, profile, Language.JAPANESE.toString());
		profile.setAccount(account);
		profile.setLocale(Constant.JA_LOCALE);

		if(profiles.size() == 0)
		{
			profile.setActiveProfileFlg(Constant.PROFILE_FLG_ACTIVE);
			profile.setUdid(udid);
		}
		else
		{
			profile.setActiveProfileFlg(Constant.PROFILE_FLG_INACTIVE);
		}
		profile.setBabyFlg(Constant.BABY_FLG_ACTIVE);
		profile.setFamilyMemberType(null);
		
		if(profile.getFullNameKana() == null){
			profile.setFullNameKana("");
		}
		
		return profileRepository.save(profile);
	}
    
    private PhrBabyGrowthHeight insertBabyGrowthHeight(BabyGrowthHeightModel babyGrowthHeightModel, Long profileId) {
    	PhrBabyGrowthHeight babyGrowthHeight = new PhrBabyGrowthHeight();
    	BeanUtils.copyProperties(babyGrowthHeightModel, babyGrowthHeight, Language.JAPANESE.toString());
    	if(babyGrowthHeightModel.getTimeMeasure() == null){
    		babyGrowthHeight.setTimeMeasure(new Timestamp(new Date().getTime()));
    	}
    	babyGrowthHeight.setProfileId(profileId);
		babyGrowthHeight = babyGrowthHeightRepository.save(babyGrowthHeight);
		return babyGrowthHeight;
	}
    
    private PhrBabyGrowthWeight insertBabyGrowthWeight(BabyGrowthWeightModel babyGrowthWeightModel, Long profileId) {
    	PhrBabyGrowthWeight babyGrowthWeight = new PhrBabyGrowthWeight();
    	BeanUtils.copyProperties(babyGrowthWeightModel, babyGrowthWeight, Language.JAPANESE.toString());
    	if(babyGrowthWeightModel.getTimeMeasure() == null){
    		babyGrowthWeight.setTimeMeasure(new Timestamp(new Date().getTime()));
    	}
    	babyGrowthWeight.setProfileId(profileId);
		babyGrowthWeight = babyGrowthWeightRepository.save(babyGrowthWeight);
		return babyGrowthWeight;
	}
    
    private PhrAccountClinic insertAccountClinic(Long profileId) {
    	PhrAccountClinic accountClinic = new PhrAccountClinic();
		accountClinic.setHospCode(AccountClinicConstant.HOSP_CODE.getValue());
		accountClinic.setHospName(AccountClinicConstant.HOSP_NAME.getValue());
		accountClinic.setUsername(AccountClinicConstant.USER_NAME.getValueName(profileId));
		accountClinic.setProfileId(profileId);
		accountClinicRepository.save(accountClinic);
		return accountClinic;
    }
    
    private PhrBabyGrowthHeight getBabyGrowthHeightByProfileId(Long profileId){
    	PhrBabyGrowthHeight babyGrowthHeight = new PhrBabyGrowthHeight();
    	List<PhrBabyGrowthHeight> babyGrowthHeights = babyGrowthHeightRepository.getLastestBabyGrowthHeightByProfileId(profileId);
    	if(!CollectionUtils.isEmpty(babyGrowthHeights)){
    		babyGrowthHeight = babyGrowthHeights.get(0);
    	}
    	return babyGrowthHeight;
    }
    
    private PhrBabyGrowthWeight getBabyGrowthWeightByProfileId(Long profileId){
    	PhrBabyGrowthWeight BabyGrowthWeight = new PhrBabyGrowthWeight();
    	List<PhrBabyGrowthWeight> BabyGrowthWeights = babyGrowthWeightRepository.getLastestBabyGrowthWeightByProfileId(profileId);
    	if(!CollectionUtils.isEmpty(BabyGrowthWeights)){
    		BabyGrowthWeight = BabyGrowthWeights.get(0);
    	}
    	return BabyGrowthWeight;
    }
    
    private PhrBabyGrowthHeight updateBabyGrowthHeight(Long profileId, BabyGrowthHeightModel babyGrowthHeightModel){
    	PhrBabyGrowthHeight babyGrowthHeight = babyGrowthHeightRepository.getBabyGrowthHeightByIdAndProfileId(babyGrowthHeightModel.getId().longValue(), profileId);
		if(babyGrowthHeight != null && babyGrowthHeight.getId() != null){
			BeanUtils.copyProperties(babyGrowthHeightModel, babyGrowthHeight, Language.JAPANESE.toString());
			if(babyGrowthHeightModel.getTimeMeasure() == null){
				babyGrowthHeight.setTimeMeasure(new Timestamp(new Date().getTime()));
			}
			babyGrowthHeight = babyGrowthHeightRepository.save(babyGrowthHeight);
		}
		return babyGrowthHeight;
    }
    
    private PhrBabyGrowthWeight updateBabyGrowthWeight(Long profileId, BabyGrowthWeightModel babyGrowthWeightModel){
    	PhrBabyGrowthWeight babyGrowthWeight = babyGrowthWeightRepository.getBabyGrowthWeightByIdAndProfileId(babyGrowthWeightModel.getId().longValue(), profileId);
		if(babyGrowthWeight != null && babyGrowthWeight.getId() != null){
			BeanUtils.copyProperties(babyGrowthWeightModel, babyGrowthWeight, Language.JAPANESE.toString());
			if(babyGrowthWeightModel.getTimeMeasure() == null){
				babyGrowthWeight.setTimeMeasure(new Timestamp(new Date().getTime()));
			}
			babyGrowthWeight = babyGrowthWeightRepository.save(babyGrowthWeight);
		}
		return babyGrowthWeight;
    }
    
    private PhrProfile updateProfile(Long profileId, ProfileBaby profileBaby) {
    	PhrProfile profile = profileRepository.findByIdAndActiveFlg(profileId, ActiveFlag.ACTIVE.toInt());
		if(profile != null){
			BeanUtils.copyProperties(profileBaby, profile, Language.JAPANESE.toString());
			profile.setId(profileId);
			
			if(profile.getFullNameKana() == null){
				profile.setFullNameKana("");
			}
			
			profile = profileRepository.save(profile);
		}
		return profile;
    }
    

    
    public ProfileStandard getStandardProfileById(Long id){
        PhrProfile phrProfile = profileRepository.findByIdAndActiveFlg(id, ActiveFlag.ACTIVE.toInt());
        if(phrProfile == null){
        	return null;
        }

		ProfileStandard profileStandard = new ProfileStandard();

		BeanUtils.copyProperties(phrProfile, profileStandard, Language.JAPANESE.toString());
        List<AccountClinicModel> listAccountClinicModel = accountClinicService.getListAccountClinic(id);
		profileStandard.setListAccountClinic(listAccountClinicModel);
		profileStandard.setAccountId(phrProfile.getAccount().getId());
        
        return profileStandard;
    }
    
    public ProfileStandard getStandardProfileByIdMbs(Long id){
        PhrProfile phrProfile = profileRepository.findByIdAndActiveFlg(id, ActiveFlag.ACTIVE.toInt());
        if(phrProfile == null){
        	return null;
        }

		ProfileStandard profileStandard = new ProfileStandard();

		BeanUtils.copyProperties(phrProfile, profileStandard, Language.JAPANESE.toString());
        List<AccountClinicModel> listAccountClinicModel = accountClinicService.getListAccountClinicMbs(id);
		profileStandard.setListAccountClinic(listAccountClinicModel);
		profileStandard.setAccountId(phrProfile.getAccount().getId());
        
        return profileStandard;
    }
    
    @Override
	public Boolean deleteStandardProfile(Long profileId){
    	Boolean isDeleted = true;
		PhrProfile phrProfile = profileRepository.findByIdAndActiveFlg(profileId, ActiveFlag.ACTIVE.toInt());
		boolean deleable = phrProfile != null 
				&& phrProfile.getActiveProfileFlg().equals(Constant.PROFILE_FLG_INACTIVE)
				&& !phrProfile.getFamilyMemberType().equals(Constant.PERSONAL_FAMILY);
												
		if(deleable){
			phrProfile.setActiveFlg(ActiveFlag.INACTIVE.toInt());
			profileRepository.save(phrProfile);
//
//			List<AccountClinicModel> listAccountClinicModel = accountClinicService.getListAccountClinic(profileId);
//			for (AccountClinicModel accountClinicModel : listAccountClinicModel) {
//				accountClinicService.deleteAccountClinic(accountClinicModel.getId());
//			}
		} else {
			isDeleted = false;
		}

		return isDeleted;
	}
    

	@Override
	public BabyTimeLine getTimelineBabyProfileByLastestDay(
			Long profileId, Integer limit) {
		BabyTimeLine babyTimeLine = new BabyTimeLine();
		PhrProfile babyProfile = profileRepository.getProfileByProfileIdAndBabyFlgAndActiveProfileFlg(profileId, Constant.BABY_FLG_ACTIVE);
		if(babyProfile == null){
			return null;
		}
		List<TimeLineDate> listProfileTimeline = sortListProfileTimeline(profileId, limit);


		Map<String, List<TimeLineDate>> map = new HashMap<>();
		for(TimeLineDate timeLineDate : listProfileTimeline){
			String date = DateUtil.toString(timeLineDate.getTimestamp(), DateUtil.PATTERN_YYYY_MM_DD);
			if(map.containsKey(date))
			{
				map.get(date).add(timeLineDate);
			}
			else {
				List<TimeLineDate> timeLineDates = new ArrayList<TimeLineDate>();
				timeLineDates.add(timeLineDate);
				map.put(date, timeLineDates);
			}
		}
		List<BabyTimeLineDate> babyTimeLineDates = new ArrayList<>();
		for (Map.Entry<String, List<TimeLineDate>> entry : map.entrySet()) {
			BabyTimeLineDate babyTimeLineDate = new BabyTimeLineDate();
			babyTimeLineDate.setDate(entry.getKey());
			if(entry.getKey() != null)
			{
				String[] date = entry.getKey().split("-");
				if(date.length > 2)
				{
					Calendar fromCalendar = Calendar.getInstance();
					fromCalendar.set(Integer.parseInt(date[0]),  Integer.parseInt(date[1])+ 1,  Integer.parseInt(date[2]));
					babyTimeLineDate.setDateTime(fromCalendar.getTime());
				}

			}
			for(TimeLineDate timeLineDate: entry.getValue() )
			{
				if(timeLineDate instanceof PhrBabyMilk){
					BabyMilkModel babyMilkModel = new BabyMilkModel();
					BeanUtils.copyProperties( timeLineDate, babyMilkModel, Language.JAPANESE.toString());
					babyTimeLineDate.getListBabyMilk().add(babyMilkModel);
				}else if(timeLineDate instanceof PhrBabyFood){
					BabyFoodModel babyFoodModel = new BabyFoodModel();
					BeanUtils.copyProperties(timeLineDate, babyFoodModel, Language.JAPANESE.toString());
					babyTimeLineDate.getListBabyFood().add(babyFoodModel);

				}else if(timeLineDate instanceof PhrBabyDiaper){
					BabyDiaperModel babyDiaperModel = new BabyDiaperModel();
					BeanUtils.copyProperties(timeLineDate, babyDiaperModel, Language.JAPANESE.toString());
					babyTimeLineDate.getListBabyDiaper().add(babyDiaperModel);

				}else if(timeLineDate instanceof PhrMedicine){
					MedicineModel medicineModel = new MedicineModel();
					BeanUtils.copyProperties(timeLineDate, medicineModel, Language.JAPANESE.toString());
					babyTimeLineDate.getListMedicine().add(medicineModel);

				}else if(timeLineDate instanceof PhrBabyGrowthHeight){
					BabyGrowthHeightModel babyGrowthHeightModel = new BabyGrowthHeightModel();
					BeanUtils.copyProperties(timeLineDate, babyGrowthHeightModel, Language.JAPANESE.toString());
					babyGrowthHeightModel.setId(BigInteger.valueOf(((PhrBabyGrowthHeight) timeLineDate).getId()));
					babyTimeLineDate.getListBabyGrowthHeight().add(babyGrowthHeightModel);
				}else if(timeLineDate instanceof PhrBabyGrowthWeight){
					BabyGrowthWeightModel babyGrowthWeightModel = new BabyGrowthWeightModel();
					BeanUtils.copyProperties(timeLineDate, babyGrowthWeightModel, Language.JAPANESE.toString());
					babyGrowthWeightModel.setId(BigInteger.valueOf(((PhrBabyGrowthWeight) timeLineDate).getId()));
					babyTimeLineDate.getListBabyGrowthWeight().add(babyGrowthWeightModel);
				}else if(timeLineDate instanceof PhrBabySleep){
					BabySleepModel babySleepModel = new BabySleepModel();
					BeanUtils.copyProperties(timeLineDate, babySleepModel, Language.JAPANESE.toString());
					babyTimeLineDate.getListBabySleep().add(babySleepModel);
				}
			}
			babyTimeLineDates.add(babyTimeLineDate);
		}
		Collections.sort(babyTimeLineDates, (o1, o2) -> {
            Date date1 = o1.getDateTime();
            Date date2 = o2.getDateTime();
            if (date1 == null) return 1;
            if (date2 == null) return -1;
            return (date2).compareTo(date1);
        });

		BeanUtils.copyProperties(babyProfile, babyTimeLine, Language.JAPANESE.toString());
		if(!StringUtils.isEmpty(babyProfile.getBirthday()) &&
				DateUtil.toDate(babyProfile.getBirthday(), DateUtil.PATTERN_YYMMDD) != null){
			int age = CommonUtils.getAge(DateUtil.toDate(babyProfile.getBirthday(), DateUtil.PATTERN_YYMMDD));
			babyTimeLine.setAge(new BigDecimal(age));
		}
		babyTimeLine.setBabyTimelineDates(babyTimeLineDates);
		return babyTimeLine;
	}
	
	public List<TimeLineDate> sortListProfileTimeline(Long profileId, Integer limit){

		List<PhrBabyMilk> listBabyMilk = babyMilkRepository.getBabyMilkByLastestDay(profileId, limit);
		List<PhrBabyFood> listBabyFood = babyFoodRepository.getBabyFoodByLastestDay(profileId, limit);
		List<PhrBabyDiaper> listBabyDiaper = babyDiaperRepository.getBabyDiaperByLastestDay(profileId, limit);
		List<PhrMedicine> listMedicine = medicineRepository.getMedicineByLastestDay(profileId, limit);
		List<PhrBabyGrowthHeight> listBabyGrowthHeight = babyGrowthHeightRepository.getBabyGrowthHeightByLastestDay(profileId, limit);
		List<PhrBabyGrowthWeight> listBabyGrowthWeight = babyGrowthWeightRepository.getBabyGrowthWeightByLastestDay(profileId, limit);
		List<PhrBabySleep> listBabySleep = babySleepRepository.getBabySleepByLastestDay(profileId, limit);

		List<TimeLineDate> listGeneric = new ArrayList<>();
		listGeneric.addAll(listBabyMilk);
		listGeneric.addAll(listBabyFood);
		listGeneric.addAll(listBabyDiaper);
		listGeneric.addAll(listMedicine);
		listGeneric.addAll(listBabyGrowthHeight);
		listGeneric.addAll(listBabyGrowthWeight);
		listGeneric.addAll(listBabySleep);


		Collections.sort(listGeneric, (o1, o2) -> {
			Date date1 = o1.getTimestamp();
			Date date2 = o2.getTimestamp();
			if (date1 == null) return 1;
			if (date2 == null) return -1;
			return (date2).compareTo(date1);
		});
		
		limit = limit < listGeneric.size() ? limit : listGeneric.size();
		return listGeneric.subList(0, limit);
	}
	
	@Override
	public StandardHomePage getStandardHomepageByProfileId(Long profileId, Long userId) throws ParseException {
		StandardHomePage standardHomePage = new StandardHomePage();
		PhrProfile standardProfile = profileRepository.getProfileByProfileIdAndBabyFlgAndActiveProfileFlg(profileId, Constant.BABY_FLG_INACTIVE);
		if(standardProfile != null){

			BeanUtils.copyProperties(standardProfile, standardHomePage, Language.JAPANESE.toString());
			standardHomePage.setAccountId(standardProfile.getAccount().getId());
			if(!StringUtils.isEmpty(standardProfile.getBirthday())){
				int age = CommonUtils.getAge(DateUtil.toDate(standardProfile.getBirthday(), DateUtil.PATTERN_YYMMDD));
				standardHomePage.setAge(new BigDecimal(age));
			}
			// 1. Get Health data
			HeightModel standardHealthHeightModel = new HeightModel();
			List<PhrStandardHealthHeight> standardHealthHeights = standardHealthHeightRepository.getLastestHealthHeightByProfileId(profileId);
			if(!CollectionUtils.isEmpty(standardHealthHeights)){
				PhrStandardHealthHeight standardHealthHeight = standardHealthHeights.get(0);
				BeanUtils.copyProperties(standardHealthHeight, standardHealthHeightModel, Language.JAPANESE.toString());
				standardHealthHeightModel.setHealthId(standardHealthHeight.getId().toString());
				standardHomePage.setStandardHealthHeightModel(standardHealthHeightModel);
			}
			WeightModel standardHealthWeightModel = new WeightModel();
			List<PhrStandardHealthWeight> standardHealthWeights = standardHealthWeightRepository.getLastestHealthWeightByProfileId(profileId);
			if(!CollectionUtils.isEmpty(standardHealthWeights)){
				PhrStandardHealthWeight standardHealthWeight = standardHealthWeights.get(0);
				BeanUtils.copyProperties(standardHealthWeight, standardHealthWeightModel, Language.JAPANESE.toString());
				standardHealthWeightModel.setHealthId(standardHealthWeight.getId().toString());
				standardHomePage.setStandardHealthWeightModel(standardHealthWeightModel);
			}
			BmiModel standardHealthBmiModel = new BmiModel();
			List<PhrStandardHealthBmi> standardHealthBmis = standardHealthBmiRepository.getLastestHealthBmiByProfileId(profileId);
			if(!CollectionUtils.isEmpty(standardHealthBmis)){
				PhrStandardHealthBmi standardHealthBmi = standardHealthBmis.get(0);
				BeanUtils.copyProperties(standardHealthBmi, standardHealthBmiModel, Language.JAPANESE.toString());
				standardHealthBmiModel.setHealthId(standardHealthBmi.getId().toString());
				standardHomePage.setStandardHealthBmiModel(standardHealthBmiModel);
			}
			PercFatModel standardHealthBfpModel= new PercFatModel();
			List<PhrStandardHealthBfp> standardHealthBfps = standardHealthBfpRepository.getLastestHealthBfpByProfileId(profileId);
			if(!CollectionUtils.isEmpty(standardHealthBfps)){
				PhrStandardHealthBfp standardHealthBfp = standardHealthBfps.get(0);
				BeanUtils.copyProperties(standardHealthBfp, standardHealthBfpModel, Language.JAPANESE.toString());
				standardHealthBfpModel.setHealthId(standardHealthBfp.getId().toString());
				standardHomePage.setStandardHealthBfpModel(standardHealthBfpModel);
			}
			
			// 2. Get Food data
			CaloriesModel standardFoodCaloryModel = new CaloriesModel();
			BigDecimal totalKcal = standardFoodCaloryRepository.getLastestFoodCaloryByProfileId(profileId);
			if(totalKcal != null){
				standardFoodCaloryModel.setKcal(totalKcal);
				standardHomePage.setStandardFoodCaloryModel(standardFoodCaloryModel);
			}
			CarbohydrateModel standardFoodCarbohydrateModel = new CarbohydrateModel();
			BigDecimal totalCarbohydrate = standardFoodCarbohydrateRepository.getLastestFoodCarbohydrateByProfileId(profileId);
			if(totalCarbohydrate != null){
				standardFoodCarbohydrateModel.setCarbohydrate(totalCarbohydrate);
				standardHomePage.setStandardFoodCarbohydrateModel(standardFoodCarbohydrateModel);
			}
			TotalFatModel standardFoodTotalFatModel = new TotalFatModel();
			BigDecimal totalFat = standardFoodTotalFatRepository.getLastestFoodTotalFatByProfileId(profileId);
			if(totalFat != null){
				standardFoodTotalFatModel.setTotalFat(totalFat);
				standardHomePage.setStandardFoodTotalFatModel(standardFoodTotalFatModel);
			}
			// 3. Get Temperature/ Physiological data
			StandardTempTemperatureModel standardTempTemperatureModel = new StandardTempTemperatureModel();
			List<PhrStandardTempTemperature> standardTempTemperatures = standardTempTemperatureRepository.getLastestTempTemperatureByProfileId(profileId);
			if(!CollectionUtils.isEmpty(standardTempTemperatures)){
				PhrStandardTempTemperature standardTempTemperature = standardTempTemperatures.get(0);
				BeanUtils.copyProperties(standardTempTemperature, standardTempTemperatureModel, Language.JAPANESE.toString());
				standardHomePage.setStandardTempTemperatureModel(standardTempTemperatureModel);
			}
			StandardTempHeartrateModel standardTempHeartrateModel =  new StandardTempHeartrateModel();
			List<PhrStandardTempHeartrate> standardTempHeartrates = standardTempHeartrateRepository.getLastestTempHeartrateByProfileId(profileId);
			if(!CollectionUtils.isEmpty(standardTempHeartrates)){
				PhrStandardTempHeartrate standardTempHeartrate = standardTempHeartrates.get(0);
				BeanUtils.copyProperties(standardTempHeartrate, standardTempHeartrateModel, Language.JAPANESE.toString());
				standardHomePage.setStandardTempHeartrateModel(standardTempHeartrateModel);
			}
			StandardTempBreathModel standardTempBreathModel = new StandardTempBreathModel();
			List<PhrStandardTempBreath> standardTempBreaths = standardTempBreathRepository.getLastestTempBreathByProfileId(profileId);
			if(!CollectionUtils.isEmpty(standardTempBreaths)){
				PhrStandardTempBreath standardTempBreath = standardTempBreaths.get(0);
				BeanUtils.copyProperties(standardTempBreath, standardTempBreathModel, Language.JAPANESE.toString());
				standardHomePage.setStandardTempBreathModel(standardTempBreathModel);
			}
			StandardTempBpModel standardTempBpModel = new StandardTempBpModel();
			List<PhrStandardTempBp> standardTempBps = standardTempBpRepository.getLastestTempBpByProfileId(profileId);
			if(!CollectionUtils.isEmpty(standardTempBps)){
				PhrStandardTempBp standardTempBp = standardTempBps.get(0);
				BeanUtils.copyProperties(standardTempBp, standardTempBpModel, Language.JAPANESE.toString());
				standardHomePage.setStandardTempBpModel(standardTempBpModel);
			}
			// 4. Get Fitness data
			StandardFitnessStepModel standardFitnessStepModel = new StandardFitnessStepModel();
			BigDecimal totalSteps = standardFitnessStepRepository.getLastestFitnessStepByProfileId(profileId);
			if(totalSteps != null){
				standardFitnessStepModel.setStepsCount(totalSteps);
				standardHomePage.setStandardFitnessStepModel(standardFitnessStepModel);
			}
			StandardFitnessDistanceModel standardFitnessDistanceModel = new StandardFitnessDistanceModel();
			BigDecimal totalDistances = standardFitnessDistanceRepository.getLastestFitnessDistanceByProfileId(profileId);
			if(totalDistances != null){
				standardFitnessDistanceModel.setWalkRunDistance(totalDistances);
				standardHomePage.setStandardFitnessDistanceModel(standardFitnessDistanceModel);
			}
			//
			StandardLifeDataStyleNoteModel standardLifeDataStyleNoteModel = new StandardLifeDataStyleNoteModel();
			BigInteger totalHoursSleep = standardLifeStyleRepository.getLastestTotalHoursSleepByProfileId(profileId);
			if(totalHoursSleep != null){
				standardLifeDataStyleNoteModel.setSleepTime(totalHoursSleep);
				standardHomePage.setStandardLifeStyleModel(standardLifeDataStyleNoteModel);
			}
		}
		
		return standardHomePage;
	}
	
	private BigDecimal getBmiFromStandardHealth(Long profileId){
		PhrStandardHealth standardHealth;
		BigDecimal bmi = null;
		List<PhrStandardHealth> listStandardHealth = standardHealthRepository.getHealthByProfileId(profileId);
		if(listStandardHealth != null && listStandardHealth.size() > 0){
			standardHealth = listStandardHealth.get(0);
			if(standardHealth.getHeight() != null &&  standardHealth.getWeight() != null){
				BigDecimal weight = standardHealth.getWeight();
				BigDecimal height = standardHealth.getHeight();
				height = height.multiply(height);
		        bmi = weight.divide(height, 2, RoundingMode.HALF_UP);
			}
		}
		return bmi;
	}
	
	private BigDecimal getTotalKcalStandardFoodMenuByProfileId(Long profileId) throws ParseException{
		Calendar frCal = Calendar.getInstance();
		Calendar toCal = Calendar.getInstance();
		frCal.set(Calendar.HOUR, 0);
		frCal.set(Calendar.MINUTE, 0);
		frCal.set(Calendar.SECOND, 0);
		
		toCal.set(Calendar.HOUR, 23);
		toCal.set(Calendar.MINUTE, 59);
		toCal.set(Calendar.SECOND, 59);
		
		Date frDate = frCal.getTime();
		Date toDate = toCal.getTime();
		return standardFoodRepository.getTotalKcalByProfileId(profileId, frDate, toDate);
	}
	
	private PhrStandardTemperature getTemperatureByProfileId(Long profileId){
		List<PhrStandardTemperature> listTemperature = standardTemperatureRepository.getTemperatureByProfileId(profileId);
		if(!CollectionUtils.isEmpty(listTemperature)){
			return listTemperature.get(0);
		}
		
		return new PhrStandardTemperature();
	}
	
	private PhrMedicine getMedicineByProfileId(Long profileId){
		List<PhrMedicine> listMedicine = medicineRepository.getMedicineByProfileId(profileId, new Date());
		if(!CollectionUtils.isEmpty(listMedicine)){
			return listMedicine.get(0);
		}
		return null;
	}
	
	private Integer getLifeStyleByProfileId(Long profileId){
		Integer totalSleepTime = null;
		List<PhrStandardLifeStyle> listStandardLifeStyle = standardLifeStyleRepository.getTotalSleepTimeByProfileId(profileId);
		if(!CollectionUtils.isEmpty(listStandardLifeStyle)){
			PhrStandardLifeStyle standardLifeStyle = listStandardLifeStyle.get(0);
			totalSleepTime = standardLifeStyle.getTotalHourSleep();
		}
		return totalSleepTime;
	}

	@Override
	public ProfileStandard addStandardProfile(ProfileStandard profileStandard, Long userId) {
		PhrProfile phrProfile = new PhrProfile();
		//profileStandard.copyToEntity(phrProfile);
		BeanUtils.copyProperties(profileStandard, phrProfile, Language.JAPANESE.toString());
		phrProfile.setActiveFlg(ActiveFlag.ACTIVE.toInt());
		phrProfile.setActiveProfileFlg(BigDecimal.valueOf(ActiveFlag.INACTIVE.toInt()));
		phrProfile.setBabyFlg(BigDecimal.valueOf(ActiveFlag.INACTIVE.toInt()));
		phrProfile.setLocale(Constant.JA_LOCALE);
		phrProfile.setFamilyMemberType(Constant.MEMBER_FAMILY);
		
		if(userId != null){
			PhrAccount phrAccount = phrAccountRepository.findByIdAndActiveFlg(userId, ActiveFlag.ACTIVE.toInt());
			phrProfile.setAccount(phrAccount);
			
			if(phrProfile.getFullNameKana() == null){
				phrProfile.setFullNameKana("");
			}
			profileRepository.save(phrProfile);
			
			// insert common clinic account
//			PhrAccountClinic phrAccountClinic = new PhrAccountClinic();
//			phrAccountClinic.setHospCode(Constant.HOSP_CODE_DEFAULT);
//			phrAccountClinic.setHospName(Constant.HOSP_NAME_DEFAULT);
//			phrAccountClinic.setUsername(Constant.PREFIX_USER_NAME + phrProfile.getId());
//			phrAccountClinic.setProfileId(phrProfile.getId());
//			accountClinicRepository.save(phrAccountClinic);
			
			// insert list clinic account
			List<AccountClinicModel> listAccountClinicModel = profileStandard.getListAccountClinic();
//			if(!CollectionUtils.isEmpty(listAccountClinicModel)){
//				for (AccountClinicModel accountClinicModel : listAccountClinicModel) {
//					accountClinicModel.setProfileId(phrProfile.getId());
//					accountClinicModel.setHospCode(Constant.HOSP_CODE_DEFAULT);
//					accountClinicModel.setHospName(Constant.HOSP_NAME_DEFAULT);
//
//					accountClinicService.addAccountClinic(accountClinicModel);
//				}
//
//				listAccountClinicModel = accountClinicService.getListAccountClinicIgnoreCommonAccount(phrProfile.getId());
//			}
//
//			profileStandard.setAccountId(phrProfile.getAccount().getId());
			profileStandard.setListAccountClinic(listAccountClinicModel);
			
			//medApiService.createOUT0101(phrAccountClinic.getUsername());
		}

		BeanUtils.copyProperties(phrProfile, profileStandard, Language.JAPANESE.toString());
		return profileStandard;
	}

	
	@Override
	public Boolean activeProfile( Long requestActiveProfileId ,String udid, int type){
		PhrProfile profile = profileRepository.findOne(requestActiveProfileId);

		if(type == 0 && profile != null && profile.getBabyFlg().equals(Constant.BABY_FLG_INACTIVE))
		{
			List<PhrProfile> phrProfiles = profileRepository.findByActiveProfileFlgAndBabyFlgAndUdid(BigDecimal.ONE, Constant.BABY_FLG_INACTIVE, udid);
			for(PhrProfile phrItem : phrProfiles)
			{
				phrItem.setActiveProfileFlg(BigDecimal.ZERO);
				profileRepository.save(phrItem);
			}

			profile.setUdid(udid);
			profile.setActiveProfileFlg(BigDecimal.ONE);
			profileRepository.save(profile);
			return true;
		}
		else if(type == 1 && profile != null && profile.getBabyFlg().equals(Constant.BABY_FLG_ACTIVE))
		{
			List<PhrProfile> phrProfiles = profileRepository.findByActiveProfileFlgAndBabyFlgAndUdid(BigDecimal.ONE, Constant.BABY_FLG_ACTIVE, udid);
			for(PhrProfile phrItem : phrProfiles)
			{
				phrItem.setActiveProfileFlg(BigDecimal.ZERO);
				profileRepository.save(phrItem);
			}

			profile.setUdid(udid);
			profile.setActiveProfileFlg(BigDecimal.ONE);
			profileRepository.save(profile);
			return true;
		}

		
		return false;
	}

	@Override
	public Boolean activeAccountClinic(Long profileId, Long requestActiveClinicAccountId) {
		accountClinicRepository.deactiveByProfileId(profileId);
		int rowUpdated = accountClinicRepository.setActiveAccount(profileId, requestActiveClinicAccountId);
		return rowUpdated > 0;
	}
	
	@Override
	public PatientClinicModel addAccountClinic(Long profileId, KcckAccountModel model) {
		// check exits account
		List<PhrAccountClinic> accts = accountClinicRepository.findByHospCodeAndPatientCode(model.getHospCode(), model.getUsername());
		if(!CollectionUtils.isEmpty(accts)){
			return new PatientClinicModel();
		}
		
		// verify account
//		PatientModel patientModel = systemAdapter.verifyPatientAccount(model);
//		if(patientModel == null){
//			return null;
//		}
		
		PatientModel patientModel = null;
		
		PatientServiceProto.VerifyPatientAccountRequest.Builder request = PatientServiceProto.VerifyPatientAccountRequest.newBuilder();
		request.setHospCode(model.getHospCode());
		request.setUsername(model.getUsername());
		request.setPassword(model.getPassword());
		
		PatientServiceProto.VerifyPatientAccountResponse response = patientRpcService.verifyPatientAccount(request.build());
		if(response != null && !StringUtils.isEmpty(response.getHospCode())){
			patientModel = new PatientModel();
			patientModel.setHospCode(response.getHospCode());
			patientModel.setHospName(response.getHospName());
			patientModel.setPatientCode(response.getPatientCode());
		} else {
			return null;
		}
		
		// find active account clinic 
		List<PhrAccountClinic> listActiveAcct = accountClinicRepository.findActiveAccountByProfileId(profileId);
		int activeAccountClinicFlag = CollectionUtils.isEmpty(listActiveAcct) ? ActiveFlag.ACTIVE.toInt() : ActiveFlag.INACTIVE.toInt();
		
		// insert new account clinic
		PhrAccountClinic account = new PhrAccountClinic();
		account.setProfileId(profileId);
		account.setUsername(patientModel.getPatientCode());
		account.setHospCode(patientModel.getHospCode());
		account.setHospName(patientModel.getHospName());
		account.setPatientCode(patientModel.getPatientCode());
		account.setActiveFlg(ActiveFlag.ACTIVE.toInt());
		account.setActiveClinicAccountFlg(activeAccountClinicFlag);
		
		accountClinicRepository.save(account);
		
		PatientClinicModel patientClinicModel = new PatientClinicModel();
		BeanUtils.copyProperties(account, patientClinicModel, Language.JAPANESE.toString());
		
		return patientClinicModel;
	}



	@Override
	public boolean isValidUidStandard(Long profileId, String udid) {
		PhrProfile profile = profileRepository.findOne(profileId);
		if(profile != null)
		{
			return profile.getUdid() != null && profile.getUdid().equals(udid) && profile.getActiveFlg() != null
				&& profile.getActiveFlg() == ActiveFlag.ACTIVE.toInt() && profile.getBabyFlg() != null &&
					profile.getBabyFlg().equals(ProfileMode.STANDARD.getValue()) ;
					
		}
		else
		{
			return false;
		}
	}
	@Override
	public boolean isValidUidBaby(Long profileId, String udid) {
		PhrProfile profile = profileRepository.findOne(profileId);
		if(profile != null)
		{
			return profile.getUdid() != null && profile.getUdid().equals(udid) && profile.getActiveFlg() != null
					&& profile.getActiveFlg() == ActiveFlag.ACTIVE.toInt() && profile.getBabyFlg() != null &&
					profile.getBabyFlg().equals(ProfileMode.BABY.getValue()) ;

		}
		else
		{
			return false;
		}
	}

	@Override
	public AccountInfo getAccountInfo(Long accountId) throws EntityNotFoundException {
		AccountInfoDto accountInfoDto = profileRepositoryImpl.getAccountInfoByAccountId(accountId);
        if(accountInfoDto != null) {
        	AccountInfo accountInfo = new AccountInfo();
			BeanUtils.copyProperties(accountInfoDto, accountInfo, Language.JAPANESE.toString());
			accountInfo.setId(accountId);
            return accountInfo;
        } else {
            throw new EntityNotFoundException(Message.MESSAGE_PROFILE_NOT_FOUND.getValue());
        }
	}

	@Override
	public List<UserChildInfo> getUserChildInfo(Long accountId) throws EntityNotFoundException {
		List<UserChildDto> userChilds = profileRepository.getUserchildsByAccountId(accountId);
		List<UserChildInfo> listProfileModel = new ArrayList<>();
		if(!CollectionUtils.isEmpty(userChilds)) {
			for(UserChildDto item : userChilds) {
				UserChildInfo info = new UserChildInfo();
				BeanUtils.copyProperties(item, info, Language.JAPANESE.toString());
				listProfileModel.add(info);
			}
		}
		return listProfileModel;
	}

	@Override
	public UserChildInfo getUserChildByChildId(BigInteger childId) throws EntityNotFoundException {
		UserChildDto userChildDto = profileRepositoryImpl.getUserchildByChildId(childId);
        if(userChildDto != null) {
        	UserChildInfo userChildInfo = new UserChildInfo();
			BeanUtils.copyProperties(userChildDto, userChildInfo, Language.JAPANESE.toString());
			userChildInfo.setId(childId);
            return userChildInfo;
        } else {
            throw new EntityNotFoundException(Message.MESSAGE_PROFILE_NOT_FOUND.getValue());
        }
	}
	
}
