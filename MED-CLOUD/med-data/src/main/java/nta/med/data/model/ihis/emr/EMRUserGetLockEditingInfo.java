package nta.med.data.model.ihis.emr;

import java.math.BigDecimal;
import java.util.Date;

public class EMRUserGetLockEditingInfo {
	private BigDecimal lockFlg;
	private String updId;
	private Date updated;
	
	public EMRUserGetLockEditingInfo(BigDecimal lockFlg, String updId,
			Date updated) {
		super();
		this.lockFlg = lockFlg;
		this.updId = updId;
		this.updated = updated;
	}
	public BigDecimal getLockFlg() {
		return lockFlg;
	}
	public void setLockFlg(BigDecimal lockFlg) {
		this.lockFlg = lockFlg;
	}
	public String getUpdId() {
		return updId;
	}
	public void setUpdId(String updId) {
		this.updId = updId;
	}
	public Date getUpdated() {
		return updated;
	}
	public void setUpdated(Date updated) {
		this.updated = updated;
	}
	
	
}
