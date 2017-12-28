package nta.med.data.model.ihis.schs;

public class SchsSCH0201Q02ReserList03ItemInfo {
	private String reserDate ;
    private String suname;
    private String inOutGubun;
    private String bunho;
    private String actingDate ;
    private String comments;
    private String jundalPartName;
    private String gwaName;       
    private String updName;
    private String contKey;
    
	public SchsSCH0201Q02ReserList03ItemInfo(String reserDate, String suname,
			String inOutGubun, String bunho, String actingDate,
			String comments, String jundalPartName, String gwaName,
			String updName, String contKey) {
		super();
		this.reserDate = reserDate;
		this.suname = suname;
		this.inOutGubun = inOutGubun;
		this.bunho = bunho;
		this.actingDate = actingDate;
		this.comments = comments;
		this.jundalPartName = jundalPartName;
		this.gwaName = gwaName;
		this.updName = updName;
		this.contKey = contKey;
	}

	public String getReserDate() {
		return reserDate;
	}

	public void setReserDate(String reserDate) {
		this.reserDate = reserDate;
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

	public String getBunho() {
		return bunho;
	}

	public void setBunho(String bunho) {
		this.bunho = bunho;
	}

	public String getActingDate() {
		return actingDate;
	}

	public void setActingDate(String actingDate) {
		this.actingDate = actingDate;
	}

	public String getComments() {
		return comments;
	}

	public void setComments(String comments) {
		this.comments = comments;
	}

	public String getJundalPartName() {
		return jundalPartName;
	}

	public void setJundalPartName(String jundalPartName) {
		this.jundalPartName = jundalPartName;
	}

	public String getGwaName() {
		return gwaName;
	}

	public void setGwaName(String gwaName) {
		this.gwaName = gwaName;
	}

	public String getUpdName() {
		return updName;
	}

	public void setUpdName(String updName) {
		this.updName = updName;
	}

	public String getContKey() {
		return contKey;
	}

	public void setContKey(String contKey) {
		this.contKey = contKey;
	}        
    
	

}
