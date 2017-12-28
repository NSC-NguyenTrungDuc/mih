package nta.med.orca.gw.model.patient;

import nta.med.ext.support.proto.PatientModelProto;
import nta.med.orca.gw.api.contracts.message.PatientInfo;
import nta.med.orca.gw.api.contracts.service.PatientInfoResponse;
import org.w3c.dom.Document;

import java.util.List;

public interface PublicInsurance {

	public PatientModelProto.PublicInsurance toProto();
	
	public List<PublicInsurance> toModelList(Document doc, PatientInfoResponse patientInfoResponse) throws Exception;
	
	public List<PublicInsurance> copyFromPatientInfo(PatientInfo pt) throws Exception;
	
	public String getStartDate();

	public void setStartDate(String startDate);

	public String getBunho();

	public void setBunho(String bunho);

	public String getSuname();

	public void setSuname(String suname);

	public String getGubun1();

	public void setGubun1(String gubun1);

	public String getGubunName1();

	public void setGubunName1(String gubunName1);

	public String getJohap();

	public void setJohap(String johap);

	public String getJohapName();

	public void setJohapName(String johapName);

	public String getTel();

	public void setTel(String tel);

	public String getGaein();

	public void setGaein(String gaein);

	public String getGaeinNo();

	public void setGaeinNo(String gaeinNo);

	public String getBoninGubun();

	public void setBoninGubun(String boninGubun);

	public String getBoninGubunName();

	public void setBoninGubunName(String boninGubunName);

	public String getPiname();

	public void setPiname(String piname);

	public String getLastCheckDate();

	public void setLastCheckDate(String lastCheckDate);

	public String getEndDate();

	public void setEndDate(String endDate);

	public String getJohapGubun();

	public void setJohapGubun(String johapGubun);

	public String getOldGubun();

	public void setOldGubun(String oldGubun);

	public String getRetrieveYn();

	public void setRetrieveYn(String retrieveYn);

	public String getOldStartDate();

	public void setOldStartDate(String oldStartDate);

	public String getChuidukDate();

	public void setChuidukDate(String chuidukDate);

	public String getEndYn();

	public void setEndYn(String endYn);
	
	public String getDataRowState();

	public void setDataRowState(String dataRowState);
}
