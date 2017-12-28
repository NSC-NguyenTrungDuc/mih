package nta.med.data.dao.mss.impl;

import java.math.BigInteger;
import java.util.List;

import javax.persistence.EntityManager;
import javax.persistence.PersistenceContext;
import javax.persistence.Query;

import nta.med.core.infrastructure.mapper.JpaResultMapper;
import nta.med.data.dao.mss.PatientRepositoryCustom;
import nta.med.data.model.mss.PatientInfo;

public class PatientRepositoryImpl implements PatientRepositoryCustom {

	@PersistenceContext
	private EntityManager entityManager;

	@Override
	public List<PatientInfo> findPatientInfoByProfileId(BigInteger profileId) {
		StringBuilder sql = new StringBuilder();
		sql.append(" SELECT p.patient_id, p.card_number, p.hospital_id, h.hospital_code               ");
		sql.append(" FROM patient p, hospital h                                                       ");
		sql.append(" WHERE                                                                            ");
		sql.append(" p.hospital_id = h.hospital_id                                                    ");
		sql.append(" AND                                                                              ");
		sql.append(" profile_id = :profileId                                                          ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("profileId", profileId);
		
		List<PatientInfo> list = new JpaResultMapper().list(query, PatientInfo.class);
		return list;
		
	}

}
