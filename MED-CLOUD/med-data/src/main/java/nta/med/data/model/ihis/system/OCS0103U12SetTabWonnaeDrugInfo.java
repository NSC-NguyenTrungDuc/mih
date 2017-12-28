package nta.med.data.model.ihis.system;

import java.math.BigInteger;

public class OCS0103U12SetTabWonnaeDrugInfo {
	private String filter;
	private BigInteger count;
	private String yakKijunCode;
	public OCS0103U12SetTabWonnaeDrugInfo(String filter, BigInteger count,
			String yakKijunCode) {
		super();
		this.filter = filter;
		this.count = count;
		this.yakKijunCode = yakKijunCode;
	}
	public String getFilter() {
		return filter;
	}
	public void setFilter(String filter) {
		this.filter = filter;
	}
	public BigInteger getCount() {
		return count;
	}
	public void setCount(BigInteger count) {
		this.count = count;
	}
	public String getYakKijunCode() {
		return yakKijunCode;
	}
	public void setYakKijunCode(String yakKijunCode) {
		this.yakKijunCode = yakKijunCode;
	}

}
