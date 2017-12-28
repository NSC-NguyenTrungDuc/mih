package nta.mss.model;

import nta.mss.entity.VaccineInjectDay;


/**
 * The Class VaccineInjectDay.
 *
 * @author MinhLS
 * @crtDate 2015/01/22
 */
public class VaccineInjectDayModel extends BaseModel<VaccineInjectDay> {

	private static final long serialVersionUID = -6925934464050842023L;

	private Integer injectedNo;
	private Integer vaccineId;
	private Integer dayMax;
	private Integer dayMin;

	public VaccineInjectDayModel() {
		super(VaccineInjectDay.class);
	}

	public Integer getInjectedNo() {
		return injectedNo;
	}

	public void setInjectedNo(Integer injectedNo) {
		this.injectedNo = injectedNo;
	}

	public Integer getVaccineId() {
		return vaccineId;
	}

	public void setVaccineId(Integer vaccineId) {
		this.vaccineId = vaccineId;
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
}