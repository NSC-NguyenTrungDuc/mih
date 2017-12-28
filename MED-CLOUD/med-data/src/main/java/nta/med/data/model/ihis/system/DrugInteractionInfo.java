package nta.med.data.model.ihis.system;

import java.math.BigDecimal;
import java.sql.Timestamp;

/**
 * @author DEV_HieuTT
 *
 */
public class DrugInteractionInfo implements DrugKinkiInterface {

	private Integer a11;

	private String a5;

	private String a6;

	private Integer a7;

	private Integer a8;

	private Integer a9;

	private BigDecimal activeFlg;

	private String branchNumber;

	private String comment;

	private Timestamp created;

	private Integer describedClassification;

	private String drugId;

	private Integer orderNote;

	private String sysId;

	private String updId;

	private Timestamp updated;

	private String yj9Code;

	
	public DrugInteractionInfo() {
		super();
	}

	public DrugInteractionInfo(Integer a11, String a5, String a6, Integer a7,
			Integer a8, Integer a9, BigDecimal activeFlg, String branchNumber,
			String comment, Timestamp created, Integer describedClassification,
			String drugId, Integer orderNote, String sysId, String updId,
			Timestamp updated, String yj9Code) {
		super();
		this.a11 = a11;
		this.a5 = a5;
		this.a6 = a6;
		this.a7 = a7;
		this.a8 = a8;
		this.a9 = a9;
		this.activeFlg = activeFlg;
		this.branchNumber = branchNumber;
		this.comment = comment;
		this.created = created;
		this.describedClassification = describedClassification;
		this.drugId = drugId;
		this.orderNote = orderNote;
		this.sysId = sysId;
		this.updId = updId;
		this.updated = updated;
		this.yj9Code = yj9Code;
	}

	public Integer getA11() {
		return a11;
	}

	public void setA11(Integer a11) {
		this.a11 = a11;
	}

	public String getA5() {
		return a5;
	}

	public void setA5(String a5) {
		this.a5 = a5;
	}

	public String getA6() {
		return a6;
	}

	public void setA6(String a6) {
		this.a6 = a6;
	}

	public Integer getA7() {
		return a7;
	}

	public void setA7(Integer a7) {
		this.a7 = a7;
	}

	public Integer getA8() {
		return a8;
	}

	public void setA8(Integer a8) {
		this.a8 = a8;
	}

	public Integer getA9() {
		return a9;
	}

	public void setA9(Integer a9) {
		this.a9 = a9;
	}

	public BigDecimal getActiveFlg() {
		return activeFlg;
	}

	public void setActiveFlg(BigDecimal activeFlg) {
		this.activeFlg = activeFlg;
	}

	public String getBranchNumber() {
		return branchNumber;
	}

	public void setBranchNumber(String branchNumber) {
		this.branchNumber = branchNumber;
	}

	public String getComment() {
		return comment;
	}

	public void setComment(String comment) {
		this.comment = comment;
	}

	public Timestamp getCreated() {
		return created;
	}

	public void setCreated(Timestamp created) {
		this.created = created;
	}

	public Integer getDescribedClassification() {
		return describedClassification;
	}

	public void setDescribedClassification(Integer describedClassification) {
		this.describedClassification = describedClassification;
	}

	public String getDrugId() {
		return drugId;
	}

	public void setDrugId(String drugId) {
		this.drugId = drugId;
	}

	public Integer getOrderNote() {
		return orderNote;
	}

	public void setOrderNote(Integer orderNote) {
		this.orderNote = orderNote;
	}

	public String getSysId() {
		return sysId;
	}

	public void setSysId(String sysId) {
		this.sysId = sysId;
	}

	public String getUpdId() {
		return updId;
	}

	public void setUpdId(String updId) {
		this.updId = updId;
	}

	public Timestamp getUpdated() {
		return updated;
	}

	public void setUpdated(Timestamp updated) {
		this.updated = updated;
	}

	public String getYj9Code() {
		return yj9Code;
	}

	public void setYj9Code(String yj9Code) {
		this.yj9Code = yj9Code;
	}

	public String convertToRowCsv() {
		StringBuilder rowCsv = new StringBuilder();
		rowCsv.append(drugId);
		rowCsv.append(",");
		rowCsv.append(branchNumber);
		rowCsv.append(",");
		rowCsv.append(yj9Code);
		rowCsv.append(",");
		rowCsv.append(describedClassification);
		rowCsv.append(",");
		rowCsv.append(a5);
		rowCsv.append(",");
		rowCsv.append(a6);
		rowCsv.append(",");
		rowCsv.append(a7);
		rowCsv.append(",");
		rowCsv.append(a8);
		rowCsv.append(",");
		rowCsv.append(a9);
		rowCsv.append(",");
		rowCsv.append(orderNote);
		rowCsv.append(",");
		rowCsv.append(a11);
		rowCsv.append(",");
		rowCsv.append(comment);

		return rowCsv.toString();
	}

	@Override
	public String[] convertItemToArray() {
		return (new String[]{drugId, branchNumber, yj9Code, String.valueOf(describedClassification), a5, a6,
				String.valueOf(a7), String.valueOf(a8), String.valueOf(a9), String.valueOf(orderNote), String.valueOf(a11), comment});
	}

}
