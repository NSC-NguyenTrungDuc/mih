package nta.med.data.model.ihis.nuri;

public class NUR1020U00InputLockInfo {

	private String limitYn;
	private String limit;

	public NUR1020U00InputLockInfo(String limitYn, String limit) {
		super();
		this.limitYn = limitYn;
		this.limit = limit;
	}

	public String getLimitYn() {
		return limitYn;
	}

	public void setLimitYn(String limitYn) {
		this.limitYn = limitYn;
	}

	public String getLimit() {
		return limit;
	}

	public void setLimit(String limit) {
		this.limit = limit;
	}

}
