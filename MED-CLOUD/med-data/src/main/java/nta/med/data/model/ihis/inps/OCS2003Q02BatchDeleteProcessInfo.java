package nta.med.data.model.ihis.inps;

public class OCS2003Q02BatchDeleteProcessInfo {

	private Integer processedCount;
	private String err;

	public OCS2003Q02BatchDeleteProcessInfo(Integer processedCount, String err) {
		super();
		this.processedCount = processedCount;
		this.err = err;
	}

	public Integer getProcessedCount() {
		return processedCount;
	}

	public void setProcessedCount(Integer processedCount) {
		this.processedCount = processedCount;
	}

	public String getErr() {
		return err;
	}

	public void setErr(String err) {
		this.err = err;
	}

}
