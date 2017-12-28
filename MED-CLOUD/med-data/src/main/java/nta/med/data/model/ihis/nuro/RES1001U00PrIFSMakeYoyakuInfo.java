package nta.med.data.model.ihis.nuro;

public class RES1001U00PrIFSMakeYoyakuInfo {
	private Double pkifs1002;
	private String errMsg;
	public RES1001U00PrIFSMakeYoyakuInfo(Double pkifs1002, String errMsg) {
		super();
		this.pkifs1002 = pkifs1002;
		this.errMsg = errMsg;
	}
	public Double getPkifs1002() {
		return pkifs1002;
	}
	public void setPkifs1002(Double pkifs1002) {
		this.pkifs1002 = pkifs1002;
	}
	public String getErrMsg() {
		return errMsg;
	}
	public void setErrMsg(String errMsg) {
		this.errMsg = errMsg;
	}
	
}	
