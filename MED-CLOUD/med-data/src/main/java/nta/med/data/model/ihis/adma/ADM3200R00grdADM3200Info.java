package nta.med.data.model.ihis.adma;

public class ADM3200R00grdADM3200Info {
	
	private String userId;
	private String userName;
	private String buseoName;
	private String coId;
	
	public ADM3200R00grdADM3200Info(String userId, String userName, String buseoName, String coId){
		this.userId = userId;
		this.userName = userName;
		this.buseoName = buseoName;
		this.coId = coId;
	}

	public String getUserId() {
		return userId;
	}

	public void setUserId(String userId) {
		this.userId = userId;
	}

	public String getUserName() {
		return userName;
	}

	public void setUserName(String userName) {
		this.userName = userName;
	}

	public String getBuseoName() {
		return buseoName;
	}

	public void setBuseoName(String buseoName) {
		this.buseoName = buseoName;
	}

	public String getCoId() {
		return coId;
	}

	public void setCoId(String coId) {
		this.coId = coId;
	}
	
	

}
