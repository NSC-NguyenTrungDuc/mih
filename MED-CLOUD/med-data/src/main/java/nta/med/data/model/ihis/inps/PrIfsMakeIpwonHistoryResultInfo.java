package nta.med.data.model.ihis.inps;

public class PrIfsMakeIpwonHistoryResultInfo {

	private Integer pkifs3011;
	private String err;

	public PrIfsMakeIpwonHistoryResultInfo(Integer pkifs3011, String err) {
		super();
		this.pkifs3011 = pkifs3011;
		this.err = err;
	}

	public Integer getPkifs3011() {
		return pkifs3011;
	}

	public void setPkifs3011(Integer pkifs3011) {
		this.pkifs3011 = pkifs3011;
	}

	public String getErr() {
		return err;
	}

	public void setErr(String err) {
		this.err = err;
	}

}
