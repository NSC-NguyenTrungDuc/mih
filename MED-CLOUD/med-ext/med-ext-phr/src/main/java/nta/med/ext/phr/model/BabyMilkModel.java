package nta.med.ext.phr.model;

import java.math.BigDecimal;
import java.sql.Timestamp;

import com.fasterxml.jackson.annotation.JsonFormat;
import com.fasterxml.jackson.annotation.JsonProperty;

/**
 * The persistent class for the PHR_BABY_MILK database table.
 * 
 */

public class BabyMilkModel {

	@JsonProperty("id")
	private Long id;

	@JsonProperty("alert")
	private BigDecimal alert;

	@JsonProperty("bottle_milk_volume")
	private String bottleMilkVolume;

	@JsonProperty("breast_time")
	private Integer breastTime;

	@JsonProperty("drink_method")
	private BigDecimal drinkMethod;

	@JsonProperty("calories")
	private BigDecimal kcal;

	@JsonProperty("milk_type")
	private String milkType;

	@JsonProperty("note")
	private String note;

	@JsonProperty("profile_id")
	private Long profileId;

	@JsonProperty("time_drink_milk")
	@JsonFormat(shape=JsonFormat.Shape.STRING, pattern="yyyy-MM-dd'T'HH:mm:ss'Z'", timezone="UTC")
	private Timestamp timeDrinkMilk;

	public BabyMilkModel() {
	}

	public Long getId() {
		return id;
	}

	public void setId(Long id) {
		this.id = id;
	}

	public BigDecimal getAlert() {
		return alert;
	}

	public void setAlert(BigDecimal alert) {
		this.alert = alert;
	}

	public String getBottleMilkVolume() {
		return bottleMilkVolume;
	}

	public void setBottleMilkVolume(String bottleMilkVolume) {
		this.bottleMilkVolume = bottleMilkVolume;
	}

	public Integer getBreastTime() {
		return breastTime;
	}

	public void setBreastTime(Integer breastTime) {
		this.breastTime = breastTime;
	}

	public BigDecimal getDrinkMethod() {
		return drinkMethod;
	}

	public void setDrinkMethod(BigDecimal drinkMethod) {
		this.drinkMethod = drinkMethod;
	}

	public BigDecimal getKcal() {
		return kcal;
	}

	public void setKcal(BigDecimal kcal) {
		this.kcal = kcal;
	}

	public String getMilkType() {
		return milkType;
	}

	public void setMilkType(String milkType) {
		this.milkType = milkType;
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

	public Timestamp getTimeDrinkMilk() {
		return timeDrinkMilk;
	}

	public void setTimeDrinkMilk(Timestamp timeDrinkMilk) {
		this.timeDrinkMilk = timeDrinkMilk;
	}


}