package nta.med.data.model.ihis.nuri;

import java.math.BigInteger;
import java.util.Date;

public class NUR1020Q00layInOutTotalInfo {

	private Date ymd;
	private BigInteger inTotal;
	private BigInteger outTotal;
	private BigInteger inoutMinus;

	public NUR1020Q00layInOutTotalInfo(Date ymd, BigInteger inTotal, BigInteger outTotal, BigInteger inoutMinus) {
		super();
		this.ymd = ymd;
		this.inTotal = inTotal;
		this.outTotal = outTotal;
		this.inoutMinus = inoutMinus;
	}

	public Date getYmd() {
		return ymd;
	}

	public void setYmd(Date ymd) {
		this.ymd = ymd;
	}

	public BigInteger getInTotal() {
		return inTotal;
	}

	public void setInTotal(BigInteger inTotal) {
		this.inTotal = inTotal;
	}

	public BigInteger getOutTotal() {
		return outTotal;
	}

	public void setOutTotal(BigInteger outTotal) {
		this.outTotal = outTotal;
	}

	public BigInteger getInoutMinus() {
		return inoutMinus;
	}

	public void setInoutMinus(BigInteger inoutMinus) {
		this.inoutMinus = inoutMinus;
	}

}
