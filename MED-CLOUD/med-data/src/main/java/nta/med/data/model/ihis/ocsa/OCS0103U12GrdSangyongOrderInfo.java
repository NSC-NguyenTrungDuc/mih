package nta.med.data.model.ihis.ocsa;

import java.math.BigInteger;

public class OCS0103U12GrdSangyongOrderInfo {
	private String slipCode;
	private String slipName;
	private String hangmogCode;
	private String hangmogName;
	private String seq;
	private String hospCode;
	private String memb;
	private String membGubun;
	private String wonnaeDrgYn;
	private String trialFlag;
	private BigInteger rownum;
	public OCS0103U12GrdSangyongOrderInfo(String slipCode, String slipName, String hangmogCode, String hangmogName,
			String seq, String hospCode, String memb, String membGubun, String wonnaeDrgYn, String trialFlag,
			BigInteger rownum) {
		super();
		this.slipCode = slipCode;
		this.slipName = slipName;
		this.hangmogCode = hangmogCode;
		this.hangmogName = hangmogName;
		this.seq = seq;
		this.hospCode = hospCode;
		this.memb = memb;
		this.membGubun = membGubun;
		this.wonnaeDrgYn = wonnaeDrgYn;
		this.trialFlag = trialFlag;
		this.rownum = rownum;
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
	public String getSeq() {
		return seq;
	}
	public void setSeq(String seq) {
		this.seq = seq;
	}
	public String getHospCode() {
		return hospCode;
	}
	public void setHospCode(String hospCode) {
		this.hospCode = hospCode;
	}
	public String getMemb() {
		return memb;
	}
	public void setMemb(String memb) {
		this.memb = memb;
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
	public String getTrialFlag() {
		return trialFlag;
	}
	public void setTrialFlag(String trialFlag) {
		this.trialFlag = trialFlag;
	}
	public BigInteger getRownum() {
		return rownum;
	}
	public void setRownum(BigInteger rownum) {
		this.rownum = rownum;
	}
	
}
