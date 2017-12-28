package nta.med.data.dao.medi.nur;

import java.util.List;

import nta.med.data.model.ihis.nuri.NUR1020U00laySiksaInfo;

/**
 * @author dainguyen.
 */
public interface Nur1021RepositoryCustom {
	
	public List<NUR1020U00laySiksaInfo> getNUR1020U00laySiksaInfo(String hospCode, String bunho, Double fkinp1001, String ymd);
}

