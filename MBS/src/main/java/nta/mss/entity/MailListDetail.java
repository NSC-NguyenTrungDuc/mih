package nta.mss.entity;

import java.io.Serializable;

import javax.persistence.Column;
import javax.persistence.EmbeddedId;
import javax.persistence.Entity;
import javax.persistence.Table;

import nta.mss.model.MailListDetailModel;

/**
 * The persistent class for the mail_list_detail database table.
 * 
 * @author linhnt
 */
@Entity
@Table(name = "mail_list_detail")
public class MailListDetail extends BaseEntity<MailListDetailModel> implements
		Serializable {
	private static final long serialVersionUID = 1L;

	@EmbeddedId
	private MailListDetailPK id;

	@Column(name = "name", length = 64)
	private String name;

	@Column(name = "phone")
	private String phone;
	
	@Column(name = "patient_id")
	private Integer patientId;
	
	@Column(name = "hospital_id")
	private Integer hospitalId;

	/**
	 * Instantiates a new mail list detail.
	 */
	public MailListDetail() {
		super(MailListDetailModel.class);
	}

	public MailListDetailPK getId() {
		return id;
	}

	public void setId(MailListDetailPK id) {
		this.id = id;
	}

	public String getName() {
		return this.name;
	}

	public void setName(String name) {
		this.name = name;
	}

	public Integer getPatientId() {
		return this.patientId;
	}

	public void setPatientId(Integer patientId) {
		this.patientId = patientId;
	}

	public String getPhone() {
		return phone;
	}

	public void setPhone(String phone) {
		this.phone = phone;
	}	
	public Integer getHospitalId() {
		return hospitalId;
	}

	public void setHospitalId(Integer hospitalId) {
		this.hospitalId = hospitalId;
	}

	@Override
	public String toString() {
		return "MailListDetail [id=" + id + ", name=" + name + ", phone="
				+ phone + ", patientId=" + patientId + "]";
	}
}