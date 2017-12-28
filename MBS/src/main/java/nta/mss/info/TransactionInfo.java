package nta.mss.info;

import java.math.BigDecimal;
import java.sql.Timestamp;

public class TransactionInfo {
	
	private String accessId;
	private String accessPass;
	private BigDecimal amount;
	private Integer id;
	private BigDecimal status;
	private String orderId;
	private Timestamp executeDateTime;
	
	public TransactionInfo(String accessId, String accessPass, BigDecimal amount, Integer id, BigDecimal status,
			String orderId, Timestamp executeDateTime) {
		super();
		this.accessId = accessId;
		this.accessPass = accessPass;
		this.amount = amount;
		this.id = id;
		this.status = status;
		this.orderId = orderId;
		this.executeDateTime = executeDateTime;
	}

	public String getAccessId() {
		return accessId;
	}
	public void setAccessId(String accessId) {
		this.accessId = accessId;
	}
	public String getAccessPass() {
		return accessPass;
	}
	public void setAccessPass(String accessPass) {
		this.accessPass = accessPass;
	}
	public BigDecimal getAmount() {
		return amount;
	}
	public void setAmount(BigDecimal amount) {
		this.amount = amount;
	}

	public Integer getId() {
		return id;
	}

	public void setId(Integer id) {
		this.id = id;
	}

	public BigDecimal getStatus() {
		return status;
	}

	public void setStatus(BigDecimal status) {
		this.status = status;
	}

	public String getOrderId() {
		return orderId;
	}

	public void setOrderId(String orderId) {
		this.orderId = orderId;
	}

	public Timestamp getExecuteDateTime() {
		return executeDateTime;
	}

	public void setExecuteDateTime(Timestamp executeDateTime) {
		this.executeDateTime = executeDateTime;
	}
	
}
