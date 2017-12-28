package nta.med.data.model.ihis.adma;

import java.math.BigDecimal;

public class ADMS2015U00SystemHospitalInfo {
	private Integer admsGroupSystemId;
	private Integer sysSeq;
	private String hospCode;
	private BigDecimal selectFlg;
	private String systemId;
	private String sysNm;
	private String rowState;
	public ADMS2015U00SystemHospitalInfo(Integer admsGroupSystemId,
			Integer sysSeq, String hospCode, BigDecimal selectFlg,
			String systemId, String sysNm, String rowState) {
		super();
		this.admsGroupSystemId = admsGroupSystemId;
		this.sysSeq = sysSeq;
		this.hospCode = hospCode;
		this.selectFlg = selectFlg;
		this.systemId = systemId;
		this.sysNm = sysNm;
		this.rowState = rowState;
	}
	public Integer getAdmsGroupSystemId() {
		return admsGroupSystemId;
	}
	public void setAdmsGroupSystemId(Integer admsGroupSystemId) {
		this.admsGroupSystemId = admsGroupSystemId;
	}
	public Integer getSysSeq() {
		return sysSeq;
	}
	public void setSysSeq(Integer sysSeq) {
		this.sysSeq = sysSeq;
	}
	public String getHospCode() {
		return hospCode;
	}
	public void setHospCode(String hospCode) {
		this.hospCode = hospCode;
	}
	public BigDecimal getSelectFlg() {
		return selectFlg;
	}
	public void setSelectFlg(BigDecimal selectFlg) {
		this.selectFlg = selectFlg;
	}
	public String getSystemId() {
		return systemId;
	}
	public void setSystemId(String systemId) {
		this.systemId = systemId;
	}
	public String getSysNm() {
		return sysNm;
	}
	public void setSysNm(String sysNm) {
		this.sysNm = sysNm;
	}
	public String getRowState() {
		return rowState;
	}
	public void setRowState(String rowState) {
		this.rowState = rowState;
	}
	
}
