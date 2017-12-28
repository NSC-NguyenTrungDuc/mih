package nta.med.data.dao.medi.ocs;

import java.util.Date;
import java.util.List;

import nta.med.data.model.ihis.ocsa.OCS0150Q00GridOCS0150Info;

/**
 * @author dainguyen.
 */
public interface Ocs0150RepositoryCustom {
	public List<OCS0150Q00GridOCS0150Info> getOCS0150Q00GridOCS0150Info(String hospCode, String language, String doctor, String gwa, String ioGubun, Date orderDate);
	public String getOcsOrderBizGetUserOptionInfo(String hospCode,String doctor,String gwa,String keyword, String gubun);
	
	public String callFnOcsUserOptionInfo(String hospCode, String doctor, String gwa, String keyword, String ioGubun);
	
}

