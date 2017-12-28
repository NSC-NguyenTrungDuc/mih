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
 * The persistent class for the PHR_STANDARD_FOOD_MENU database table.
 * 
 */
@Entity
@Table(name = "PHR_STANDARD_FOOD_MENU")
@NamedQuery(name = "PhrStandardFoodMenu.findAll", query = "SELECT p FROM PhrStandardFoodMenu p")
public class PhrStandardFoodMenu extends PhrBaseEntity {
	private static final long serialVersionUID = 1L;

	@Id
	@GeneratedValue(strategy = GenerationType.IDENTITY)
	@Column(name = "ID", unique = true, nullable = false)
	private Long id;

	@Column(name = "EATING_TIME")
	private Timestamp eatingTime;

	@Column(name = "FROM_HOUR")
	private Integer fromHour;

	private Integer full;

	@Column(name = "IMAGE_URL")
	private String imageUrl;

	private BigDecimal kcal;

	private String note;

	@Column(name = "PROFILE_ID")
	private Long profileId;

	private Integer rating;

	@Column(name = "SYS_ID")
	private String sysId;

	@Column(name = "TO_HOUR")
	private Integer toHour;

	@Column(name = "UPD_ID")
	private String updId;

	public PhrStandardFoodMenu() {
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

	public Integer getFromHour() {
		return this.fromHour;
	}

	public void setFromHour(Integer fromHour) {
		this.fromHour = fromHour;
	}

	public Integer getFull() {
		return this.full;
	}

	public void setFull(Integer full) {
		this.full = full;
	}

	public String getImageUrl() {
		return this.imageUrl;
	}

	public void setImageUrl(String imageUrl) {
		this.imageUrl = imageUrl;
	}

	public BigDecimal getKcal() {
		return this.kcal;
	}

	public void setKcal(BigDecimal kcal) {
		this.kcal = kcal;
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

	public Integer getRating() {
		return this.rating;
	}

	public void setRating(Integer rating) {
		this.rating = rating;
	}

	public String getSysId() {
		return this.sysId;
	}

	public void setSysId(String sysId) {
		this.sysId = sysId;
	}

	public Integer getToHour() {
		return this.toHour;
	}

	public void setToHour(Integer toHour) {
		this.toHour = toHour;
	}

	public String getUpdId() {
		return this.updId;
	}

	public void setUpdId(String updId) {
		this.updId = updId;
	}

}