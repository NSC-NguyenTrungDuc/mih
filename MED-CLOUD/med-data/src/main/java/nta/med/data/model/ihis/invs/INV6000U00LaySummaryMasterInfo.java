package nta.med.data.model.ihis.invs;

import java.math.BigInteger;

public class INV6000U00LaySummaryMasterInfo {
	private String slipCode      ;
	private String slipName      ;
	private BigInteger drgCount      ;
	private String sougaku        ;
	private String magamDate     ;
	private String magamDonthJp ;
	public INV6000U00LaySummaryMasterInfo(String slipCode, String slipName, BigInteger drgCount, String sougaku,
			String magamDate, String magamDonthJp) {
		super();
		this.slipCode = slipCode;
		this.slipName = slipName;
		this.drgCount = drgCount;
		this.sougaku = sougaku;
		this.magamDate = magamDate;
		this.magamDonthJp = magamDonthJp;
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
	public BigInteger getDrgCount() {
		return drgCount;
	}
	public void setDrgCount(BigInteger drgCount) {
		this.drgCount = drgCount;
	}
	public String getSougaku() {
		return sougaku;
	}
	public void setSougaku(String sougaku) {
		this.sougaku = sougaku;
	}
	public String getMagamDate() {
		return magamDate;
	}
	public void setMagamDate(String magamDate) {
		this.magamDate = magamDate;
	}
	public String getMagamDonthJp() {
		return magamDonthJp;
	}
	public void setMagamDonthJp(String magamDonthJp) {
		this.magamDonthJp = magamDonthJp;
	}
	
}
