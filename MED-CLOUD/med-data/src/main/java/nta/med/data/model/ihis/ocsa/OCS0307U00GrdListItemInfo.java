package nta.med.data.model.ihis.ocsa;

import java.math.BigInteger;

public class OCS0307U00GrdListItemInfo {
	private String sangCode;
	private String sangName;
	private BigInteger pkocs0307;
	public OCS0307U00GrdListItemInfo(String sangCode, String sangName, BigInteger pkocs0307) {
		super();
		this.sangCode = sangCode;
		this.sangName = sangName;
		this.pkocs0307 = pkocs0307;
	}
	public String getSangCode() {
		return sangCode;
	}
	public void setSangCode(String sangCode) {
		this.sangCode = sangCode;
	}
	public String getSangName() {
		return sangName;
	}
	public void setSangName(String sangName) {
		this.sangName = sangName;
	}
	public BigInteger getPkocs0307() {
		return pkocs0307;
	}
	public void setPkocs0307(BigInteger pkocs0307) {
		this.pkocs0307 = pkocs0307;
	}
	
}
