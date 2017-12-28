package nta.med.data.model.ihis.nuri;

import java.math.BigInteger;

public class NUR1020Q00layNUR7002Info {

	private Double fkinp1001;
	private BigInteger diff;
	private String hangmogGubun;
	private String hangmogSeq;
	private String hangmogValue;

	public NUR1020Q00layNUR7002Info(Double fkinp1001, BigInteger diff, String hangmogGubun, String hangmogSeq,
			String hangmogValue) {
		super();
		this.fkinp1001 = fkinp1001;
		this.diff = diff;
		this.hangmogGubun = hangmogGubun;
		this.hangmogSeq = hangmogSeq;
		this.hangmogValue = hangmogValue;
	}

	public Double getFkinp1001() {
		return fkinp1001;
	}

	public void setFkinp1001(Double fkinp1001) {
		this.fkinp1001 = fkinp1001;
	}

	public BigInteger getDiff() {
		return diff;
	}

	public void setDiff(BigInteger diff) {
		this.diff = diff;
	}

	public String getHangmogGubun() {
		return hangmogGubun;
	}

	public void setHangmogGubun(String hangmogGubun) {
		this.hangmogGubun = hangmogGubun;
	}

	public String getHangmogSeq() {
		return hangmogSeq;
	}

	public void setHangmogSeq(String hangmogSeq) {
		this.hangmogSeq = hangmogSeq;
	}

	public String getHangmogValue() {
		return hangmogValue;
	}

	public void setHangmogValue(String hangmogValue) {
		this.hangmogValue = hangmogValue;
	}

}
