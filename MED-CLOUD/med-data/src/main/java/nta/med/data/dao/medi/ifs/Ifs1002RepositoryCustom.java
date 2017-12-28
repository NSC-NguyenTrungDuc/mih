package nta.med.data.dao.medi.ifs;

import nta.med.data.model.ihis.nuro.RES1001U00PrIFSMakeYoyakuInfo;

/**
 * @author dainguyen.
 */
public interface Ifs1002RepositoryCustom {
	public RES1001U00PrIFSMakeYoyakuInfo callRES1001U00PrIFSMakeYoyaku(String hospCode, Double pkout1001, String proGubun, 
			String yoyakiGubun, String ioGubun, String userId, String bunho, String gwa, String doctor, String naewonDate, String jubsuTime);
}

