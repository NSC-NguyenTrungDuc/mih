package nta.mss.model;

import nta.mss.entity.VaccineRecommendAge;


/**
 * The Class VaccineRecommendAge.
 *
 * @author MinhLS
 * @crtDate 2015/01/22
 */
public class VaccineRecommendAgeModel extends BaseModel<VaccineRecommendAge> {

	private static final long serialVersionUID = 3311773789099479671L;

	private Integer recommendId;
	private Integer vaccineId;
	private Integer fromMonth;
	private Integer toMonth;

	public VaccineRecommendAgeModel() {
		super(VaccineRecommendAge.class);
	}
	
	public Integer getRecommendId() {
		return recommendId;
	}

	public void setRecommendId(Integer recommendId) {
		this.recommendId = recommendId;
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