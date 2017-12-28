package nta.med.data.model.ihis.bill;

import java.math.BigDecimal;
import java.util.Date;

public class BIL2016R01GrdReportInfo {
	private String serviceId;
	private String serviceName;
	private String executeDept;
	private String executeDoctor;
	private String assignDept;
	private String assignDoctor;
	private Date actingDate;
	private String quantity;
	private BigDecimal sum;
	private BigDecimal discount;
	public BIL2016R01GrdReportInfo(String serviceId, String serviceName, String executeDept, String executeDoctor,
			String assignDept, String assignDoctor, Date actingDate, String quantity, BigDecimal sum,
			BigDecimal discount) {
		super();
		this.serviceId = serviceId;
		this.serviceName = serviceName;
		this.executeDept = executeDept;
		this.executeDoctor = executeDoctor;
		this.assignDept = assignDept;
		this.assignDoctor = assignDoctor;
		this.actingDate = actingDate;
		this.quantity = quantity;
		this.sum = sum;
		this.discount = discount;
	}
	public String getServiceId() {
		return serviceId;
	}
	public void setServiceId(String serviceId) {
		this.serviceId = serviceId;
	}
	public String getServiceName() {
		return serviceName;
	}
	public void setServiceName(String serviceName) {
		this.serviceName = serviceName;
	}
	public String getExecuteDept() {
		return executeDept;
	}
	public void setExecuteDept(String executeDept) {
		this.executeDept = executeDept;
	}
	public String getExecuteDoctor() {
		return executeDoctor;
	}
	public void setExecuteDoctor(String executeDoctor) {
		this.executeDoctor = executeDoctor;
	}
	public String getAssignDept() {
		return assignDept;
	}
	public void setAssignDept(String assignDept) {
		this.assignDept = assignDept;
	}
	public String getAssignDoctor() {
		return assignDoctor;
	}
	public void setAssignDoctor(String assignDoctor) {
		this.assignDoctor = assignDoctor;
	}
	public Date getActingDate() {
		return actingDate;
	}
	public void setActingDate(Date actingDate) {
		this.actingDate = actingDate;
	}
	public String getQuantity() {
		return quantity;
	}
	public void setQuantity(String quantity) {
		this.quantity = quantity;
	}
	public BigDecimal getSum() {
		return sum;
	}
	public void setSum(BigDecimal sum) {
		this.sum = sum;
	}
	public BigDecimal getDiscount() {
		return discount;
	}
	public void setDiscount(BigDecimal discount) {
		this.discount = discount;
	}
	
}
