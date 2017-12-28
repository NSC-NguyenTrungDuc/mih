package nta.med.orca.gw.model.patient;

import nta.med.ext.support.proto.PatientModelProto;
import nta.med.orca.gw.api.contracts.message.PatientInfo;

import org.w3c.dom.Document;

import java.util.List;

public interface PrivateInsurance {

	public PatientModelProto.PrivateInsurance toProto();
	
	public List<PrivateInsurance> toModelList(Document doc) throws Exception;
	
	public List<PrivateInsurance> copyFromPatientInfo(PatientInfo pt) throws Exception;
	
	public String getStartDate();

	public void setStartDate(String startDate);

	public String getBunho();

	public void setBunho(String bunho);

	public String getBudamjaBunho();

	public void setBudamjaBunho(String budamjaBunho);

	public String getGongbiCode();

	public void setGongbiCode(String gongbiCode);

	public String getSugubjaBunho();

	public void setSugubjaBunho(String sugubjaBunho);

	public String getEndDate();

	public void setEndDate(String endDate);

	public String getRemark();

	public void setRemark(String remark);

	public String getLastCheckDate();

	public void setLastCheckDate(String lastCheckDate);

	public String getGongbiName();

	public void setGongbiName(String gongbiName);

	public String getRetrieveYn();

	public void setRetrieveYn(String retrieveYn);

	public String getOldStartDate();

	public void setOldStartDate(String oldStartDate);

	public String getEndYn();

	public void setEndYn(String endYn);
	
	public String getDataRowState();

	public void setDataRowState(String dataRowState);
}
