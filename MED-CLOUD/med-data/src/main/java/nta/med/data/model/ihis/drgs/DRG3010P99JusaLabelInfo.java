package nta.med.data.model.ihis.drgs;

public class DRG3010P99JusaLabelInfo {
	private String bunho;
	private String drgBunho;
	private String orderDateText;
	private String jubsuDate;
	private String hopeDate;
	private String orderDate;
	private String serialV;
	private String serialText;
	private String suname;
	private String suname2;
	private String sexAge;
	private String hoCode;
	private String hoDong;
	private String bogyongName;
	private String cnt;
	
	public DRG3010P99JusaLabelInfo(String bunho, String drgBunho, String orderDateText, String jubsuDate,
			String hopeDate, String orderDate, String serialV, String serialText, String suname, String suname2,
			String sexAge, String hoCode, String hoDong, String bogyongName, String cnt) {
		super();
		this.bunho = bunho;
		this.drgBunho = drgBunho;
		this.orderDateText = orderDateText;
		this.jubsuDate = jubsuDate;
		this.hopeDate = hopeDate;
		this.orderDate = orderDate;
		this.serialV = serialV;
		this.serialText = serialText;
		this.suname = suname;
		this.suname2 = suname2;
		this.sexAge = sexAge;
		this.hoCode = hoCode;
		this.hoDong = hoDong;
		this.bogyongName = bogyongName;
		this.cnt = cnt;
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

	public String getOrderDateText() {
		return orderDateText;
	}

	public void setOrderDateText(String orderDateText) {
		this.orderDateText = orderDateText;
	}

	public String getJubsuDate() {
		return jubsuDate;
	}

	public void setJubsuDate(String jubsuDate) {
		this.jubsuDate = jubsuDate;
	}

	public String getHopeDate() {
		return hopeDate;
	}

	public void setHopeDate(String hopeDate) {
		this.hopeDate = hopeDate;
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

	public String getBogyongName() {
		return bogyongName;
	}

	public void setBogyongName(String bogyongName) {
		this.bogyongName = bogyongName;
	}

	public String getCnt() {
		return cnt;
	}

	public void setCnt(String cnt) {
		this.cnt = cnt;
	}
	
}
