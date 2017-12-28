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
 * The persistent class for the PHR_BABY_MILK database table.
 * 
 */
@Entity
@Table(name = "PHR_BABY_MILK")
@NamedQuery(name = "PhrBabyMilk.findAll", query = "SELECT p FROM PhrBabyMilk p")
public class PhrBabyMilk extends PhrBaseEntity implements TimeLineDate {
	private static final long serialVersionUID = 1L;

	@Id
	@GeneratedValue(strategy = GenerationType.IDENTITY)
	@Column(name = "ID", unique = true, nullable = false)
	private Long id;

	private BigDecimal alert;

	@Column(name = "BOTTLE_MILK_VOLUME")
	private String bottleMilkVolume;

	@Column(name = "BREAST_TIME")
	private Integer breastTime;

	@Column(name = "DRINK_METHOD")
	private BigDecimal drinkMethod;

	private BigDecimal kcal;

	@Column(name = "MILK_TYPE")
	private String milkType;

	private String note;

	@Column(name = "PROFILE_ID")
	private Long profileId;

	@Column(name = "SYS_ID")
	private String sysId;

	@Column(name = "TIME_DRINK_MILK")
	private Timestamp timeDrinkMilk;

	@Column(name = "UPD_ID")
	private String updId;

	public PhrBabyMilk() {
	}

	public Long getId() {
		return this.id;
	}

	public void setId(Long id) {
		this.id = id;
	}

	public BigDecimal getAlert() {
		return this.alert;
	}

	public void setAlert(BigDecimal alert) {
		this.alert = alert;
	}

	public String getBottleMilkVolume() {
		return this.bottleMilkVolume;
	}

	public void setBottleMilkVolume(String bottleMilkVolume) {
		this.bottleMilkVolume = bottleMilkVolume;
	}

	public Integer getBreastTime() {
		return this.breastTime;
	}

	public void setBreastTime(Integer breastTime) {
		this.breastTime = breastTime;
	}

	public BigDecimal getDrinkMethod() {
		return this.drinkMethod;
	}

	public void setDrinkMethod(BigDecimal drinkMethod) {
		this.drinkMethod = drinkMethod;
	}

	public BigDecimal getKcal() {
		return this.kcal;
	}

	public void setKcal(BigDecimal kcal) {
		this.kcal = kcal;
	}

	public String getMilkType() {
		return this.milkType;
	}

	public void setMilkType(String milkType) {
		this.milkType = milkType;
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

	public Timestamp getTimeDrinkMilk() {
		return this.timeDrinkMilk;
	}

	public void setTimeDrinkMilk(Timestamp timeDrinkMilk) {
		this.timeDrinkMilk = timeDrinkMilk;
	}

	public String getUpdId() {
		return this.updId;
	}

	public void setUpdId(String updId) {
		this.updId = updId;
	}

	public Timestamp getTimestamp() {
		return timeDrinkMilk;
	}

}