package nta.mss.entity;

import java.io.Serializable;

import javax.persistence.Column;
import javax.persistence.EmbeddedId;
import javax.persistence.Entity;
import javax.persistence.FetchType;
import javax.persistence.JoinColumn;
import javax.persistence.ManyToOne;
import javax.persistence.Table;

import nta.mss.model.VaccineInjectDayModel;


/**
 * The persistent class for the vaccing_inject_day database table.
 * 
 */
@Entity
@Table(name="vaccine_inject_day")
public class VaccineInjectDay extends BaseEntity<VaccineInjectDayModel> implements Serializable {
	private static final long serialVersionUID = 1L;

	@EmbeddedId
	private VaccineInjectDayPK id;

	@Column(name="day_max")
	private Integer dayMax;

	@Column(name="day_min")
	private Integer dayMin;

	//bi-directional many-to-one association to Vaccine
	@ManyToOne(fetch=FetchType.LAZY)
	@JoinColumn(name="vaccine_id", nullable=false, insertable=false, updatable=false)
	private Vaccine vaccine;

	public VaccineInjectDay() {
		super(VaccineInjectDayModel.class);
	}

	public VaccineInjectDayPK getId() {
		return this.id;
	}

	public void setId(VaccineInjectDayPK id) {
		this.id = id;
	}

	public Integer getDayMax() {
		return this.dayMax;
	}

	public void setDayMax(Integer dayMax) {
		this.dayMax = dayMax;
	}

	public Integer getDayMin() {
		return this.dayMin;
	}

	public void setDayMin(Integer dayMin) {
		this.dayMin = dayMin;
	}

	public Vaccine getVaccine() {
		return this.vaccine;
	}

	public void setVaccine(Vaccine vaccine) {
		this.vaccine = vaccine;
	}

}