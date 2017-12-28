package nta.med.data.dao.medi.cht.impl;

import nta.med.core.domain.cht.Cht0115;
import nta.med.core.infrastructure.mapper.JpaResultMapper;
import nta.med.data.dao.medi.cht.Cht0115Repository;
import nta.med.data.dao.medi.cht.Cht0115SRepository;
import nta.med.data.dao.medi.cht.Cht0115SRepositoryCustom;
import nta.med.data.dao.medi.inp.Inp1001RepositoryCustom;
import nta.med.data.model.ihis.chts.CHT0115Q00GrdScInfo;
import nta.med.data.model.ihis.chts.CHT0115Q00SusikCodeInfo;
import nta.med.data.model.ihis.chts.CHT0115Q01grdCHT0115Info;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.cache.annotation.CacheEvict;
import org.springframework.cache.annotation.Cacheable;
import org.springframework.data.jpa.repository.support.SimpleJpaRepository;
import org.springframework.stereotype.Repository;
import org.springframework.util.CollectionUtils;
import org.springframework.util.StringUtils;

import javax.persistence.*;
import java.util.Date;
import java.util.List;

/**
 * @author dainguyen.
 */

public class Cht0115SRepositoryImpl implements Cht0115SRepositoryCustom {

	@PersistenceContext
	private EntityManager entityManager;

	@Override
	public List<CHT0115Q01grdCHT0115Info> getCHT0115sQ01grdCHT0115ListItem(String susikDetail, Integer pageNumber, Integer offset) {
		StringBuilder sql = new StringBuilder();
		sql.append("	SELECT SUSIK_CODE													");
		sql.append("	     , SUSIK_NAME                                                   ");
		sql.append("	     , SUSIK_NAME_GANA                                              ");
		sql.append("	     , SUSIK_CR_DATE                                                ");
		sql.append("	     , SUSIK_UPD_DATE                                               ");
		sql.append("	     , SUSIK_DISABLE_DATE                                           ");
		sql.append("	     , SUSIK_GWANRI_NO                                              ");
		sql.append("	     , SUSIK_GUBUN                                                  ");
		sql.append("	     , SUSIK_CHANGE_CODE                                            ");
		sql.append("	     , SUSIK_DETAIL_GUBUN                                           ");
		sql.append("	     , START_DATE                                                   ");
		sql.append("	     , END_DATE                                                     ");
		sql.append("	     , SORT                                                         ");
		sql.append("	     , ''                                                           ");
		sql.append("	  FROM CHT0115S                                                     ");
		sql.append("	 WHERE  SUSIK_DETAIL_GUBUN LIKE :susikDetail                        ");
		sql.append("	 ORDER BY SUSIK_DETAIL_GUBUN, SUSIK_CODE                            ");
		sql.append(" LIMIT :f_page_number,:f_offset                                         ");

		Query query = entityManager.createNativeQuery(sql.toString());

		query.setParameter("susikDetail", susikDetail);
		query.setParameter("f_page_number",pageNumber);
		query.setParameter("f_offset", offset);
		List<CHT0115Q01grdCHT0115Info> list = new JpaResultMapper().list(query, CHT0115Q01grdCHT0115Info.class);
		return list;

	}
}

