package nta.med.data.model.ihis.bass;

import java.util.Date;

public class Ifs0003U00GrdIFS0003Info {
	private String mapGubun;
	private Date mapGubunYmd;
	private String ocsCode;
	private String ocsCodeName;
	private String ocsDefaultYn;
	private String ifCode;
	private String ifCodeName;
	private String ifDefaultYn;
	private String remark;

	public Ifs0003U00GrdIFS0003Info(String mapGubun, Date mapGubunYmd,
			String ocsCode, String ocsCodeName, String ocsDefaultYn,
			String ifCode, String ifCodeName, String ifDefaultYn, String remark) {
		super();
		this.mapGubun = mapGubun;
		this.mapGubunYmd = mapGubunYmd;
		this.ocsCode = ocsCode;
		this.ocsCodeName = ocsCodeName;
		this.ocsDefaultYn = ocsDefaultYn;
		this.ifCode = ifCode;
		this.ifCodeName = ifCodeName;
		this.ifDefaultYn = ifDefaultYn;
		this.remark = remark;
	}

	public String getMapGubun() {
		return mapGubun;
	}

	public void setMapGubun(String mapGubun) {
		this.mapGubun = mapGubun;
	}

	public Date getMapGubunYmd() {
		return mapGubunYmd;
	}

	public void setMapGubunYmd(Date mapGubunYmd) {
		this.mapGubunYmd = mapGubunYmd;
	}

	public String getOcsCode() {
		return ocsCode;
	}

	public void setOcsCode(String ocsCode) {
		this.ocsCode = ocsCode;
	}

	public String getOcsCodeName() {
		return ocsCodeName;
	}

	public void setOcsCodeName(String ocsCodeName) {
		this.ocsCodeName = ocsCodeName;
	}

	public String getOcsDefaultYn() {
		return ocsDefaultYn;
	}

	public void setOcsDefaultYn(String ocsDefaultYn) {
		this.ocsDefaultYn = ocsDefaultYn;
	}

	public String getIfCode() {
		return ifCode;
	}

	public void setIfCode(String ifCode) {
		this.ifCode = ifCode;
	}

	public String getIfCodeName() {
		return ifCodeName;
	}

	public void setIfCodeName(String ifCodeName) {
		this.ifCodeName = ifCodeName;
	}

	public String getIfDefaultYn() {
		return ifDefaultYn;
	}

	public void setIfDefaultYn(String ifDefaultYn) {
		this.ifDefaultYn = ifDefaultYn;
	}

	public String getRemark() {
		return remark;
	}

	public void setRemark(String remark) {
		this.remark = remark;
	}

}