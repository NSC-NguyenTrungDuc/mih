package nta.med.data.dao.medi.pfe;

import java.util.Date;

/**
 * @author dainguyen.
 */
public interface Pfe0201RepositoryCustom {
	public Double callPrPfeEkgPfe5010Insert (String hospCode, Date oderDate, String dataDubun, String inOutGubun, String bunho, Integer fk);
	public String callPrPfeEkgIfsProc (String hospCode, String ioGubun, Integer fkpfe, String userId);
}

