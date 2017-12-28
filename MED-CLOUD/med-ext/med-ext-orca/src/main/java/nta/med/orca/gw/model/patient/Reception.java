package nta.med.orca.gw.model.patient;

import nta.med.ext.support.proto.PatientModelProto;
import org.w3c.dom.Document;

public interface Reception {

	public PatientModelProto.ReceptionInfo toProto();
	
	public Reception toModel(Document doc) throws Exception;
	
	public String getOrcaReceptionId();

	public void setOrcaReceptionId(String orcaReceptionId);

	public String getActCode();

	public void setActCode(String actCode);

	public String getActiveFlg();

	public void setActiveFlg(String activeFlg);

	public String getAppTime();

	public void setAppTime(String appTime);

	public String getBundNum();

	public void setBundNum(String bundNum);

	public String getClassCode();

	public void setClassCode(String classCode);

	public String getCreated();

	public void setCreated(String created);

	public String getDoctor();

	public void setDoctor(String doctor);

	public String getFkout1001();

	public void setFkout1001(String fkout1001);

	public String getGwa();

	public void setGwa(String gwa);

	public String getHospCode();

	public void setHospCode(String hospCode);

	public String getIoFlag();

	public void setIoFlag(String ioFlag);

	public String getOrderTime();

	public void setOrderTime(String orderTime);

	public String getPerformTime();

	public void setPerformTime(String performTime);

	public String getRegistTime();

	public void setRegistTime(String registTime);

	public String getSubCode();

	public void setSubCode(String subCode);

	public String getSysId();

	public void setSysId(String sysId);

	public String getTimeClass();

	public void setTimeClass(String timeClass);

	public String getUpdId();

	public void setUpdId(String updId);

	public String getUpdated();

	public void setUpdated(String updated);
}
