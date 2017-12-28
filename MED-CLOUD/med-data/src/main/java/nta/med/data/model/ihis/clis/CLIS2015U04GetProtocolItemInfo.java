/**
 * 
 */
package nta.med.data.model.ihis.clis;

import java.util.Date;

public class CLIS2015U04GetProtocolItemInfo {
	private Integer clisProtocolId ;
	private String protocolCode    ;
	private String protocolName    ;
	private Date startDate;
	private Date endDate;
	public CLIS2015U04GetProtocolItemInfo(Integer clisProtocolId,
			String protocolCode, String protocolName, Date startDate, Date endDate) {
		super();
		this.clisProtocolId = clisProtocolId;
		this.protocolCode = protocolCode;
		this.protocolName = protocolName;
		this.startDate = startDate;
		this.endDate = endDate;
	}

	public Integer getClisProtocolId() {
		return clisProtocolId;
	}
	public void setClisProtocolId(Integer clisProtocolId) {
		this.clisProtocolId = clisProtocolId;
	}
	public String getProtocolCode() {
		return protocolCode;
	}
	public void setProtocolCode(String protocolCode) {
		this.protocolCode = protocolCode;
	}
	public String getProtocolName() {
		return protocolName;
	}
	public void setProtocolName(String protocolName) {
		this.protocolName = protocolName;
	}
	public Date getStartDate() {
		return startDate;
	}
	public void setStartDate(Date startDate) {
		this.startDate = startDate;
	}
	public Date getEndDate() {
		return endDate;
	}
	public void setEndDate(Date endDate) {
		this.endDate = endDate;
	}
}
