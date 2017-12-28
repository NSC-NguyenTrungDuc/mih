package nta.med.data.model.ihis.nuri;

import java.util.Date;

public class NUR1020Q00layIOInfo {

	private Date ymd;
	private String type;
	private String gubun;
	private String value;

	public NUR1020Q00layIOInfo(Date ymd, String type, String gubun, String value) {
		super();
		this.ymd = ymd;
		this.type = type;
		this.gubun = gubun;
		this.value = value;
	}

	public Date getYmd() {
		return ymd;
	}

	public void setYmd(Date ymd) {
		this.ymd = ymd;
	}

	public String getType() {
		return type;
	}

	public void setType(String type) {
		this.type = type;
	}

	public String getGubun() {
		return gubun;
	}

	public void setGubun(String gubun) {
		this.gubun = gubun;
	}

	public String getValue() {
		return value;
	}

	public void setValue(String value) {
		this.value = value;
	}

}
