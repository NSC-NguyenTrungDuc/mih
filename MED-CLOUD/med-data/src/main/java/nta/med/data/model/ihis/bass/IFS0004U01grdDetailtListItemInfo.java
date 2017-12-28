package nta.med.data.model.ihis.bass;

import java.util.Date;

public class IFS0004U01grdDetailtListItemInfo {
	private String nuGubun;
	private String nuCode;
	private Date nuYmd;
	private String bunCode;
	private String bunName;
	private String sgCode;
	private String sgName;

	public IFS0004U01grdDetailtListItemInfo(String nuGubun, String nuCode,
			Date nuYmd, String bunCode, String bunName, String sgCode,
			String sgName) {
		super();
		this.nuGubun = nuGubun;
		this.nuCode = nuCode;
		this.nuYmd = nuYmd;
		this.bunCode = bunCode;
		this.bunName = bunName;
		this.sgCode = sgCode;
		this.sgName = sgName;
	}

	public String getNuGubun() {
		return nuGubun;
	}

	public void setNuGubun(String nuGubun) {
		this.nuGubun = nuGubun;
	}

	public String getNuCode() {
		return nuCode;
	}

	public void setNuCode(String nuCode) {
		this.nuCode = nuCode;
	}

	public Date getNuYmd() {
		return nuYmd;
	}

	public void setNuYmd(Date nuYmd) {
		this.nuYmd = nuYmd;
	}

	public String getBunCode() {
		return bunCode;
	}

	public void setBunCode(String bunCode) {
		this.bunCode = bunCode;
	}

	public String getBunName() {
		return bunName;
	}

	public void setBunName(String bunName) {
		this.bunName = bunName;
	}

	public String getSgCode() {
		return sgCode;
	}

	public void setSgCode(String sgCode) {
		this.sgCode = sgCode;
	}

	public String getSgName() {
		return sgName;
	}

	public void setSgName(String sgName) {
		this.sgName = sgName;
	}

}