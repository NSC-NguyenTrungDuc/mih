package nta.med.data.model.ihis.cpls;

import java.math.BigDecimal;

public class CplsCPL2010U00GrdTubeCPL2010ListItemInfo2 {

	private String tubeCode;
	private String tubeName;
	private BigDecimal cnt;
	public CplsCPL2010U00GrdTubeCPL2010ListItemInfo2(String tubeCode,
			String tubeName, BigDecimal cnt) {
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
	public BigDecimal getCnt() {
		return cnt;
	}
	public void setCnt(BigDecimal cnt) {
		this.cnt = cnt;
	}
	
}
