package nta.med.data.dao.medi.inp;

import java.util.List;

import nta.med.data.model.ihis.inps.CommonProcResultInfo;
import nta.med.data.model.ihis.inps.INP1001U01ChangeGubunGrdHistoryInfo;
import nta.med.data.model.ihis.inps.INP1001U01LoadBoheomChildListInfo;
import nta.med.data.model.ihis.inps.INPBATCHTRANSgrdInpListQueryStartingrbnMiTransInfo;

/**
 * @author dainguyen.
 */
public interface Inp1002RepositoryCustom {
	
	public String getINP3003U00GrdMasterItem(String hospCode, Double pkinp1001);
	public List<INP1001U01LoadBoheomChildListInfo> getINP1001U01LoadBoheomChildListInfo(String hospCode, String language, Double fkinp1001);
	public List<INP1001U01ChangeGubunGrdHistoryInfo> getINP1001U01ChangeGubunGrdHistoryInfo(String hospCode, double fkinp1001);
	
	public List<INPBATCHTRANSgrdInpListQueryStartingrbnMiTransInfo> getINPBATCHTRANSgrdInpListQueryStartingrbnMiTransInfo(String hospCode, String language, String bunho, String fromDate, String queryDate, String hoDong1);
	
	public List<INPBATCHTRANSgrdInpListQueryStartingrbnMiTransInfo> getINPBATCHTRANSgrdInpListQueryStartingrbnTransInfo(String hospCode, String language, String bunho, String fromDate, String queryDate, String hoDong1);
	
	public Double getMaxGubunTransCnt(String hospCode, String fkinp1001);
	
	public Integer iNP1001U01ChangeGubunUpdateInp1002(String userId, String gubunipwonDate, String hospCode, Double fkinp1001, Double gubunTransCnt);
	
	public CommonProcResultInfo callPrInpMakePkinp1002(Double fkinp1001, String gubun, String hospCode);
}

