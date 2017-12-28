package nta.med.data.model.ihis.drgs;

public class DRG3010P99getBodyIndexBarcodeInfo {
	private String height;
	private String cm;
	private String weight;
	private String kg;
	private String cplResult;
	
	public DRG3010P99getBodyIndexBarcodeInfo(String height, String cm, String weight, String kg, String cplResult){
		this.height = height;
		this.cm = cm;
		this.weight = weight;
		this.kg = kg;
		this.cplResult = cplResult;
	}

	public String getHeight() {
		return height;
	}

	public void setHeight(String height) {
		this.height = height;
	}

	public String getCm() {
		return cm;
	}

	public void setCm(String cm) {
		this.cm = cm;
	}

	public String getWeight() {
		return weight;
	}

	public void setWeight(String weight) {
		this.weight = weight;
	}

	public String getKg() {
		return kg;
	}

	public void setKg(String kg) {
		this.kg = kg;
	}

	public String getCplResult() {
		return cplResult;
	}

	public void setCplResult(String cplResult) {
		this.cplResult = cplResult;
	}
	
}
