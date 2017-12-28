package nta.med.data.dao.medi.ifs.impl;

import java.math.BigDecimal;
import java.util.List;

import javax.persistence.EntityManager;
import javax.persistence.PersistenceContext;
import javax.persistence.Query;

import nta.med.core.caching.model.medi.drgs.InformationSchemaColumn;
import nta.med.core.infrastructure.mapper.JpaResultMapper;
import nta.med.data.dao.medi.ifs.Ifs7101RepositoryCustom;

/**
 * @author dainguyen.
 */
public class Ifs7101RepositoryImpl implements Ifs7101RepositoryCustom {
	
	@PersistenceContext
	private EntityManager entityManager;
	
	@Override
	public List<InformationSchemaColumn> getInformationSchemaColumn(String schema){
		StringBuilder sql = new StringBuilder();
		sql.append("SELECT TABLE_SCHEMA, TABLE_NAME, COLUMN_NAME, DATA_TYPE, CHARACTER_MAXIMUM_LENGTH                                         ");
		sql.append("  FROM INFORMATION_SCHEMA.COLUMNS                                                                                         ");
		sql.append(" WHERE TABLE_SCHEMA = :schema                                                                                      ");
		sql.append("   AND TABLE_NAME IN ('IFS7101','IFS7102','IFS7103','IFS7104','IFS7106','IFS7107', 'IFS7301', 'IFS7302','IFS7401')        ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("schema", schema);
		List<InformationSchemaColumn> list = new JpaResultMapper().list(query, InformationSchemaColumn.class);
		return list;
	}
	
	@Override
	public BigDecimal getIfs7101Seq(String seqName){
		StringBuilder sql = new StringBuilder("SELECT SWF_NextVal(:f_seq_name)");
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_seq_name", seqName);
		
		List<BigDecimal> result = query.getResultList();
		if(!result.isEmpty()){
			 return result.get(0);
		}
		return null;
	}
}

