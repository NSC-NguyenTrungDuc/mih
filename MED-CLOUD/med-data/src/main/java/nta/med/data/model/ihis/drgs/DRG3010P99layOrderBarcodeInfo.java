package nta.med.data.model.ihis.drgs;

public class DRG3010P99layOrderBarcodeInfo {
	private String barDrgBunho;
	private String barRpBunho;
	private String ser;
	private String bunho;
	
	public DRG3010P99layOrderBarcodeInfo(String barDrgBunho, String barRpBunho, String ser, String bunho){
		this.barDrgBunho = barDrgBunho;
		this.barRpBunho = barRpBunho;
		this.ser = ser;
		this.bunho = bunho;
	}

	public String getBarDrgBunho() {
		return barDrgBunho;
	}

	public void setBarDrgBunho(String barDrgBunho) {
		this.barDrgBunho = barDrgBunho;
	}

	public String getBarRpBunho() {
		return barRpBunho;
	}

	public void setBarRpBunho(String barRpBunho) {
		this.barRpBunho = barRpBunho;
	}

	public String getSer() {
		return ser;
	}

	public void setSer(String ser) {
		this.ser = ser;
	}

	public String getBunho() {
		return bunho;
	}

	public void setBunho(String bunho) {
		this.bunho = bunho;
	}
	
}
