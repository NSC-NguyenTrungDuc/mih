package nta.med.data.model.ihis.inps;

import java.util.Date;

public class INP3003U00grdINP1001PastInfo {
	private Double pkinp1001;
	private Date ipwonDate;
	private String ipwonType;
	private String ipwonTypeName;
	private String gwa;
	private String gwaName;
	private String doctor;
	private String doctorName;
	private Integer jaewonIlsu;
	private String resultCode;
	private String result;
	private Date toiwonDate;
	private Date toiwonResDate;

	public INP3003U00grdINP1001PastInfo(Double pkinp1001, Date ipwonDate, String ipwonType, String ipwonTypeName,
			String gwa, String gwaName, String doctor, String doctorName, Integer jaewonIlsu, String resultCode,
			String result, Date toiwonDate, Date toiwonResDate) {
		super();
		this.pkinp1001 = pkinp1001;
		this.ipwonDate = ipwonDate;
		this.ipwonType = ipwonType;
		this.ipwonTypeName = ipwonTypeName;
		this.gwa = gwa;
		this.gwaName = gwaName;
		this.doctor = doctor;
		this.doctorName = doctorName;
		this.jaewonIlsu = jaewonIlsu;
		this.resultCode = resultCode;
		this.result = result;
		this.toiwonDate = toiwonDate;
		this.toiwonResDate = toiwonResDate;
	}

	public Double getPkinp1001() {
		return pkinp1001;
	}

	public void setPkinp1001(Double pkinp1001) {
		this.pkinp1001 = pkinp1001;
	}

	public Date getIpwonDate() {
		return ipwonDate;
	}

	public void setIpwonDate(Date ipwonDate) {
		this.ipwonDate = ipwonDate;
	}

	public String getIpwonType() {
		return ipwonType;
	}

	public void setIpwonType(String ipwonType) {
		this.ipwonType = ipwonType;
	}

	public String getIpwonTypeName() {
		return ipwonTypeName;
	}

	public void setIpwonTypeName(String ipwonTypeName) {
		this.ipwonTypeName = ipwonTypeName;
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

	public String getDoctor() {
		return doctor;
	}

	public void setDoctor(String doctor) {
		this.doctor = doctor;
	}

	public String getDoctorName() {
		return doctorName;
	}

	public void setDoctorName(String doctorName) {
		this.doctorName = doctorName;
	}

	public Integer getJaewonIlsu() {
		return jaewonIlsu;
	}

	public void setJaewonIlsu(Integer jaewonIlsu) {
		this.jaewonIlsu = jaewonIlsu;
	}

	public String getResultCode() {
		return resultCode;
	}

	public void setResultCode(String resultCode) {
		this.resultCode = resultCode;
	}

	public String getResult() {
		return result;
	}

	public void setResult(String result) {
		this.result = result;
	}

	public Date getToiwonDate() {
		return toiwonDate;
	}

	public void setToiwonDate(Date toiwonDate) {
		this.toiwonDate = toiwonDate;
	}

	public Date getToiwonResDate() {
		return toiwonResDate;
	}

	public void setToiwonResDate(Date toiwonResDate) {
		this.toiwonResDate = toiwonResDate;
	}

}
