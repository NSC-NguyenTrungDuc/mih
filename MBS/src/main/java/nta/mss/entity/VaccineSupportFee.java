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

import nta.mss.model.VaccineSupportFeeModel;


/**
 * The persistent class for the vaccine_support_fee database table.
 * 
 */
@Entity
@Table(name="vaccine_support_fee")
public class VaccineSupportFee extends BaseEntity<VaccineSupportFeeModel> implements Serializable {
	private static final long serialVersionUID = 1L;

	@Id
	@GeneratedValue(strategy=GenerationType.IDENTITY)
	@Column(name="support_id")
	private int supportId;

	@Column(name="from_month")
	private int fromMonth;

	@Column(name="to_month")
	private int toMonth;

	//bi-directional many-to-one association to Vaccine
	@ManyToOne(fetch=FetchType.LAZY)
	@JoinColumn(name="vaccine_id", nullable=false, insertable=false, updatable=false)
	private Vaccine vaccine;

	public VaccineSupportFee() {
		super(VaccineSupportFeeModel.class);
	}

	public int getSupportId() {
		return this.supportId;
	}

	public void setSupportId(int supportId) {
		this.supportId = supportId;
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