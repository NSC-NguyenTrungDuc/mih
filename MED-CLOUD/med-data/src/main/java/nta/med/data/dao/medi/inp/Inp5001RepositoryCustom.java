package nta.med.data.dao.medi.inp;

import java.util.Date;
import java.util.List;

import nta.med.data.model.ihis.ocsi.OCS2005U02RecoveryDataCheckDeleteInfo;
import nta.med.data.model.ihis.ocsi.OCS2005U02RecoveryDataCheckInfo;
import nta.med.data.model.ihis.ocsi.OCS2005U02getMagamStatus1Info;

/**
 * @author dainguyen.
 */
public interface Inp5001RepositoryCustom {

	public List<OCS2005U02getMagamStatus1Info> getOCS2005U02getMagamStatus1(String hospCode, String magamDate, Integer startNum, Integer offset);

	public List<OCS2005U02RecoveryDataCheckDeleteInfo> getOCS2005U02RecoveryDataCheckDeleteInfo(String hospCode,
			String fromDate, String toDate);

	public String getNutIsSiksaMagamYn(String hospCode);
	public List<OCS2005U02RecoveryDataCheckInfo> getOCS2005U02RecoveryDataCheckInfo(String hospCode, Date magamDate);
	public List<OCS2005U02RecoveryDataCheckInfo> getOCS2005U02RecoveryDataCheckInfoByMinMaxDate(String hospCode, Date fromDate, Date toDate);
}

