package nta.med.data.model.ihis.nuro;

public class NuroRES0102U00UpdateRES0104Info {
	private String userId;
    private String doctor;
    private String sayu;
    private String startDate;
    private String endDate;
    
	public NuroRES0102U00UpdateRES0104Info() {
		super();
	}
	public NuroRES0102U00UpdateRES0104Info(String userId, String doctor,
			String sayu, String startDate, String endDate) {
		super();
		this.userId = userId;
		this.doctor = doctor;
		this.sayu = sayu;
		this.startDate = startDate;
		this.endDate = endDate;
	}
	public String getUserId() {
		return userId;
	}
	public void setUserId(String userId) {
		this.userId = userId;
	}
	public String getDoctor() {
		return doctor;
	}
	public void setDoctor(String doctor) {
		this.doctor = doctor;
	}
	public String getSayu() {
		return sayu;
	}
	public void setSayu(String sayu) {
		this.sayu = sayu;
	}
	public String getStartDate() {
		return startDate;
	}
	public void setStartDate(String startDate) {
		this.startDate = startDate;
	}
	public String getEndDate() {
		return endDate;
	}
	public void setEndDate(String endDate) {
		this.endDate = endDate;
	}
    
}
