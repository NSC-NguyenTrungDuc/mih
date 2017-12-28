package nta.mss.entity;

import java.util.List;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.FetchType;
import javax.persistence.GeneratedValue;
import javax.persistence.GenerationType;
import javax.persistence.Id;
import javax.persistence.OneToMany;
import javax.persistence.Table;

import nta.mss.model.HospitalModel;

/**
 * The persistent class for the hospital database table.
 * 
 */
@Entity
@Table(name = "hospital")
public class Hospital extends BaseEntity<HospitalModel> {
	private static final long serialVersionUID = -3739748781054398217L;

	@Id
	@GeneratedValue(strategy = GenerationType.IDENTITY)
	@Column(name = "hospital_id", unique = true, nullable = false)
	private Integer hospitalId;
	
	@Column(name = "hospital_code", length = 16, nullable = false)
	private String hospitalCode;

	@Column(name = "address", length = 256)
	private String address;

	@Column(name = "email", length = 128)
	private String email;

	@Column(name = "hospital_name", length = 256)
	private String hospitalName;

	@Column(name = "hospital_name_furigana", length = 256)
	private String hospitalNameFurigana;

	@Column(name = "hospital_type")
	private Integer hospitalType;

	@Column(name = "phone_number", length = 64)
	private String phoneNumber;
	
	@Column(name = "is_hide_dept_type", length = 3)
	private Integer isHideDeptType;	

	// bi-directional many-to-one association to Deparment
	@OneToMany(mappedBy = "hospital", fetch = FetchType.LAZY)
	private List<Department> departments;

	// bi-directional many-to-one association to HospitalSchedule
	@OneToMany(mappedBy = "hospital", fetch = FetchType.LAZY)
	private List<HospitalSchedule> hospitalSchedules;

	// bi-directional many-to-one association to Deparment
	@OneToMany(mappedBy = "hospital", fetch = FetchType.LAZY)
	private List<User> users;
	
	@Column(name = "hospital_parent_id")
	private Integer hospitalParentId;
	
	@Column(name = "is_use_sms")
	private Integer isUseSms;
	
	@Column(name = "is_use_mt")
	private Integer isUseMt;	
	@Column(name = "hospital_icon_path", length = 256)
	private String hospitalIconPath;
	
	@Column(name = "locale")
	private String locale;
	
	/**
	 * Instantiates a new hospital.
	 */
	public Hospital() {
		super(HospitalModel.class);
	}

	public Integer getHospitalId() {
		return this.hospitalId;
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

	public String getAddress() {
		return this.address;
	}

	public void setAddress(String address) {
		this.address = address;
	}

	public String getEmail() {
		return this.email;
	}

	public void setEmail(String email) {
		this.email = email;
	}

	public String getHospitalName() {
		return this.hospitalName;
	}

	public void setHospitalName(String hospitalName) {
		this.hospitalName = hospitalName;
	}

	public String getHospitalNameFurigana() {
		return this.hospitalNameFurigana;
	}

	public void setHospitalNameFurigana(String hospitalNameFurigana) {
		this.hospitalNameFurigana = hospitalNameFurigana;
	}

	public Integer getHospitalType() {
		return this.hospitalType;
	}

	public void setHospitalType(Integer hospitalType) {
		this.hospitalType = hospitalType;
	}

	public String getPhoneNumber() {
		return this.phoneNumber;
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

	public List<Department> getDepartments() {
		return this.departments;
	}

	public void setDepartments(List<Department> departments) {
		this.departments = departments;
	}

	public List<HospitalSchedule> getHospitalSchedules() {
		return this.hospitalSchedules;
	}

	public void setHospitalSchedules(List<HospitalSchedule> hospitalSchedules) {
		this.hospitalSchedules = hospitalSchedules;
	}
	
	public List<User> getUsers() {
		return this.users;
	}

	public void setUsers(List<User> users) {
		this.users = users;
	}

	public Integer getHospitalParentId() {
		return hospitalParentId;
	}

	public void setHospitalParentId(Integer hospitalParentId) {
		this.hospitalParentId = hospitalParentId;
	}
	
	public Integer getIsUseSms() {
		return isUseSms;
	}

	public void setIsUseSms(Integer isUseSms) {
		this.isUseSms = isUseSms;
	}

	
	public Integer getIsUseMt() {
		return isUseMt;
	}

	public void setIsUseMt(Integer isUseMt) {
		this.isUseMt = isUseMt;
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
	
}