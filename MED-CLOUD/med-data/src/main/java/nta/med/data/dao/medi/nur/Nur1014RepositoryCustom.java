package nta.med.data.dao.medi.nur;

import java.util.Date;
import java.util.List;

import nta.med.data.model.ihis.common.ComboListItemInfo;
import nta.med.data.model.ihis.inps.INPORDERTRANSGrdWoiChulInfo;
import nta.med.data.model.ihis.inps.INPORDERTRANSSelectListSQL1Info;
import nta.med.data.model.ihis.nuri.NUR1014U00grdNur1014Info;
import nta.med.data.model.ihis.nuri.NUR5020U00grdWoiInfo;
import nta.med.data.model.ihis.nuro.ORDERTRANSGrdListInfo;
import nta.med.data.model.ihis.nuro.ORDERTRANSGrdWoichulInfo;

/**
 * @author dainguyen.
 */
public interface Nur1014RepositoryCustom {
	public List<ORDERTRANSGrdWoichulInfo> getORDERTRANSGrdWoichulInfo(String hospCode, String language, String sendYn, String bunho, Double pk1001, String orderDate);
	public List<ORDERTRANSGrdListInfo> getORDERTRANSGrdListInfoCase2(String hospCode, String language, String ioGubun, String sendYn, String bunho);
	public List<INPORDERTRANSGrdWoiChulInfo> getINPORDERTRANSGrdWoiChulInfo(String hospCode, String language, String sendYn, String bunho, 
			Date firstDate, Date lastDate, Integer startNum, Integer offset);
	public List<INPORDERTRANSSelectListSQL1Info> getINPORDERTRANSSelectListSQL2(String hospCode, String language, String bunho, Date firstDate, Date lastDate, String fnNutYyyymm);
	public List<NUR1014U00grdNur1014Info> getNUR1014U00grdNur1014Info(String hospCode, String bunho, Integer startNum, Integer offset);
	public String getNUR1014U00ValidationCheck(String hospCode, String bunho, String outDate, String outTime, Double fkinp1001);
	public ComboListItemInfo callPrInpJaewonRangeCheck(String hospCode, Double fkinp1001, String startDate, String startTime,
			String endDate, String endTime);
	public List<NUR5020U00grdWoiInfo> getNUR5020U00grdWoiInfo(String hospCode, String hoDong, String date, String language,
			Integer startNum, Integer offset);
	
}

