package nta.med.data.model.ihis.cpls;


public class CplsCPL2010U00GrdTubeCPL2010ListItemInfo {
	private String tubeCode;
	private String tubeName;
	private Double cnt;
	public CplsCPL2010U00GrdTubeCPL2010ListItemInfo(String tubeCode,
			String tubeName, Double cnt) {
		super();
		this.tubeCode = tubeCode;
		this.tubeName = tubeName;
		this.cnt = cnt;
	}
	public String getTubeCode() {
		return tubeCode;
	}
	public void setTubeCode(String tubeCode) {
		this.tubeCode = tubeCode;
	}
	public String getTubeName() {
		return tubeName;
	}
	public void setTubeName(String tubeName) {
		this.tubeName = tubeName;
	}
	public Double getCnt() {
		return cnt;
	}
	public void setCnt(Double cnt) {
		this.cnt = cnt;
	}
	
}
