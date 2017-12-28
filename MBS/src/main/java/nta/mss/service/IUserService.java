package nta.mss.service;

import java.util.List;

import nta.mss.model.UserModel;

/**
 * The Interface UserService.
 *
 * @author MinhLS
 * @crtDate 2015/01/20
 */
public interface IUserService {

	UserModel getUser(Integer userId);
	UserModel getActiveUserByLoginId (String loginId, Integer hospitalId);
	UserModel getActiveUserByEmail (String email, Integer hospitalId);
	UserModel getActiveUserByEmailAndLoginId (String email, Integer hospitalId);
	UserModel getUserByEmail(String email, Integer hospitalId);
	UserModel getUserByLoginId(String loginId, Integer hospitalId);
	//List<UserModel> getAllUser();
	//List<UserModel> getAllUserByHospitalCode(String hospitalCode);

	UserModel updatePassword(UserModel userModel);
	boolean deleteUser(UserModel userModel);
	boolean addNewUser(UserModel userModel, boolean isActive) throws Exception;
	boolean registerUser(String email, Integer hospitalId);
	public void saveUser(UserModel userModel) throws Exception;
	//public UserModel findUserById(Integer userId) throws Exception;
	public List<UserModel> findByCondition(UserModel userModel) throws Exception;
	public UserModel findByToken(String tokenId) throws Exception;

	//UserModel getUserByUserId(Integer userId, String token);
}
