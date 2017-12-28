package nta.med.data.dao.medi.nur;

import java.util.Date;
import java.util.List;

import nta.med.data.model.ihis.inps.CommonProcResultInfo;
import nta.med.data.model.ihis.nuri.NUR1020Q00layGraphInfo;
import nta.med.data.model.ihis.nuri.NUR1020Q00layNUR7002Info;
import nta.med.data.model.ihis.nuri.NUR1020Q00layNutInfo;
import nta.med.data.model.ihis.nuri.NUR1020U00grdNUR1020Info;
import nta.med.data.model.ihis.nuri.NUR8003U03QueryFormGrdBPInfo;

/**
 * @author dainguyen.
 */
public interface Nur1020RepositoryCustom {
	
	public String getDataFromNur1020(String hospCode, Double fkinp1001, String ymd, String timeGubun, String prGubun);

	public List<NUR1020U00grdNUR1020Info> getNUR1020U00grdNUR1020Info(String hospCode, String bunho, Double fkInp1001, String fDate);
	
	public String getNUR1020U00MaxYmd(String hospCode, String bunho, String ymd);
	
	public void callPrNurInputVitalValue(String userId, String hospCode, String bunho, Double fkinp1001, Date orderDate,
			String gubun1, String gubun2, String gubun3, String value);
	
	public CommonProcResultInfo callPrCplInsertUrine(String hospCode, Date orderDate, String bunho, Double pkinp1001);
	
	public List<NUR1020Q00layGraphInfo> getNUR1020Q00layGraphInfo(String hospCode, String bunho, Double fkinp1001, String ymd);
	
	public List<NUR1020Q00layNutInfo> getNUR1020Q00layNutInfo(String hospCode, String bunho, Double pkinp1001, String ymd);
	
	public List<NUR1020Q00layNUR7002Info> getNUR1020Q00layNUR7002Info(String hospCode, Double fkinp1001, String ymd);
	
	public List<NUR8003U03QueryFormGrdBPInfo> getNUR8003U03QueryFormGrdBPInfo(String hospCode, String bunho,
			Double fkinp1001, Date writeDate);
}
