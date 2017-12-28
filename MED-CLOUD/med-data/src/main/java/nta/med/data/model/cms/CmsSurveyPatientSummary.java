package nta.med.data.model.cms;

import java.math.BigDecimal;
import java.math.BigInteger;

public class CmsSurveyPatientSummary {

	private String departmentCode;
	private BigInteger total;
	private BigDecimal totalAnswered;
	private BigDecimal totalWaiting;

	public CmsSurveyPatientSummary(String departmentCode, BigInteger total,
			BigDecimal totalAnswered, BigDecimal totalWaiting) {
		super();
		this.departmentCode = departmentCode;
		this.total = total;
		this.totalAnswered = totalAnswered;
		this.totalWaiting = totalWaiting;
	}

	public String getDepartmentCode() {
		return departmentCode;
	}

	public void setDepartmentCode(String departmentCode) {
		this.departmentCode = departmentCode;
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

	public BigInteger getTotal() {
		return total;
	}

	public void setTotal(BigInteger total) {
		this.total = total;
	}
}
