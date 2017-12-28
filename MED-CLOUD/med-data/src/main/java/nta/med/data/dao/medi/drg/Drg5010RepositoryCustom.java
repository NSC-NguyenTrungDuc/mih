package nta.med.data.dao.medi.drg;

import java.util.Date;

/**
 * @author dainguyen.
 */
public interface Drg5010RepositoryCustom {
	public Double callPrJihDrgDrg5010Insert(String hospitalCode, Date jubsuDate, String drgBunho, String dataDubun, String inOutGubun, String bunho, Integer fk);
}

