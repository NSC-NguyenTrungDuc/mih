package nta.med.data.model.ihis.ocsa;

import java.util.Date;

public class OCS0103U00GrdOCS0108Info {
	private String hangmogCode       ;            
	private String ordDanui          ;                         
	private Double seq                ;                         
	private Double sunabGijun        ;
	private Double subulGijun        ;
	private String hospCode          ;                         
	private Date hangmogStartDate ;                         
	private String codeName1         ;
	private String codeName2         ;
	public OCS0103U00GrdOCS0108Info(String hangmogCode, String ordDanui,
			Double seq, Double sunabGijun, Double subulGijun, String hospCode,
			Date hangmogStartDate, String codeName1, String codeName2) {
		super();
		this.hangmogCode = hangmogCode;
		this.ordDanui = ordDanui;
		this.seq = seq;
		this.sunabGijun = sunabGijun;
		this.subulGijun = subulGijun;
		this.hospCode = hospCode;
		this.hangmogStartDate = hangmogStartDate;
		this.codeName1 = codeName1;
		this.codeName2 = codeName2;
	}
	public String getHangmogCode() {
		return hangmogCode;
	}
	public void setHangmogCode(String hangmogCode) {
		this.hangmogCode = hangmogCode;
	}
	public String getOrdDanui() {
		return ordDanui;
	}
	public void setOrdDanui(String ordDanui) {
		this.ordDanui = ordDanui;
	}
	public Double getSeq() {
		return seq;
	}
	public void setSeq(Double seq) {
		this.seq = seq;
	}
	public Double getSunabGijun() {
		return sunabGijun;
	}
	public void setSunabGijun(Double sunabGijun) {
		this.sunabGijun = sunabGijun;
	}
	public Double getSubulGijun() {
		return subulGijun;
	}
	public void setSubulGijun(Double subulGijun) {
		this.subulGijun = subulGijun;
	}
	public String getHospCode() {
		return hospCode;
	}
	public void setHospCode(String hospCode) {
		this.hospCode = hospCode;
	}
	public Date getHangmogStartDate() {
		return hangmogStartDate;
	}
	public void setHangmogStartDate(Date hangmogStartDate) {
		this.hangmogStartDate = hangmogStartDate;
	}
	public String getCodeName1() {
		return codeName1;
	}
	public void setCodeName1(String codeName1) {
		this.codeName1 = codeName1;
	}
	public String getCodeName2() {
		return codeName2;
	}
	public void setCodeName2(String codeName2) {
		this.codeName2 = codeName2;
	}
	
}
