package nta.med.data.model.ihis.nuri;

import java.util.Date;

public class NUR1020U00grdNUR1122Info {

	private String bunho;
	private Double fkinp1001;
	private Date ymd;
	private String hangmogCode;
	private String hangmogValue1;
	private String hangmogValue2;
	private String hangmogValue3;
	private String hangmogName;
	private String endYn;

	public NUR1020U00grdNUR1122Info(String bunho, Double fkinp1001, Date ymd, String hangmogCode, String hangmogValue1,
			String hangmogValue2, String hangmogValue3, String hangmogName, String endYn) {
		super();
		this.bunho = bunho;
		this.fkinp1001 = fkinp1001;
		this.ymd = ymd;
		this.hangmogCode = hangmogCode;
		this.hangmogValue1 = hangmogValue1;
		this.hangmogValue2 = hangmogValue2;
		this.hangmogValue3 = hangmogValue3;
		this.hangmogName = hangmogName;
		this.endYn = endYn;
	}

	public String getBunho() {
		return bunho;
	}

	public void setBunho(String bunho) {
		this.bunho = bunho;
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

	public String getHangmogCode() {
		return hangmogCode;
	}

	public void setHangmogCode(String hangmogCode) {
		this.hangmogCode = hangmogCode;
	}

	public String getHangmogValue1() {
		return hangmogValue1;
	}

	public void setHangmogValue1(String hangmogValue1) {
		this.hangmogValue1 = hangmogValue1;
	}

	public String getHangmogValue2() {
		return hangmogValue2;
	}

	public void setHangmogValue2(String hangmogValue2) {
		this.hangmogValue2 = hangmogValue2;
	}

	public String getHangmogValue3() {
		return hangmogValue3;
	}

	public void setHangmogValue3(String hangmogValue3) {
		this.hangmogValue3 = hangmogValue3;
	}

	public String getHangmogName() {
		return hangmogName;
	}

	public void setHangmogName(String hangmogName) {
		this.hangmogName = hangmogName;
	}

	public String getEndYn() {
		return endYn;
	}

	public void setEndYn(String endYn) {
		this.endYn = endYn;
	}

}
