package nta.med.data.model.ihis.adma;

import java.math.BigDecimal;

public class ADMS2015U00GetSystemHospitalInfo {
	private String admsGroupSystemId;
	private String sysId;
	private String sysSeq;
	private String hospCode;
	private String selectFlg;
	private String sysNm;
	public ADMS2015U00GetSystemHospitalInfo(String admsGroupSystemId,
			String sysId, String sysSeq, String hospCode, String selectFlg,
			String sysNm) {
		super();
		this.admsGroupSystemId = admsGroupSystemId;
		this.sysId = sysId;
		this.sysSeq = sysSeq;
		this.hospCode = hospCode;
		this.selectFlg = selectFlg;
		this.sysNm = sysNm;
	}
	public String getAdmsGroupSystemId() {
		return admsGroupSystemId;
	}
	public void setAdmsGroupSystemId(String admsGroupSystemId) {
		this.admsGroupSystemId = admsGroupSystemId;
	}
	public String getSysId() {
		return sysId;
	}
	public void setSysId(String sysId) {
		this.sysId = sysId;
	}
	public String getSysSeq() {
		return sysSeq;
	}
	public void setSysSeq(String sysSeq) {
		this.sysSeq = sysSeq;
	}
	public String getHospCode() {
		return hospCode;
	}
	public void setHospCode(String hospCode) {
		this.hospCode = hospCode;
	}
	public String getSelectFlg() {
		return selectFlg;
	}
	public void setSelectFlg(String selectFlg) {
		this.selectFlg = selectFlg;
	}
	public String getSysNm() {
		return sysNm;
	}
	public void setSysNm(String sysNm) {
		this.sysNm = sysNm;
	}

}
