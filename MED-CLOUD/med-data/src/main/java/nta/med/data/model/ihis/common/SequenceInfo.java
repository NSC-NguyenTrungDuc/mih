package nta.med.data.model.ihis.common;

import java.math.BigDecimal;
import java.math.BigInteger;

public class SequenceInfo {
	private BigDecimal nextSeq;
	private BigInteger limitSeq;
	private String overLoad;
	public SequenceInfo(BigDecimal nextSeq, BigInteger limitSeq, String overLoad) {
		super();
		this.nextSeq = nextSeq;
		this.limitSeq = limitSeq;
		this.overLoad = overLoad;
	}
	public BigDecimal getNextSeq() {
		return nextSeq;
	}
	public void setNextSeq(BigDecimal nextSeq) {
		this.nextSeq = nextSeq;
	}
	public BigInteger getLimitSeq() {
		return limitSeq;
	}
	public void setLimitSeq(BigInteger limitSeq) {
		this.limitSeq = limitSeq;
	}
	public String getOverLoad() {
		return overLoad;
	}
	public void setOverLoad(String overLoad) {
		this.overLoad = overLoad;
	}

}
