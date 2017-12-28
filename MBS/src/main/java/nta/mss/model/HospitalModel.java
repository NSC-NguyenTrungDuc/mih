package nta.mss.model;

import java.util.List;
import java.util.Map;

import org.hibernate.validator.constraints.NotEmpty;
import org.springframework.web.multipart.MultipartFile;

import nta.mss.entity.Hospital;
import nta.mss.validation.Email;
import nta.mss.validation.FuriganaText;
import nta.mss.validation.Phone;

/**
 * The Class HospitalModel.
 * 
 * @author DinhNX
 * @CrtDate Jul 29, 2014
 */
public class HospitalModel extends BaseModel<Hospital> {
	
	/** The Constant serialVersionUID. */
	private static final long serialVersionUID = 3402701871014539833L;
	
	private Integer hospitalId;
	private String hospitalCode;
	@NotEmpty(message="{be202.validate}")
	private String address;
	@NotEmpty(message="{be202.validate}")
	@Email(message="{be202.email.validate}")
	private String email;
	@NotEmpty(message="{be202.validate}")
	private String hospitalName;
	@NotEmpty(message="{be202.validate}")
	@FuriganaText
	private String hospitalNameFurigana;
	private Integer hospitalType;
	@NotEmpty(message="{be202.validate}")
	@Phone
	private String phoneNumber;
	private Integer isHideDeptType;
	private Integer isUseSms;
	private Integer isUseMt;
	private List<DepartmentModel> departments;
	private Map<Integer, List<DoctorModel>> mapDeptIdWithListDoctor;
	private Integer hospitalParentId;
	private String hospitalIconPath;
	private String locale;
	
	private MultipartFile file;
	
	/**
	 * Instantiates a new hospital model.
	 */
	public HospitalModel() {
		super(Hospital.class);
	}

	public Integer getHospitalId() {
		return hospitalId;
	}

	public void setHospitalId(Integer hospitalId) {
		this.hospitalId = hospitalId;
	}

	public String getAddress() {
		return address;
	}

	public void setAddress(String address) {
		this.address = address;
	}

	public String getEmail() {
		return email;
	}

	public void setEmail(String email) {
		this.email = email;
	}

	public String getHospitalName() {
		return hospitalName;
	}

	public void setHospitalName(String hospitalName) {
		this.hospitalName = hospitalName;
	}

	public String getHospitalNameFurigana() {
		return hospitalNameFurigana;
	}

	public void setHospitalNameFurigana(String hospitalNameFurigana) {
		this.hospitalNameFurigana = hospitalNameFurigana;
	}

	public Integer getHospitalType() {
		return hospitalType;
	}

	public void setHospitalType(Integer hospitalType) {
		this.hospitalType = hospitalType;
	}

	public String getPhoneNumber() {
		return phoneNumber;
	}

	public void setPhoneNumber(String phoneNumber) {
		this.phoneNumber = phoneNumber;
	}
	public Integer getIsHideDeptType() {
		return isHideDeptType;
	}

	public void setIsHideDeptType(Integer isHideDeptType) {
		this.isHideDeptType = isHideDeptType;
	}

	public Integer getIsUseMt() {
		return isUseMt;
	}

	public void setIsUseMt(Integer isUseMt) {
		this.isUseMt = isUseMt;
	}

	public List<DepartmentModel> getDepartments() {
		return departments;
	}

	public void setDepartments(List<DepartmentModel> departments) {
		this.departments = departments;
	}

	public Map<Integer, List<DoctorModel>> getMapDeptIdWithListDoctor() {
		return mapDeptIdWithListDoctor;
	}

	public void setMapDeptIdWithListDoctor(
			Map<Integer, List<DoctorModel>> mapDeptIdWithListDoctor) {
		this.mapDeptIdWithListDoctor = mapDeptIdWithListDoctor;
	}

	public String getHospitalCode() {
		return hospitalCode;
	}

	public void setHospitalCode(String hospitalCode) {
		this.hospitalCode = hospitalCode;
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
	
	public MultipartFile getFile() {
		return file;
	}

	public void setFile(MultipartFile file) {
		this.file = file;
	}

	public Integer getIsUseSms() {
		return isUseSms;
	}

	public void setIsUseSms(Integer isUseSms) {
		this.isUseSms = isUseSms;
	}
	
	
	public boolean isUseSms(){
		return this.isUseSms != null && this.isUseSms.equals(1);
	}
	
	
}
