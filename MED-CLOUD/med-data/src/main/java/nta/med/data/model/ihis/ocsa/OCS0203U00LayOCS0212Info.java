package nta.med.data.model.ihis.ocsa;

public class OCS0203U00LayOCS0212Info {
	private String hangmogCode;
    private String oftenUse;
    private String memb;
    private String membGubun;
    private String hospCode;
	public OCS0203U00LayOCS0212Info(String hangmogCode, String oftenUse,
			String memb, String membGubun, String hospCode) {
		super();
		this.hangmogCode = hangmogCode;
		this.oftenUse = oftenUse;
		this.memb = memb;
		this.membGubun = membGubun;
		this.hospCode = hospCode;
	}
	public String getHangmogCode() {
		return hangmogCode;
	}
	public void setHangmogCode(String hangmogCode) {
		this.hangmogCode = hangmogCode;
	}
	public String getOftenUse() {
		return oftenUse;
	}
	public void setOftenUse(String oftenUse) {
		this.oftenUse = oftenUse;
	}
	public String getMemb() {
		return memb;
	}
	public void setMemb(String memb) {
		this.memb = memb;
	}
	public String getMembGubun() {
		return membGubun;
	}
	public void setMembGubun(String membGubun) {
		this.membGubun = membGubun;
	}
	public String getHospCode() {
		return hospCode;
	}
	public void setHospCode(String hospCode) {
		this.hospCode = hospCode;
	}
}
