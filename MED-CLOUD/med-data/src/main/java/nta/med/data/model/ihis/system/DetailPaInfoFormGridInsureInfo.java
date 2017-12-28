package nta.med.data.model.ihis.system;

import java.sql.Timestamp;

public class DetailPaInfoFormGridInsureInfo {
	private Timestamp startDate;
    private String typeName;
    private Timestamp endDate;
    private String johapName;
    private String percentage;
    private String percentageNo;
    private Timestamp lastCheckDate;
	public DetailPaInfoFormGridInsureInfo(Timestamp startDate, String typeName,
			Timestamp endDate, String johapName, String percentage,
			String percentageNo, Timestamp lastCheckDate) {
		super();
		this.startDate = startDate;
		this.typeName = typeName;
		this.endDate = endDate;
		this.johapName = johapName;
		this.percentage = percentage;
		this.percentageNo = percentageNo;
		this.lastCheckDate = lastCheckDate;
	}
	public Timestamp getStartDate() {
		return startDate;
	}
	public void setStartDate(Timestamp startDate) {
		this.startDate = startDate;
	}
	public String getTypeName() {
		return typeName;
	}
	public void setTypeName(String typeName) {
		this.typeName = typeName;
	}
	public Timestamp getEndDate() {
		return endDate;
	}
	public void setEndDate(Timestamp endDate) {
		this.endDate = endDate;
	}
	public String getJohapName() {
		return johapName;
	}
	public void setJohapName(String johapName) {
		this.johapName = johapName;
	}
	public String getPercentage() {
		return percentage;
	}
	public void setPercentage(String percentage) {
		this.percentage = percentage;
	}
	public String getPercentageNo() {
		return percentageNo;
	}
	public void setPercentageNo(String percentageNo) {
		this.percentageNo = percentageNo;
	}
	public Timestamp getLastCheckDate() {
		return lastCheckDate;
	}
	public void setLastCheckDate(Timestamp lastCheckDate) {
		this.lastCheckDate = lastCheckDate;
	}
	
}
