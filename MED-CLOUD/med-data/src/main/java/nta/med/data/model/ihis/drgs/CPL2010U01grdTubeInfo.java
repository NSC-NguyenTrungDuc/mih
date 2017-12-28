package nta.med.data.model.ihis.drgs;

public class CPL2010U01grdTubeInfo {

	private String tubeCode;
	private String tubeName;
	private String cnt;

	public CPL2010U01grdTubeInfo(String tubeCode, String tubeName, String cnt) {
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

	public String getCnt() {
		return cnt;
	}

	public void setCnt(String cnt) {
		this.cnt = cnt;
	}

}
