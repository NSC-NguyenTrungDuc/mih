package nta.med.data.model.ihis.phys;

public class PHY0001U00GrdRehaSinryouryouCodeInfo {
	private String code;
    private String hangmogCode;
    private String hangmogName;
	public PHY0001U00GrdRehaSinryouryouCodeInfo(String code,
			String hangmogCode, String hangmogName) {
		super();
		this.code = code;
		this.hangmogCode = hangmogCode;
		this.hangmogName = hangmogName;
	}
	public String getCode() {
		return code;
	}
	public void setCode(String code) {
		this.code = code;
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
}
