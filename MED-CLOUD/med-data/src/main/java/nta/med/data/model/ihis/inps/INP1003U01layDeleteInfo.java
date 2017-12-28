package nta.med.data.model.ihis.inps;

public class INP1003U01layDeleteInfo {
	private String bunho;
	private Double reserFkinp1001;
	private String reserDate;
	public INP1003U01layDeleteInfo(String bunho, Double reserFkinp1001, String reserDate) {
		super();
		this.bunho = bunho;
		this.reserFkinp1001 = reserFkinp1001;
		this.reserDate = reserDate;
	}
	public String getBunho() {
		return bunho;
	}
	public void setBunho(String bunho) {
		this.bunho = bunho;
	}
	public Double getReserFkinp1001() {
		return reserFkinp1001;
	}
	public void setReserFkinp1001(Double reserFkinp1001) {
		this.reserFkinp1001 = reserFkinp1001;
	}
	public String getReserDate() {
		return reserDate;
	}
	public void setReserDate(String reserDate) {
		this.reserDate = reserDate;
	}
	
}
