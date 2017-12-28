package nta.med.data.model.ihis.system;

import java.math.BigDecimal;
import java.sql.Timestamp;
/**
 * The persistent class for the DRUG_DOSAGE database table.
 * 
 */

public class DrugDosageInfo implements DrugKinkiInterface  {

	private String a12;

	private String a13;

	private Integer a4;

	private Integer a5;

	private String a8;

	private BigDecimal activeFlg;

	private String adaptation;

	private String adaptationRelated;

	private String ageClassification;

	private String appropriate;

	private String appropriateCondition;

	private String branchNumber;

	private Timestamp created;

	private String dosageBranchNumber;

	private String drugId;

	private String oneDose;

	private String sysId;

	private String updId;

	private Timestamp updated;
	
	public String convertToRowCsv(){
		
		StringBuilder rowCsv = new StringBuilder();
		rowCsv.append(drugId);
		rowCsv.append(",");
		rowCsv.append(branchNumber);
		rowCsv.append(",");
		rowCsv.append(dosageBranchNumber);
		rowCsv.append(",");
		rowCsv.append(a4);
		rowCsv.append(",");
		rowCsv.append(a5);
		rowCsv.append(",");
		rowCsv.append(adaptation);
		rowCsv.append(",");
		rowCsv.append(adaptationRelated);
		rowCsv.append(",");
		rowCsv.append(a8);
		rowCsv.append(",");
		rowCsv.append(ageClassification);
		rowCsv.append(",");
		rowCsv.append(appropriate);
		rowCsv.append(",");
		rowCsv.append(appropriateCondition);
		rowCsv.append(",");
		rowCsv.append(a12);
		rowCsv.append(",");
		rowCsv.append(a13);
		rowCsv.append(",");
		rowCsv.append(oneDose);
		
		return rowCsv.toString();
	}

	@Override
	public String[] convertItemToArray() {
		return (new String[]{drugId, branchNumber, dosageBranchNumber, String.valueOf(a4), String.valueOf(a5),
				adaptation, adaptationRelated, a8, ageClassification, appropriate, appropriateCondition,
				a12, a13, oneDose});

	}

	public DrugDosageInfo() {
	}

	public String getA12() {
		return this.a12;
	}

	public void setA12(String a12) {
		this.a12 = a12;
	}

	public String getA13() {
		return this.a13;
	}

	public void setA13(String a13) {
		this.a13 = a13;
	}

	public Integer getA4() {
		return this.a4;
	}

	public void setA4(Integer a4) {
		this.a4 = a4;
	}

	public Integer getA5() {
		return this.a5;
	}

	public void setA5(Integer a5) {
		this.a5 = a5;
	}

	public String getA8() {
		return this.a8;
	}

	public void setA8(String a8) {
		this.a8 = a8;
	}

	
	public BigDecimal getActiveFlg() {
		return this.activeFlg;
	}

	public void setActiveFlg(BigDecimal activeFlg) {
		this.activeFlg = activeFlg;
	}

	public String getAdaptation() {
		return this.adaptation;
	}

	public void setAdaptation(String adaptation) {
		this.adaptation = adaptation;
	}

	
	public String getAdaptationRelated() {
		return this.adaptationRelated;
	}

	public void setAdaptationRelated(String adaptationRelated) {
		this.adaptationRelated = adaptationRelated;
	}

	
	public String getAgeClassification() {
		return this.ageClassification;
	}

	public void setAgeClassification(String ageClassification) {
		this.ageClassification = ageClassification;
	}

	public String getAppropriate() {
		return this.appropriate;
	}

	public void setAppropriate(String appropriate) {
		this.appropriate = appropriate;
	}

	
	public String getAppropriateCondition() {
		return this.appropriateCondition;
	}

	public void setAppropriateCondition(String appropriateCondition) {
		this.appropriateCondition = appropriateCondition;
	}

	
	public String getBranchNumber() {
		return this.branchNumber;
	}

	public void setBranchNumber(String branchNumber) {
		this.branchNumber = branchNumber;
	}

	public Timestamp getCreated() {
		return this.created;
	}

	public void setCreated(Timestamp created) {
		this.created = created;
	}

	
	public String getDosageBranchNumber() {
		return this.dosageBranchNumber;
	}

	public void setDosageBranchNumber(String dosageBranchNumber) {
		this.dosageBranchNumber = dosageBranchNumber;
	}

	
	public String getDrugId() {
		return this.drugId;
	}

	public void setDrugId(String drugId) {
		this.drugId = drugId;
	}

	
	public String getOneDose() {
		return this.oneDose;
	}

	public void setOneDose(String oneDose) {
		this.oneDose = oneDose;
	}

	
	public String getSysId() {
		return this.sysId;
	}

	public void setSysId(String sysId) {
		this.sysId = sysId;
	}

	
	public String getUpdId() {
		return this.updId;
	}

	public void setUpdId(String updId) {
		this.updId = updId;
	}

	public Timestamp getUpdated() {
		return this.updated;
	}

	public void setUpdated(Timestamp updated) {
		this.updated = updated;
	}

}