package nta.med.data.model.ihis.adma;

public class ADMS2015U00GetHospitalInfo {
	private String hospCode;
	private String yoyangName;
	private String yoyangName2;
	public ADMS2015U00GetHospitalInfo(String hospCode, String yoyangName,
			String yoyangName2) {
		super();
		this.hospCode = hospCode;
		this.yoyangName = yoyangName;
		this.yoyangName2 = yoyangName2;
	}
	public String getHospCode() {
		return hospCode;
	}
	public void setHospCode(String hospCode) {
		this.hospCode = hospCode;
	}
	public String getYoyangName() {
		return yoyangName;
	}
	public void setYoyangName(String yoyangName) {
		this.yoyangName = yoyangName;
	}
	public String getYoyangName2() {
		return yoyangName2;
	}
	public void setYoyangName2(String yoyangName2) {
		this.yoyangName2 = yoyangName2;
	}
	
}
