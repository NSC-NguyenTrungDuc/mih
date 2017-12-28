package nta.med.data.model.ihis.nuro;

public class NUR2016U02TranferSgCodeInfo {
	private String hangmogCode;
	private Double pkocs1003;
	private String hangmogName;
	private String sgCode;
	private String actingDate;
	public NUR2016U02TranferSgCodeInfo(String hangmogCode, Double pkocs1003, String hangmogName, String sgCode,
			String actingDate) {
		super();
		this.hangmogCode = hangmogCode;
		this.pkocs1003 = pkocs1003;
		this.hangmogName = hangmogName;
		this.sgCode = sgCode;
		this.actingDate = actingDate;
	}
	public String getHangmogCode() {
		return hangmogCode;
	}
	public void setHangmogCode(String hangmogCode) {
		this.hangmogCode = hangmogCode;
	}
	public Double getPkocs1003() {
		return pkocs1003;
	}
	public void setPkocs1003(Double pkocs1003) {
		this.pkocs1003 = pkocs1003;
	}
	public String getHangmogName() {
		return hangmogName;
	}
	public void setHangmogName(String hangmogName) {
		this.hangmogName = hangmogName;
	}
	public String getSgCode() {
		return sgCode;
	}
	public void setSgCode(String sgCode) {
		this.sgCode = sgCode;
	}
	public String getActingDate() {
		return actingDate;
	}
	public void setActingDate(String actingDate) {
		this.actingDate = actingDate;
	}

}
