package nta.med.data.model.ihis.bass;

import java.io.Serializable;
import java.util.Date;

public class BAS0311Q01GrdBAS0311Info implements Serializable {
	private Date sgYmd;
    private String sgCode;
    private String sgName;
    private String sgNameKana;
    private String bunCode;
    private String groupGubun;
    private String danui;
    private Date bulyongYmd;
	public BAS0311Q01GrdBAS0311Info(Date sgYmd, String sgCode, String sgName,
			String sgNameKana, String bunCode, String groupGubun, String danui,
			Date bulyongYmd) {
		super();
		this.sgYmd = sgYmd;
		this.sgCode = sgCode;
		this.sgName = sgName;
		this.sgNameKana = sgNameKana;
		this.bunCode = bunCode;
		this.groupGubun = groupGubun;
		this.danui = danui;
		this.bulyongYmd = bulyongYmd;
	}
	public Date getSgYmd() {
		return sgYmd;
	}
	public void setSgYmd(Date sgYmd) {
		this.sgYmd = sgYmd;
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
	public String getSgNameKana() {
		return sgNameKana;
	}
	public void setSgNameKana(String sgNameKana) {
		this.sgNameKana = sgNameKana;
	}
	public String getBunCode() {
		return bunCode;
	}
	public void setBunCode(String bunCode) {
		this.bunCode = bunCode;
	}
	public String getGroupGubun() {
		return groupGubun;
	}
	public void setGroupGubun(String groupGubun) {
		this.groupGubun = groupGubun;
	}
	public String getDanui() {
		return danui;
	}
	public void setDanui(String danui) {
		this.danui = danui;
	}
	public Date getBulyongYmd() {
		return bulyongYmd;
	}
	public void setBulyongYmd(Date bulyongYmd) {
		this.bulyongYmd = bulyongYmd;
	}
}
