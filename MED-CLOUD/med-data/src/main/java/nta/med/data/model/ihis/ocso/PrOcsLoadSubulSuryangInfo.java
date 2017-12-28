package nta.med.data.model.ihis.ocso;

public class PrOcsLoadSubulSuryangInfo {
	private String subulDanui;
	private Integer subulSuryang;
	private String oFlag ;
	public PrOcsLoadSubulSuryangInfo(){
		
	}
	public PrOcsLoadSubulSuryangInfo(String subulDanui, Integer subulSuryang,
			String oFlag) {
		super();
		this.subulDanui = subulDanui;
		this.subulSuryang = subulSuryang;
		this.oFlag = oFlag;
	}
	public String getSubulDanui() {
		return subulDanui;
	}
	public void setSubulDanui(String subulDanui) {
		this.subulDanui = subulDanui;
	}
	public Integer getSubulSuryang() {
		return subulSuryang;
	}
	public void setSubulSuryang(Integer subulSuryang) {
		this.subulSuryang = subulSuryang;
	}
	public String getoFlag() {
		return oFlag;
	}
	public void setoFlag(String oFlag) {
		this.oFlag = oFlag;
	}
	

}
