package nta.med.data.model.ihis.cpls;

public class CplsCPL2010U00FwkPaCPL2010ListItemInfo {
	private String bunho ;
	private String suname ;
	private String inOutGubun ;
	private String fnBasLoadGwaName ;
	private String orderTime ;
	private String todayYn ;
	private String reserYn ;
	public CplsCPL2010U00FwkPaCPL2010ListItemInfo(String bunho, String suname,
			String inOutGubun, String fnBasLoadGwaName, String orderTime,
			String todayYn, String reserYn) {
		super();
		this.bunho = bunho;
		this.suname = suname;
		this.inOutGubun = inOutGubun;
		this.fnBasLoadGwaName = fnBasLoadGwaName;
		this.orderTime = orderTime;
		this.todayYn = todayYn;
		this.reserYn = reserYn;
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
	public String getInOutGubun() {
		return inOutGubun;
	}
	public void setInOutGubun(String inOutGubun) {
		this.inOutGubun = inOutGubun;
	}
	public String getFnBasLoadGwaName() {
		return fnBasLoadGwaName;
	}
	public void setFnBasLoadGwaName(String fnBasLoadGwaName) {
		this.fnBasLoadGwaName = fnBasLoadGwaName;
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
	
}
