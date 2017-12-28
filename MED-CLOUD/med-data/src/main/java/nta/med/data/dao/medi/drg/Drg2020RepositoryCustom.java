package nta.med.data.dao.medi.drg;

import java.util.Date;

/**
 * @author dainguyen.
 */
public interface Drg2020RepositoryCustom {
	public String callPrDrgMakeBongtuOut(Date sysDate, String userId, Date orderDate, Date jubsuDate, String jubsuTime, Integer drgBunho, 
			String wonyoiOrderYn, String jubsuYn, String gyunbonYn, String hospCode, String language);
}

