package nta.med.data.model.ihis.bass;

import java.io.Serializable;
import java.util.Date;

public class HOTCODEMASTERGetGrdListInfo implements Serializable{
	private String hotCode          ; 
	private String hotCode7         ;
	private String cinCode          ;
	private String dispenseCode     ;
	private String logisticCode     ;
	private String janCode          ;
	private String yakKijunCode    ;
	private String yjCode           ;
	private String sgCode           ;
	private String sgCode1           ;
	private String hangmogName       ;
	private String hangmogName1      ;
	private String hangmogName2      ;
	private String standardUnit      ;
	private String pkgStatus         ;
	private String pkgNumUnit       ;
	private String ordDanui          ;
	private String pkgTotal          ;
	private String pkgTotalUnit     ;
	private String clsif             ;
	private String manufComp         ;
	private String salesComp         ;
	private String clsifUpd          ;
	private Date sgYmd             ;
	public HOTCODEMASTERGetGrdListInfo(String hotCode, String hotCode7,
			String cinCode, String dispenseCode, String logisticCode,
			String janCode, String yakKijunCode, String yjCode, String sgCode,
			String sgCode1, String hangmogName, String hangmogName1,
			String hangmogName2, String standardUnit, String pkgStatus,
			String pkgNumUnit, String ordDanui, String pkgTotal,
			String pkgTotalUnit, String clsif, String manufComp,
			String salesComp, String clsifUpd, Date sgYmd) {
		super();
		this.hotCode = hotCode;
		this.hotCode7 = hotCode7;
		this.cinCode = cinCode;
		this.dispenseCode = dispenseCode;
		this.logisticCode = logisticCode;
		this.janCode = janCode;
		this.yakKijunCode = yakKijunCode;
		this.yjCode = yjCode;
		this.sgCode = sgCode;
		this.sgCode1 = sgCode1;
		this.hangmogName = hangmogName;
		this.hangmogName1 = hangmogName1;
		this.hangmogName2 = hangmogName2;
		this.standardUnit = standardUnit;
		this.pkgStatus = pkgStatus;
		this.pkgNumUnit = pkgNumUnit;
		this.ordDanui = ordDanui;
		this.pkgTotal = pkgTotal;
		this.pkgTotalUnit = pkgTotalUnit;
		this.clsif = clsif;
		this.manufComp = manufComp;
		this.salesComp = salesComp;
		this.clsifUpd = clsifUpd;
		this.sgYmd = sgYmd;
	}
	public String getHotCode() {
		return hotCode;
	}
	public void setHotCode(String hotCode) {
		this.hotCode = hotCode;
	}
	public String getHotCode7() {
		return hotCode7;
	}
	public void setHotCode7(String hotCode7) {
		this.hotCode7 = hotCode7;
	}
	public String getCinCode() {
		return cinCode;
	}
	public void setCinCode(String cinCode) {
		this.cinCode = cinCode;
	}
	public String getDispenseCode() {
		return dispenseCode;
	}
	public void setDispenseCode(String dispenseCode) {
		this.dispenseCode = dispenseCode;
	}
	public String getLogisticCode() {
		return logisticCode;
	}
	public void setLogisticCode(String logisticCode) {
		this.logisticCode = logisticCode;
	}
	public String getJanCode() {
		return janCode;
	}
	public void setJanCode(String janCode) {
		this.janCode = janCode;
	}
	public String getYakKijunCode() {
		return yakKijunCode;
	}
	public void setYakKijunCode(String yakKijunCode) {
		this.yakKijunCode = yakKijunCode;
	}
	public String getYjCode() {
		return yjCode;
	}
	public void setYjCode(String yjCode) {
		this.yjCode = yjCode;
	}
	public String getSgCode() {
		return sgCode;
	}
	public void setSgCode(String sgCode) {
		this.sgCode = sgCode;
	}
	public String getSgCode1() {
		return sgCode1;
	}
	public void setSgCode1(String sgCode1) {
		this.sgCode1 = sgCode1;
	}
	public String getHangmogName() {
		return hangmogName;
	}
	public void setHangmogName(String hangmogName) {
		this.hangmogName = hangmogName;
	}
	public String getHangmogName1() {
		return hangmogName1;
	}
	public void setHangmogName1(String hangmogName1) {
		this.hangmogName1 = hangmogName1;
	}
	public String getHangmogName2() {
		return hangmogName2;
	}
	public void setHangmogName2(String hangmogName2) {
		this.hangmogName2 = hangmogName2;
	}
	public String getStandardUnit() {
		return standardUnit;
	}
	public void setStandardUnit(String standardUnit) {
		this.standardUnit = standardUnit;
	}
	public String getPkgStatus() {
		return pkgStatus;
	}
	public void setPkgStatus(String pkgStatus) {
		this.pkgStatus = pkgStatus;
	}
	public String getPkgNumUnit() {
		return pkgNumUnit;
	}
	public void setPkgNumUnit(String pkgNumUnit) {
		this.pkgNumUnit = pkgNumUnit;
	}
	public String getOrdDanui() {
		return ordDanui;
	}
	public void setOrdDanui(String ordDanui) {
		this.ordDanui = ordDanui;
	}
	public String getPkgTotal() {
		return pkgTotal;
	}
	public void setPkgTotal(String pkgTotal) {
		this.pkgTotal = pkgTotal;
	}
	public String getPkgTotalUnit() {
		return pkgTotalUnit;
	}
	public void setPkgTotalUnit(String pkgTotalUnit) {
		this.pkgTotalUnit = pkgTotalUnit;
	}
	public String getClsif() {
		return clsif;
	}
	public void setClsif(String clsif) {
		this.clsif = clsif;
	}
	public String getManufComp() {
		return manufComp;
	}
	public void setManufComp(String manufComp) {
		this.manufComp = manufComp;
	}
	public String getSalesComp() {
		return salesComp;
	}
	public void setSalesComp(String salesComp) {
		this.salesComp = salesComp;
	}
	public String getClsifUpd() {
		return clsifUpd;
	}
	public void setClsifUpd(String clsifUpd) {
		this.clsifUpd = clsifUpd;
	}
	public Date getSgYmd() {
		return sgYmd;
	}
	public void setSgYmd(Date sgYmd) {
		this.sgYmd = sgYmd;
	}

}
