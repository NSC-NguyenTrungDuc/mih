package nta.mss.service;

import java.util.List;

import nta.mss.entity.UserChild;
import nta.mss.model.UserChildModel;

/**
 * The Interface IUserChildService.
 *
 */
public interface IUserChildService {

	/**
	 * Find user child by active flg.
	 *
	 * @param activeFlg the active flg
	 * @return the list
	 */
	public List<UserChildModel> findUserChildByActiveFlg(Integer userId, Integer activeFlg) throws Exception;
	
	/**
	 * Find by id.
	 *
	 * @param childId the child id
	 * @return the user child model
	 */
	public UserChildModel findById(Integer childId) throws Exception;
	
	/**
	 * Find by id.
	 *
	 * @param childId the child id
	 * @return the user child model
	 */
	//public UserChildModel findById(Integer childId, String token) throws Exception;
	
	/**
	 * Save.
	 *
	 * @param userChildModel the user child model
	 * @throws Exception the exception
	 */
	public void save(UserChildModel userChildModel) throws Exception;

	/**
	 * 
	 * @param patientId
	 * @return
	 */
	public UserChild getUserChildByPatientId(Integer patientId);
	
	//public List<UserChildModel> findUserChildByUserId(Integer userId, String token);
}
