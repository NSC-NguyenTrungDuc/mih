package nta.med.data.model.ihis.ocsa;

public class OCS0311U00grdSetHangmogGridFindListInfo {
	private String ordDanui ;
	private String codeName ;
	private Double seq ;
	public OCS0311U00grdSetHangmogGridFindListInfo(String ordDanui,
			String codeName, Double seq) {
		super();
		this.ordDanui = ordDanui;
		this.codeName = codeName;
		this.seq = seq;
	}
	public String getOrdDanui() {
		return ordDanui;
	}
	public void setOrdDanui(String ordDanui) {
		this.ordDanui = ordDanui;
	}
	public String getCodeName() {
		return codeName;
	}
	public void setCodeName(String codeName) {
		this.codeName = codeName;
	}
	public Double getSeq() {
		return seq;
	}
	public void setSeq(Double seq) {
		this.seq = seq;
	}
	
}
