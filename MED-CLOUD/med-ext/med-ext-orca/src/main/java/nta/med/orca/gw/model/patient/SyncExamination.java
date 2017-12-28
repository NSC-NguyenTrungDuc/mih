package nta.med.orca.gw.model.patient;

import nta.med.ext.support.proto.PatientModelProto;
import nta.med.orca.gw.api.contracts.message.AcceptlstInfo;
import org.w3c.dom.Document;

public interface SyncExamination {

	public PatientModelProto.SyncExamination toProto();

	public SyncExamination toModel(Document doc, int decisionThreshold) throws Exception;

	public SyncExamination toModel(AcceptlstInfo info, String acceptanceDate, String gigwanCode);
	
	public SyncExamination copyFromAcceptlstInfo(AcceptlstInfo info, String acceptanceDate);
	
	String getDepartmentCode();

	void setDepartmentCode(String departmentCode);

	String getDepartmentName();

	void setDepartmentName(String departmentName);

	String getDoctorCode();

	void setDoctorCode(String doctorCode);

	String getDoctorName();

	void setDoctorName(String doctorName);

	String getExamStatus();

	void setExamStatus(String examStatus);

	String getReceptionNo();

	void setReceptionNo(String receptionNo);

	String getInsurCode();

	void setInsurCode(String insurCode);

	String getInsurName();

	void setInsurName(String insurName);

	String getPatientCode();

	void setPatientCode(String patientCode);

	String getComingDate();

	void setComingDate(String comingDate);

	String getPkout1001();

	void setPkout1001(String pkout1001);

	String getReceptionTime();

	void setReceptionTime(String receptionTime);

	String getComingStatus();

	void setComingStatus(String comingStatus);

	String getComingType();

	void setComingType(String comingType);

	String getSunnabStatus();

	void setSunnabStatus(String sunnabStatus);

	String getFkinp1001();

	void setFkinp1001(String fkinp1001);

	String getReceptionType();

	void setReceptionType(String receptionType);

	String getInpTransStatus();

	void setInpTransStatus(String inpTransStatus);

	String getBigo();

	void setBigo(String bigo);

	String getInsurCode1();

	void setInsurCode1(String insurCode1);

	String getInsurCode2();

	void setInsurCode2(String insurCode2);

	String getInsurCode3();

	void setInsurCode3(String insurCode3);

	String getInsurCode4();

	void setInsurCode4(String insurCode4);

	String getPriority1();

	void setPriority1(String priority1);

	String getPriority2();

	void setPriority2(String priority2);

	String getPriority3();

	void setPriority3(String priority3);

	String getPriority4();

	void setPriority4(String priority4);

	String getSujinNo();

	void setSujinNo(String sujinNo);

	String getWonyoiOrderStatus();

	void setWonyoiOrderStatus(String wonyoiOrderStatus);

	String getReserStatus();

	void setReserStatus(String reserStatus);

	String getButton();

	void setButton(String button);

	String getCheckComing();

	void setCheckComing(String checkComing);

	String getArriveTime();

	void setArriveTime(String arriveTime);

	String getGroupKey();

	void setGroupKey(String groupKey);

	String getContKey();

	void setContKey(String contKey);

	String getDataRowState();

	void setDataRowState(String dataRowState);

	String getDeletedRowTable();

	void setDeletedRowTable(String deletedRowTable);

	String getSysId();

	void setSysId(String sysId);

	String getUpdId();

	void setUpdId(String updId);

	String getOrcaGigwanCode();

	void setOrcaGigwanCode(String orcaGigwanCode);

	Reception getReception();

	void setReception(Reception reception);

	String getModifyFlg();

	void setModifyFlg(String modifyFlg);

	String getHasAppointment();

	void setHasAppointment(String hasAppointment);
	
	String getReceptRefId();

	void setReceptRefId(String receptRefId);
}
