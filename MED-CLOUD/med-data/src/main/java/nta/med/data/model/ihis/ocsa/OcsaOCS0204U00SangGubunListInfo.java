package nta.med.data.model.ihis.ocsa;

public class OcsaOCS0204U00SangGubunListInfo {
	private String sangGubun;
	private String sangGubunName;
	public OcsaOCS0204U00SangGubunListInfo(String sangGubun,
			String sangGubunName) {
		super();
		this.sangGubun = sangGubun;
		this.sangGubunName = sangGubunName;
	}
	public String getSangGubun() {
		return sangGubun;
	}
	public void setSangGubun(String sangGubun) {
		this.sangGubun = sangGubun;
	}
	public String getSangGubunName() {
		return sangGubunName;
	}
	public void setSangGubunName(String sangGubunName) {
		this.sangGubunName = sangGubunName;
	}
	
}
