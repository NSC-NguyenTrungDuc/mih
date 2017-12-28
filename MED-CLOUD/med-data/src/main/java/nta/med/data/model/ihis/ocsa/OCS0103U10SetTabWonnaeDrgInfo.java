package nta.med.data.model.ihis.ocsa;

import java.math.BigDecimal;
import java.math.BigInteger;

public class OCS0103U10SetTabWonnaeDrgInfo {
	private String filter ;
	private BigDecimal cnt ;
	private String yakKijunCode ;

	public OCS0103U10SetTabWonnaeDrgInfo() {
	}

	public OCS0103U10SetTabWonnaeDrgInfo(String filter, BigDecimal cnt,
			String yakKijunCode) {
		super();
		this.filter = filter;
		this.cnt = cnt;
		this.yakKijunCode = yakKijunCode;
	}
	public String getFilter() {
		return filter;
	}
	public void setFilter(String filter) {
		this.filter = filter;
	}
	public BigDecimal getCnt() {
		return cnt;
	}
	public void setCnt(BigDecimal cnt) {
		this.cnt = cnt;
	}
	public String getYakKijunCode() {
		return yakKijunCode;
	}
	public void setYakKijunCode(String yakKijunCode) {
		this.yakKijunCode = yakKijunCode;
	}

}
