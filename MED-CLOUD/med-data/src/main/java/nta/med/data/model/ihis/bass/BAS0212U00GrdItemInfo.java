package nta.med.data.model.ihis.bass;

import java.io.Serializable;
import java.util.Date;

public class BAS0212U00GrdItemInfo implements Serializable{
	private String gongbiCode;
	private Date startDate;
	private Date endDate;
	private String lawNo;
	private String gongbiName;
	private String totalYn;
	private String gongbiJiyeok;

	public BAS0212U00GrdItemInfo(String gongbiCode, Date startDate, Date endDate, String lawNo, String gongbiName,
			String totalYn, String gongbiJiyeok) {
		super();
		this.gongbiCode = gongbiCode;
		this.startDate = startDate;
		this.endDate = endDate;
		this.lawNo = lawNo;
		this.gongbiName = gongbiName;
		this.totalYn = totalYn;
		this.gongbiJiyeok = gongbiJiyeok;
	}

	public String getGongbiCode() {
		return gongbiCode;
	}

	public void setGongbiCode(String gongbiCode) {
		this.gongbiCode = gongbiCode;
	}

	public Date getStartDate() {
		return startDate;
	}

	public void setStartDate(Date startDate) {
		this.startDate = startDate;
	}

	public Date getEndDate() {
		return endDate;
	}

	public void setEndDate(Date endDate) {
		this.endDate = endDate;
	}

	public String getLawNo() {
		return lawNo;
	}

	public void setLawNo(String lawNo) {
		this.lawNo = lawNo;
	}

	public String getGongbiName() {
		return gongbiName;
	}

	public void setGongbiName(String gongbiName) {
		this.gongbiName = gongbiName;
	}

	public String getTotalYn() {
		return totalYn;
	}

	public void setTotalYn(String totalYn) {
		this.totalYn = totalYn;
	}

	public String getGongbiJiyeok() {
		return gongbiJiyeok;
	}

	public void setGongbiJiyeok(String gongbiJiyeok) {
		this.gongbiJiyeok = gongbiJiyeok;
	}

}
