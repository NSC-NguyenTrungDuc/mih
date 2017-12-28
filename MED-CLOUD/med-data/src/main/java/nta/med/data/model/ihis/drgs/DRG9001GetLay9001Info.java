package nta.med.data.model.ihis.drgs;

import java.math.BigDecimal;
import java.math.BigInteger;

public class DRG9001GetLay9001Info {
	private String holiDay;
    private BigInteger drgCnt;
    private BigInteger drgGroupCnt;
    private BigDecimal drgHangmogCnt;
    private BigInteger injCnt;
    private BigInteger injGroupCnt;
    private BigDecimal injHangmogCnt;
    private BigInteger drgInjCnt;
    private BigInteger drgInjGroupCnt;
    private BigDecimal drgInjHangmogCnt;
	public DRG9001GetLay9001Info(String holiDay, BigInteger drgCnt,
			BigInteger drgGroupCnt, BigDecimal drgHangmogCnt,
			BigInteger injCnt, BigInteger injGroupCnt,
			BigDecimal injHangmogCnt, BigInteger drgInjCnt,
			BigInteger drgInjGroupCnt, BigDecimal drgInjHangmogCnt) {
		super();
		this.holiDay = holiDay;
		this.drgCnt = drgCnt;
		this.drgGroupCnt = drgGroupCnt;
		this.drgHangmogCnt = drgHangmogCnt;
		this.injCnt = injCnt;
		this.injGroupCnt = injGroupCnt;
		this.injHangmogCnt = injHangmogCnt;
		this.drgInjCnt = drgInjCnt;
		this.drgInjGroupCnt = drgInjGroupCnt;
		this.drgInjHangmogCnt = drgInjHangmogCnt;
	}
	public String getHoliDay() {
		return holiDay;
	}
	public void setHoliDay(String holiDay) {
		this.holiDay = holiDay;
	}
	public BigInteger getDrgCnt() {
		return drgCnt;
	}
	public void setDrgCnt(BigInteger drgCnt) {
		this.drgCnt = drgCnt;
	}
	public BigInteger getDrgGroupCnt() {
		return drgGroupCnt;
	}
	public void setDrgGroupCnt(BigInteger drgGroupCnt) {
		this.drgGroupCnt = drgGroupCnt;
	}
	public BigDecimal getDrgHangmogCnt() {
		return drgHangmogCnt;
	}
	public void setDrgHangmogCnt(BigDecimal drgHangmogCnt) {
		this.drgHangmogCnt = drgHangmogCnt;
	}
	public BigInteger getInjCnt() {
		return injCnt;
	}
	public void setInjCnt(BigInteger injCnt) {
		this.injCnt = injCnt;
	}
	public BigInteger getInjGroupCnt() {
		return injGroupCnt;
	}
	public void setInjGroupCnt(BigInteger injGroupCnt) {
		this.injGroupCnt = injGroupCnt;
	}
	public BigDecimal getInjHangmogCnt() {
		return injHangmogCnt;
	}
	public void setInjHangmogCnt(BigDecimal injHangmogCnt) {
		this.injHangmogCnt = injHangmogCnt;
	}
	public BigInteger getDrgInjCnt() {
		return drgInjCnt;
	}
	public void setDrgInjCnt(BigInteger drgInjCnt) {
		this.drgInjCnt = drgInjCnt;
	}
	public BigInteger getDrgInjGroupCnt() {
		return drgInjGroupCnt;
	}
	public void setDrgInjGroupCnt(BigInteger drgInjGroupCnt) {
		this.drgInjGroupCnt = drgInjGroupCnt;
	}
	public BigDecimal getDrgInjHangmogCnt() {
		return drgInjHangmogCnt;
	}
	public void setDrgInjHangmogCnt(BigDecimal drgInjHangmogCnt) {
		this.drgInjHangmogCnt = drgInjHangmogCnt;
	}
}