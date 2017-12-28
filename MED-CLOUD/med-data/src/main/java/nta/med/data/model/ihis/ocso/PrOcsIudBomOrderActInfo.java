package nta.med.data.model.ihis.ocso;

public class PrOcsIudBomOrderActInfo {
	private String ioErr ;
	private String ioErrMsg ;
	private Double ioPkocs2003 ;
	public PrOcsIudBomOrderActInfo(){
		
	}
	public PrOcsIudBomOrderActInfo(String ioErr, String ioErrMsg,
			Double ioPkocs2003) {
		super();
		this.ioErr = ioErr;
		this.ioErrMsg = ioErrMsg;
		this.ioPkocs2003 = ioPkocs2003;
	}
	public String getIoErr() {
		return ioErr;
	}
	public void setIoErr(String ioErr) {
		this.ioErr = ioErr;
	}
	public String getIoErrMsg() {
		return ioErrMsg;
	}
	public void setIoErrMsg(String ioErrMsg) {
		this.ioErrMsg = ioErrMsg;
	}
	public Double getIoPkocs2003() {
		return ioPkocs2003;
	}
	public void setIoPkocs2003(Double ioPkocs2003) {
		this.ioPkocs2003 = ioPkocs2003;
	}
	

}
