package nta.med.data.model.ihis.ocsa;

import java.math.BigInteger;

public class OCS0203U00GrdOcs0203P1Info {
	private String memb;
    private String slipCode;
    private BigInteger value999;
    private String nValue;
    private String hangmogCode;
    private String hangmogName;
    private String bulyongYn;
    private String newFlag;
	public OCS0203U00GrdOcs0203P1Info(String memb, String slipCode,
			BigInteger value999, String nValue, String hangmogCode,
			String hangmogName, String bulyongYn, String newFlag) {
		super();
		this.memb = memb;
		this.slipCode = slipCode;
		this.value999 = value999;
		this.nValue = nValue;
		this.hangmogCode = hangmogCode;
		this.hangmogName = hangmogName;
		this.bulyongYn = bulyongYn;
		this.newFlag = newFlag;
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
	public BigInteger getValue999() {
		return value999;
	}
	public void setValue999(BigInteger value999) {
		this.value999 = value999;
	}
	public String getnValue() {
		return nValue;
	}
	public void setnValue(String nValue) {
		this.nValue = nValue;
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
	public String getBulyongYn() {
		return bulyongYn;
	}
	public void setBulyongYn(String bulyongYn) {
		this.bulyongYn = bulyongYn;
	}
	public String getNewFlag() {
		return newFlag;
	}
	public void setNewFlag(String newFlag) {
		this.newFlag = newFlag;
	}
}
