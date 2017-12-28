package nta.med.data.dao.medi.cpl;

import java.util.Date;

/**
 * @author dainguyen.
 */
public interface Cpl9000RepositoryCustom {
	public String callCPL3010U01PrCplInsertCpl9000(String hospCode,String language,String createUser,Date createDate,
			String createTime,String iraiKey,String bunho,Date partJubsuDate,String partJubsuTime,String gubun,String centerCode);
}

