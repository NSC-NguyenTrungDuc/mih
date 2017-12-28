package nta.med.data.model.ihis.nuri;

import java.util.Date;

public class NUR1020U00grdNUR1022INInfo {

	private String bunho;
	private Double fkinp1001;
	private Date ymd;
	private String type;
	private String typeName;
	private String gubn;
	private String value;

	public NUR1020U00grdNUR1022INInfo(String bunho, Double fkinp1001, Date ymd, String type, String typeName,
			String gubn, String value) {
		super();
		this.bunho = bunho;
		this.fkinp1001 = fkinp1001;
		this.ymd = ymd;
		this.type = type;
		this.typeName = typeName;
		this.gubn = gubn;
		this.value = value;
	}

	public String getBunho() {
		return bunho;
	}

	public void setBunho(String bunho) {
		this.bunho = bunho;
	}

	public Double getFkinp1001() {
		return fkinp1001;
	}

	public void setFkinp1001(Double fkinp1001) {
		this.fkinp1001 = fkinp1001;
	}

	public Date getYmd() {
		return ymd;
	}

	public void setYmd(Date ymd) {
		this.ymd = ymd;
	}

	public String getType() {
		return type;
	}

	public void setType(String type) {
		this.type = type;
	}

	public String getTypeName() {
		return typeName;
	}

	public void setTypeName(String typeName) {
		this.typeName = typeName;
	}

	public String getGubn() {
		return gubn;
	}

	public void setGubn(String gubn) {
		this.gubn = gubn;
	}

	public String getValue() {
		return value;
	}

	public void setValue(String value) {
		this.value = value;
	}

}
