package nta.med.data.model.ihis.nuro;

public class ORDERTRANSMisaGetHangmogInfo {

	private String hangmogCode;
	private String hangmogName;
	private Double suryang;
	private Double nalsu;
	private Double dv;

	public ORDERTRANSMisaGetHangmogInfo(String hangmogCode, String hangmogName, Double suryang, Double nalsu,
			Double dv) {
		super();
		this.hangmogCode = hangmogCode;
		this.hangmogName = hangmogName;
		this.suryang = suryang;
		this.nalsu = nalsu;
		this.dv = dv;
	}

	public String getHangmogCode() {
		return hangmogCode;
	}

	public void setHangmogCode(String hangmogCode) {
		this.hangmogCode = hangmogCode;
	}

	public String getHangmogName() {
		return hangmogName;
	}

	public void setHangmogName(String hangmogName) {
		this.hangmogName = hangmogName;
	}

	public Double getSuryang() {
		return suryang;
	}

	public void setSuryang(Double suryang) {
		this.suryang = suryang;
	}

	public Double getNalsu() {
		return nalsu;
	}

	public void setNalsu(Double nalsu) {
		this.nalsu = nalsu;
	}

	public Double getDv() {
		return dv;
	}

	public void setDv(Double dv) {
		this.dv = dv;
	}

}