package nta.med.data.dao.medi.bas;

import java.util.Date;
import java.util.List;

import nta.med.data.model.ihis.bass.BAS0203U00GrdBAS0203Info;


/**
 * @author dainguyen.
 */
public interface Bas0203RepositoryCustom {
	public String getBAS0203U00LayDupCheckRequest(String hospCode, String symyaGubun, String bunCode, String sgCode, Date jyDate, String fromTime);
	public List<BAS0203U00GrdBAS0203Info> getBAS0203U00GrdBAS0203Info(String hospCode, String language, Date jyDate, String symyaGubun);
}

