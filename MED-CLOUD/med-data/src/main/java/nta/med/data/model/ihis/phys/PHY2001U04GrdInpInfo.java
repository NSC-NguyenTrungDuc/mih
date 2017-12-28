package nta.med.data.model.ihis.phys;

public class PHY2001U04GrdInpInfo {
	private String orderDate       ;
	private String bunho            ;
	private String suname           ;
	private String suname2          ;
	private String doctorName      ;
	private String hangmogCode     ;
	private String hangmogName     ;
	private String ptFlag          ;
	private String otFlag          ;
	private String stFlag          ;
	private String buFlag          ;
	private String ocsFlag         ;
	public PHY2001U04GrdInpInfo(String orderDate, String bunho, String suname,
			String suname2, String doctorName, String hangmogCode,
			String hangmogName, String ptFlag, String otFlag, String stFlag,
			String buFlag, String ocsFlag) {
		super();
		this.orderDate = orderDate;
		this.bunho = bunho;
		this.suname = suname;
		this.suname2 = suname2;
		this.doctorName = doctorName;
		this.hangmogCode = hangmogCode;
		this.hangmogName = hangmogName;
		this.ptFlag = ptFlag;
		this.otFlag = otFlag;
		this.stFlag = stFlag;
		this.buFlag = buFlag;
		this.ocsFlag = ocsFlag;
	}
	public String getOrderDate() {
		return orderDate;
	}
	public void setOrderDate(String orderDate) {
		this.orderDate = orderDate;
	}
	public String getBunho() {
		return bunho;
	}
	public void setBunho(String bunho) {
		this.bunho = bunho;
	}
	public String getSuname() {
		return suname;
	}
	public void setSuname(String suname) {
		this.suname = suname;
	}
	public String getSuname2() {
		return suname2;
	}
	public void setSuname2(String suname2) {
		this.suname2 = suname2;
	}
	public String getDoctorName() {
		return doctorName;
	}
	public void setDoctorName(String doctorName) {
		this.doctorName = doctorName;
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
	public String getPtFlag() {
		return ptFlag;
	}
	public void setPtFlag(String ptFlag) {
		this.ptFlag = ptFlag;
	}
	public String getOtFlag() {
		return otFlag;
	}
	public void setOtFlag(String otFlag) {
		this.otFlag = otFlag;
	}
	public String getStFlag() {
		return stFlag;
	}
	public void setStFlag(String stFlag) {
		this.stFlag = stFlag;
	}
	public String getBuFlag() {
		return buFlag;
	}
	public void setBuFlag(String buFlag) {
		this.buFlag = buFlag;
	}
	public String getOcsFlag() {
		return ocsFlag;
	}
	public void setOcsFlag(String ocsFlag) {
		this.ocsFlag = ocsFlag;
	}
	

}
