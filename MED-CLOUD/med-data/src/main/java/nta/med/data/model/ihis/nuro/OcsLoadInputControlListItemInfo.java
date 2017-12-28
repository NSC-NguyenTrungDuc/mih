package nta.med.data.model.ihis.nuro;

public class OcsLoadInputControlListItemInfo {
	private String inputControl;
	private String inputControlName;
	private String specimenCode;
	private String suryang;
	private String ordDanui;
	private String dv;
	private String nalsu;
	private String jusa;
	private String bogyongCode;
	private String toiwonDrgYn;
	private String portableYn;
	private String amt;
	private String wonyoiOrderYn;

	public OcsLoadInputControlListItemInfo(String inputControl,
			String inputControlName, String specimenCode, String suryang,
			String ordDanui, String dv, String nalsu, String jusa,
			String bogyongCode, String toiwonDrgYn, String portableYn,
			String amt, String wonyoiOrderYn) {
		super();
		this.inputControl = inputControl;
		this.inputControlName = inputControlName;
		this.specimenCode = specimenCode;
		this.suryang = suryang;
		this.ordDanui = ordDanui;
		this.dv = dv;
		this.nalsu = nalsu;
		this.jusa = jusa;
		this.bogyongCode = bogyongCode;
		this.toiwonDrgYn = toiwonDrgYn;
		this.portableYn = portableYn;
		this.amt = amt;
		this.wonyoiOrderYn = wonyoiOrderYn;
	}

	public String getInputControl() {
		return inputControl;
	}

	public void setInputControl(String inputControl) {
		this.inputControl = inputControl;
	}

	public String getInputControlName() {
		return inputControlName;
	}

	public void setInputControlName(String inputControlName) {
		this.inputControlName = inputControlName;
	}

	public String getSpecimenCode() {
		return specimenCode;
	}

	public void setSpecimenCode(String specimenCode) {
		this.specimenCode = specimenCode;
	}

	public String getSuryang() {
		return suryang;
	}

	public void setSuryang(String suryang) {
		this.suryang = suryang;
	}

	public String getOrdDanui() {
		return ordDanui;
	}

	public void setOrdDanui(String ordDanui) {
		this.ordDanui = ordDanui;
	}

	public String getDv() {
		return dv;
	}

	public void setDv(String dv) {
		this.dv = dv;
	}

	public String getNalsu() {
		return nalsu;
	}

	public void setNalsu(String nalsu) {
		this.nalsu = nalsu;
	}

	public String getJusa() {
		return jusa;
	}

	public void setJusa(String jusa) {
		this.jusa = jusa;
	}

	public String getBogyongCode() {
		return bogyongCode;
	}

	public void setBogyongCode(String bogyongCode) {
		this.bogyongCode = bogyongCode;
	}

	public String getToiwonDrgYn() {
		return toiwonDrgYn;
	}

	public void setToiwonDrgYn(String toiwonDrgYn) {
		this.toiwonDrgYn = toiwonDrgYn;
	}

	public String getPortableYn() {
		return portableYn;
	}

	public void setPortableYn(String portableYn) {
		this.portableYn = portableYn;
	}

	public String getAmt() {
		return amt;
	}

	public void setAmt(String amt) {
		this.amt = amt;
	}

	public String getWonyoiOrderYn() {
		return wonyoiOrderYn;
	}

	public void setWonyoiOrderYn(String wonyoiOrderYn) {
		this.wonyoiOrderYn = wonyoiOrderYn;
	}

}
