package nta.med.data.model.ihis.xrts;

public class CboBuwiBunryuInfo {
	private String code;
	private String code_Name;
	private Double seq;

	public CboBuwiBunryuInfo(String code, String code_Name, Double seq) {
		super();
		this.code = code;
		this.code_Name = code_Name;
		this.seq = seq;
	}

	public String getCode() {
		return code;
	}

	public void setCode(String code) {
		this.code = code;
	}

	public String getCode_Name() {
		return code_Name;
	}

	public void setCode_Name(String code_Name) {
		this.code_Name = code_Name;
	}

	public Double getSeq() {
		return seq;
	}

	public void setSeq(Double seq) {
		this.seq = seq;
	}

}
