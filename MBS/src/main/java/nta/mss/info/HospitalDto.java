package nta.mss.info;

/**
 * 
 * @author DEV-HuanLT
 *
 */
public class HospitalDto {
	private Integer hospitalId;
	private String hospitalCode;
	private String hospitalName;
	private Integer hospitalParentId;
	private String hospitalIconPath;
	private String locale;
	private String email;
	private Byte timeZone;
	private Byte isUseVaccine;
	private Byte isUseMt;
	
	public HospitalDto(Integer hospitalId, String hospitalCode, String hospitalName, Integer hospitalParentId,
			String hospitalIconPath, String locale, String email, Byte timeZone, Byte isUseVaccine, Byte isUseMt) {
		super();
		this.hospitalId = hospitalId;
		this.hospitalCode = hospitalCode;
		this.hospitalName = hospitalName;
		this.hospitalParentId = hospitalParentId;
		this.hospitalIconPath = hospitalIconPath;
		this.locale = locale;
		this.email = email;
		this.timeZone = timeZone;
		this.isUseVaccine = isUseVaccine;
		this.isUseMt = isUseMt;
	}
	public Integer getHospitalId() {
		return hospitalId;
	}
	public void setHospitalId(Integer hospitalId) {
		this.hospitalId = hospitalId;
	}
	public String getHospitalCode() {
		return hospitalCode;
	}
	public void setHospitalCode(String hospitalCode) {
		this.hospitalCode = hospitalCode;
	}
	public String getHospitalName() {
		return hospitalName;
	}
	public void setHospitalName(String hospitalName) {
		this.hospitalName = hospitalName;
	}
	public Integer getHospitalParentId() {
		return hospitalParentId;
	}
	public void setHospitalParentId(Integer hospitalParentId) {
		this.hospitalParentId = hospitalParentId;
	}
	public String getHospitalIconPath() {
		return hospitalIconPath;
	}
	public void setHospitalIconPath(String hospitalIconPath) {
		this.hospitalIconPath = hospitalIconPath;
	}
	public String getLocale() {
		return locale;
	}
	public void setLocale(String locale) {
		this.locale = locale;
	}
	public String getEmail() {
		return email;
	}
	public void setEmail(String email) {
		this.email = email;
	}
	
	public Byte getTimeZone() {
		return timeZone;
	}

	public void setTimeZone(Byte timeZone) {
		this.timeZone = timeZone;
	}
	
	public Byte getIsUseVaccine() {
		return isUseVaccine;
	}

	public void setIsUseVaccine(Byte isUseVaccine) {
		this.isUseVaccine = isUseVaccine;
	}
	
	public Byte getIsUseMt() {
		return isUseMt;
	}
	public void setIsUseMt(Byte isUseMt) {
		this.isUseMt = isUseMt;
	}
	@Override
	public String toString() {
		return "HospitalDto [hospitalId=" + hospitalId + ", hospitalCode=" + hospitalCode + ", hospitalName="
				+ hospitalName + ", hospitalParentId=" + hospitalParentId + ", hospitalIconPath=" + hospitalIconPath
				+ ", locale=" + locale + ", email=" + email + ", timeZone=" + timeZone + ", isUseVaccine="
				+ isUseVaccine + ", isUseMt=" + isUseMt + "]";
	}

	
	
}
