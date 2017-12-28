package nta.med.core.domain.phr;

import java.io.Serializable;
import javax.persistence.*;
import java.math.BigDecimal;
import java.sql.Timestamp;
import java.math.BigInteger;


/**
 * The persistent class for the phr_standard_food_carbohydate database table.
 * 
 */
@Entity
@Table(name="PHR_STANDARD_FOOD_CARBOHYDRATE")
@NamedQuery(name="PhrStandardFoodCarbohydrate.findAll", query="SELECT p FROM PhrStandardFoodCarbohydrate p")
public class PhrStandardFoodCarbohydrate extends PhrBaseEntity implements Serializable {
	private static final long serialVersionUID = 1L;

	@Id
	@GeneratedValue(strategy = GenerationType.IDENTITY)
	@Column(name = "ID", unique = true, nullable = false)
	private Long id;

	private BigDecimal carbohydrate;

	@Column(name="EATING_TIME")
	private Timestamp eatingTime;

	@Column(name="NOTE")
	private String note;

	@Column(name="PROFILE_ID")
	private Long profileId;

	@Column(name="RATING")
	private Long rating;

	@Column(name="SOURCE")
	private String source;

	@Column(name="SYNC_ID")
	private BigInteger syncId;

	@Column(name="SYS_ID")
	private String sysId;

	@Column(name="UPD_ID")
	private String updId;

	public PhrStandardFoodCarbohydrate() {
	}

	public Long getId() {
		return this.id;
	}

	public void setId(Long id) {
		this.id = id;
	}

	public BigDecimal getCarbohydrate() {
		return carbohydrate;
	}

	public void setCarbohydrate(BigDecimal carbohydrate) {
		this.carbohydrate = carbohydrate;
	}

	public Timestamp getEatingTime() {
		return eatingTime;
	}

	public void setEatingTime(Timestamp eatingTime) {
		this.eatingTime = eatingTime;
	}

	public String getNote() {
		return note;
	}

	public void setNote(String note) {
		this.note = note;
	}

	public Long getProfileId() {
		return profileId;
	}

	public void setProfileId(Long profileId) {
		this.profileId = profileId;
	}

	public Long getRating() {
		return rating;
	}

	public void setRating(Long rating) {
		this.rating = rating;
	}

	public String getSource() {
		return source;
	}

	public void setSource(String source) {
		this.source = source;
	}

	public BigInteger getSyncId() {
		return syncId;
	}

	public void setSyncId(BigInteger syncId) {
		this.syncId = syncId;
	}

	public String getSysId() {
		return sysId;
	}

	public void setSysId(String sysId) {
		this.sysId = sysId;
	}

	public String getUpdId() {
		return updId;
	}

	public void setUpdId(String updId) {
		this.updId = updId;
	}
}