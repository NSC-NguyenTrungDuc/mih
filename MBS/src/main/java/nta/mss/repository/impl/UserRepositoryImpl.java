package nta.mss.repository.impl;

import java.util.HashMap;
import java.util.List;
import java.util.Map;

import javax.persistence.EntityManager;
import javax.persistence.PersistenceContext;
import javax.persistence.Query;

import nta.mss.entity.User;
import nta.mss.misc.common.MssContextHolder;
import nta.mss.model.UserModel;
import nta.mss.repository.UserRepositoryCustom;

import org.apache.commons.lang.StringUtils;

public class UserRepositoryImpl implements UserRepositoryCustom {

	@PersistenceContext
	private EntityManager entityManager;
	
	@SuppressWarnings("unchecked")
	@Override
	public List<User> findByCondition(UserModel userModel)
			throws Exception {
		Map<String, Object> mapParams = new HashMap<String, Object>();
		StringBuilder sql = new StringBuilder();
		sql.append("SELECT u FROM User u WHERE u.activeFlg = 1 ");
		if (!StringUtils.isBlank(userModel.getName())) {
			sql.append("AND lower(u.name) LIKE :name ");
			mapParams.put("name", "%" + userModel.getName().trim().toLowerCase() + "%");
		}
		if (!StringUtils.isBlank(userModel.getNameFurigana())) {
			sql.append("AND u.nameFurigana LIKE :nameFurigana ");
			mapParams.put("nameFurigana", "%" + userModel.getNameFurigana() + "%");
		}
		if (!StringUtils.isBlank(userModel.getPhoneNumber())) {
			sql.append("AND u.phoneNumber LIKE :phoneNumber ");
			mapParams.put("phoneNumber", "%" + userModel.getPhoneNumber() + "%");
		}
		if (!StringUtils.isBlank(userModel.getEmail())) {
			sql.append("AND u.email LIKE :email ");
			mapParams.put("email", "%" + userModel.getEmail() + "%");
		}
		
		sql.append("AND u.hospital.hospitalId = :hospitalId ");
		mapParams.put("hospitalId", MssContextHolder.getHospitalId());
		
		Query query = entityManager.createQuery(sql.toString());
		for (Map.Entry<String, Object> entry : mapParams.entrySet()) {
			query.setParameter(entry.getKey(), entry.getValue());
		}
		List<User>  lstUser = query.getResultList();
		return lstUser;
	}
	
}
