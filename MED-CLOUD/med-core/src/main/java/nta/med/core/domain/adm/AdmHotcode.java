package nta.med.core.domain.adm;

import java.io.Serializable;

import javax.persistence.*;

import java.math.BigDecimal;
import java.util.Date;
import java.sql.Timestamp;


/**
 * The persistent class for the ADM_HOTCODE database table.
 * 
 */
@Entity
@Table(name="ADM_HOTCODE")
public class AdmHotcode implements Serializable {
	private static final long serialVersionUID = 1L;

	@Id
	@GeneratedValue(strategy = GenerationType.IDENTITY)
	@Column(name="ADM_HOTCODE_ID")
	private int admHotcodeId;

	@Column(name="ACTIVE_FLG")
	private BigDecimal activeFlg;

	@Column(name="CIN_CODE")
	private String cinCode;

	private String classif;

	@Column(name="CLASSIF_UPD")
	private String classifUpd;

	private Timestamp created;

	@Column(name="DISPENSE_CODE")
	private String dispenseCode;

	@Column(name="HANGMOG_NAME")
	private String hangmogName;

	@Column(name="HANGMOG_NAME1")
	private String hangmogName1;

	@Column(name="HANGMOG_NAME2")
	private String hangmogName2;
	
	@Column(name="HOTCODE")
	private String hotCode;

	@Column(name="HOTCODE7")
	private String hotCode7;

	@Column(name="JAN_CODE")
	private String janCode;

	@Column(name="LOGISTIC_CODE")
	private String logisticCode;

	@Column(name="MANUF_COMP")
	private String manufComp;

	@Column(name="ORD_DANUI")
	private String ordDanui;

	@Column(name="PKG_NUM_UNIT")
	private String pkgNumUnit;

	@Column(name="PKG_STATUS")
	private String pkgStatus;

	@Column(name="PKG_TOTAL")
	private String pkgTotal;

	@Column(name="PKG_TOTAL_UNIT")
	private String pkgTotalUnit;

	@Column(name="SALES_COMP")
	private String salesComp;

	@Column(name="SG_CODE")
	private String sgCode;

	@Column(name="SG_CODE1")
	private String sgCode1;

	@Temporal(TemporalType.DATE)
	@Column(name="SG_YMD")
	private Date sgYmd;

	@Column(name="STANDARD_UNIT")
	private String standardUnit;

	@Column(name="SYS_ID")
	private String sysId;

	@Column(name="UPD_ID")
	private String updId;

	private Timestamp updated;

	@Column(name="YAK_KIJUN_CODE")
	private String yakKijunCode;

	@Column(name="YJ_CODE")
	private String yjCode;

	public AdmHotcode() {
	}

	public int getAdmHotcodeId() {
		return this.admHotcodeId;
	}

	public void setAdmHotcodeId(int admHotcodeId) {
		this.admHotcodeId = admHotcodeId;
	}

	public BigDecimal getActiveFlg() {
		return this.activeFlg;
	}

	public void setActiveFlg(BigDecimal activeFlg) {
		this.activeFlg = activeFlg;
	}

	public String getCinCode() {
		return this.cinCode;
	}

	public void setCinCode(String cinCode) {
		this.cinCode = cinCode;
	}

	public String getClassif() {
		return this.classif;
	}

	public void setClassif(String classif) {
		this.classif = classif;
	}

	public String getClassifUpd() {
		return this.classifUpd;
	}

	public void setClassifUpd(String classifUpd) {
		this.classifUpd = classifUpd;
	}

	public Timestamp getCreated() {
		return this.created;
	}

	public void setCreated(Timestamp created) {
		this.created = created;
	}

	public String getDispenseCode() {
		return this.dispenseCode;
	}

	public void setDispenseCode(String dispenseCode) {
		this.dispenseCode = dispenseCode;
	}

	public String getHangmogName() {
		return this.hangmogName;
	}

	public void setHangmogName(String hangmogName) {
		this.hangmogName = hangmogName;
	}

	public String getHangmogName1() {
		return this.hangmogName1;
	}

	public void setHangmogName1(String hangmogName1) {
		this.hangmogName1 = hangmogName1;
	}

	public String getHangmogName2() {
		return this.hangmogName2;
	}

	public void setHangmogName2(String hangmogName2) {
		this.hangmogName2 = hangmogName2;
	}

	public String getHotCode() {
		return this.hotCode;
	}

	public void setHotCode(String hotCode) {
		this.hotCode = hotCode;
	}

	public String getHotCode7() {
		return this.hotCode7;
	}

	public void setHotCode7(String hotCode7) {
		this.hotCode7 = hotCode7;
	}

	public String getJanCode() {
		return this.janCode;
	}

	public void setJanCode(String janCode) {
		this.janCode = janCode;
	}

	public String getLogisticCode() {
		return this.logisticCode;
	}

	public void setLogisticCode(String logisticCode) {
		this.logisticCode = logisticCode;
	}

	public String getManufComp() {
		return this.manufComp;
	}

	public void setManufComp(String manufComp) {
		this.manufComp = manufComp;
	}

	public String getOrdDanui() {
		return this.ordDanui;
	}

	public void setOrdDanui(String ordDanui) {
		this.ordDanui = ordDanui;
	}

	public String getPkgNumUnit() {
		return this.pkgNumUnit;
	}

	public void setPkgNumUnit(String pkgNumUnit) {
		this.pkgNumUnit = pkgNumUnit;
	}

	public String getPkgStatus() {
		return this.pkgStatus;
	}

	public void setPkgStatus(String pkgStatus) {
		this.pkgStatus = pkgStatus;
	}

	public String getPkgTotal() {
		return this.pkgTotal;
	}

	public void setPkgTotal(String pkgTotal) {
		this.pkgTotal = pkgTotal;
	}

	public String getPkgTotalUnit() {
		return this.pkgTotalUnit;
	}

	public void setPkgTotalUnit(String pkgTotalUnit) {
		this.pkgTotalUnit = pkgTotalUnit;
	}

	public String getSalesComp() {
		return this.salesComp;
	}

	public void setSalesComp(String salesComp) {
		this.salesComp = salesComp;
	}

	public String getSgCode() {
		return this.sgCode;
	}

	public void setSgCode(String sgCode) {
		this.sgCode = sgCode;
	}

	public String getSgCode1() {
		return this.sgCode1;
	}

	public void setSgCode1(String sgCode1) {
		this.sgCode1 = sgCode1;
	}

	public Date getSgYmd() {
		return this.sgYmd;
	}

	public void setSgYmd(Date sgYmd) {
		this.sgYmd = sgYmd;
	}

	public String getStandardUnit() {
		return this.standardUnit;
	}

	public void setStandardUnit(String standardUnit) {
		this.standardUnit = standardUnit;
	}

	public String getSysId() {
		return this.sysId;
	}

	public void setSysId(String sysId) {
		this.sysId = sysId;
	}

	public String getUpdId() {
		return this.updId;
	}

	public void setUpdId(String updId) {
		this.updId = updId;
	}

	public Timestamp getUpdated() {
		return this.updated;
	}

	public void setUpdated(Timestamp updated) {
		this.updated = updated;
	}

	public String getYakKijunCode() {
		return this.yakKijunCode;
	}

	public void setYakKijunCode(String yakKijunCode) {
		this.yakKijunCode = yakKijunCode;
	}

	public String getYjCode() {
		return this.yjCode;
	}

	public void setYjCode(String yjCode) {
		this.yjCode = yjCode;
	}

}