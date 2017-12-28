package nta.mss.repository;

import java.util.List;

import nta.mss.entity.User;
import nta.mss.model.UserModel;

/**
 * The Interface UserRepositoryCustom.
 */
public interface UserRepositoryCustom {
	public List<User> findByCondition(UserModel userModel) throws Exception;
}
