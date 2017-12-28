package nta.med.data.model.cms;

import java.math.BigInteger;

public class CmsQuestionInfo {

	private BigInteger id;
	private String questionType;
	private String departmentCode;
	private String departmentName;
	private String content;

	public CmsQuestionInfo(BigInteger id, String questionType, String departmentCode, String departmentName,
			String content) {
		super();
		this.id = id;
		this.questionType = questionType;
		this.departmentCode = departmentCode;
		this.departmentName = departmentName;
		this.content = content;
	}

	public BigInteger getId() {
		return id;
	}

	public void setId(BigInteger id) {
		this.id = id;
	}

	public String getQuestionType() {
		return questionType;
	}

	public void setQuestionType(String questionType) {
		this.questionType = questionType;
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

	public String getContent() {
		return content;
	}

	public void setContent(String content) {
		this.content = content;
	}

}
