package nta.med.data.model.ihis.ocsa;

import java.util.Date;

public class OCS0103U00LayCommonJaeryoCodeInfo {
	private String jaeryoName ;
	private Date bulyongDate ;
	public OCS0103U00LayCommonJaeryoCodeInfo(String jaeryoName, Date bulyongDate) {
		super();
		this.jaeryoName = jaeryoName;
		this.bulyongDate = bulyongDate;
	}
	public String getJaeryoName() {
		return jaeryoName;
	}
	public void setJaeryoName(String jaeryoName) {
		this.jaeryoName = jaeryoName;
	}
	public Date getBulyongDate() {
		return bulyongDate;
	}
	public void setBulyongDate(Date bulyongDate) {
		this.bulyongDate = bulyongDate;
	}
	
}
