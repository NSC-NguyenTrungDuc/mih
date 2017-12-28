package nta.mss.model;

import nta.mss.entity.VaccineSupportFee;

/**
 * The Class VaccineSupportFee.
 *
 * @author MinhLS
 * @crtDate 2015/01/22
 */
public class VaccineSupportFeeModel extends BaseModel<VaccineSupportFee> {

	private static final long serialVersionUID = 9011639912019685514L;
	
	private Integer supportId;
	private Integer vaccineId;
	private Integer fromMonth;
	private Integer toMonth;

	public VaccineSupportFeeModel() {
		super(VaccineSupportFee.class);
	}

	public Integer getSupportId() {
		return supportId;
	}

	public void setSupportId(Integer supportId) {
		this.supportId = supportId;
	}

	public Integer getVaccineId() {
		return vaccineId;
	}

	public void setVaccineId(Integer vaccineId) {
		this.vaccineId = vaccineId;
	}

	public Integer getFromMonth() {
		return this.fromMonth;
	}

	public void setFromMonth(Integer fromMonth) {
		this.fromMonth = fromMonth;
	}

	public Integer getToMonth() {
		return this.toMonth;
	}

	public void setToMonth(Integer toMonth) {
		this.toMonth = toMonth;
	}
}