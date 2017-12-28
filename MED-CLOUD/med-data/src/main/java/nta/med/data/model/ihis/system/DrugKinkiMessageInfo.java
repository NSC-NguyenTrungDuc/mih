package nta.med.data.model.ihis.system;

import java.math.BigDecimal;

public class DrugKinkiMessageInfo implements DrugKinkiInterface   {
	private String drugId ;
	
	private String branchNumber ;
	private BigDecimal warningLevel ;
	private String kinkiId ;
	private String message ;
	private String category ;
	public DrugKinkiMessageInfo(String drugId, String branchNumber,
			BigDecimal warningLevel, String kinkiId, String message, String category) {
		super();
		this.drugId = drugId;
		this.branchNumber = branchNumber;
		this.warningLevel = warningLevel;
		this.kinkiId = kinkiId;
		this.message = message;
		this.category = category;
	}
	public String getDrugId() {
		return drugId;
	}
	public void setDrugId(String drugId) {
		this.drugId = drugId;
	}
	public String getBranchNumber() {
		return branchNumber;
	}
	public void setBranchNumber(String branchNumber) {
		this.branchNumber = branchNumber;
	}
	public BigDecimal getWarningLevel() {
		return warningLevel;
	}
	public void setWarningLevel(BigDecimal warningLevel) {
		this.warningLevel = warningLevel;
	}
	public String getKinkiId() {
		return kinkiId;
	}
	public void setKinkiId(String kinkiId) {
		this.kinkiId = kinkiId;
	}
	public String getMessage() {
		return message;
	}
	public void setMessage(String message) {
		this.message = message;
	}
	public String getCategory() {
		return category;
	}
	public void setCategory(String category) {
		this.category = category;
	}
	public String convertToRowCsv() {
		StringBuilder rowCsv = new StringBuilder();
		rowCsv.append(drugId );
		rowCsv.append(",");
		rowCsv.append(branchNumber);
		rowCsv.append(",");
		rowCsv.append(warningLevel);
		rowCsv.append(",");
		rowCsv.append(kinkiId);
		rowCsv.append(",");
		rowCsv.append(message);
		rowCsv.append(",");
		rowCsv.append(category);

		return rowCsv.toString();
	}

	@Override
	public String[] convertItemToArray() {
		return (new String[]{drugId, branchNumber, String.valueOf(warningLevel), kinkiId, message, category});
	}
}
