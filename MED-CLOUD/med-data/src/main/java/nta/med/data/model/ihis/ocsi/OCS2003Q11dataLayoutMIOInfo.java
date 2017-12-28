package nta.med.data.model.ihis.ocsi;

public class OCS2003Q11dataLayoutMIOInfo {
	private String sortGubun;
	private String orderGubun;
	private String orderGubunName;
	private String hoCode1;
	private String bunho;
	private String suname;
	private String suname2;
	private String hangmogCode;
	private String hangmogName;
	private String inputGubun;
	private String inputGubunName;
	private Double pkocs2003;
	private String comments;
	
	public OCS2003Q11dataLayoutMIOInfo(String sortGubun, String orderGubun, String orderGubunName, String hoCode1, String bunho, String suname,
			String suname2, String hangmogCode, String hangmogName, String inputGubun, String inputGubunName, Double pkocs2003, String comments){
		this.sortGubun = sortGubun;
		this.orderGubun = orderGubun;
		this.orderGubunName = orderGubunName;
		this.hoCode1 = hoCode1;
		this.bunho = bunho;
		this.suname = suname;
		this.suname2 = suname2;
		this.hangmogCode = hangmogCode;
		this.hangmogName = hangmogName;
		this.inputGubun = inputGubun;
		this.inputGubunName = inputGubunName;
		this.pkocs2003 = pkocs2003;
		this.comments = comments;
	}

	public String getSortGubun() {
		return sortGubun;
	}

	public void setSortGubun(String sortGubun) {
		this.sortGubun = sortGubun;
	}

	public String getOrderGubun() {
		return orderGubun;
	}

	public void setOrderGubun(String orderGubun) {
		this.orderGubun = orderGubun;
	}

	public String getOrderGubunName() {
		return orderGubunName;
	}

	public void setOrderGubunName(String orderGubunName) {
		this.orderGubunName = orderGubunName;
	}

	public String getHoCode1() {
		return hoCode1;
	}

	public void setHoCode1(String hoCode1) {
		this.hoCode1 = hoCode1;
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

	public String getInputGubun() {
		return inputGubun;
	}

	public void setInputGubun(String inputGubun) {
		this.inputGubun = inputGubun;
	}

	public String getInputGubunName() {
		return inputGubunName;
	}

	public void setInputGubunName(String inputGubunName) {
		this.inputGubunName = inputGubunName;
	}

	public Double getPkocs2003() {
		return pkocs2003;
	}

	public void setPkocs2003(Double pkocs2003) {
		this.pkocs2003 = pkocs2003;
	}

	public String getComments() {
		return comments;
	}

	public void setComments(String comments) {
		this.comments = comments;
	}
	
}
