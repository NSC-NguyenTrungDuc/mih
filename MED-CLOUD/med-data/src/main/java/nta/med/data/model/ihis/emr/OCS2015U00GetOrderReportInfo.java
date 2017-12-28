package nta.med.data.model.ihis.emr;

public class OCS2015U00GetOrderReportInfo {
	private String hangmogCode;
	private String hangmogName;
	private Double suryang ;
	private Double dv;
	private Double nalsu;
	private String bogyongName;
	private String codeName;
	private Double dvQuantity ;
	public OCS2015U00GetOrderReportInfo(String hangmogCode, String hangmogName, Double suryang, Double dv, Double nalsu,
			String bogyongName, String codeName, Double dvQuantity) {
		super();
		this.hangmogCode = hangmogCode;
		this.hangmogName = hangmogName;
		this.suryang = suryang;
		this.dv = dv;
		this.nalsu = nalsu;
		this.bogyongName = bogyongName;
		this.codeName = codeName;
		this.dvQuantity = dvQuantity;
	}
	public String getHangmogCode() {
		return hangmogCode;
	}
	public void setHangmogCode(String hangmogCode) {
		this.hangmogCode = hangmogCode;
	}
	public String getHangmogName() {
		return hangmogName;
	}
	public void setHangmogName(String hangmogName) {
		this.hangmogName = hangmogName;
	}
	public Double getSuryang() {
		return suryang;
	}
	public void setSuryang(Double suryang) {
		this.suryang = suryang;
	}
	public Double getDv() {
		return dv;
	}
	public void setDv(Double dv) {
		this.dv = dv;
	}
	public Double getNalsu() {
		return nalsu;
	}
	public void setNalsu(Double nalsu) {
		this.nalsu = nalsu;
	}
	public String getBogyongName() {
		return bogyongName;
	}
	public void setBogyongName(String bogyongName) {
		this.bogyongName = bogyongName;
	}
	public String getCodeName() {
		return codeName;
	}
	public void setCodeName(String codeName) {
		this.codeName = codeName;
	}
	public Double getDvQuantity() {
		return dvQuantity;
	}
	public void setDvQuantity(Double dvQuantity) {
		this.dvQuantity = dvQuantity;
	}
	
}
