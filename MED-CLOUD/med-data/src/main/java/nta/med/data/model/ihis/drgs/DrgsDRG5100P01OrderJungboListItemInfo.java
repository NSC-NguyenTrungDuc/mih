package nta.med.data.model.ihis.drgs;

public class DrgsDRG5100P01OrderJungboListItemInfo {
	private String seq1;
	private String seq2;
	private String text1;
	private String text2;
	private String text3;
	private String remark;
	private String barDrgBunho;
	private String bunho;
	public DrgsDRG5100P01OrderJungboListItemInfo(String seq1, String seq2,
			String text1, String text2, String text3, String remark,
			String barDrgBunho, String bunho) {
		super();
		this.seq1 = seq1;
		this.seq2 = seq2;
		this.text1 = text1;
		this.text2 = text2;
		this.text3 = text3;
		this.remark = remark;
		this.barDrgBunho = barDrgBunho;
		this.bunho = bunho;
	}
	public String getSeq1() {
		return seq1;
	}
	public void setSeq1(String seq1) {
		this.seq1 = seq1;
	}
	public String getSeq2() {
		return seq2;
	}
	public void setSeq2(String seq2) {
		this.seq2 = seq2;
	}
	public String getText1() {
		return text1;
	}
	public void setText1(String text1) {
		this.text1 = text1;
	}
	public String getText2() {
		return text2;
	}
	public void setText2(String text2) {
		this.text2 = text2;
	}
	public String getText3() {
		return text3;
	}
	public void setText3(String text3) {
		this.text3 = text3;
	}
	public String getRemark() {
		return remark;
	}
	public void setRemark(String remark) {
		this.remark = remark;
	}
	public String getBarDrgBunho() {
		return barDrgBunho;
	}
	public void setBarDrgBunho(String barDrgBunho) {
		this.barDrgBunho = barDrgBunho;
	}
	public String getBunho() {
		return bunho;
	}
	public void setBunho(String bunho) {
		this.bunho = bunho;
	}
}
