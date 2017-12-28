package nta.med.data.model.ihis.ocso;

public class OCSACTGetFindWorkerInfo {
	private String ordDanui ;
	private String codeName ;
	private Double seq       ;
	public OCSACTGetFindWorkerInfo(String ordDanui, String codeName, Double seq) {
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
