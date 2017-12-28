package nta.mss.model;

import java.util.List;

import nta.mss.entity.VaccineGroup;

/**
 * The Class VaccineGroup.
 *
 * @author MinhLS
 * @crtDate 2015/01/22
 */
public class VaccineGroupModel extends BaseModel<VaccineGroup>{

	private static final long serialVersionUID = -7200112388671061731L;
	
	private Integer vaccineGroupId;
	private String color;
	private String name;
	private List<VaccineModel> vaccines;

	public VaccineGroupModel() {
		super(VaccineGroup.class);
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

	public List<VaccineModel> getVaccines() {
		return this.vaccines;
	}

	public void setVaccines(List<VaccineModel> vaccines) {
		this.vaccines = vaccines;
	}
}