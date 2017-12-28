package nta.med.data.model.ihis.inps;

public class INP1001U01DoubleGrdINP1008Info {
	private String nValue;
	private String gongbiCode;
	private String gongbiName;
	private String fkinp1002;
	private String bunho;
	private String gubun;
	private String gubunName;
	private String emptyValue;

	public INP1001U01DoubleGrdINP1008Info(String nValue, String gongbiCode, String gongbiName, String fkinp1002,
			String bunho, String gubun, String gubunName, String emptyValue) {
		super();
		this.nValue = nValue;
		this.gongbiCode = gongbiCode;
		this.gongbiName = gongbiName;
		this.fkinp1002 = fkinp1002;
		this.bunho = bunho;
		this.gubun = gubun;
		this.gubunName = gubunName;
		this.emptyValue = emptyValue;
	}

	public String getnValue() {
		return nValue;
	}

	public void setnValue(String nValue) {
		this.nValue = nValue;
	}

	public String getGongbiCode() {
		return gongbiCode;
	}

	public void setGongbiCode(String gongbiCode) {
		this.gongbiCode = gongbiCode;
	}

	public String getGongbiName() {
		return gongbiName;
	}

	public void setGongbiName(String gongbiName) {
		this.gongbiName = gongbiName;
	}

	public String getFkinp1002() {
		return fkinp1002;
	}

	public void setFkinp1002(String fkinp1002) {
		this.fkinp1002 = fkinp1002;
	}

	public String getBunho() {
		return bunho;
	}

	public void setBunho(String bunho) {
		this.bunho = bunho;
	}

	public String getGubun() {
		return gubun;
	}

	public void setGubun(String gubun) {
		this.gubun = gubun;
	}

	public String getGubunName() {
		return gubunName;
	}

	public void setGubunName(String gubunName) {
		this.gubunName = gubunName;
	}

	public String getEmptyValue() {
		return emptyValue;
	}

	public void setEmptyValue(String emptyValue) {
		this.emptyValue = emptyValue;
	}

}
