package nta.med.data.model.ihis.adma;

import java.io.Serializable;
import java.util.Date;

public class BAS0310U00GrdListInfo implements Serializable {
	private String sgCode;
    private String groupGubun;
    private String sgName;
    private String sgNameKana;
    private Date sgYmd;
    private String sugaChange;
    private String sugaChangeNmD;
    private Date bulyongYmd;
    private String bulyongSayu;
    private String bulyongSayuNmD;
    private String danui;
    private String danuiName;
    private String bunCode;
    private String bunCodeName;
    private String marumeGubun;
    private String sgUnion;
    private String remark;
    private String marumeName; 
    private String hubalDrgYn;
    private String sunabQcodeOut;
    private String sunabQcodeInp;
    private String taxYn;
    private String privateFeeYn;
    private String modifyFlg;
	public BAS0310U00GrdListInfo(String sgCode, String groupGubun, String sgName, String sgNameKana, Date sgYmd,
			String sugaChange, String sugaChangeNmD, Date bulyongYmd, String bulyongSayu, String bulyongSayuNmD,
			String danui, String danuiName, String bunCode, String bunCodeName, String marumeGubun, String sgUnion,
			String remark, String marumeName, String hubalDrgYn, String sunabQcodeOut, String sunabQcodeInp,
			String taxYn, String privateFeeYn, String modifyFlg) {
		super();
		this.sgCode = sgCode;
		this.groupGubun = groupGubun;
		this.sgName = sgName;
		this.sgNameKana = sgNameKana;
		this.sgYmd = sgYmd;
		this.sugaChange = sugaChange;
		this.sugaChangeNmD = sugaChangeNmD;
		this.bulyongYmd = bulyongYmd;
		this.bulyongSayu = bulyongSayu;
		this.bulyongSayuNmD = bulyongSayuNmD;
		this.danui = danui;
		this.danuiName = danuiName;
		this.bunCode = bunCode;
		this.bunCodeName = bunCodeName;
		this.marumeGubun = marumeGubun;
		this.sgUnion = sgUnion;
		this.remark = remark;
		this.marumeName = marumeName;
		this.hubalDrgYn = hubalDrgYn;
		this.sunabQcodeOut = sunabQcodeOut;
		this.sunabQcodeInp = sunabQcodeInp;
		this.taxYn = taxYn;
		this.privateFeeYn = privateFeeYn;
		this.modifyFlg = modifyFlg;
	}
	public String getSgCode() {
		return sgCode;
	}
	public void setSgCode(String sgCode) {
		this.sgCode = sgCode;
	}
	public String getGroupGubun() {
		return groupGubun;
	}
	public void setGroupGubun(String groupGubun) {
		this.groupGubun = groupGubun;
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
	public Date getSgYmd() {
		return sgYmd;
	}
	public void setSgYmd(Date sgYmd) {
		this.sgYmd = sgYmd;
	}
	public String getSugaChange() {
		return sugaChange;
	}
	public void setSugaChange(String sugaChange) {
		this.sugaChange = sugaChange;
	}
	public String getSugaChangeNmD() {
		return sugaChangeNmD;
	}
	public void setSugaChangeNmD(String sugaChangeNmD) {
		this.sugaChangeNmD = sugaChangeNmD;
	}
	public Date getBulyongYmd() {
		return bulyongYmd;
	}
	public void setBulyongYmd(Date bulyongYmd) {
		this.bulyongYmd = bulyongYmd;
	}
	public String getBulyongSayu() {
		return bulyongSayu;
	}
	public void setBulyongSayu(String bulyongSayu) {
		this.bulyongSayu = bulyongSayu;
	}
	public String getBulyongSayuNmD() {
		return bulyongSayuNmD;
	}
	public void setBulyongSayuNmD(String bulyongSayuNmD) {
		this.bulyongSayuNmD = bulyongSayuNmD;
	}
	public String getDanui() {
		return danui;
	}
	public void setDanui(String danui) {
		this.danui = danui;
	}
	public String getDanuiName() {
		return danuiName;
	}
	public void setDanuiName(String danuiName) {
		this.danuiName = danuiName;
	}
	public String getBunCode() {
		return bunCode;
	}
	public void setBunCode(String bunCode) {
		this.bunCode = bunCode;
	}
	public String getBunCodeName() {
		return bunCodeName;
	}
	public void setBunCodeName(String bunCodeName) {
		this.bunCodeName = bunCodeName;
	}
	public String getMarumeGubun() {
		return marumeGubun;
	}
	public void setMarumeGubun(String marumeGubun) {
		this.marumeGubun = marumeGubun;
	}
	public String getSgUnion() {
		return sgUnion;
	}
	public void setSgUnion(String sgUnion) {
		this.sgUnion = sgUnion;
	}
	public String getRemark() {
		return remark;
	}
	public void setRemark(String remark) {
		this.remark = remark;
	}
	public String getMarumeName() {
		return marumeName;
	}
	public void setMarumeName(String marumeName) {
		this.marumeName = marumeName;
	}
	public String getHubalDrgYn() {
		return hubalDrgYn;
	}
	public void setHubalDrgYn(String hubalDrgYn) {
		this.hubalDrgYn = hubalDrgYn;
	}
	public String getSunabQcodeOut() {
		return sunabQcodeOut;
	}
	public void setSunabQcodeOut(String sunabQcodeOut) {
		this.sunabQcodeOut = sunabQcodeOut;
	}
	public String getSunabQcodeInp() {
		return sunabQcodeInp;
	}
	public void setSunabQcodeInp(String sunabQcodeInp) {
		this.sunabQcodeInp = sunabQcodeInp;
	}
	public String getTaxYn() {
		return taxYn;
	}
	public void setTaxYn(String taxYn) {
		this.taxYn = taxYn;
	}
	public String getPrivateFeeYn() {
		return privateFeeYn;
	}
	public void setPrivateFeeYn(String privateFeeYn) {
		this.privateFeeYn = privateFeeYn;
	}
	public String getModifyFlg() {
		return modifyFlg;
	}
	public void setModifyFlg(String modifyFlg) {
		this.modifyFlg = modifyFlg;
	}
}
