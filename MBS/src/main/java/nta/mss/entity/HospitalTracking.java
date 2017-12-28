package nta.mss.entity;
import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.GeneratedValue;
import javax.persistence.GenerationType;
import javax.persistence.Id;
import javax.persistence.Table;

import nta.mss.model.HospitalTrackingModel;

@Entity
@Table(name = "hospital_tracking")
public class HospitalTracking extends BaseEntity<HospitalTrackingModel>{
	
	private static final long serialVersionUID = 1L;

	@Id
	@GeneratedValue(strategy = GenerationType.IDENTITY)
	@Column(name = "hospital_tracking_id", unique = true, nullable = false)
	private Integer hospitalTrackingId;

	@Column(name = "hospital_id", length = 11, nullable = false)
	private Integer hospitalId;

	@Column(name = "tracking_script", length = 2000)
	private String trackingScript;

	@Column(name = "page_code", length = 30)
	private String pageCode;
	
	public HospitalTracking() {
		super(HospitalTrackingModel.class);
	}

	public Integer getHospitalTrackingId() {
		return hospitalTrackingId;
	}

	public void setHospitalTrackingId(Integer hospitalTrackingId) {
		this.hospitalTrackingId = hospitalTrackingId;
	}

	public Integer getHospitalId() {
		return hospitalId;
	}

	public void setHospitalId(Integer hospitalId) {
		this.hospitalId = hospitalId;
	}

	public String getTrackingScript() {
		return trackingScript;
	}

	public void setTrackingScript(String trackingScript) {
		this.trackingScript = trackingScript;
	}

	public String getPageCode() {
		return pageCode;
	}

	public void setPageCode(String pageCode) {
		this.pageCode = pageCode;
	}

}
