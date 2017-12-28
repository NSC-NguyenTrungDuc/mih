package nta.med.data.dao.medi.out;

import java.util.Date;
import java.util.List;

import nta.med.data.model.ihis.common.ComboListItemInfo;
import nta.med.data.model.ihis.emr.InsuranceProviderInfo;
import nta.med.data.model.ihis.inps.INP1001U01FwkGubunInfo;
import nta.med.data.model.ihis.nuro.CompanyInsurance;
import nta.med.data.model.ihis.nuro.NuroOUT1001U01GetTypeInfo;
import nta.med.data.model.ihis.nuro.ORDERTRANSGrdHokenInfo;
import nta.med.data.model.ihis.system.DetailPaInfoFormGridInsureInfo;

/**
 * @author dainguyen.
 */
public interface Out0102RepositoryCustom {
	/**
	 * @param hospCode
	 * @param patientCode
	 * @return
	 */
	public List<DetailPaInfoFormGridInsureInfo> getDetailPaInfoFormGridInsure(String hospCode, String patientCode, String language);
	
	public List<NuroOUT1001U01GetTypeInfo> getNuroOUT1001U01GetTypeInfo(String hospCode, String bunho, String naewonDate, String find1, String language);
	
	public String getNuroOUT0101U02GetY(String hospCode, String bunho, String gubun1, Date startDate);
	public List<ORDERTRANSGrdHokenInfo> getORDERTRANSGrdHokenInfo(String hospCode, String actingDate, String gubun, String bunho, String sendYn);
	public List<ComboListItemInfo> getORDERTRANSFwkFind(String hospCode, String bunho, String actingDate);
	public String getJohapByHospCodeAndBunho(String hospCode, String bunho);
	
	public List<CompanyInsurance> getCompanyInsurance(String hospCode, String bunho, Double pkout1001);
	
	public List<InsuranceProviderInfo> getOCS2015U00GetDataInsProviderInfo(String hospCode, String patientCode, String firstExaminationDate, String lastExaminationDate);
	
	public List<INP1001U01FwkGubunInfo> getINP1001U01FwkGubunInfo(String hospCode, String language, String bunho, String naewonDate, String find1);
}