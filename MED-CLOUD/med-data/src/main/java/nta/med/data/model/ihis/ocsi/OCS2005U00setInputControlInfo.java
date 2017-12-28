package nta.med.data.model.ihis.ocsi;

public class OCS2005U00setInputControlInfo {
	private String suryangCrYn ;
    private String ordDanuiCrYn ;
    private String dvCrYn ;
    private String nalsuCrYn ;
    private String jusaCrYn ;
    private String bogyongCodeCrYn ;
	public OCS2005U00setInputControlInfo(String suryangCrYn, String ordDanuiCrYn, String dvCrYn, String nalsuCrYn,
			String jusaCrYn, String bogyongCodeCrYn) {
		super();
		this.suryangCrYn = suryangCrYn;
		this.ordDanuiCrYn = ordDanuiCrYn;
		this.dvCrYn = dvCrYn;
		this.nalsuCrYn = nalsuCrYn;
		this.jusaCrYn = jusaCrYn;
		this.bogyongCodeCrYn = bogyongCodeCrYn;
	}
	public String getSuryangCrYn() {
		return suryangCrYn;
	}
	public void setSuryangCrYn(String suryangCrYn) {
		this.suryangCrYn = suryangCrYn;
	}
	public String getOrdDanuiCrYn() {
		return ordDanuiCrYn;
	}
	public void setOrdDanuiCrYn(String ordDanuiCrYn) {
		this.ordDanuiCrYn = ordDanuiCrYn;
	}
	public String getDvCrYn() {
		return dvCrYn;
	}
	public void setDvCrYn(String dvCrYn) {
		this.dvCrYn = dvCrYn;
	}
	public String getNalsuCrYn() {
		return nalsuCrYn;
	}
	public void setNalsuCrYn(String nalsuCrYn) {
		this.nalsuCrYn = nalsuCrYn;
	}
	public String getJusaCrYn() {
		return jusaCrYn;
	}
	public void setJusaCrYn(String jusaCrYn) {
		this.jusaCrYn = jusaCrYn;
	}
	public String getBogyongCodeCrYn() {
		return bogyongCodeCrYn;
	}
	public void setBogyongCodeCrYn(String bogyongCodeCrYn) {
		this.bogyongCodeCrYn = bogyongCodeCrYn;
	}
    
}
