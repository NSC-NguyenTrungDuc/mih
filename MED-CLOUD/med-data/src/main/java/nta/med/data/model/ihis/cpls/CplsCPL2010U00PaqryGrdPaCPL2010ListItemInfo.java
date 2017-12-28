package nta.med.data.model.ihis.cpls;

public class CplsCPL2010U00PaqryGrdPaCPL2010ListItemInfo {
	private String bunho ;
	private String suname ;
	private String inOutGubun ;
	private String gwaName ;
	private String orderTime ;
	private String todayYn ;
	private String reserYn ;
	private String doctorName ;
	public CplsCPL2010U00PaqryGrdPaCPL2010ListItemInfo(String bunho,
			String suname, String in_outGubun, String gwaName,
			String orderTime, String todayYn, String reserYn, String doctorName) {
		super();
		this.bunho = bunho;
		this.suname = suname;
		this.inOutGubun = in_outGubun;
		this.gwaName = gwaName;
		this.orderTime = orderTime;
		this.todayYn = todayYn;
		this.reserYn = reserYn;
		this.doctorName = doctorName;
	}
	public String getBunho() {
		return bunho;
	}
	public void setBunho(String bunho) {
		this.bunho = bunho;
	}
	public String getSuname() {
		return suname;
	}
	public void setSuname(String suname) {
		this.suname = suname;
	}
	public String getIn_outGubun() {
		return inOutGubun;
	}
	public void setIn_outGubun(String in_outGubun) {
		this.inOutGubun = in_outGubun;
	}
	public String getGwaName() {
		return gwaName;
	}
	public void setGwaName(String gwaName) {
		this.gwaName = gwaName;
	}
	public String getOrderTime() {
		return orderTime;
	}
	public void setOrderTime(String orderTime) {
		this.orderTime = orderTime;
	}
	public String getTodayYn() {
		return todayYn;
	}
	public void setTodayYn(String todayYn) {
		this.todayYn = todayYn;
	}
	public String getReserYn() {
		return reserYn;
	}
	public void setReserYn(String reserYn) {
		this.reserYn = reserYn;
	}
	public String getDoctorName() {
		return doctorName;
	}
	public void setDoctorName(String doctorName) {
		this.doctorName = doctorName;
	} 
	
}
