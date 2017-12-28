package nta.med.core.domain.phr;

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
 * The persistent class for the PHR_STANDARD_HEALTH database table.
 * 
 */
@Entity
@Table(name = "PHR_STANDARD_HEALTH")
@NamedQuery(name = "PhrStandardHealth.findAll", query = "SELECT p FROM PhrStandardHealth p")
public class PhrStandardHealth extends PhrBaseEntity {
	private static final long serialVersionUID = 1L;

	@Id
	@GeneratedValue(strategy = GenerationType.IDENTITY)
	@Column(name = "ID", unique = true, nullable = false)
	private Long id;

	@Column(name = "CHEST_SIZE")
	private String chestSize;

	@Column(name = "DATETIME_RECORD")
	private Timestamp datetimeRecord;

	private BigDecimal height;

	@Column(name = "HIGH_BLOOD_PRESS")
	private String highBloodPress;

	@Column(name = "LOW_BLOOD_PRESS")
	private String lowBloodPress;

	private String note;

	@Column(name = "PERC_FAT")
	private String percFat;

	@Column(name = "PROFILE_ID")
	private Long profileId;

	@Column(name = "SYS_ID")
	private String sysId;

	@Column(name = "UPD_ID")
	private String updId;

	@Column(name = "WAIST_LINE")
	private String waistLine;

	private BigDecimal weight;

	public PhrStandardHealth() {
	}

	public Long getId() {
		return this.id;
	}

	public void setId(Long id) {
		this.id = id;
	}

	public String getChestSize() {
		return this.chestSize;
	}

	public void setChestSize(String chestSize) {
		this.chestSize = chestSize;
	}

	public Timestamp getDatetimeRecord() {
		return this.datetimeRecord;
	}

	public void setDatetimeRecord(Timestamp datetimeRecord) {
		this.datetimeRecord = datetimeRecord;
	}

	public BigDecimal getHeight() {
		return this.height;
	}

	public void setHeight(BigDecimal height) {
		this.height = height;
	}

	public String getHighBloodPress() {
		return this.highBloodPress;
	}

	public void setHighBloodPress(String highBloodPress) {
		this.highBloodPress = highBloodPress;
	}

	public String getLowBloodPress() {
		return this.lowBloodPress;
	}

	public void setLowBloodPress(String lowBloodPress) {
		this.lowBloodPress = lowBloodPress;
	}

	public String getNote() {
		return this.note;
	}

	public void setNote(String note) {
		this.note = note;
	}

	public String getPercFat() {
		return this.percFat;
	}

	public void setPercFat(String percFat) {
		this.percFat = percFat;
	}

	public Long getProfileId() {
		return this.profileId;
	}

	public void setProfileId(Long profileId) {
		this.profileId = profileId;
	}

	public String getSysId() {
		return this.sysId;
	}

	public void setSysId(String sysId) {
		this.sysId = sysId;
	}

	public String getUpdId() {
		return this.updId;
	}

	public void setUpdId(String updId) {
		this.updId = updId;
	}

	public String getWaistLine() {
		return this.waistLine;
	}

	public void setWaistLine(String waistLine) {
		this.waistLine = waistLine;
	}

	public BigDecimal getWeight() {
		return this.weight;
	}

	public void setWeight(BigDecimal weight) {
		this.weight = weight;
	}

}