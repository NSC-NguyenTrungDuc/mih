package nta.mss.model;

public class HospitalTrackingModel {
	
	//private Integer hospital_tracking_id;
	private Integer hospital_id;
	private String tracking_scripts;
	private String page_code;
	//private Integer active_flg;
	//private Date created;
	//private Date updated;
	
	
	
	public HospitalTrackingModel(Integer hospital_id, String tracking_scripts, String page_code) {
		super();
		this.hospital_id = hospital_id;
		this.tracking_scripts = tracking_scripts;
		this.page_code = page_code;
	}
	/*public Integer getHospital_tracking_id() {
		return hospital_tracking_id;
	}
	public void setHospital_tracking_id(Integer hospital_tracking_id) {
		this.hospital_tracking_id = hospital_tracking_id;
	}*/
	public Integer getHospital_id() {
		return hospital_id;
	}
	public void setHospital_id(Integer hospital_id) {
		this.hospital_id = hospital_id;
	}
	public String getTracking_scripts() {
		return tracking_scripts;
	}
	public void setTracking_scripts(String tracking_scripts) {
		this.tracking_scripts = tracking_scripts;
	}
	public String getPage_code() {
		return page_code;
	}
	public void setPage_code(String page_code) {
		this.page_code = page_code;
	}
	/*public Integer getActive_flg() {
		return active_flg;
	}
	public void setActive_flg(Integer active_flg) {
		this.active_flg = active_flg;
	}
	public Date getCreated() {
		return created;
	}
	public void setCreated(Date created) {
		this.created = created;
	}
	public Date getUpdated() {
		return updated;
	}
	public void setUpdated(Date updated) {
		this.updated = updated;
	}*/
	

}
