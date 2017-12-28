package nta.med.data.dao.medi.cpl.impl;

import java.util.List;

import javax.persistence.EntityManager;
import javax.persistence.PersistenceContext;


import javax.persistence.Query;

import nta.med.data.dao.medi.cpl.Cplreq1RepositoryCustom;

/**
 * @author dainguyen.
 */
public class Cplreq1RepositoryImpl implements Cplreq1RepositoryCustom {
	@PersistenceContext
	private EntityManager entityManager;

}

