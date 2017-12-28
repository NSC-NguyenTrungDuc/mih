package nta.med.data.model.ihis.phys;

import java.util.Date;

public class PHY2001U04BtnDeleteGetDataTableInfo {
	private Double pkout1001         ;
	private Double  pkocs1003        ;
	private String  hangmogCode      ;
	private Double  sinryouryouGubun ;
	private Date  sunabDate        ;
	public PHY2001U04BtnDeleteGetDataTableInfo(Double pkout1001,
			Double pkocs1003, String hangmogCode, Double sinryouryouGubun,
			Date sunabDate) {
		super();
		this.pkout1001 = pkout1001;
		this.pkocs1003 = pkocs1003;
		this.hangmogCode = hangmogCode;
		this.sinryouryouGubun = sinryouryouGubun;
		this.sunabDate = sunabDate;
	}
	public Double getPkout1001() {
		return pkout1001;
	}
	public void setPkout1001(Double pkout1001) {
		this.pkout1001 = pkout1001;
	}
	public Double getPkocs1003() {
		return pkocs1003;
	}
	public void setPkocs1003(Double pkocs1003) {
		this.pkocs1003 = pkocs1003;
	}
	public String getHangmogCode() {
		return hangmogCode;
	}
	public void setHangmogCode(String hangmogCode) {
		this.hangmogCode = hangmogCode;
	}
	public Double getSinryouryouGubun() {
		return sinryouryouGubun;
	}
	public void setSinryouryouGubun(Double sinryouryouGubun) {
		this.sinryouryouGubun = sinryouryouGubun;
	}
	public Date getSunabDate() {
		return sunabDate;
	}
	public void setSunabDate(Date sunabDate) {
		this.sunabDate = sunabDate;
	}
	
}
