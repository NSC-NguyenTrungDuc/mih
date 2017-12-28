package nta.med.core.domain.bas;

import java.util.Date;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.NamedQuery;
import javax.persistence.Table;
import javax.persistence.Temporal;
import javax.persistence.TemporalType;

import nta.med.core.domain.BaseEntity;

/**
 * The persistent class for the BAS0310 database table.
 * 
 */
@Entity
@NamedQuery(name = "Bas0310.findAll", query = "SELECT b FROM Bas0310 b")
@Table(name = "BAS0310")
public class Bas0310 extends BaseEntity {
	private static final long serialVersionUID = 1L;
	private String bulyongSayu;
	private Date bulyongYmd;
	private String bunCode;
	private String danui;
	private String groupGubun;
	private String hospCode;
	private String hubalDrgYn;
	private String kCode;
	private String marumeGubun;
	private String oldCodeYn;
	private double point;
	private String pointGubun;
	private String remark;
	private String sgCode;
	private String sgGubun;
	private String sgName;
	private String sgNameInd;
	private String sgNameKana;
	private String sgUnion;
	private Date sgYmd;
	private String sugaChange;
	private String sunabQcodeInp;
	private String sunabQcodeOut;
	private Date sysDate;
	private String sysId;
	private String taxYn;
	private Date updDate;
	private String updId;
	private String modifyFlg;
	private String privateFeeYn;

	public Bas0310() {
	}

	@Column(name = "BULYONG_SAYU")
	public String getBulyongSayu() {
		return this.bulyongSayu;
	}

	public void setBulyongSayu(String bulyongSayu) {
		this.bulyongSayu = bulyongSayu;
	}

	@Temporal(TemporalType.TIMESTAMP)
	@Column(name = "BULYONG_YMD")
	public Date getBulyongYmd() {
		return this.bulyongYmd;
	}

	public void setBulyongYmd(Date bulyongYmd) {
		this.bulyongYmd = bulyongYmd;
	}

	@Column(name = "BUN_CODE")
	public String getBunCode() {
		return this.bunCode;
	}

	public void setBunCode(String bunCode) {
		this.bunCode = bunCode;
	}

	@Column(name = "DANUI")
	public String getDanui() {
		return this.danui;
	}

	public void setDanui(String danui) {
		this.danui = danui;
	}

	@Column(name = "GROUP_GUBUN")
	public String getGroupGubun() {
		return this.groupGubun;
	}

	public void setGroupGubun(String groupGubun) {
		this.groupGubun = groupGubun;
	}

	@Column(name = "HOSP_CODE")
	public String getHospCode() {
		return this.hospCode;
	}

	public void setHospCode(String hospCode) {
		this.hospCode = hospCode;
	}

	@Column(name = "HUBAL_DRG_YN")
	public String getHubalDrgYn() {
		return this.hubalDrgYn;
	}

	public void setHubalDrgYn(String hubalDrgYn) {
		this.hubalDrgYn = hubalDrgYn;
	}

	@Column(name = "K_CODE")
	public String getKCode() {
		return this.kCode;
	}

	public void setKCode(String kCode) {
		this.kCode = kCode;
	}

	@Column(name = "MARUME_GUBUN")
	public String getMarumeGubun() {
		return this.marumeGubun;
	}

	public void setMarumeGubun(String marumeGubun) {
		this.marumeGubun = marumeGubun;
	}

	@Column(name = "OLD_CODE_YN")
	public String getOldCodeYn() {
		return this.oldCodeYn;
	}

	public void setOldCodeYn(String oldCodeYn) {
		this.oldCodeYn = oldCodeYn;
	}

	public double getPoint() {
		return this.point;
	}

	public void setPoint(double point) {
		this.point = point;
	}

	@Column(name = "POINT_GUBUN")
	public String getPointGubun() {
		return this.pointGubun;
	}

	public void setPointGubun(String pointGubun) {
		this.pointGubun = pointGubun;
	}

	@Column(name = "REMARK")
	public String getRemark() {
		return this.remark;
	}

	public void setRemark(String remark) {
		this.remark = remark;
	}

	@Column(name = "SG_CODE")
	public String getSgCode() {
		return this.sgCode;
	}

	public void setSgCode(String sgCode) {
		this.sgCode = sgCode;
	}

	@Column(name = "SG_GUBUN")
	public String getSgGubun() {
		return this.sgGubun;
	}

	public void setSgGubun(String sgGubun) {
		this.sgGubun = sgGubun;
	}

	@Column(name = "SG_NAME")
	public String getSgName() {
		return this.sgName;
	}

	public void setSgName(String sgName) {
		this.sgName = sgName;
	}

	@Column(name = "SG_NAME_IND")
	public String getSgNameInd() {
		return this.sgNameInd;
	}

	public void setSgNameInd(String sgNameInd) {
		this.sgNameInd = sgNameInd;
	}

	@Column(name = "SG_NAME_KANA")
	public String getSgNameKana() {
		return this.sgNameKana;
	}

	public void setSgNameKana(String sgNameKana) {
		this.sgNameKana = sgNameKana;
	}

	@Column(name = "SG_UNION")
	public String getSgUnion() {
		return this.sgUnion;
	}

	public void setSgUnion(String sgUnion) {
		this.sgUnion = sgUnion;
	}

	@Temporal(TemporalType.TIMESTAMP)
	@Column(name = "SG_YMD")
	public Date getSgYmd() {
		return this.sgYmd;
	}

	public void setSgYmd(Date sgYmd) {
		this.sgYmd = sgYmd;
	}

	@Column(name = "SUGA_CHANGE")
	public String getSugaChange() {
		return this.sugaChange;
	}

	public void setSugaChange(String sugaChange) {
		this.sugaChange = sugaChange;
	}

	@Column(name = "SUNAB_QCODE_INP")
	public String getSunabQcodeInp() {
		return this.sunabQcodeInp;
	}

	public void setSunabQcodeInp(String sunabQcodeInp) {
		this.sunabQcodeInp = sunabQcodeInp;
	}

	@Column(name = "SUNAB_QCODE_OUT")
	public String getSunabQcodeOut() {
		return this.sunabQcodeOut;
	}

	public void setSunabQcodeOut(String sunabQcodeOut) {
		this.sunabQcodeOut = sunabQcodeOut;
	}

	@Temporal(TemporalType.TIMESTAMP)
	@Column(name = "SYS_DATE")
	public Date getSysDate() {
		return this.sysDate;
	}

	public void setSysDate(Date sysDate) {
		this.sysDate = sysDate;
	}

	@Column(name = "SYS_ID")
	public String getSysId() {
		return this.sysId;
	}

	public void setSysId(String sysId) {
		this.sysId = sysId;
	}

	@Column(name = "TAX_YN")
	public String getTaxYn() {
		return this.taxYn;
	}

	public void setTaxYn(String taxYn) {
		this.taxYn = taxYn;
	}

	@Temporal(TemporalType.TIMESTAMP)
	@Column(name = "UPD_DATE")
	public Date getUpdDate() {
		return this.updDate;
	}

	public void setUpdDate(Date updDate) {
		this.updDate = updDate;
	}

	@Column(name = "UPD_ID")
	public String getUpdId() {
		return this.updId;
	}

	public void setUpdId(String updId) {
		this.updId = updId;
	}

	@Column(name = "MODIFY_FLG")
	public String getModifyFlg() {
		return modifyFlg;
	}

	public void setModifyFlg(String modifyFlg) {
		this.modifyFlg = modifyFlg;
	}
	
	@Column(name = "PRIVATE_FEE_YN")
	public String getPrivateFeeYn() {
		return privateFeeYn;
	}

	public void setPrivateFeeYn(String privateFeeYn) {
		this.privateFeeYn = privateFeeYn;
	}
	
}