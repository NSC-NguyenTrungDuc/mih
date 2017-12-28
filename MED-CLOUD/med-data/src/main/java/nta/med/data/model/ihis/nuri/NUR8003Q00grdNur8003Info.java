package nta.med.data.model.ihis.nuri;

public class NUR8003Q00grdNur8003Info {
	private String writeDate;
	private String count;
	private String allCount;
	private String per;
	private String cal;
	public NUR8003Q00grdNur8003Info(String writeDate, String count, String allCount, String per, String cal) {
		super();
		this.writeDate = writeDate;
		this.count = count;
		this.allCount = allCount;
		this.per = per;
		this.cal = cal;
	}
	public String getWriteDate() {
		return writeDate;
	}
	public void setWriteDate(String writeDate) {
		this.writeDate = writeDate;
	}
	public String getCount() {
		return count;
	}
	public void setCount(String count) {
		this.count = count;
	}
	public String getAllCount() {
		return allCount;
	}
	public void setAllCount(String allCount) {
		this.allCount = allCount;
	}
	public String getPer() {
		return per;
	}
	public void setPer(String per) {
		this.per = per;
	}
	public String getCal() {
		return cal;
	}
	public void setCal(String cal) {
		this.cal = cal;
	}
}
