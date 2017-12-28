package nta.med.orca.gw.model.patient.impl;

import nta.med.ext.support.proto.PatientModelProto;
import nta.med.orca.gw.api.contracts.message.AppointlstInformationChild;
import nta.med.orca.gw.model.patient.SyncReservation;

public class SyncReservationImpl implements SyncReservation {

	private String bunho;
	private String gwa;
	private String jinryoPreDate;
	private String jinryoPreTime;
	private String doctor;
	private String inputGubun;
	private String pkout1001;
	private String reserComment;
	private String reserGubun;
	private String gubun;
	private String jubsuNo;
	private String chojae;
	private String changgu;
	private String resGubun;
	private String newrow;
	private String rowState;
	private String patientName;
	private String patientNameFurigana;
	private String phone;
	private String email;
	private String birth;
	private String sex;

	@Override
	public PatientModelProto.SyncReservation toProto() {
		PatientModelProto.SyncReservation.Builder builder = PatientModelProto.SyncReservation.newBuilder()
				.setBunho(bunho == null ? "" : org.apache.commons.lang3.StringUtils.leftPad(bunho, 9, "0"))
				.setGwa(gwa == null ? "" : gwa)
				.setJinryoPreDate(jinryoPreDate == null ? "" : jinryoPreDate)
				.setJinryoPreTime(jinryoPreTime == null ? "" : jinryoPreTime)
				.setDoctor(doctor == null ? "" : doctor)
				.setInputGubun(inputGubun == null ? "" : inputGubun)
				.setPkout1001(pkout1001 == null ? "" : pkout1001)
				.setReserComment(reserComment == null ? "" : reserComment)
				.setReserGubun(reserGubun == null ? "" : reserGubun)
				.setGubun(gubun == null ? "" : gubun)
				.setJubsuNo(jubsuNo == null ? "" : jubsuNo)
				.setChojae(chojae == null ? "" : chojae)
				.setChanggu(changgu == null ? "" : changgu)
				.setResGubun(resGubun == null ? "" : resGubun)
				.setNewrow(newrow == null ? "" : newrow)
				.setRowState(rowState == null ? "" : rowState)
				.setPatientName(patientName == null ? "" : patientName)
				.setPatientNameFurigana(patientNameFurigana == null ? "" : patientNameFurigana)
				.setPhone(phone == null ? "" : phone)
				.setEmail(email == null ? "" : email)
				.setBirth(birth == null ? "" : birth)
				.setSex(sex == null ? "" : sex);
		
		return builder.build();
	}
	
	@Override
	public SyncReservation copyFromAppointment(AppointlstInformationChild appointment, String appointmentDate) {
		if(appointment.getPatientInformation() != null){
			this.setBunho(appointment.getPatientInformation().getPatientId());
		}
		
		this.setGwa(appointment.getDepartmentCode().getValue());
		this.setJinryoPreDate(appointmentDate);
		this.setJinryoPreTime(appointment.getAppointmentTime().getValue().replace(":", "").substring(0, 4));
		this.setDoctor(appointment.getPhysicianCode().getValue());
		this.setInputGubun("E");
		this.setPkout1001("");
		this.setReserComment("");
		this.setReserGubun("2");
		this.setGubun("G");
		this.setJubsuNo("");
		this.setChojae("");		//TODO Setting on KCCK
		this.setChanggu("ORCA");
		this.setResGubun("E");
		this.setNewrow("");
		this.setRowState("");
		this.setPatientName("");
		this.setPatientNameFurigana("");
		this.setPhone("");
		this.setEmail("");
		this.setBirth("");
		this.setSex("");
		
		return this;
	}
	
	@Override
	public String getBunho() {
		return bunho;
	}

	@Override
	public void setBunho(String bunho) {
		this.bunho = bunho;
	}

	@Override
	public String getGwa() {
		return gwa;
	}

	@Override
	public void setGwa(String gwa) {
		this.gwa = gwa;
	}

	@Override
	public String getJinryoPreDate() {
		return jinryoPreDate;
	}

	@Override
	public void setJinryoPreDate(String jinryoPreDate) {
		this.jinryoPreDate = jinryoPreDate;
	}

	@Override
	public String getJinryoPreTime() {
		return jinryoPreTime;
	}

	@Override
	public void setJinryoPreTime(String jinryoPreTime) {
		this.jinryoPreTime = jinryoPreTime;
	}

	@Override
	public String getDoctor() {
		return doctor;
	}

	@Override
	public void setDoctor(String doctor) {
		this.doctor = doctor;
	}

	@Override
	public String getInputGubun() {
		return inputGubun;
	}

	@Override
	public void setInputGubun(String inputGubun) {
		this.inputGubun = inputGubun;
	}

	@Override
	public String getPkout1001() {
		return pkout1001;
	}

	@Override
	public void setPkout1001(String pkout1001) {
		this.pkout1001 = pkout1001;
	}

	@Override
	public String getReserComment() {
		return reserComment;
	}

	@Override
	public void setReserComment(String reserComment) {
		this.reserComment = reserComment;
	}

	@Override
	public String getReserGubun() {
		return reserGubun;
	}

	@Override
	public void setReserGubun(String reserGubun) {
		this.reserGubun = reserGubun;
	}

	@Override
	public String getGubun() {
		return gubun;
	}

	@Override
	public void setGubun(String gubun) {
		this.gubun = gubun;
	}

	@Override
	public String getJubsuNo() {
		return jubsuNo;
	}

	@Override
	public void setJubsuNo(String jubsuNo) {
		this.jubsuNo = jubsuNo;
	}

	@Override
	public String getChojae() {
		return chojae;
	}

	@Override
	public void setChojae(String chojae) {
		this.chojae = chojae;
	}

	@Override
	public String getChanggu() {
		return changgu;
	}

	@Override
	public void setChanggu(String changgu) {
		this.changgu = changgu;
	}

	@Override
	public String getResGubun() {
		return resGubun;
	}

	@Override
	public void setResGubun(String resGubun) {
		this.resGubun = resGubun;
	}

	@Override
	public String getNewrow() {
		return newrow;
	}

	@Override
	public void setNewrow(String newrow) {
		this.newrow = newrow;
	}

	@Override
	public String getRowState() {
		return rowState;
	}

	@Override
	public void setRowState(String rowState) {
		this.rowState = rowState;
	}

	@Override
	public String getPatientName() {
		return patientName;
	}

	@Override
	public void setPatientName(String patientName) {
		this.patientName = patientName;
	}

	@Override
	public String getPatientNameFurigana() {
		return patientNameFurigana;
	}

	@Override
	public void setPatientNameFurigana(String patientNameFurigana) {
		this.patientNameFurigana = patientNameFurigana;
	}

	@Override
	public String getPhone() {
		return phone;
	}

	@Override
	public void setPhone(String phone) {
		this.phone = phone;
	}

	@Override
	public String getEmail() {
		return email;
	}

	@Override
	public void setEmail(String email) {
		this.email = email;
	}

	@Override
	public String getBirth() {
		return birth;
	}

	@Override
	public void setBirth(String birth) {
		this.birth = birth;
	}

	@Override
	public String getSex() {
		return sex;
	}

	@Override
	public void setSex(String sex) {
		this.sex = sex;
	}

}
