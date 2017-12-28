package nta.med.data.dao.medi.ocs;

import java.util.Date;
import java.util.List;

import nta.med.data.model.ihis.ocsa.OcsaOCS0503Q01GrdOCS0503ListInfo;
import nta.med.data.model.ihis.ocsa.OcsaOCS0503Q01ListDataInfo;
import nta.med.data.model.ihis.ocsa.OcsaOCS0503U00GetFindWorkerConsultGwaInfo;
import nta.med.data.model.ihis.ocsa.OcsaOCS0503U00GridOSC0503ListInfo;
import nta.med.data.model.ihis.ocsa.OcsaOCS0503U00ValidationCheckInfo;
import nta.med.data.model.ihis.ocso.OCS2016GetLinkingDepartmentInfo;
import nta.med.data.model.ihis.ocso.OCS2016GetUserDepartmentInfo;

/**
 * @author dainguyen.
 */
public interface Ocs0503RepositoryCustom {
	
	public  List<OcsaOCS0503Q01ListDataInfo> getOcsaOCS0503Q01ListDataInfo(String hospCode,String language, String bunho, String fromDate, String toDate);
	
	public List<OcsaOCS0503Q01GrdOCS0503ListInfo> getOcsaOCS0503Q01GrdOCS0503ListInfo(String hospCode, String reqDate, String bunho, String consultDoctor);
	
	public Double getSeqOcs0503();
	public Double getOCS0503U00CheckInpPatient(String hopsCode,String bunho);
	public List<OcsaOCS0503U00ValidationCheckInfo> getOCS0503U00ValidationCheck(String hospCode,Double fkout1001);
	public String getGwaNameOCS0503U00(String hospCode,String language,String code);
	public List<OcsaOCS0503U00GridOSC0503ListInfo> getOcsaOCS0503U00GridOSC0503ListInfo(String hospCode,String language,String bunho,String reqDoctor);
	public List<OcsaOCS0503U00GetFindWorkerConsultGwaInfo> getOcsaOCS0503U00GetFindWorkerListInfoProcess1(String hospCode,String language);
	public String checkCanReserOCS0503U00(String hospCode,Date reserDate,String reserTime,String reserDoctor);
	
	public String getNoConfirmConsult(String hospCode, String bunho, Date naewonDate, String gwa, String doctor, String ioGubun);
	
	public List<OCS2016GetLinkingDepartmentInfo> getListOCS2016GetLinkingDepartmentInfo(String hospCode, String language, String find1);
	
	public List<OCS2016GetUserDepartmentInfo> getOCS2016GetUserDepartmentInfo(String hospCode, String doctor, String language);
}

