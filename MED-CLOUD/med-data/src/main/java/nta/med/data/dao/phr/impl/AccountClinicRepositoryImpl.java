package nta.med.data.dao.phr.impl;

import java.util.List;

import javax.persistence.EntityManager;
import javax.persistence.PersistenceContext;
import javax.persistence.Query;

import nta.med.core.infrastructure.mapper.JpaResultMapper;
import nta.med.data.dao.phr.AccountClinicRepositoryCustom;
import nta.med.data.model.phr.AccountClinicInfo;

/**
 * @author DEV-TiepNM
 */
public class AccountClinicRepositoryImpl implements AccountClinicRepositoryCustom {
	@PersistenceContext
	private EntityManager entityManager;

	@Override
	public List<AccountClinicInfo> getAccountClinic(Long accountId) {
		StringBuilder sql = new StringBuilder();
		sql.append(" SELECT A.HOSP_CODE , A.PATIENT_CODE, A.PROFILE_ID FROM PHR_ACCOUNT_CLINIC A , PHR_PROFILE B    ");
		sql.append(" WHERE B.ACCOUNT_ID = :accountId AND B.ID = A.PROFILE_ID AND B.FAMILY_MEMBER_TYPE = 'PERSONAL'  ");
		sql.append("  AND A.ACTIVE_FLG = 1                                                                          ");

		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("accountId", accountId);

		List<AccountClinicInfo> accountClinicInfos = new JpaResultMapper().list(query, AccountClinicInfo.class);
		return accountClinicInfos;
	}

	@Override
	public List<AccountClinicInfo> getAccountClinic(String patientCode, String hospCode) {
		StringBuilder sql = new StringBuilder();
		sql.append(
				" SELECT C.ID, A.HOSP_CODE , A.PATIENT_CODE, A.PROFILE_ID FROM PHR_ACCOUNT_CLINIC A , PHR_PROFILE B,  PHR_ACCOUNT C                    ");
		sql.append(
				" WHERE A.PATIENT_CODE = :patientCode and A.HOSP_CODE = :hospCode AND B.ID = A.PROFILE_ID AND B.FAMILY_MEMBER_TYPE = 'PERSONAL'      ");
		sql.append(
				"  AND A.ACTIVE_FLG = 1  AND B.ACCOUNT_ID = C.ID                                                                                        ");

		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hospCode", hospCode);
		query.setParameter("patientCode", patientCode);

		List<AccountClinicInfo> accountClinicInfos = new JpaResultMapper().list(query, AccountClinicInfo.class);
		return accountClinicInfos;
	}

	@Override
	public Integer addPhrAccountClinic(Long profileId, String username, String hospCode, String hospName,
			String patientCode, String sysId) {
		StringBuilder sql0 = new StringBuilder();
		sql0.append(" SELECT A.ID, A.HOSP_CODE , A.PATIENT_CODE, A.PROFILE_ID 											");
		sql0.append(" FROM PHR_ACCOUNT_CLINIC A 																	");
		sql0.append(" WHERE A.HOSP_CODE =:hospCode AND A.PATIENT_CODE =:patientCode  ");
		Query query0 = entityManager.createNativeQuery(sql0.toString());
		query0.setParameter("hospCode", hospCode);
		query0.setParameter("patientCode", patientCode);
//		query0.setParameter("profileId", profileId);
		List<AccountClinicInfo> accountClinicInfos = new JpaResultMapper().list(query0, AccountClinicInfo.class);
		if (accountClinicInfos.size() > 0)
			return -1;
		else {
			StringBuilder sql = new StringBuilder();
			sql.append(
					" INSERT INTO PHR_ACCOUNT_CLINIC(profile_id,username,hosp_code,hosp_name,patient_code,sys_id,active_flg,active_clinic_account_flg) ");
			sql.append(" VALUES(:profileId,:username,:hospCode,:hospName, :patientCode,:sysId,1,1)");
			Query query = entityManager.createNativeQuery(sql.toString());
			query.setParameter("profileId", profileId);
			query.setParameter("username", username);
			query.setParameter("hospCode", hospCode);
			query.setParameter("hospName", hospName);
			query.setParameter("patientCode", patientCode);
			query.setParameter("sysId", sysId);
			return query.executeUpdate();

		}

	}

}
