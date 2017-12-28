package nta.med.data.model.ihis.clis;

public class CLIS2015U03ProtocolListInfo {
	private Integer clisProtocolId ;
	private String protocolCode    ;
	private String protocolName    ;
	public CLIS2015U03ProtocolListInfo(Integer clisProtocolId,
			String protocolCode, String protocolName) {
		super();
		this.clisProtocolId = clisProtocolId;
		this.protocolCode = protocolCode;
		this.protocolName = protocolName;
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
}
