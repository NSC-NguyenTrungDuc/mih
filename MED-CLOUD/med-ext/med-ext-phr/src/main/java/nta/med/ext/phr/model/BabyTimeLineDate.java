package nta.med.ext.phr.model;

import java.util.ArrayList;
import java.util.Date;
import java.util.List;

import com.fasterxml.jackson.annotation.JsonIgnore;
import com.fasterxml.jackson.annotation.JsonProperty;

/**
 * @author DEV-TiepNM
 */
public class BabyTimeLineDate {

	@JsonProperty("date")
	private String date;

	@JsonIgnore
	private Date dateTime;

	@JsonProperty("list_baby_milk")
	private List<BabyMilkModel> listBabyMilk = new ArrayList<BabyMilkModel>();

	@JsonProperty("list_baby_food")
	private List<BabyFoodModel> listBabyFood = new ArrayList<BabyFoodModel>();

	@JsonProperty("list_baby_diaper")
	private List<BabyDiaperModel> listBabyDiaper = new ArrayList<BabyDiaperModel>();

	@JsonProperty("list_medicine")
	private List<MedicineModel> listMedicine = new ArrayList<MedicineModel>();

	@JsonProperty("list_baby_growth_height")
	private List<BabyGrowthHeightModel> listBabyGrowthHeight = new ArrayList<BabyGrowthHeightModel>();
	
	@JsonProperty("list_baby_growth_weight")
	private List<BabyGrowthWeightModel> listBabyGrowthWeight = new ArrayList<BabyGrowthWeightModel>();

	@JsonProperty("list_baby_sleep")
	private List<BabySleepModel> listBabySleep = new ArrayList<BabySleepModel>();

	public String getDate() {
		return date;
	}

	public void setDate(String date) {
		this.date = date;
	}

	public List<BabyMilkModel> getListBabyMilk() {
		return listBabyMilk;
	}

	public void setListBabyMilk(List<BabyMilkModel> listBabyMilk) {
		this.listBabyMilk = listBabyMilk;
	}

	public List<BabyFoodModel> getListBabyFood() {
		return listBabyFood;
	}

	public void setListBabyFood(List<BabyFoodModel> listBabyFood) {
		this.listBabyFood = listBabyFood;
	}

	public List<BabyDiaperModel> getListBabyDiaper() {
		return listBabyDiaper;
	}

	public void setListBabyDiaper(List<BabyDiaperModel> listBabyDiaper) {
		this.listBabyDiaper = listBabyDiaper;
	}

	public List<MedicineModel> getListMedicine() {
		return listMedicine;
	}

	public void setListMedicine(List<MedicineModel> listMedicine) {
		this.listMedicine = listMedicine;
	}

	public List<BabyGrowthHeightModel> getListBabyGrowthHeight() {
		return listBabyGrowthHeight;
	}

	public void setListBabyGrowthHeight(List<BabyGrowthHeightModel> listBabyGrowthHeight) {
		this.listBabyGrowthHeight = listBabyGrowthHeight;
	}

	public List<BabyGrowthWeightModel> getListBabyGrowthWeight() {
		return listBabyGrowthWeight;
	}

	public void setListBabyGrowthWeight(List<BabyGrowthWeightModel> listBabyGrowthWeight) {
		this.listBabyGrowthWeight = listBabyGrowthWeight;
	}

	public List<BabySleepModel> getListBabySleep() {
		return listBabySleep;
	}

	public void setListBabySleep(List<BabySleepModel> listBabySleep) {
		this.listBabySleep = listBabySleep;
	}

	public Date getDateTime() {
		return dateTime;
	}

	public void setDateTime(Date dateTime) {
		this.dateTime = dateTime;
	}
}
