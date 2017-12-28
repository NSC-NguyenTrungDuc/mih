package nta.med.data.dao.medi.nur.impl;

import javax.persistence.EntityManager;
import javax.persistence.PersistenceContext;

import nta.med.data.dao.medi.nur.Nur1009RepositoryCustom;

/**
 * @author dainguyen.
 */
public class Nur1009RepositoryImpl implements Nur1009RepositoryCustom {
	
	@PersistenceContext
	private EntityManager entityManager;
	
}
