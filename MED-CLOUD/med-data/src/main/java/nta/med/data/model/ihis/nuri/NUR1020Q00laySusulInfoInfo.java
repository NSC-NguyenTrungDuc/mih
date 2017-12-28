package nta.med.data.model.ihis.nuri;

public class NUR1020Q00laySusulInfoInfo {

	private String opReserDate;
	private String susulName;

	public NUR1020Q00laySusulInfoInfo(String opReserDate, String susulName) {
		super();
		this.opReserDate = opReserDate;
		this.susulName = susulName;
	}

	public String getOpReserDate() {
		return opReserDate;
	}

	public void setOpReserDate(String opReserDate) {
		this.opReserDate = opReserDate;
	}

	public String getSusulName() {
		return susulName;
	}

	public void setSusulName(String susulName) {
		this.susulName = susulName;
	}

}
