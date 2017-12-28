package nta.mss.service.impl;

import java.util.ArrayList;
import java.util.List;

import nta.mss.misc.common.MssConfiguration;
import org.apache.commons.collections.CollectionUtils;
import org.apache.commons.lang.StringUtils;
import org.dozer.Mapper;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;

import nta.mss.entity.Hospital;
import nta.mss.entity.User;
import nta.mss.misc.common.EncryptionUtils;
import nta.mss.misc.enums.ActiveFlag;
import nta.mss.misc.enums.UserStatus;
import nta.mss.model.UserModel;
import nta.mss.repository.HospitalRepository;
import nta.mss.repository.UserRepository;
import nta.mss.repository.UserRepositoryCustom;
import nta.mss.service.IUserService;

/**
 * The Class UserService.
 *
 * @author MinhLS
 * @crtDate 2015/01/20
 */
@Service
@Transactional
public class UserService implements IUserService {
	// private static Logger LOG = LogManager.getLogger(SysUserService.class);
	private Mapper mapper;
	private UserRepository userRepository;
	private UserRepositoryCustom userRepositoryCustom;
	private HospitalRepository hospitalRepository;

	public UserService() {
	}

	/**
	 * Instantiates a new user service.
	 *
	 * @param mapper the mapper
	 * @param userRepository the user repository
	 */
	@Autowired
	public UserService(Mapper mapper, UserRepository userRepository, UserRepositoryCustom userRepositoryCustom, HospitalRepository hospitalRepository) {
		this.mapper = mapper;
		this.userRepository = userRepository;
		this.userRepositoryCustom = userRepositoryCustom;
		this.hospitalRepository = hospitalRepository;
	}

	public UserModel getUser(Integer userId) {
		User user = this.userRepository.findOne(userId);
		return user == null ? null : user.toModel(this.mapper);
	}

	public UserModel getActiveUserByLoginId (String loginId, Integer hospitalId) {
		List<User> userList = this.userRepository.findByLoginIdAndStatus(loginId, UserStatus.REGISTER_COMPLETED.toInt(), hospitalId, ActiveFlag.ACTIVE.toInt());
		if (userList.isEmpty()) {
			return null;
		}
		return userList.get(0).toModel(mapper);
	}

	public UserModel getActiveUserByEmail (String email, Integer hospitalId) {
		List<User> userList = this.userRepository.findByEmailAndStatus(email, UserStatus.REGISTER_COMPLETED.toInt(), hospitalId);
		if (userList.isEmpty()) {
			return null;
		}
		return userList.get(0).toModel(mapper);
	}
	public UserModel getActiveUserByEmailAndLoginId (String email, Integer hospitalId)
	{
		List<User> userList = this.userRepository.findByEmailAndStatusAndLoginId(email, UserStatus.REGISTER_COMPLETED.toInt(), hospitalId);
		if (userList.isEmpty()) {
			return null;
		}
		return userList.get(0).toModel(mapper);
	}
	public UserModel getUserByEmail(String email, Integer hospitalId) {
		List<User> userList = this.userRepository.findByEmailAndLoginIdIsNull(email, hospitalId);
		if (userList.isEmpty()) {
			return null;
		}
		return userList.get(0).toModel(mapper);
	}

	public UserModel getUserByLoginId(String loginId, Integer hospitalId) {
		List<User> userList = this.userRepository.findByLoginId(loginId, hospitalId);
		if (userList.isEmpty()) {
			return null;
		}
		return userList.get(0).toModel(mapper);
	}

	/*public List<UserModel> getAllUser() {
		List<UserModel> result = new ArrayList<>();
		List<User> userList = this.userRepository.getAllUser();
		for (User user : userList) {
			result.add(user.toModel(mapper));
		}
		return result;
	}*/
	
	/*@Override
	public List<UserModel> getAllUserByHospitalCode(String hospitalCode) {
		List<UserModel> result = new ArrayList<>();
		List<User> userList = this.userRepository.getAllUserByHospitalCode(hospitalCode);
		for (User user : userList) {
			result.add(user.toModel(mapper));
		}
		return result;
	}*/

	public UserModel updatePassword(UserModel userModel) {
		List<User> userList = this.userRepository.findByEmail(userModel.getEmail(), userModel.getHospitalId());
		if(!userList.isEmpty()) {
			User user = userList.get(0);
			user.setPassword(EncryptionUtils.cryptWithMD5(userModel.getPassword()));
			this.userRepository.save(user);
			return user.toModel(mapper);
		}
		return null;
	}

	public boolean deleteUser(UserModel userModel) {
		List<User> userList = this.userRepository.findByEmail(userModel.getEmail(), userModel.getHospitalId());
		if(!userList.isEmpty()) {
			User user = userList.get(0);
			user.setActiveFlg(ActiveFlag.INACTIVE.toInt());
			this.userRepository.save(user);
			return true;
		}
		return false;
	}

	public boolean addNewUser(UserModel userModel, boolean isActive) throws Exception {
		List<User> userList = this.userRepository.findByEmail(userModel.getEmail(), userModel.getHospitalId());
		if(userList.isEmpty()) {
			User user = userModel.toEntity(mapper);
			if(userModel.getPassword() != null)
			{
				user.setPassword(EncryptionUtils.cryptWithMD5(userModel.getPassword()));
			}

			user.setUserStatus(UserStatus.REGISTER_ACCEPTED.toInt());
			// set hospitalId
			List<Hospital> hospitalList = this.hospitalRepository.findByHospitalCode(userModel.getHospitalCode());
			if (hospitalList != null && hospitalList.size() != 0) {
				user.setHospital(hospitalList.get(0));
			}

			if(StringUtils.isNotBlank(user.getDob())) {
				String formatedDate = user.getDob().replaceAll("/", "");
				user.setDob(formatedDate);
			}
			if(isActive)
			{
				user.setUserStatus(UserStatus.REGISTER_COMPLETED.toInt());
				user.setPassword(EncryptionUtils.cryptWithMD5(MssConfiguration.getInstance().getDefaultPassword()));
			}

			this.userRepository.save(user);
			return true;
		}
		return false;
	}

	public boolean registerUser(String email, Integer hospitalId) {
		List<User> userList = this.userRepository.findByEmailAndLoginIdIsNull(email, hospitalId);
		if(!userList.isEmpty()) {
			User user = userList.get(0);
			user.setUserStatus(UserStatus.REGISTER_COMPLETED.toInt());
			this.userRepository.save(user);
			return true;
		}
		return false;
	}

	/**
	 * Save user.
	 *
	 * @param userModel the user model
	 */
	public void saveUser(UserModel userModel) throws Exception {
		this.userRepository.save(userModel.toEntity(mapper));
	}
	
	/*public UserModel findUserById(Integer userId) throws Exception {
		if (userId == null) {
			return null;
		}
		User user = this.userRepository.findUserById(userId);
		return user.toModel(mapper);
	}*/

	@Override
	public List<UserModel> findByCondition(UserModel userModel)
			throws Exception {
		List<UserModel> lstUserModel = new ArrayList<UserModel>();
		List<User> lstUser = this.userRepositoryCustom.findByCondition(userModel);
		if (CollectionUtils.isNotEmpty(lstUser)) {
			for (User user : lstUser) {
				lstUserModel.add(user.toModel(mapper));
			}
		}
		return lstUserModel;
	}

	public UserModel findByToken(String tokenId) throws Exception {
		User user = this.userRepository.findUserByToken(tokenId);
		if (user == null) {
			return null;
		}
		return user.toModel(mapper);
	}

	/*@Override
	public UserModel getUserByUserId(Integer userId, String token) {
		UserModel userModel = null;
		
		// Call HPR api
		PhrApiService phrApiService = new PhrApiService();
		PhrAccountInfoModel phrAccountInfoModel = new PhrAccountInfoModel();
		phrAccountInfoModel.setId(new Long(userId));
		PhrAccountInfoModel phrAccountInfoModelRes = phrApiService.getAccountInfo(phrAccountInfoModel, token);
//		System.out.println(phrAccountInfoModelRes.toString());
		
		if(phrAccountInfoModelRes != null) {
			userModel = new UserModel();
			userModel.setName(phrAccountInfoModelRes.getName());
			userModel.setNameFurigana(phrAccountInfoModelRes.getName_kana());
			userModel.setEmail(phrAccountInfoModelRes.getEmail());
			userModel.setDob(phrAccountInfoModelRes.getBirthday());
			
			if("M".equalsIgnoreCase(phrAccountInfoModelRes.getSex()))
				userModel.setSex("1");
			if("F".equalsIgnoreCase(phrAccountInfoModelRes.getSex()))
				userModel.setSex("0");
			
			userModel.setPhoneNumber(null);
			userModel.setUserId(Integer.valueOf(phrAccountInfoModelRes.getId().intValue()));
			userModel.setPatientCode(null);
		}
		
		return userModel;
	}*/

}
