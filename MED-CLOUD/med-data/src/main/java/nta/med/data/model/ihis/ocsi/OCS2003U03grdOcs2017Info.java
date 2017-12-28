package nta.med.data.model.ihis.ocsi;

import java.math.BigDecimal;
import java.util.Date;

public class OCS2003U03grdOcs2017Info {
	private Date actResDate;
	private BigDecimal seq;
	private String patternGubun;
	private String actYn;
	private String passUser;
	private String userNm;
	public OCS2003U03grdOcs2017Info(Date actResDate, BigDecimal seq, String patternGubun, String actYn, String passUser,
			String userNm) {
		super();
		this.actResDate = actResDate;
		this.seq = seq;
		this.patternGubun = patternGubun;
		this.actYn = actYn;
		this.passUser = passUser;
		this.userNm = userNm;
	}
	public Date getActResDate() {
		return actResDate;
	}
	public void setActResDate(Date actResDate) {
		this.actResDate = actResDate;
	}
	public BigDecimal getSeq() {
		return seq;
	}
	public void setSeq(BigDecimal seq) {
		this.seq = seq;
	}
	public String getPatternGubun() {
		return patternGubun;
	}
	public void setPatternGubun(String patternGubun) {
		this.patternGubun = patternGubun;
	}
	public String getActYn() {
		return actYn;
	}
	public void setActYn(String actYn) {
		this.actYn = actYn;
	}
	public String getPassUser() {
		return passUser;
	}
	public void setPassUser(String passUser) {
		this.passUser = passUser;
	}
	public String getUserNm() {
		return userNm;
	}
	public void setUserNm(String userNm) {
		this.userNm = userNm;
	}
	
}
