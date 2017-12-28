package nta.med.data.model.ihis.drgs;

public class DRG3010P10LayOrderJungboInfo {
    private String seq1;
    private String seq2;
    private String text1;
    private String remark;
    private String barDrgBunho;
    private String bunho;
	public DRG3010P10LayOrderJungboInfo(String seq1, String seq2, String text1,
			String remark, String barDrgBunho, String bunho) {
		super();
		this.seq1 = seq1;
		this.seq2 = seq2;
		this.text1 = text1;
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
