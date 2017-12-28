package nta.med.data.model.ihis.nuro;

public class NuroRES1001U00AverageTimeListItemInfo {
	private Double avgTime;
	private Double docResLimit;
	
	public NuroRES1001U00AverageTimeListItemInfo(Double avgTime,
			Double docResLimit) {
		this.avgTime = avgTime;
		this.docResLimit = docResLimit;
	}
	public Double getAvgTime() {
		return avgTime;
	}

	public void setAvgTime(Double avgTime) {
		this.avgTime = avgTime;
	}

	public Double getDocResLimit() {
		return docResLimit;
	}

	public void setDocResLimit(Double docResLimit) {
		this.docResLimit = docResLimit;
	}
}
