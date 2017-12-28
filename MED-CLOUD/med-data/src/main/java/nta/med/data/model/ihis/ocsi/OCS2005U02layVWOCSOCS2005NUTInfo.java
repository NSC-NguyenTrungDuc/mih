package nta.med.data.model.ihis.ocsi;

public class OCS2005U02layVWOCSOCS2005NUTInfo {

	private String nutDate;
	private String bldGubun;
	private String sikGubun;
	private String sikjong;
	private String jusik;
	private String busik;
	private String nomimono;
	private String fkinp1001;
	
	public OCS2005U02layVWOCSOCS2005NUTInfo(String nutDate, String bldGubun, String sikGubun, String sikjong, String jusik,
			String busik, String nomimono, String fkinp1001){
		this.nutDate = nutDate;
		this.bldGubun = bldGubun;
		this.sikGubun = sikGubun;
		this.sikjong = sikjong;
		this.jusik = jusik;
		this.busik = busik;
		this.nomimono = nomimono;
		this.fkinp1001 = fkinp1001;
	}

	public String getNutDate() {
		return nutDate;
	}

	public void setNutDate(String nutDate) {
		this.nutDate = nutDate;
	}

	public String getBldGubun() {
		return bldGubun;
	}

	public void setBldGubun(String bldGubun) {
		this.bldGubun = bldGubun;
	}

	public String getSikGubun() {
		return sikGubun;
	}

	public void setSikGubun(String sikGubun) {
		this.sikGubun = sikGubun;
	}

	public String getSikjong() {
		return sikjong;
	}

	public void setSikjong(String sikjong) {
		this.sikjong = sikjong;
	}

	public String getJusik() {
		return jusik;
	}

	public void setJusik(String jusik) {
		this.jusik = jusik;
	}

	public String getBusik() {
		return busik;
	}

	public void setBusik(String busik) {
		this.busik = busik;
	}

	public String getNomimono() {
		return nomimono;
	}

	public void setNomimono(String nomimono) {
		this.nomimono = nomimono;
	}

	public String getFkinp1001() {
		return fkinp1001;
	}

	public void setFkinp1001(String fkinp1001) {
		this.fkinp1001 = fkinp1001;
	}
	
}
