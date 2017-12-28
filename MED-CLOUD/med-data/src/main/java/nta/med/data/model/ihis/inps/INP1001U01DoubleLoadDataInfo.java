package nta.med.data.model.ihis.inps;

public class INP1001U01DoubleLoadDataInfo {
	private String checkY;
	private Double pkinp1001;
	public INP1001U01DoubleLoadDataInfo(String checkY, Double pkinp1001) {
		super();
		this.checkY = checkY;
		this.pkinp1001 = pkinp1001;
	}
	public String getCheckY() {
		return checkY;
	}
	public void setCheckY(String checkY) {
		this.checkY = checkY;
	}
	public Double getPkinp1001() {
		return pkinp1001;
	}
	public void setPkinp1001(Double pkinp1001) {
		this.pkinp1001 = pkinp1001;
	}
	
}
