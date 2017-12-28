package nta.med.data.model.ihis.system;

public class LoadOftenUsedResponseInfo {
	private String memb;
	private String slipCode;
	private String slipName;
	private String hangmogCode;
	private String hangmogName;
	private Double seq;
	private String hospCode;
	private String membGubun;
	private String wonnaeDrgYn;
	private String orderByKey;
	public LoadOftenUsedResponseInfo(String memb, String slipCode,
			String slipName, String hangmogCode, String hangmogName,
			Double seq, String hospCode, String membGubun, String wonnaeDrgYn,
			String orderByKey) {
		super();
		this.memb = memb;
		this.slipCode = slipCode;
		this.slipName = slipName;
		this.hangmogCode = hangmogCode;
		this.hangmogName = hangmogName;
		this.seq = seq;
		this.hospCode = hospCode;
		this.membGubun = membGubun;
		this.wonnaeDrgYn = wonnaeDrgYn;
		this.orderByKey = orderByKey;
	}
	public String getMemb() {
		return memb;
	}
	public void setMemb(String memb) {
		this.memb = memb;
	}
	public String getSlipCode() {
		return slipCode;
	}
	public void setSlipCode(String slipCode) {
		this.slipCode = slipCode;
	}
	public String getSlipName() {
		return slipName;
	}
	public void setSlipName(String slipName) {
		this.slipName = slipName;
	}
	public String getHangmogCode() {
		return hangmogCode;
	}
	public void setHangmogCode(String hangmogCode) {
		this.hangmogCode = hangmogCode;
	}
	public String getHangmogName() {
		return hangmogName;
	}
	public void setHangmogName(String hangmogName) {
		this.hangmogName = hangmogName;
	}
	public Double getSeq() {
		return seq;
	}
	public void setSeq(Double seq) {
		this.seq = seq;
	}
	public String getHospCode() {
		return hospCode;
	}
	public void setHospCode(String hospCode) {
		this.hospCode = hospCode;
	}
	public String getMembGubun() {
		return membGubun;
	}
	public void setMembGubun(String membGubun) {
		this.membGubun = membGubun;
	}
	public String getWonnaeDrgYn() {
		return wonnaeDrgYn;
	}
	public void setWonnaeDrgYn(String wonnaeDrgYn) {
		this.wonnaeDrgYn = wonnaeDrgYn;
	}
	public String getOrderByKey() {
		return orderByKey;
	}
	public void setOrderByKey(String orderByKey) {
		this.orderByKey = orderByKey;
	}
}
