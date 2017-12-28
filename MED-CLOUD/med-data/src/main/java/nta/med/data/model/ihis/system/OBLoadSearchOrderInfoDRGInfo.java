package nta.med.data.model.ihis.system;

public class OBLoadSearchOrderInfoDRGInfo {
	private String slipCode                 ;
	private String slipName                 ;
	private String hangmogCode              ;
	private String hangmogName              ;
	private String wonnaeDrgYn              ;
	private String genericName              ;
	private String emptyStr                 ;
	private String genericCodeOrgSubstr     ;
	private String genericCodeOrg           ;
	private String yakKijunCode             ;
	private String trialFlg                 ;
	public OBLoadSearchOrderInfoDRGInfo(String slipCode, String slipName,
			String hangmogCode, String hangmogName, String wonnaeDrgYn,
			String genericName, String emptyStr, String genericCodeOrgSubstr,
			String genericCodeOrg, String yakKijunCode, String trialFlg) {
		super();
		this.slipCode = slipCode;
		this.slipName = slipName;
		this.hangmogCode = hangmogCode;
		this.hangmogName = hangmogName;
		this.wonnaeDrgYn = wonnaeDrgYn;
		this.genericName = genericName;
		this.emptyStr = emptyStr;
		this.genericCodeOrgSubstr = genericCodeOrgSubstr;
		this.genericCodeOrg = genericCodeOrg;
		this.yakKijunCode = yakKijunCode;
		this.trialFlg = trialFlg;
	}
	public String getSlipCode() {
		return slipCode;
	}
	public void setSlipCode(String slipCode) {
		this.slipCode = slipCode;
	}
	public String getSlipName() {
		return slipName;
	}
	public void setSlipName(String slipName) {
		this.slipName = slipName;
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
	public String getWonnaeDrgYn() {
		return wonnaeDrgYn;
	}
	public void setWonnaeDrgYn(String wonnaeDrgYn) {
		this.wonnaeDrgYn = wonnaeDrgYn;
	}
	public String getGenericName() {
		return genericName;
	}
	public void setGenericName(String genericName) {
		this.genericName = genericName;
	}
	public String getEmptyStr() {
		return emptyStr;
	}
	public void setEmptyStr(String emptyStr) {
		this.emptyStr = emptyStr;
	}
	public String getGenericCodeOrgSubstr() {
		return genericCodeOrgSubstr;
	}
	public void setGenericCodeOrgSubstr(String genericCodeOrgSubstr) {
		this.genericCodeOrgSubstr = genericCodeOrgSubstr;
	}
	public String getGenericCodeOrg() {
		return genericCodeOrg;
	}
	public void setGenericCodeOrg(String genericCodeOrg) {
		this.genericCodeOrg = genericCodeOrg;
	}
	public String getYakKijunCode() {
		return yakKijunCode;
	}
	public void setYakKijunCode(String yakKijunCode) {
		this.yakKijunCode = yakKijunCode;
	}
	public String getTrialFlg() {
		return trialFlg;
	}
	public void setTrialFlg(String trialFlg) {
		this.trialFlg = trialFlg;
	}
	
}
