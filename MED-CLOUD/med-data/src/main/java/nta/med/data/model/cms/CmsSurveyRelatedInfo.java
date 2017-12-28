package nta.med.data.model.cms;

import java.math.BigInteger;

public class CmsSurveyRelatedInfo {
	
	private String departmentCode;
	private String departmentName;
	private BigInteger id;
	private String answerDate;
	
	public CmsSurveyRelatedInfo(String departmentCode, String departmentName, BigInteger id, String answerDate) {
		super();
		this.departmentCode = departmentCode;
		this.departmentName = departmentName;
		this.id = id;
		this.answerDate = answerDate;
	}
	
	public String getDepartmentCode() {
		return departmentCode;
	}
	public void setDepartmentCode(String departmentCode) {
		this.departmentCode = departmentCode;
	}
	public String getDepartmentName() {
		return departmentName;
	}
	public void setDepartmentName(String departmentName) {
		this.departmentName = departmentName;
	}
	public BigInteger getId() {
		return id;
	}
	public void setId(BigInteger id) {
		this.id = id;
	}
	public String getAnswerDate() {
		return answerDate;
	}
	public void setAnswerDate(String answerDate) {
		this.answerDate = answerDate;
	}
	
	
	
}
