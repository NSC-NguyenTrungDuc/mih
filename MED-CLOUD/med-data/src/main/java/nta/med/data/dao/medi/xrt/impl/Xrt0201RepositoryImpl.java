package nta.med.data.dao.medi.xrt.impl;

import javax.persistence.EntityManager;
import javax.persistence.PersistenceContext;

import nta.med.data.dao.medi.xrt.Xrt0201RepositoryCustom;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;

/**
 * @author dainguyen.
 */
public class Xrt0201RepositoryImpl implements Xrt0201RepositoryCustom {

	private static final Log LOG = LogFactory.getLog(Xrt0201RepositoryImpl.class);
	
	@PersistenceContext
	private EntityManager entityManager;
	
}

