package nta.med.data.model.ihis.nuri;

public class NUR6011U01grdImageInfo {
	private String bunho;
	private String fromDate;
	private String buwiGubun;
	private String assessorDate;
	private String seq;
	private String image;
	private String image1;
	private String imagePath;
	private String baseImagePath;
	private String dataRowState;
	
	public NUR6011U01grdImageInfo(String bunho, String fromDate, String buwiGubun, String assessorDate, String seq,
			String image, String image1, String imagePath, String baseImagePath, String dataRowState) {
		super();
		this.bunho = bunho;
		this.fromDate = fromDate;
		this.buwiGubun = buwiGubun;
		this.assessorDate = assessorDate;
		this.seq = seq;
		this.image = image;
		this.image1 = image1;
		this.imagePath = imagePath;
		this.baseImagePath = baseImagePath;
		this.dataRowState = dataRowState;
	}

	public String getBunho() {
		return bunho;
	}

	public void setBunho(String bunho) {
		this.bunho = bunho;
	}

	public String getFromDate() {
		return fromDate;
	}

	public void setFromDate(String fromDate) {
		this.fromDate = fromDate;
	}

	public String getBuwiGubun() {
		return buwiGubun;
	}

	public void setBuwiGubun(String buwiGubun) {
		this.buwiGubun = buwiGubun;
	}

	public String getAssessorDate() {
		return assessorDate;
	}

	public void setAssessorDate(String assessorDate) {
		this.assessorDate = assessorDate;
	}

	public String getSeq() {
		return seq;
	}

	public void setSeq(String seq) {
		this.seq = seq;
	}

	public String getImage() {
		return image;
	}

	public void setImage(String image) {
		this.image = image;
	}

	public String getImage1() {
		return image1;
	}

	public void setImage1(String image1) {
		this.image1 = image1;
	}

	public String getImagePath() {
		return imagePath;
	}

	public void setImagePath(String imagePath) {
		this.imagePath = imagePath;
	}

	public String getBaseImagePath() {
		return baseImagePath;
	}

	public void setBaseImagePath(String baseImagePath) {
		this.baseImagePath = baseImagePath;
	}

	public String getDataRowState() {
		return dataRowState;
	}

	public void setDataRowState(String dataRowState) {
		this.dataRowState = dataRowState;
	}
	
	
}
