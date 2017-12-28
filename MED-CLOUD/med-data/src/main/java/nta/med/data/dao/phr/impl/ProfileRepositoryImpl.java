package nta.med.data.dao.phr.impl;

import java.math.BigInteger;
import java.util.List;

import javax.persistence.EntityManager;
import javax.persistence.PersistenceContext;
import javax.persistence.Query;

import nta.med.core.infrastructure.mapper.JpaResultMapper;
import nta.med.data.dao.phr.ProfileRepositoryCustom;
import nta.mss.info.AccountInfoDto;
import nta.mss.info.UserChildDto;

public class ProfileRepositoryImpl implements ProfileRepositoryCustom {
	
	@PersistenceContext
	private EntityManager entityManager;
	
	@Override
	public AccountInfoDto getAccountInfoByAccountId(Long accountId) {
		StringBuilder sql = new StringBuilder();
		sql.append("   SELECT a.id,                     ");
		sql.append("   a.email,                         ");
		sql.append("   p.full_name,                     ");
		sql.append("   p.full_name_kana,                ");
		sql.append("   p.sex,                           ");
		sql.append("   p.baby_flg,                      ");
		sql.append("   p.relationship,                  ");
		sql.append("   p.family_member_type,            ");
		sql.append("   p.active_profile_flg,            ");
		sql.append("   p.birthday,                      ");
		sql.append("   p.phone                          ");
		sql.append("   FROM phr_account a               ");
		sql.append("   JOIN phr_profile p               ");
		sql.append("   ON a.id=p.account_id             ");
		sql.append("   WHERE                            ");
		sql.append("   a.id = :accountId                ");
		sql.append("   AND p.baby_flg = 0               ");
		sql.append("   AND p.active_profile_flg = 1     ");
		sql.append("   AND p.active_flg = 1             ");
		sql.append("   AND p.family_member_type='PERSONAL'             ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("accountId", accountId);

		List<AccountInfoDto> list = new JpaResultMapper().list(query, AccountInfoDto.class);
		if(list != null && list.size() > 0)
			return list.get(0);

		return null;
	}

	@Override
	public List<UserChildDto> getUserchildsByAccountId(Long accountId) {
		StringBuilder sql = new StringBuilder();
		sql.append("   SELECT id, account_id, full_name, full_name_kana, birthday, sex, locale, baby_flg, phone ");
		sql.append("   FROM phr_profile                             ");
		sql.append("   WHERE                                        ");
		sql.append("   account_id = :accountId                      ");
		sql.append("   AND active_profile_flg = 1                   ");
		sql.append("   AND baby_flg = 1                             ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("accountId", accountId);

		List<UserChildDto> list = new JpaResultMapper().list(query, UserChildDto.class);
		return list;
	}

	@Override
	public UserChildDto getUserchildByChildId(BigInteger childId) {
		StringBuilder sql = new StringBuilder();
		sql.append("   SELECT id, account_id, full_name, full_name_kana, birthday, sex, locale, baby_flg, phone ");
		sql.append("   FROM phr_profile                             ");
		sql.append("   WHERE                                        ");
		sql.append("   id = :childId                               ");
		sql.append("   AND active_profile_flg = 1                   ");
		sql.append("   AND baby_flg = 1                             ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("childId", childId);

		List<UserChildDto> list = new JpaResultMapper().list(query, UserChildDto.class);
		if(list != null && list.size() > 0)
			return list.get(0);

		return null;
	}

}
