package nta.med.data.model.ihis.ocsa;

import java.io.Serializable;
import java.util.Date;

public class OCS0103U00LayCommonInfo implements Serializable {
	private String name          ; 
	private Date bulyong       ; 
	private String drgYn         ;
	public OCS0103U00LayCommonInfo(String name, Date bulyong, String drgYn) {
		super();
		this.name = name;
		this.bulyong = bulyong;
		this.drgYn = drgYn;
	}
	public String getName() {
		return name;
	}
	public void setName(String name) {
		this.name = name;
	}
	public Date getBulyong() {
		return bulyong;
	}
	public void setBulyong(Date bulyong) {
		this.bulyong = bulyong;
	}
	public String getDrgYn() {
		return drgYn;
	}
	public void setDrgYn(String drgYn) {
		this.drgYn = drgYn;
	}
}
