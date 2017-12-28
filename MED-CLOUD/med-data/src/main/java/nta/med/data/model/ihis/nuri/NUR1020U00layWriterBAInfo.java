package nta.med.data.model.ihis.nuri;

import java.util.Date;

public class NUR1020U00layWriterBAInfo {

	private Double fkinp1001;
	private Date ymd;
	private String hangmogGubun;
	private Double hangmogSeq;
	private String hangmogValue;

	public NUR1020U00layWriterBAInfo(Double fkinp1001, Date ymd, String hangmogGubun, Double hangmogSeq,
			String hangmogValue) {
		super();
		this.fkinp1001 = fkinp1001;
		this.ymd = ymd;
		this.hangmogGubun = hangmogGubun;
		this.hangmogSeq = hangmogSeq;
		this.hangmogValue = hangmogValue;
	}

	public Double getFkinp1001() {
		return fkinp1001;
	}

	public void setFkinp1001(Double fkinp1001) {
		this.fkinp1001 = fkinp1001;
	}

	public Date getYmd() {
		return ymd;
	}

	public void setYmd(Date ymd) {
		this.ymd = ymd;
	}

	public String getHangmogGubun() {
		return hangmogGubun;
	}

	public void setHangmogGubun(String hangmogGubun) {
		this.hangmogGubun = hangmogGubun;
	}

	public Double getHangmogSeq() {
		return hangmogSeq;
	}

	public void setHangmogSeq(Double hangmogSeq) {
		this.hangmogSeq = hangmogSeq;
	}

	public String getHangmogValue() {
		return hangmogValue;
	}

	public void setHangmogValue(String hangmogValue) {
		this.hangmogValue = hangmogValue;
	}

}
