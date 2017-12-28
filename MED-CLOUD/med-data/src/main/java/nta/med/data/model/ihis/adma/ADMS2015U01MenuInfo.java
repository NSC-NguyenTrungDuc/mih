package nta.med.data.model.ihis.adma;

import java.math.BigDecimal;

public class ADMS2015U01MenuInfo {
	private String sysId; 
	private String trId;
	private Double trSeq;
	private String pgmId;
	private String upprMenu;  
	private String pgmNm;
	private String pgmTp;
	private BigDecimal selectFlg;
	public ADMS2015U01MenuInfo(String sysId, String trId, Double trSeq,
			String pgmId, String upprMenu, String pgmNm, String pgmTp,
			BigDecimal selectFlg) {
		super();
		this.sysId = sysId;
		this.trId = trId;
		this.trSeq = trSeq;
		this.pgmId = pgmId;
		this.upprMenu = upprMenu;
		this.pgmNm = pgmNm;
		this.pgmTp = pgmTp;
		this.selectFlg = selectFlg;
	}
	public String getSysId() {
		return sysId;
	}
	public void setSysId(String sysId) {
		this.sysId = sysId;
	}
	public String getTrId() {
		return trId;
	}
	public void setTrId(String trId) {
		this.trId = trId;
	}
	public Double getTrSeq() {
		return trSeq;
	}
	public void setTrSeq(Double trSeq) {
		this.trSeq = trSeq;
	}
	public String getPgmId() {
		return pgmId;
	}
	public void setPgmId(String pgmId) {
		this.pgmId = pgmId;
	}
	public String getUpprMenu() {
		return upprMenu;
	}
	public void setUpprMenu(String upprMenu) {
		this.upprMenu = upprMenu;
	}
	public String getPgmNm() {
		return pgmNm;
	}
	public void setPgmNm(String pgmNm) {
		this.pgmNm = pgmNm;
	}
	public String getPgmTp() {
		return pgmTp;
	}
	public void setPgmTp(String pgmTp) {
		this.pgmTp = pgmTp;
	}
	public BigDecimal getSelectFlg() {
		return selectFlg;
	}
	public void setSelectFlg(BigDecimal selectFlg) {
		this.selectFlg = selectFlg;
	}
}
