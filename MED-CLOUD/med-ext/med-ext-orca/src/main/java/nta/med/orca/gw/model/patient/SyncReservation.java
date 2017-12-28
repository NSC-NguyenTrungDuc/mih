package nta.med.orca.gw.model.patient;

import nta.med.ext.support.proto.PatientModelProto;
import nta.med.orca.gw.api.contracts.message.AppointlstInformationChild;

public interface SyncReservation {

	public PatientModelProto.SyncReservation toProto();
	
	public SyncReservation copyFromAppointment(AppointlstInformationChild appointment, String appointmentDate);
	
	String getBunho();

	void setBunho(String bunho);

	String getGwa();

	void setGwa(String gwa);

	String getJinryoPreDate();

	void setJinryoPreDate(String jinryoPreDate);

	String getJinryoPreTime();

	void setJinryoPreTime(String jinryoPreTime);

	String getDoctor();

	void setDoctor(String doctor);

	String getInputGubun();

	void setInputGubun(String inputGubun);

	String getPkout1001();

	void setPkout1001(String pkout1001);

	String getReserComment();

	void setReserComment(String reserComment);

	String getReserGubun();

	void setReserGubun(String reserGubun);

	String getGubun();

	void setGubun(String gubun);

	String getJubsuNo();

	void setJubsuNo(String jubsuNo);

	String getChojae();

	void setChojae(String chojae);

	String getChanggu();

	void setChanggu(String changgu);

	String getResGubun();

	void setResGubun(String resGubun);

	String getNewrow();

	void setNewrow(String newrow);

	String getRowState();

	void setRowState(String rowState);

	String getPatientName();

	void setPatientName(String patientName);

	String getPatientNameFurigana();

	void setPatientNameFurigana(String patientNameFurigana);

	String getPhone();

	void setPhone(String phone);

	String getEmail();

	void setEmail(String email);

	String getBirth();

	void setBirth(String birth);

	String getSex();

	void setSex(String sex);
}
