package nta.med.data.model.ihis.clis;


public class CLIS2015U02GrdStatusInfo {
	  private Integer protocolId;
      private Integer statusId;
      private String statusCode;
      private String statusName;
      private Integer sortNo;
      private String displayFlg;
	public CLIS2015U02GrdStatusInfo(Integer protocolId, Integer statusId,
			String statusCode, String statusName, Integer sortNo,
			String displayFlg) {
		super();
		this.protocolId = protocolId;
		this.statusId = statusId;
		this.statusCode = statusCode;
		this.statusName = statusName;
		this.sortNo = sortNo;
		this.displayFlg = displayFlg;
	}
	public Integer getProtocolId() {
		return protocolId;
	}
	public void setProtocolId(Integer protocolId) {
		this.protocolId = protocolId;
	}
	public Integer getStatusId() {
		return statusId;
	}
	public void setStatusId(Integer statusId) {
		this.statusId = statusId;
	}
	public String getStatusCode() {
		return statusCode;
	}
	public void setStatusCode(String statusCode) {
		this.statusCode = statusCode;
	}
	public String getStatusName() {
		return statusName;
	}
	public void setStatusName(String statusName) {
		this.statusName = statusName;
	}
	public Integer getSortNo() {
		return sortNo;
	}
	public void setSortNo(Integer sortNo) {
		this.sortNo = sortNo;
	}
	public String getDisplayFlg() {
		return displayFlg;
	}
	public void setDisplayFlg(String displayFlg) {
		this.displayFlg = displayFlg;
	}
}
