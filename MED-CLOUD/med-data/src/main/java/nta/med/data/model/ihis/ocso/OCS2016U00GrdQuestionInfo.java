package nta.med.data.model.ihis.ocso;

public class OCS2016U00GrdQuestionInfo {

	private String grpQuestionId;
	private String reqDate;
	private String reqGwa;
	private String reqDoctor;
	private String consultGwa;
	private String consultDoctor;
	private String consultDate;
	private String consultHospCode;
	private String bunho;
	private String finishYn;
	private String hospCode;
	private String reqGwaName;
	private String consultGwaName;
	private String consultDoctorName;
	private String consultHospName;
	private String reqDoctorName;
	private String reqHospitalName;
	private String status;

	public OCS2016U00GrdQuestionInfo(String grpQuestionId, String reqDate, String reqGwa, String reqDoctor,
			String consultGwa, String consultDoctor, String consultDate, String consultHospCode, String bunho,
			String finishYn, String hospCode, String reqGwaName, String consultGwaName, String consultDoctorName,
			String consultHospName, String reqDoctorName, String reqHospitalName, String status) {
		super();
		this.grpQuestionId = grpQuestionId;
		this.reqDate = reqDate;
		this.reqGwa = reqGwa;
		this.reqDoctor = reqDoctor;
		this.consultGwa = consultGwa;
		this.consultDoctor = consultDoctor;
		this.consultDate = consultDate;
		this.consultHospCode = consultHospCode;
		this.bunho = bunho;
		this.finishYn = finishYn;
		this.hospCode = hospCode;
		this.reqGwaName = reqGwaName;
		this.consultGwaName = consultGwaName;
		this.consultDoctorName = consultDoctorName;
		this.consultHospName = consultHospName;
		this.reqDoctorName = reqDoctorName;
		this.reqHospitalName = reqHospitalName;
		this.status = status;
	}

	public String getGrpQuestionId() {
		return grpQuestionId;
	}

	public void setGrpQuestionId(String grpQuestionId) {
		this.grpQuestionId = grpQuestionId;
	}

	public String getReqDate() {
		return reqDate;
	}

	public void setReqDate(String reqDate) {
		this.reqDate = reqDate;
	}

	public String getReqGwa() {
		return reqGwa;
	}

	public void setReqGwa(String reqGwa) {
		this.reqGwa = reqGwa;
	}

	public String getReqDoctor() {
		return reqDoctor;
	}

	public void setReqDoctor(String reqDoctor) {
		this.reqDoctor = reqDoctor;
	}

	public String getConsultGwa() {
		return consultGwa;
	}

	public void setConsultGwa(String consultGwa) {
		this.consultGwa = consultGwa;
	}

	public String getConsultDoctor() {
		return consultDoctor;
	}

	public void setConsultDoctor(String consultDoctor) {
		this.consultDoctor = consultDoctor;
	}

	public String getConsultDate() {
		return consultDate;
	}

	public void setConsultDate(String consultDate) {
		this.consultDate = consultDate;
	}

	public String getConsultHospCode() {
		return consultHospCode;
	}

	public void setConsultHospCode(String consultHospCode) {
		this.consultHospCode = consultHospCode;
	}

	public String getBunho() {
		return bunho;
	}

	public void setBunho(String bunho) {
		this.bunho = bunho;
	}

	public String getFinishYn() {
		return finishYn;
	}

	public void setFinishYn(String finishYn) {
		this.finishYn = finishYn;
	}

	public String getHospCode() {
		return hospCode;
	}

	public void setHospCode(String hospCode) {
		this.hospCode = hospCode;
	}

	public String getReqGwaName() {
		return reqGwaName;
	}

	public void setReqGwaName(String reqGwaName) {
		this.reqGwaName = reqGwaName;
	}

	public String getConsultGwaName() {
		return consultGwaName;
	}

	public void setConsultGwaName(String consultGwaName) {
		this.consultGwaName = consultGwaName;
	}

	public String getConsultDoctorName() {
		return consultDoctorName;
	}

	public void setConsultDoctorName(String consultDoctorName) {
		this.consultDoctorName = consultDoctorName;
	}

	public String getConsultHospName() {
		return consultHospName;
	}

	public void setConsultHospName(String consultHospName) {
		this.consultHospName = consultHospName;
	}

	public String getReqDoctorName() {
		return reqDoctorName;
	}

	public void setReqDoctorName(String reqDoctorName) {
		this.reqDoctorName = reqDoctorName;
	}

	public String getReqHospitalName() {
		return reqHospitalName;
	}

	public void setReqHospitalName(String reqHospitalName) {
		this.reqHospitalName = reqHospitalName;
	}

	public String getStatus() {
		return status;
	}

	public void setStatus(String status) {
		this.status = status;
	}

}
