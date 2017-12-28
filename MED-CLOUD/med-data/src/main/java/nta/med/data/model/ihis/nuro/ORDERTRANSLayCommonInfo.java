package nta.med.data.model.ihis.nuro;

public class ORDERTRANSLayCommonInfo {
	private String gubunName    ;
	private String ifValidYn   ;
	private String gongbiYn     ;
	public ORDERTRANSLayCommonInfo(String gubunName, String ifValidYn,
			String gongbiYn) {
		super();
		this.gubunName = gubunName;
		this.ifValidYn = ifValidYn;
		this.gongbiYn = gongbiYn;
	}
	public String getGubunName() {
		return gubunName;
	}
	public void setGubunName(String gubunName) {
		this.gubunName = gubunName;
	}
	public String getIfValidYn() {
		return ifValidYn;
	}
	public void setIfValidYn(String ifValidYn) {
		this.ifValidYn = ifValidYn;
	}
	public String getGongbiYn() {
		return gongbiYn;
	}
	public void setGongbiYn(String gongbiYn) {
		this.gongbiYn = gongbiYn;
	}
	
}
