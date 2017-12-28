package nta.med.data.dao.medi.out;

import java.util.Date;
import java.util.List;

import nta.med.data.model.ihis.emr.OCS2015U00GetDataInsPersonInfo;
import nta.med.data.model.ihis.inps.INP1001U01GrdInp1008Info;
import nta.med.data.model.ihis.nuro.ORDERTRANSGrdGongbiListInfo;
import nta.med.data.model.ihis.nuro.PublicInsurance;

/**
 * @author dainguyen.
 */
public interface Out0105RepositoryCustom {
	public List<ORDERTRANSGrdGongbiListInfo> getORDERTRANSGrdGongbiListInfoCaseEqualOAndN(String hospCode, String bunho, String out1001, String language);
	public List<ORDERTRANSGrdGongbiListInfo> getORDERTRANSGrdGongbiListInfoCaseElseEqualN(String hospCode, String bunho, String out1001, String language);
	public List<PublicInsurance> getPublicInsurance(String hospCode, String bunho, Double pkout1001);
	
	public List<OCS2015U00GetDataInsPersonInfo> getOCS2015U00GetDataInsPersonInfo(String hospCode, String patientCode, String firstExaminationDate, String lastExaminationDate, String priority);
	public List<INP1001U01GrdInp1008Info> getINP1001U01GrdInp1008Info(String hospCode, String language, String bunho, String gubun, String fkinp1002, String gubunIpwonDate, String ipwonDate, Integer startNum, Integer offset);
	public String inp1001U01CheckIsExistCode(String hospCode, String bunho, String gongbiCode);
}

