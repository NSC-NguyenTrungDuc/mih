package nta.med.data.model.ihis.nuri;

import java.util.Date;

public class NUR4005U01GrdNUR4005Info {

	private String fknur4001;
	private String gubun;
	private Date reserDate;
	private String valuContents;
	private Date valuDate;
	private String valuer;
	private String valuerName;

	public NUR4005U01GrdNUR4005Info(String fknur4001, String gubun, Date reserDate, String valuContents, Date valuDate,
			String valuer, String valuerName) {
		super();
		this.fknur4001 = fknur4001;
		this.gubun = gubun;
		this.reserDate = reserDate;
		this.valuContents = valuContents;
		this.valuDate = valuDate;
		this.valuer = valuer;
		this.valuerName = valuerName;
	}

	public String getFknur4001() {
		return fknur4001;
	}

	public void setFknur4001(String fknur4001) {
		this.fknur4001 = fknur4001;
	}

	public String getGubun() {
		return gubun;
	}

	public void setGubun(String gubun) {
		this.gubun = gubun;
	}

	public Date getReserDate() {
		return reserDate;
	}

	public void setReserDate(Date reserDate) {
		this.reserDate = reserDate;
	}

	public String getValuContents() {
		return valuContents;
	}

	public void setValuContents(String valuContents) {
		this.valuContents = valuContents;
	}

	public Date getValuDate() {
		return valuDate;
	}

	public void setValuDate(Date valuDate) {
		this.valuDate = valuDate;
	}

	public String getValuer() {
		return valuer;
	}

	public void setValuer(String valuer) {
		this.valuer = valuer;
	}

	public String getValuerName() {
		return valuerName;
	}

	public void setValuerName(String valuerName) {
		this.valuerName = valuerName;
	}

}
