package nta.med.data.dao.phr.impl;

import javax.persistence.EntityManager;
import javax.persistence.PersistenceContext;

import nta.med.data.dao.phr.PhrAccountRepositoryCustom;

public class PhrAccountRepositoryImpl implements PhrAccountRepositoryCustom {

	@PersistenceContext
	private EntityManager entityManager;

}
