package nta.med.data.model.ihis.emr;

public class OCS2015U09TagParentAndChild {
	private String tagParent;
	private String tagChild;
	private Integer emrTemplateId;
	public OCS2015U09TagParentAndChild(String tagParent, String tagChild, Integer emrTemplateId) {
		super();
		this.tagParent = tagParent;
		this.tagChild = tagChild;
		this.emrTemplateId = emrTemplateId;
	}
	public String getTagParent() {
		return tagParent;
	}
	public void setTagParent(String tagParent) {
		this.tagParent = tagParent;
	}
	public String getTagChild() {
		return tagChild;
	}
	public void setTagChild(String tagChild) {
		this.tagChild = tagChild;
	}
	public Integer getEmrTemplateId() {
		return emrTemplateId;
	}
	public void setEmrTemplateId(Integer emrTemplateId) {
		this.emrTemplateId = emrTemplateId;
	}
	
}
