package nta.med.data.model.ihis.emr;

public class OCS2015U07TagChildInfo {
	private String tagCode;
	private String tagName;
	private String tagDisplayText;
	public OCS2015U07TagChildInfo(String tagCode, String tagName,
			String tagDisplayText) {
		super();
		this.tagCode = tagCode;
		this.tagName = tagName;
		this.tagDisplayText = tagDisplayText;
	}
	public String getTagCode() {
		return tagCode;
	}
	public void setTagCode(String tagCode) {
		this.tagCode = tagCode;
	}
	public String getTagName() {
		return tagName;
	}
	public void setTagName(String tagName) {
		this.tagName = tagName;
	}
	public String getTagDisplayText() {
		return tagDisplayText;
	}
	public void setTagDisplayText(String tagDisplayText) {
		this.tagDisplayText = tagDisplayText;
	}
	
}
