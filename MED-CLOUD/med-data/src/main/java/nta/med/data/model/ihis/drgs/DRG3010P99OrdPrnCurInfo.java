package nta.med.data.model.ihis.drgs;

public class DRG3010P99OrdPrnCurInfo {
	private String bunho;
	private String drgBunho;
	private String orderDateTex;
	private String jubsuDate;
	private String orderDate;
	private String serialV;
	private String serialText;
	private String gwaName;
	private String doctorName;
	private String suname;
	private String suname2;
	private String birth;
	private String sexAge;
	private String hoCode;
	private String hoDong;
	private String magamGubun;
	private String rpBarcode;
	
	public DRG3010P99OrdPrnCurInfo( String bunho, String drgBunho, String orderDateTex, String jubsuDate, String orderDate, String serialV,
			String serialText, String gwaName, String doctorName, String suname, String suname2, String birth, String sexAge, String hoCode,
			String hoDong, String magamGubun, String rpBarcode){
		this.bunho = bunho;
		this.drgBunho = drgBunho;
		this.orderDateTex = orderDateTex;
		this.jubsuDate = jubsuDate;
		this.orderDate = orderDate;
		this.serialV = serialV;
		this.serialText = serialText;
		this.gwaName = gwaName;
		this.doctorName = doctorName;
		this.suname = suname;
		this.suname2 = suname2;
		this.birth = birth;
		this.sexAge = sexAge;
		this.hoCode = hoCode;
		this.hoDong = hoDong;
		this.magamGubun = magamGubun;
		this.rpBarcode = rpBarcode;
	}

	public String getBunho() {
		return bunho;
	}

	public void setBunho(String bunho) {
		this.bunho = bunho;
	}

	public String getDrgBunho() {
		return drgBunho;
	}

	public void setDrgBunho(String drgBunho) {
		this.drgBunho = drgBunho;
	}

	public String getOrderDateTex() {
		return orderDateTex;
	}

	public void setOrderDateTex(String orderDateTex) {
		this.orderDateTex = orderDateTex;
	}

	public String getJubsuDate() {
		return jubsuDate;
	}

	public void setJubsuDate(String jubsuDate) {
		this.jubsuDate = jubsuDate;
	}

	public String getOrderDate() {
		return orderDate;
	}

	public void setOrderDate(String orderDate) {
		this.orderDate = orderDate;
	}

	public String getSerialV() {
		return serialV;
	}

	public void setSerialV(String serialV) {
		this.serialV = serialV;
	}

	public String getSerialText() {
		return serialText;
	}

	public void setSerialText(String serialText) {
		this.serialText = serialText;
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

	public String getBirth() {
		return birth;
	}

	public void setBirth(String birth) {
		this.birth = birth;
	}

	public String getSexAge() {
		return sexAge;
	}

	public void setSexAge(String sexAge) {
		this.sexAge = sexAge;
	}

	public String getHoCode() {
		return hoCode;
	}

	public void setHoCode(String hoCode) {
		this.hoCode = hoCode;
	}

	public String getHoDong() {
		return hoDong;
	}

	public void setHoDong(String hoDong) {
		this.hoDong = hoDong;
	}

	public String getMagamGubun() {
		return magamGubun;
	}

	public void setMagamGubun(String magamGubun) {
		this.magamGubun = magamGubun;
	}

	public String getRpBarcode() {
		return rpBarcode;
	}

	public void setRpBarcode(String rpBarcode) {
		this.rpBarcode = rpBarcode;
	}
	
}
