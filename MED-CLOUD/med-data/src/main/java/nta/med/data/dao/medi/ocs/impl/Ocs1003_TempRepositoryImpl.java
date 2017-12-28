package nta.med.data.dao.medi.ocs.impl;

import nta.med.data.dao.medi.ocs.Ocs1003RepositoryCustom;
import nta.med.data.dao.medi.ocs.Ocs1003_TempRepositoryCustom;

import javax.persistence.EntityManager;
import javax.persistence.ParameterMode;
import javax.persistence.PersistenceContext;
import javax.persistence.StoredProcedureQuery;
import java.util.Date;

/**
 * @author DEV-TiepNM
 */
public class Ocs1003_TempRepositoryImpl  implements Ocs1003_TempRepositoryCustom {

    @PersistenceContext
    private EntityManager entityManager;
    public void callProcedureInsertOcs1003(){



        StoredProcedureQuery query = entityManager.createStoredProcedureQuery("PR_UPDATE_OCS1003");

        query.execute();


    }

}
