package nta.med.data.model.ihis.system;

import java.math.BigDecimal;
import java.sql.Timestamp;


/**
 * The persistent class for the DRUG_GENERIC_NAME database table.
 * 
 */



public class DrugGenericNameInfo implements DrugKinkiInterface {

	private String a6;

	private Integer a8;

	private BigDecimal activeFlg;

	private String branchNumber;

	private String comment1;

	private String comment2;

	private Timestamp created;

	private Integer describedClassification;

	private String drugId;

	private Integer orderNote;

	private String sysId;

	private String updId;

	private Timestamp updated;

	private String yj9Code;

	private String yj9CodeEffect;
	
	public String convertToRowCsv(){
		
		StringBuilder rowCsv = new StringBuilder();
		rowCsv.append(drugId);
		rowCsv.append(",");
		rowCsv.append(branchNumber);
		rowCsv.append(",");
		rowCsv.append(yj9Code);
		rowCsv.append(",");
		rowCsv.append(describedClassification);
		rowCsv.append(",");
		rowCsv.append(orderNote);
		rowCsv.append(",");
		rowCsv.append(a6);
		rowCsv.append(",");
		rowCsv.append(yj9CodeEffect);
		rowCsv.append(",");
		rowCsv.append(a8);
		rowCsv.append(",");
		rowCsv.append(comment1);
		rowCsv.append(",");
		rowCsv.append(comment2);
		
		return rowCsv.toString();
	}

	@Override
	public String[] convertItemToArray() {
		return (new String[]{drugId, branchNumber, yj9Code, String.valueOf(describedClassification), String.valueOf(orderNote),
				a6, yj9CodeEffect, String.valueOf(a8), comment1, comment2});
	}

	public DrugGenericNameInfo() {
	}

	public String getA6() {
		return this.a6;
	}

	public void setA6(String a6) {
		this.a6 = a6;
	}

	public Integer getA8() {
		return this.a8;
	}

	public void setA8(Integer a8) {
		this.a8 = a8;
	}

	
	public BigDecimal getActiveFlg() {
		return this.activeFlg;
	}

	public void setActiveFlg(BigDecimal activeFlg) {
		this.activeFlg = activeFlg;
	}

	
	public String getBranchNumber() {
		return this.branchNumber;
	}

	public void setBranchNumber(String branchNumber) {
		this.branchNumber = branchNumber;
	}

	public String getComment1() {
		return this.comment1;
	}

	public void setComment1(String comment1) {
		this.comment1 = comment1;
	}

	public String getComment2() {
		return this.comment2;
	}

	public void setComment2(String comment2) {
		this.comment2 = comment2;
	}

	public Timestamp getCreated() {
		return this.created;
	}

	public void setCreated(Timestamp created) {
		this.created = created;
	}

	
	public Integer getDescribedClassification() {
		return this.describedClassification;
	}

	public void setDescribedClassification(Integer describedClassification) {
		this.describedClassification = describedClassification;
	}

	
	public String getDrugId() {
		return this.drugId;
	}

	public void setDrugId(String drugId) {
		this.drugId = drugId;
	}

	
	public Integer getOrderNote() {
		return this.orderNote;
	}

	public void setOrderNote(Integer orderNote) {
		this.orderNote = orderNote;
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

	
	public String getYj9Code() {
		return this.yj9Code;
	}

	public void setYj9Code(String yj9Code) {
		this.yj9Code = yj9Code;
	}

	
	public String getYj9CodeEffect() {
		return this.yj9CodeEffect;
	}

	public void setYj9CodeEffect(String yj9CodeEffect) {
		this.yj9CodeEffect = yj9CodeEffect;
	}

}