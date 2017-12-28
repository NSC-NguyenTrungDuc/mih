package nta.med.data.model.ihis.ocsi;

import java.math.BigInteger;

public class OCS2003U03getSysInfo {
	private String height;
	private String cm;
	private String weight;
	private String kg;
	private String cplResult;
	private String comments;
	private BigInteger cnt;

	public OCS2003U03getSysInfo(String height, String cm, String weight, String kg, String cplResult, String comments,
			BigInteger cnt) {
		super();
		this.height = height;
		this.cm = cm;
		this.weight = weight;
		this.kg = kg;
		this.cplResult = cplResult;
		this.comments = comments;
		this.cnt = cnt;
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

	public String getComments() {
		return comments;
	}

	public void setComments(String comments) {
		this.comments = comments;
	}

	public BigInteger getCnt() {
		return cnt;
	}

	public void setCnt(BigInteger cnt) {
		this.cnt = cnt;
	}

}
