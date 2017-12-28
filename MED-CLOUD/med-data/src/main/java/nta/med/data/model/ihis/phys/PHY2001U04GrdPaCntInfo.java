package nta.med.data.model.ihis.phys;

import java.math.BigInteger;

public class PHY2001U04GrdPaCntInfo {
	private String gwa;
	private String gwaName;
	private String doctorName;
	private BigInteger paCnt;
	public PHY2001U04GrdPaCntInfo(String gwa, String gwaName,
			String doctorName, BigInteger paCnt) {
		super();
		this.gwa = gwa;
		this.gwaName = gwaName;
		this.doctorName = doctorName;
		this.paCnt = paCnt;
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
	public BigInteger getPaCnt() {
		return paCnt;
	}
	public void setPaCnt(BigInteger paCnt) {
		this.paCnt = paCnt;
	}
}
