package nta.med.data.model.ihis.emr;

public class OCS2015U00GetDiseaseReportInfo {
	private String sangCode;
	private String sangName;
	public OCS2015U00GetDiseaseReportInfo(String sangCode, String sangName) {
		super();
		this.sangCode = sangCode;
		this.sangName = sangName;
	}
	public String getSangCode() {
		return sangCode;
	}
	public void setSangCode(String sangCode) {
		this.sangCode = sangCode;
	}
	public String getSangName() {
		return sangName;
	}
	public void setSangName(String sangName) {
		this.sangName = sangName;
	}
	
}
