package nta.med.data.model.ihis.inps;

public class PrInpMakePkinp1002 {
	private String pkinp1002;
	private Integer seq;
	private String err;
	public PrInpMakePkinp1002(String pkinp1002, Integer seq, String err) {
		super();
		this.pkinp1002 = pkinp1002;
		this.seq = seq;
		this.err = err;
	}
	public String getPkinp1002() {
		return pkinp1002;
	}
	public void setPkinp1002(String pkinp1002) {
		this.pkinp1002 = pkinp1002;
	}
	public Integer getSeq() {
		return seq;
	}
	public void setSeq(Integer seq) {
		this.seq = seq;
	}
	public String getErr() {
		return err;
	}
	public void setErr(String err) {
		this.err = err;
	}
	
}
