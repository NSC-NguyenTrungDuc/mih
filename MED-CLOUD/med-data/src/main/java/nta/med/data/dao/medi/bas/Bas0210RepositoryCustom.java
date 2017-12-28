package nta.med.data.dao.medi.bas;

import java.util.Date;
import java.util.List;

import nta.med.data.model.ihis.bass.BAS0210U00grdBAS0210ItemInfo;
import nta.med.data.model.ihis.nuro.NuroOUT0101U02GetType;
import nta.med.data.model.ihis.nuro.ORDERTRANSLayCommonInfo;

/**
 * @author dainguyen.
 */
public interface Bas0210RepositoryCustom {
	
	public String getNuroChkGetGongbiYN(String gubun, String date, String language);
	public List<BAS0210U00grdBAS0210ItemInfo> getBAS0210U00grdBAS0210ItemInfo(String hospCode, String language,Date startDate, String gubunCode);
	public List<ORDERTRANSLayCommonInfo> getORDERTRANSLayCommonInfo(String hospCode, String gubun, String actingDate, String bunho, String language);
	public List<String> getBAS0111U00LayGetJohap(String gubun, String naewonDate, String language);
	public String getNuroOUT0101U02GetTypeName(String gubun, String language);
	public List<NuroOUT0101U02GetType> getNuroOUT0101U02GetType(String johapGubun, String find1, String language);
	
	public String getOcs2015U00InsuranceInfo(String hospCode, String patientCode, String language);
	
	public String getBAS0210U00DupCheckext(String language, String gubun, Date ipwonDate);
}

