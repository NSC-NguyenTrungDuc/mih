package nta.med.data.model.ihis.bass;

public class BAS0101U00PrBasGridColumnChangedItemInfo {
	private String dupYn;
	private String error;
	public BAS0101U00PrBasGridColumnChangedItemInfo(){}
	public BAS0101U00PrBasGridColumnChangedItemInfo(String dupYn,
			String error) {
		super();
		this.dupYn = dupYn;
		this.error = error;
	}
	public String getDupYn() {
		return dupYn;
	}
	public void setDupYn(String dupYn) {
		this.dupYn = dupYn;
	}
	public String getError() {
		return error;
	}
	public void setError(String error) {
		this.error = error;
	} 
}
