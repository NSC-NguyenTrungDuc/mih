package nta.med.data.model.ihis.phys;

import java.math.BigInteger;

public class PHY2001U04RefreshCounterInfo {
	private BigInteger g1 ;
	private BigInteger g2;
	private BigInteger sa;
	private BigInteger re;
	public PHY2001U04RefreshCounterInfo(BigInteger g1, BigInteger g2,
			BigInteger sa, BigInteger re) {
		super();
		this.g1 = g1;
		this.g2 = g2;
		this.sa = sa;
		this.re = re;
	}
	public BigInteger getG1() {
		return g1;
	}
	public void setG1(BigInteger g1) {
		this.g1 = g1;
	}
	public BigInteger getG2() {
		return g2;
	}
	public void setG2(BigInteger g2) {
		this.g2 = g2;
	}
	public BigInteger getSa() {
		return sa;
	}
	public void setSa(BigInteger sa) {
		this.sa = sa;
	}
	public BigInteger getRe() {
		return re;
	}
	public void setRe(BigInteger re) {
		this.re = re;
	}
	
}
