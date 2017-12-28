package nta.med.data.model.ihis.nuro;

public class RES1001U00FrmModifyReserGrdRES1001Info {
	private String amStart;
	private String amEnd;
	private String pmStart;
	private String pmEnd;
	private Double avgTime;
	public RES1001U00FrmModifyReserGrdRES1001Info(String amStart, String amEnd,
			String pmStart, String pmEnd, Double avgTime) {
		super();
		this.amStart = amStart;
		this.amEnd = amEnd;
		this.pmStart = pmStart;
		this.pmEnd = pmEnd;
		this.avgTime = avgTime;
	}
	public String getAmStart() {
		return amStart;
	}
	public void setAmStart(String amStart) {
		this.amStart = amStart;
	}
	public String getAmEnd() {
		return amEnd;
	}
	public void setAmEnd(String amEnd) {
		this.amEnd = amEnd;
	}
	public String getPmStart() {
		return pmStart;
	}
	public void setPmStart(String pmStart) {
		this.pmStart = pmStart;
	}
	public String getPmEnd() {
		return pmEnd;
	}
	public void setPmEnd(String pmEnd) {
		this.pmEnd = pmEnd;
	}
	public Double getAvgTime() {
		return avgTime;
	}
	public void setAvgTime(Double avgTime) {
		this.avgTime = avgTime;
	}
}
