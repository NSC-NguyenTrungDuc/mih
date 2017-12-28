package nta.med.core.domain.phr;

import java.sql.Timestamp;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.GeneratedValue;
import javax.persistence.GenerationType;
import javax.persistence.Id;
import javax.persistence.NamedQuery;
import javax.persistence.Table;

/**
 * The persistent class for the PHR_BABY_FOOD database table.
 * 
 */
@Entity
@Table(name = "PHR_BABY_FOOD")
@NamedQuery(name = "PhrBabyFood.findAll", query = "SELECT p FROM PhrBabyFood p")
public class PhrBabyFood extends PhrBaseEntity implements TimeLineDate {
	private static final long serialVersionUID = 1L;

	@Id
	@GeneratedValue(strategy = GenerationType.IDENTITY)
	@Column(name = "ID", unique = true, nullable = false)
	private Long id;

	@Column(name = "EATING_TIME")
	private Timestamp eatingTime;

	private String food;

	@Column(name = "IMAGE_URL")
	private String imageUrl;

	private String kcal;

	@Column(name = "MEAL_TYPE")
	private String mealType;

	private String note;

	@Column(name = "PROFILE_ID")
	private Long profileId;

	@Column(name = "SYS_ID")
	private String sysId;

	@Column(name = "UPD_ID")
	private String updId;

	public PhrBabyFood() {
	}

	public Long getId() {
		return this.id;
	}

	public void setId(Long id) {
		this.id = id;
	}

	public Timestamp getEatingTime() {
		return this.eatingTime;
	}

	public void setEatingTime(Timestamp eatingTime) {
		this.eatingTime = eatingTime;
	}

	public String getFood() {
		return this.food;
	}

	public void setFood(String food) {
		this.food = food;
	}

	public String getImageUrl() {
		return this.imageUrl;
	}

	public void setImageUrl(String imageUrl) {
		this.imageUrl = imageUrl;
	}

	public String getKcal() {
		return this.kcal;
	}

	public void setKcal(String kcal) {
		this.kcal = kcal;
	}

	public String getMealType() {
		return this.mealType;
	}

	public void setMealType(String mealType) {
		this.mealType = mealType;
	}

	public String getNote() {
		return this.note;
	}

	public void setNote(String note) {
		this.note = note;
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

	public Timestamp getTimestamp() {
		return eatingTime;
	}

}