package nta.med.data.model.ihis.injs;

import java.util.Date;

public class INJ0000Q00layActingInfo {
	private String gwa ;
    private String doctorName ;
    private Date resultDate ;
    private String hangmogCode ;
    private String hangmogName ;
	public INJ0000Q00layActingInfo(String gwa, String doctorName, Date resultDate, String hangmogCode,
			String hangmogName) {
		super();
		this.gwa = gwa;
		this.doctorName = doctorName;
		this.resultDate = resultDate;
		this.hangmogCode = hangmogCode;
		this.hangmogName = hangmogName;
	}
	public String getGwa() {
		return gwa;
	}
	public void setGwa(String gwa) {
		this.gwa = gwa;
	}
	public String getDoctorName() {
		return doctorName;
	}
	public void setDoctorName(String doctorName) {
		this.doctorName = doctorName;
	}
	public Date getResultDate() {
		return resultDate;
	}
	public void setResultDate(Date resultDate) {
		this.resultDate = resultDate;
	}
	public String getHangmogCode() {
		return hangmogCode;
	}
	public void setHangmogCode(String hangmogCode) {
		this.hangmogCode = hangmogCode;
	}
	public String getHangmogName() {
		return hangmogName;
	}
	public void setHangmogName(String hangmogName) {
		this.hangmogName = hangmogName;
	}
    
}
