package nta.med.data.model.ihis.system;

public class PrAdmMessageCallOutputInfo {
	private String errFlag;
	private Integer tSendSeq;
	public PrAdmMessageCallOutputInfo(String errFlag, Integer tSendSeq) {
		super();
		this.errFlag = errFlag;
		this.tSendSeq = tSendSeq;
	}
	public String getErrFlag() {
		return errFlag;
	}
	public void setErrFlag(String errFlag) {
		this.errFlag = errFlag;
	}
	public Integer gettSendSeq() {
		return tSendSeq;
	}
	public void settSendSeq(Integer tSendSeq) {
		this.tSendSeq = tSendSeq;
	}
}
