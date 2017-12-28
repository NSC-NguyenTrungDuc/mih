package nta.mss.entity;

import java.io.Serializable;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.GeneratedValue;
import javax.persistence.GenerationType;
import javax.persistence.Id;
import javax.persistence.Table;

import nta.mss.model.MailListModel;

/**
 * The persistent class for the mail_list database table.
 * 
 */
@Entity
@Table(name = "mail_list")
public class MailList extends BaseEntity<MailListModel> implements Serializable {
	private static final long serialVersionUID = 1L;

	@Id
	@GeneratedValue(strategy = GenerationType.IDENTITY)
	@Column(name = "mail_list_id", unique = true, nullable = false)
	private int mailListId;

	@Column(name = "mail_list_name", nullable = false, length = 256)
	private String mailListName;
	
	@Column(name = "hospital_id")
	private Integer hospitalId;

	/**
	 * Instantiates a new mail list.
	 */
	public MailList() {
		super(MailListModel.class);
	}

	public int getMailListId() {
		return this.mailListId;
	}

	public void setMailListId(int mailListId) {
		this.mailListId = mailListId;
	}

	public String getMailListName() {
		return this.mailListName;
	}

	public void setMailListName(String mailListName) {
		this.mailListName = mailListName;
	}

	public Integer getHospitalId() {
		return hospitalId;
	}

	public void setHospitalId(Integer hospitalId) {
		this.hospitalId = hospitalId;
	}
}