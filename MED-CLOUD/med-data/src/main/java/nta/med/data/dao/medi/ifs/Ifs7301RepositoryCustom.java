package nta.med.data.dao.medi.ifs;

import nta.med.data.model.ihis.system.TripleListItemInfo;

/**
 * @author dainguyen.
 */
public interface Ifs7301RepositoryCustom {

	public String callPrDrgIfsProc(String hospCode, String ioGubun, Double fkdrg, String userId);

	public String callPrDrgMasterInsert(String hospCode, String jubsuDate, String drgBunho, String dataGubun,
			String inOutGubun, String bunho, String fk);

	public TripleListItemInfo callPrIfsDrgProcMain(String hospCode, String ioGubun, String masterFk, String sendYn);
}

