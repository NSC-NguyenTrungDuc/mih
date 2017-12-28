package nta.mss.entity;

import java.io.Serializable;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.FetchType;
import javax.persistence.GeneratedValue;
import javax.persistence.GenerationType;
import javax.persistence.Id;
import javax.persistence.JoinColumn;
import javax.persistence.ManyToOne;
import javax.persistence.Table;

import nta.mss.model.VaccineRecommendAgeModel;


/**
 * The persistent class for the vaccine_recommend_age database table.
 * 
 */
@Entity
@Table(name="vaccine_recommend_age")
public class VaccineRecommendAge extends BaseEntity<VaccineRecommendAgeModel> implements Serializable {
	private static final long serialVersionUID = 1L;

	@Id
	@GeneratedValue(strategy=GenerationType.IDENTITY)
	@Column(name="recommend_id")
	private int recommendId;

	@Column(name="from_month")
	private int fromMonth;

	@Column(name="to_month")
	private int toMonth;

	//bi-directional many-to-one association to Vaccine
	@ManyToOne(fetch=FetchType.LAZY)
	@JoinColumn(name="vaccine_id", nullable=false, insertable=false, updatable=false)
	private Vaccine vaccine;

	public VaccineRecommendAge() {
		super(VaccineRecommendAgeModel.class);
	}

	public int getRecommendId() {
		return this.recommendId;
	}

	public void setRecommendId(int recommendId) {
		this.recommendId = recommendId;
	}

	public int getFromMonth() {
		return this.fromMonth;
	}

	public void setFromMonth(int fromMonth) {
		this.fromMonth = fromMonth;
	}

	public int getToMonth() {
		return this.toMonth;
	}

	public void setToMonth(int toMonth) {
		this.toMonth = toMonth;
	}

	public Vaccine getVaccine() {
		return this.vaccine;
	}

	public void setVaccine(Vaccine vaccine) {
		this.vaccine = vaccine;
	}
}