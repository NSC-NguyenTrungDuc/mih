package nta.med.data.model.ihis.nuts;

public class NUT9001U00grdINP5001Info {

	private String magamDate;
	private String chargeYn;
	private String nutJoMagamYn;
	private String nutJuMagamYn;
	private String nutSeokMagamYn;
	private String bSeq;
	private String lSeq;
	private String dSeq;
	private String contKey;

	public NUT9001U00grdINP5001Info(String magamDate, String chargeYn, String nutJoMagamYn, String nutJuMagamYn,
			String nutSeokMagamYn, String bSeq, String lSeq, String dSeq, String contKey) {
		super();
		this.magamDate = magamDate;
		this.chargeYn = chargeYn;
		this.nutJoMagamYn = nutJoMagamYn;
		this.nutJuMagamYn = nutJuMagamYn;
		this.nutSeokMagamYn = nutSeokMagamYn;
		this.bSeq = bSeq;
		this.lSeq = lSeq;
		this.dSeq = dSeq;
		this.contKey = contKey;
	}

	public String getMagamDate() {
		return magamDate;
	}

	public void setMagamDate(String magamDate) {
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

	public String getBSeq() {
		return bSeq;
	}

	public void setBSeq(String bSeq) {
		this.bSeq = bSeq;
	}

	public String getLSeq() {
		return lSeq;
	}

	public void setLSeq(String lSeq) {
		this.lSeq = lSeq;
	}

	public String getDSeq() {
		return dSeq;
	}

	public void setDSeq(String dSeq) {
		this.dSeq = dSeq;
	}

	public String getContKey() {
		return contKey;
	}

	public void setContKey(String contKey) {
		this.contKey = contKey;
	}

	
}
