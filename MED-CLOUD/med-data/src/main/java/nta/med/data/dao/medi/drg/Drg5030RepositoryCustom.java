package nta.med.data.dao.medi.drg;

import java.util.Date;

/**
 * @author dainguyen.
 */
public interface Drg5030RepositoryCustom {
	public Double callPrJihDrgDrg5030Insert(String hospitalCode, Date jubsuDate, String drgBunho, String dataDubun, String inOutGubun, String bunho, Integer fk);
}

