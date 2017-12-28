package nta.med.data.model.ihis.nuri;

public class NUR1010Q00SelectDokboInfo {
	private String dokbo;
	private String hosong;
	private String dansong;
	
	public NUR1010Q00SelectDokboInfo(String dokbo, String hosong, String dansong) {
		super();
		this.dokbo = dokbo;
		this.hosong = hosong;
		this.dansong = dansong;
	}

	public String getDokbo() {
		return dokbo;
	}

	public void setDokbo(String dokbo) {
		this.dokbo = dokbo;
	}

	public String getHosong() {
		return hosong;
	}

	public void setHosong(String hosong) {
		this.hosong = hosong;
	}

	public String getDansong() {
		return dansong;
	}

	public void setDansong(String dansong) {
		this.dansong = dansong;
	}
	
}
