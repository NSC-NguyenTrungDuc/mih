package nta.med.core.domain.mss;

import java.io.Serializable;
import java.math.BigDecimal;
import java.sql.Timestamp;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.GeneratedValue;
import javax.persistence.GenerationType;
import javax.persistence.Id;
import javax.persistence.NamedQuery;
import javax.persistence.Table;


/**
 * The persistent class for the hospital database table.
 * 
 */
@Entity
@Table(name = "hospital")
@NamedQuery(name="Hospital.findAll", query="SELECT h FROM Hospital h")
public class Hospital implements Serializable {
	private static final long serialVersionUID = 1L;
	private Integer hospitalId;
	private BigDecimal activeFlg;
	private String address;
	private Timestamp created;
	private String email;
	private String hospitalCode;
	private String hospitalIconPath;
	private String hospitalName;
	private String hospitalNameFurigana;
	private BigDecimal hospitalType;
	private String locale;
	private String phoneNumber;
	private Timestamp updated;
	private Integer hospitalParentId;
	private Integer isUseMt;
	private Integer isUseMis;

	public Hospital() {
	}


	@Id
	@GeneratedValue(strategy = GenerationType.IDENTITY)
	@Column(name="hospital_id", unique = true, nullable = false)
	public Integer getHospitalId() {
		return this.hospitalId;
	}

	public void setHospitalId(Integer hospitalId) {
		this.hospitalId = hospitalId;
	}


	@Column(name="active_flg")
	public BigDecimal getActiveFlg() {
		return this.activeFlg;
	}

	public void setActiveFlg(BigDecimal activeFlg) {
		this.activeFlg = activeFlg;
	}


	public String getAddress() {
		return this.address;
	}

	public void setAddress(String address) {
		this.address = address;
	}


	public Timestamp getCreated() {
		return this.created;
	}

	public void setCreated(Timestamp created) {
		this.created = created;
	}


	public String getEmail() {
		return this.email;
	}

	public void setEmail(String email) {
		this.email = email;
	}


	@Column(name="hospital_code")
	public String getHospitalCode() {
		return this.hospitalCode;
	}

	public void setHospitalCode(String hospitalCode) {
		this.hospitalCode = hospitalCode;
	}


	@Column(name="hospital_icon_path")
	public String getHospitalIconPath() {
		return this.hospitalIconPath;
	}

	public void setHospitalIconPath(String hospitalIconPath) {
		this.hospitalIconPath = hospitalIconPath;
	}


	@Column(name="hospital_name")
	public String getHospitalName() {
		return this.hospitalName;
	}

	public void setHospitalName(String hospitalName) {
		this.hospitalName = hospitalName;
	}


	@Column(name="hospital_name_furigana")
	public String getHospitalNameFurigana() {
		return this.hospitalNameFurigana;
	}

	public void setHospitalNameFurigana(String hospitalNameFurigana) {
		this.hospitalNameFurigana = hospitalNameFurigana;
	}

	@Column(name="hospital_type")
	public BigDecimal getHospitalType() {
		return this.hospitalType;
	}

	public void setHospitalType(BigDecimal hospitalType) {
		this.hospitalType = hospitalType;
	}

	public String getLocale() {
		return this.locale;
	}

	public void setLocale(String locale) {
		this.locale = locale;
	}


	@Column(name="phone_number")
	public String getPhoneNumber() {
		return this.phoneNumber;
	}

	public void setPhoneNumber(String phoneNumber) {
		this.phoneNumber = phoneNumber;
	}


	public Timestamp getUpdated() {
		return this.updated;
	}

	public void setUpdated(Timestamp updated) {
		this.updated = updated;
	}

	@Column(name = "hospital_parent_id")
	public Integer getHospitalParentId() {
		return hospitalParentId;
	}


	public void setHospitalParentId(Integer hospitalParentId) {
		this.hospitalParentId = hospitalParentId;
	}

	@Column(name = "is_use_mt")
	public Integer getIsUseMt() {
		return isUseMt;
	}


	public void setIsUseMt(Integer isUseMt) {
		this.isUseMt = isUseMt;
	}

	@Column(name = "is_use_mis")
	public Integer getIsUseMis() {
		return isUseMis;
	}


	public void setIsUseMis(Integer isUseMis) {
		this.isUseMis = isUseMis;
	}

}