package nta.med.data.dao.medi.inp;

import java.util.Date;
import java.util.List;

import nta.med.data.model.ihis.inps.INP2001U02grdOcs1003Info;
import nta.med.data.model.ihis.inps.INP2001U02layNuGroupInfo;

/**
 * @author dainguyen.
 */
public interface Inp2001RepositoryCustom {

	public String callPrOutCreateInp2001Temp(String hospCode, Integer pkOcs, String userId);
	
	public List<INP2001U02layNuGroupInfo> getListINP2001U02layNuGroupInfo(String hospCode, String language, String bunho, String ipwonDate);
	
	public String getINP2001U02setIconCnt(String hospCode, String bunho, Double pkout1001, Date ipwonDate);
	
	public List<INP2001U02grdOcs1003Info> getINP2001U02grdOcs1003Info(String hospCode, String jubsuGubun, String pkOut1001, String ipwonDate
			, String kaikeiYn, String bunho, String language, Integer startNum, Integer offset);
	
	public String callPrOcsTransOrder(String hospCode, String jobGubun, double pkInp1001, double pkOcs1003, String userId);
}
