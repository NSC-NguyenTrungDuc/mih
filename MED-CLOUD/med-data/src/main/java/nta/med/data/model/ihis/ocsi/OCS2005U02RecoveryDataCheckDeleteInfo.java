package nta.med.data.model.ihis.ocsi;

public class OCS2005U02RecoveryDataCheckDeleteInfo {
	private String chargeYn;
	private String nutJoMagamYn;
	private String nutJuMagamYn;
	private String nutSeokMagamYn;
	private String magamDate;
	
	public OCS2005U02RecoveryDataCheckDeleteInfo(String chargeYn, String nutJoMagamYn, String nutJuMagamYn, String nutSeokMagamYn, String magamDate){
		this.chargeYn = chargeYn;
		this.nutJoMagamYn = nutJoMagamYn;
		this.nutJuMagamYn = nutJuMagamYn;
		this.nutSeokMagamYn = nutSeokMagamYn;
		this.magamDate = magamDate;
	}

	public String getChargeYn() {
		return chargeYn;
	}

	public void setChargeYn(String chargeYn) {
		this.chargeYn = chargeYn;
	}

	public String getNutJoMagamYn() {
		return nutJoMagamYn;
	}

	public void setNutJoMagamYn(String nutJoMagamYn) {
		this.nutJoMagamYn = nutJoMagamYn;
	}

	public String getNutJuMagamYn() {
		return nutJuMagamYn;
	}

	public void setNutJuMagamYn(String nutJuMagamYn) {
		this.nutJuMagamYn = nutJuMagamYn;
	}

	public String getNutSeokMagamYn() {
		return nutSeokMagamYn;
	}

	public void setNutSeokMagamYn(String nutSeokMagamYn) {
		this.nutSeokMagamYn = nutSeokMagamYn;
	}

	public String getMagamDate() {
		return magamDate;
	}

	public void setMagamDate(String magamDate) {
		this.magamDate = magamDate;
	}
	
	
}
