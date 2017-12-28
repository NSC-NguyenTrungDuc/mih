package nta.med.data.model.ihis.bass;

import java.util.Date;

public class IFS0004U01grdMasterListItemInfo {
	private String nuGubun;
	private String nuCode;
	private Date nuYmd;
	private String nuCodeName;

	public IFS0004U01grdMasterListItemInfo(String nuGubun, String nuCode,
			Date nuYmd, String nuCodeName) {
		super();
		this.nuGubun = nuGubun;
		this.nuCode = nuCode;
		this.nuYmd = nuYmd;
		this.nuCodeName = nuCodeName;
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

	public String getNuCodeName() {
		return nuCodeName;
	}

	public void setNuCodeName(String nuCodeName) {
		this.nuCodeName = nuCodeName;
	}

}