package nta.med.data.model.ihis.clis;

import java.util.Date;

public class CLIS2015U02GrdProtocolInfo {
	private Integer protocolId;
    private String protocolCode;
    private String protocolName;
    private Date fromDate;
    private Date toDate;
    private String protocolStatus;
    private String description;
    private String resource;
	public CLIS2015U02GrdProtocolInfo(Integer protocolId, String protocolCode,
			String protocolName, Date fromDate, Date toDate,
			String protocolStatus, String description, String resource) {
		super();
		this.protocolId = protocolId;
		this.protocolCode = protocolCode;
		this.protocolName = protocolName;
		this.fromDate = fromDate;
		this.toDate = toDate;
		this.protocolStatus = protocolStatus;
		this.description = description;
		this.resource = resource;
	}
	public Integer getProtocolId() {
		return protocolId;
	}
	public void setProtocolId(Integer protocolId) {
		this.protocolId = protocolId;
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
	public Date getFromDate() {
		return fromDate;
	}
	public void setFromDate(Date fromDate) {
		this.fromDate = fromDate;
	}
	public Date getToDate() {
		return toDate;
	}
	public void setToDate(Date toDate) {
		this.toDate = toDate;
	}
	public String getProtocolStatus() {
		return protocolStatus;
	}
	public void setProtocolStatus(String protocolStatus) {
		this.protocolStatus = protocolStatus;
	}
	public String getDescription() {
		return description;
	}
	public void setDescription(String description) {
		this.description = description;
	}
	public String getResource() {
		return resource;
	}
	public void setResource(String resource) {
		this.resource = resource;
	}
}
