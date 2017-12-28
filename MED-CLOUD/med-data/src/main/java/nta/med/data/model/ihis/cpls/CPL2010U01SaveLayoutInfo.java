package nta.med.data.model.ihis.cpls;

public class CPL2010U01SaveLayoutInfo {
	private boolean saveResult;
	private int jubsuCnt;
	private int cancelCnt;
	private String oFlag;
	private String msg;

	public CPL2010U01SaveLayoutInfo() {
		super();
	}

	public boolean isSaveResult() {
		return saveResult;
	}

	public void setSaveResult(boolean saveResult) {
		this.saveResult = saveResult;
	}

	public int getJubsuCnt() {
		return jubsuCnt;
	}

	public void setJubsuCnt(int jubsuCnt) {
		this.jubsuCnt = jubsuCnt;
	}

	public int getCancelCnt() {
		return cancelCnt;
	}

	public void setCancelCnt(int cancelCnt) {
		this.cancelCnt = cancelCnt;
	}

	public String getoFlag() {
		return oFlag;
	}

	public void setoFlag(String oFlag) {
		this.oFlag = oFlag;
	}

	public String getMsg() {
		return msg;
	}

	public void setMsg(String msg) {
		this.msg = msg;
	}

}
