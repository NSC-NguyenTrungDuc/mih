package nta.med.ext.cms.model.cms;

import java.math.BigDecimal;
import java.math.BigInteger;

import com.fasterxml.jackson.annotation.JsonProperty;

//cms 13
public class SurveyPatientStatusModel {
	@JsonProperty("department_code")
	private String departmentCode;

	@JsonProperty("name")
	private String departmentName;

	@JsonProperty("total")
	private BigInteger total = new BigInteger("0");

	@JsonProperty("answer")
	private BigDecimal totalAnswered = new BigDecimal(0);

	@JsonProperty("waiting")
	private BigDecimal totalWaiting = new BigDecimal(0);
	
	public SurveyPatientStatusModel(){}

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

	public BigInteger getTotal() {
		return total;
	}

	public void setTotal(BigInteger total) {
		this.total = total;
	}

	public BigDecimal getTotalAnswered() {
		return totalAnswered;
	}

	public void setTotalAnswered(BigDecimal totalAnswered) {
		this.totalAnswered = totalAnswered;
	}

	public BigDecimal getTotalWaiting() {
		return totalWaiting;
	}

	public void setTotalWaiting(BigDecimal totalWaiting) {
		this.totalWaiting = totalWaiting;
	}

}
