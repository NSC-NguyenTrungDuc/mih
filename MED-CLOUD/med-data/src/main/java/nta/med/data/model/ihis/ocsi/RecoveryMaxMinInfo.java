package nta.med.data.model.ihis.ocsi;

import java.util.Date;

public class RecoveryMaxMinInfo {

	private Date minNutDate;
	private Date maxNutDate;

	public RecoveryMaxMinInfo(Date minNutDate, Date maxNutDate) {
		super();
		this.minNutDate = minNutDate;
		this.maxNutDate = maxNutDate;
	}

	public Date getMinNutDate() {
		return minNutDate;
	}

	public void setMinNutDate(Date minNutDate) {
		this.minNutDate = minNutDate;
	}

	public Date getMaxNutDate() {
		return maxNutDate;
	}

	public void setMaxNutDate(Date maxNutDate) {
		this.maxNutDate = maxNutDate;
	}

}
