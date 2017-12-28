package nta.mss.entity;

import java.io.Serializable;
import java.util.List;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.GeneratedValue;
import javax.persistence.GenerationType;
import javax.persistence.Id;
import javax.persistence.OneToMany;
import javax.persistence.Table;

import nta.mss.model.VaccineGroupModel;


/**
 * The persistent class for the vaccine_group database table.
 * 
 */
@Entity
@Table(name="vaccine_group")
public class VaccineGroup extends BaseEntity<VaccineGroupModel> implements Serializable {
	private static final long serialVersionUID = 1L;

	@Id
	@GeneratedValue(strategy=GenerationType.IDENTITY)
	@Column(name="vaccine_group_id", unique=true, nullable=false, length=10)
	private Integer vaccineGroupId;

	@Column(nullable=false, length=6)
	private String color;

	@Column(nullable=false, length=128)
	private String name;

	//bi-directional many-to-one association to Vaccine
	@OneToMany(mappedBy="vaccineGroup")
	private List<Vaccine> vaccines;

	public VaccineGroup() {
		super(VaccineGroupModel.class);
	}

	public Integer getVaccineGroupId() {
		return vaccineGroupId;
	}

	public void setVaccineGroupId(Integer vaccineGroupId) {
		this.vaccineGroupId = vaccineGroupId;
	}

	public String getColor() {
		return this.color;
	}

	public void setColor(String color) {
		this.color = color;
	}

	public String getName() {
		return this.name;
	}

	public void setName(String name) {
		this.name = name;
	}

	public List<Vaccine> getVaccines() {
		return this.vaccines;
	}

	public void setVaccines(List<Vaccine> vaccines) {
		this.vaccines = vaccines;
	}
}