package nta.med.data.model.ihis.system;

import java.util.Date;

public class PrOcsLoadIpwonReserInfo {
	private Date reserDate;
    private String ipwonGwa;
    private String parentGwa;
    private String resident;
    private String flag;
	public PrOcsLoadIpwonReserInfo(Date reserDate, String ipwonGwa,
			String parentGwa, String resident, String flag) {
		super();
		this.reserDate = reserDate;
		this.ipwonGwa = ipwonGwa;
		this.parentGwa = parentGwa;
		this.resident = resident;
		this.flag = flag;
	}
	public Date getReserDate() {
		return reserDate;
	}
	public void setReserDate(Date reserDate) {
		this.reserDate = reserDate;
	}
	public String getIpwonGwa() {
		return ipwonGwa;
	}
	public void setIpwonGwa(String ipwonGwa) {
		this.ipwonGwa = ipwonGwa;
	}
	public String getParentGwa() {
		return parentGwa;
	}
	public void setParentGwa(String parentGwa) {
		this.parentGwa = parentGwa;
	}
	public String getResident() {
		return resident;
	}
	public void setResident(String resident) {
		this.resident = resident;
	}
	public String getFlag() {
		return flag;
	}
	public void setFlag(String flag) {
		this.flag = flag;
	}
}
