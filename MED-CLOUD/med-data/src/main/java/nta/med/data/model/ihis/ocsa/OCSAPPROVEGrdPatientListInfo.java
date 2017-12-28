package nta.med.data.model.ihis.ocsa;

import java.math.BigInteger;
import java.util.Date;

public class OCSAPPROVEGrdPatientListInfo {
	private Date naewonDate;
	private String gwa;
	private String gwaName;
	private String doctorName;
	private BigInteger nalsu;
	private String bunho;
	private String doctor;
	private String gubunName;
	private String chojaeName;
	private String naewonType;
	private Double jubsuNo;
	private Double pkOrder;
	private String inputGubun;
	private String toiwonDrg;
	private String inputTab;
	private String ioGubun;
	private String patientName;
	private String selectYn;

	public OCSAPPROVEGrdPatientListInfo(Date naewonDate, String gwa,
			String gwaName, String doctorName, BigInteger nalsu, String bunho,
			String doctor, String gubunName, String chojaeName,
			String naewonType, Double jubsuNo, Double pkOrder,
			String inputGubun, String toiwonDrg, String inputTab,
			String ioGubun, String patientName, String selectYn) {
		super();
		this.naewonDate = naewonDate;
		this.gwa = gwa;
		this.gwaName = gwaName;
		this.doctorName = doctorName;
		this.nalsu = nalsu;
		this.bunho = bunho;
		this.doctor = doctor;
		this.gubunName = gubunName;
		this.chojaeName = chojaeName;
		this.naewonType = naewonType;
		this.jubsuNo = jubsuNo;
		this.pkOrder = pkOrder;
		this.inputGubun = inputGubun;
		this.toiwonDrg = toiwonDrg;
		this.inputTab = inputTab;
		this.ioGubun = ioGubun;
		this.patientName = patientName;
		this.selectYn = selectYn;
	}

	public Date getNaewonDate() {
		return naewonDate;
	}

	public void setNaewonDate(Date naewonDate) {
		this.naewonDate = naewonDate;
	}

	public String getGwa() {
		return gwa;
	}

	public void setGwa(String gwa) {
		this.gwa = gwa;
	}

	public String getGwaName() {
		return gwaName;
	}

	public void setGwaName(String gwaName) {
		this.gwaName = gwaName;
	}

	public String getDoctorName() {
		return doctorName;
	}

	public void setDoctorName(String doctorName) {
		this.doctorName = doctorName;
	}

	public BigInteger getNalsu() {
		return nalsu;
	}

	public void setNalsu(BigInteger nalsu) {
		this.nalsu = nalsu;
	}

	public String getBunho() {
		return bunho;
	}

	public void setBunho(String bunho) {
		this.bunho = bunho;
	}

	public String getDoctor() {
		return doctor;
	}

	public void setDoctor(String doctor) {
		this.doctor = doctor;
	}

	public String getGubunName() {
		return gubunName;
	}

	public void setGubunName(String gubunName) {
		this.gubunName = gubunName;
	}

	public String getChojaeName() {
		return chojaeName;
	}

	public void setChojaeName(String chojaeName) {
		this.chojaeName = chojaeName;
	}

	public String getNaewonType() {
		return naewonType;
	}

	public void setNaewonType(String naewonType) {
		this.naewonType = naewonType;
	}

	public Double getJubsuNo() {
		return jubsuNo;
	}

	public void setJubsuNo(Double jubsuNo) {
		this.jubsuNo = jubsuNo;
	}

	public Double getPkOrder() {
		return pkOrder;
	}

	public void setPkOrder(Double pkOrder) {
		this.pkOrder = pkOrder;
	}

	public String getInputGubun() {
		return inputGubun;
	}

	public void setInputGubun(String inputGubun) {
		this.inputGubun = inputGubun;
	}

	public String getToiwonDrg() {
		return toiwonDrg;
	}

	public void setToiwonDrg(String toiwonDrg) {
		this.toiwonDrg = toiwonDrg;
	}

	public String getInputTab() {
		return inputTab;
	}

	public void setInputTab(String inputTab) {
		this.inputTab = inputTab;
	}

	public String getIoGubun() {
		return ioGubun;
	}

	public void setIoGubun(String ioGubun) {
		this.ioGubun = ioGubun;
	}

	public String getPatientName() {
		return patientName;
	}

	public void setPatientName(String patientName) {
		this.patientName = patientName;
	}

	public String getSelectYn() {
		return selectYn;
	}

	public void setSelectYn(String selectYn) {
		this.selectYn = selectYn;
	}

}