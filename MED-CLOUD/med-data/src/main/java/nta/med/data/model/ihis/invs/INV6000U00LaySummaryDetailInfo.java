package nta.med.data.model.ihis.invs;

public class INV6000U00LaySummaryDetailInfo {
	private String slipCode    ;
	private String jaeryoCode  ;
	private String jaeryoName  ;
	private String subul_danga  ;
	private String danui        ;
	private String jaegoQty    ;
	private String sougaku      ;
	public INV6000U00LaySummaryDetailInfo(String slipCode, String jaeryoCode, String jaeryoName, String subul_danga,
			String danui, String jaegoQty, String sougaku) {
		super();
		this.slipCode = slipCode;
		this.jaeryoCode = jaeryoCode;
		this.jaeryoName = jaeryoName;
		this.subul_danga = subul_danga;
		this.danui = danui;
		this.jaegoQty = jaegoQty;
		this.sougaku = sougaku;
	}
	public String getSlipCode() {
		return slipCode;
	}
	public void setSlipCode(String slipCode) {
		this.slipCode = slipCode;
	}
	public String getJaeryoCode() {
		return jaeryoCode;
	}
	public void setJaeryoCode(String jaeryoCode) {
		this.jaeryoCode = jaeryoCode;
	}
	public String getJaeryoName() {
		return jaeryoName;
	}
	public void setJaeryoName(String jaeryoName) {
		this.jaeryoName = jaeryoName;
	}
	public String getSubul_danga() {
		return subul_danga;
	}
	public void setSubul_danga(String subul_danga) {
		this.subul_danga = subul_danga;
	}
	public String getDanui() {
		return danui;
	}
	public void setDanui(String danui) {
		this.danui = danui;
	}
	public String getJaegoQty() {
		return jaegoQty;
	}
	public void setJaegoQty(String jaegoQty) {
		this.jaegoQty = jaegoQty;
	}
	public String getSougaku() {
		return sougaku;
	}
	public void setSougaku(String sougaku) {
		this.sougaku = sougaku;
	}
	
}
