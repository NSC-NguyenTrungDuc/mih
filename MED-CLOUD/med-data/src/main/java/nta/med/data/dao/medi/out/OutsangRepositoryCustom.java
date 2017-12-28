package nta.med.data.dao.medi.out;

import java.util.Date;
import java.util.List;

import nta.med.data.model.ihis.emr.OCS2015U00GetDiseaseReportInfo;
import nta.med.data.model.ihis.injs.INJ1001U01GrdSangItemInfo;
import nta.med.data.model.ihis.inps.INP3003U00grdINP2002Info;
import nta.med.data.model.ihis.inps.INPORDERTRANSGrdOutSangInfo;
import nta.med.data.model.ihis.inps.OCS2003R00layOCS2001Info;
import nta.med.data.model.ihis.nuro.ORCATransferOrdersDiseaseInfo;
import nta.med.data.model.ihis.nuro.ORDERTRANSGrdOutSangInfo;
import nta.med.data.model.ihis.ocsa.OCS1003Q09GridSangInfo;
import nta.med.data.model.ihis.ocsa.OCS2003P01GrdOutsangInfo;
import nta.med.data.model.ihis.ocsa.Ocs3003Q10GrdSangListItemInfo;
import nta.med.data.model.ihis.ocso.OCS1003Q02grdOCS1001Info;
import nta.med.data.model.ihis.ocso.OCS1003R00LayOCS1001Info;
import nta.med.data.model.ihis.ocso.OUTSANGQ00GrdOutSangInfo;
import nta.med.data.model.ihis.ocso.OUTSANGQ00IsEnableSangCodeInfo;
import nta.med.data.model.ihis.ocso.OUTSANGU00InitializeListItemInfo;
import nta.med.data.model.ihis.ocso.OcsoOCS1003P01GridOutSangInfo;
import nta.med.data.model.ihis.ocso.OcsoOCS1003Q05DiseaseListItemInfo;
import nta.med.data.model.ihis.nuro.DiseaseInfo;
import nta.med.data.model.ihis.system.HospitalDetailInfo;
import nta.med.data.model.phr.SyncDiseaseInfo;

/**
 * @author dainguyen.
 */
public interface OutsangRepositoryCustom {
	
	/**
	 * @param hospCode
	 * @param language
	 * @param bunho
	 * @param gwa
	 * @param naewonDate
	 * @return
	 */
	public List<OcsoOCS1003P01GridOutSangInfo> getOcsoOCS1003P01GridOutSangInfo(String hospCode, String language, String bunho, String gwa, String naewonDate);
	
	public String checkOcsoOCS1003P01SangDupCheck(String hospCode, String ioGubun, String gwa, String bunho, Double fkinp1001, String sangCode, String sangName, String postModifierName,
			String preModifierName,String  sangStartDate,String  sangEndDate,String  sangJindanDate,String  dataGubun,String juSangYn);
	
	public List<OcsoOCS1003Q05DiseaseListItemInfo> getOcsoOCS1003Q05DiseaseList(String hospCode, String language, String ioGubun, String jubsuNo, 
			String naewonDate, String gwa, String doctor, String naewonType, String bunho);
	
	public List<OUTSANGU00InitializeListItemInfo> getOUTSANGU00InitializeListItemInfo(String hospCode, String bunho, String gwa, String ioGubun,
			String allSangYn, String gijunDate);
	
	public Double getOUTSANGU00PkSeq(String hospCode, String bunho, String gwa, String ioGubun);
	
	public Double getOUTSANGU00Ser(String hospCode, String bunho);
	
	public String getOUTSANGU00ResultSang(String hospCode, String ioGubun, String gwa, String bunho, String fkinp1001, String sangCode, String sangName,
			String postModifierName, String preModifierName, String sangStartDate, String sangEndDate, String sangJindanDate, String dataGubun, String juSangYn);
	
	public String getIfDataSendYn(String hospCode, String bunho, String gwa, String ioGubun, Double pkSeq);
	
	public List<INJ1001U01GrdSangItemInfo> getINJ1001U01GrdSangItemInfo(String hospCode, String bunho, String gwa, String reserDate);
	
	
	public List<OCS1003Q09GridSangInfo> getOCS1003Q09GridSangListItem(String hospCode, String language, String ioGubun, String jubsuNo, Date naewonDate,
			String gwa, String doctor, String naewonType, String bunho);
	public List<OCS1003Q02grdOCS1001Info> getOCS1003Q02grdOCS1001Info(String hospCode,String bunho,String gwa,Date naewonDate);
	public List<OCS1003R00LayOCS1001Info> getOCS1003R00LayOCS1001Info(String hospCode,String bunho,String gwa,String doctor,
			String jubsuNo,String naewonDate);
	public List<String> getOCSACTGrdSangByungInfo(String hospCode,String bunho, Date orderDate);
	
	public List<OUTSANGQ00GrdOutSangInfo> getOUTSANGQ00GrdOutSangInfo(String hospCode, String language, String bunho, String gwa, String ioGubun,
			String allSangYn, Date gijunDate);
	
	public List<OUTSANGQ00IsEnableSangCodeInfo> getOUTSANGQ00IsEnableSangCodeInfo(String hospCode, Double pkoutsang, String bunho);
	
	public List<Ocs3003Q10GrdSangListItemInfo> getOcs3003Q10GrdSangListItem(String hospCode, String language, String ioGubun, String jubsuNo, Date naewonDate,
			String gwa, String doctor, String naewonType, String bunho);
	
	public List<ORDERTRANSGrdOutSangInfo> getORDERTRANSGrdOutSangInfo(String hospCode, String language, String bunho, String gubun, Date gijunDate);
	public List<ORCATransferOrdersDiseaseInfo> getORCATransferOrdersDiseaseInfo(String hospCode, String bunho);
	
	public String callPrIfsOutsangTrans(String hospCode, String ioGubun, Integer masterFk, String sendYn);
	public List<OCS2015U00GetDiseaseReportInfo> getOCS2015U00GetDiseaseReportInfo(String hospCode, String gwa, String bunho, Date naewonDate);
	public List<HospitalDetailInfo> getHospitalList(String hospName, String address, String tel, String countryCode, String hospNameConverted, String addressConverted);

	public List<SyncDiseaseInfo> getSyncDiseaseInfo(String hospCode, String patientCode, String language);
	
	public List<DiseaseInfo> getDiseaseInfo(String hospCode, String bunho);
	public List<INP3003U00grdINP2002Info> getINP3003U00grdINP2002Info(String hospCode, String language, String bunho, String gwa, Integer startNum, Integer offset);
	public List<INPORDERTRANSGrdOutSangInfo> getINPORDERTRANSGrdOutSangInfo(String hospCode, String language, String bunho, String ioGubun, Date gijunDate);
	public List<OCS2003R00layOCS2001Info> getOCS2003R00layOCS2001Info(String hospCode, String bunho, Double fkinp1001, String gwa);
	
	public List<OCS2003P01GrdOutsangInfo> getOCS2003P01GrdOutsangInfo(String hospCode, String language, String bunho, String gwa, String naewonDate);
 }

