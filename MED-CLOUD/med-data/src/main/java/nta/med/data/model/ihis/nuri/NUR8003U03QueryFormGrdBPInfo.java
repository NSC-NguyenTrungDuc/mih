package nta.med.data.model.ihis.nuri;

import java.util.Date;

public class NUR8003U03QueryFormGrdBPInfo {

	private Date ymd;
	private String timeGubun;
	private String bph;
	private String bpl;

	public NUR8003U03QueryFormGrdBPInfo(Date ymd, String timeGubun, String bph, String bpl) {
		super();
		this.ymd = ymd;
		this.timeGubun = timeGubun;
		this.bph = bph;
		this.bpl = bpl;
	}

	public Date getYmd() {
		return ymd;
	}

	public void setYmd(Date ymd) {
		this.ymd = ymd;
	}

	public String getTimeGubun() {
		return timeGubun;
	}

	public void setTimeGubun(String timeGubun) {
		this.timeGubun = timeGubun;
	}

	public String getBph() {
		return bph;
	}

	public void setBph(String bph) {
		this.bph = bph;
	}

	public String getBpl() {
		return bpl;
	}

	public void setBpl(String bpl) {
		this.bpl = bpl;
	}

}
