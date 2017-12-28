package nta.med.data.model.ihis.ocsa;

import java.util.Date;

public class OCS3003Q10GrdOrderDateListItemInfo {
	private Date orderDate;
	private String gwa;
	private String gwaName;
	private String doctorName;
	private String bunho;
	private String doctor;
	private String naewonType;
	private Double jubsuNo;
	private Double pkOrder;
	private String ioGubun;
	private String specificComment;
	private Double pkocskey;
	private String hangmogName;
	private String hangmogCode;
	private String jundalPart;
	private String iraiKubun;
	private String image;
	private String imagePath;
	private Date crTime;
	public OCS3003Q10GrdOrderDateListItemInfo(Date orderDate, String gwa,
			String gwaName, String doctorName, String bunho, String doctor,
			String naewonType, Double jubsuNo, Double pkOrder, String ioGubun,
			String specificComment, Double pkocskey, String hangmogName,
			String hangmogCode, String jundalPart, String iraiKubun,
			String image, String imagePath, Date crTime) {
		super();
		this.orderDate = orderDate;
		this.gwa = gwa;
		this.gwaName = gwaName;
		this.doctorName = doctorName;
		this.bunho = bunho;
		this.doctor = doctor;
		this.naewonType = naewonType;
		this.jubsuNo = jubsuNo;
		this.pkOrder = pkOrder;
		this.ioGubun = ioGubun;
		this.specificComment = specificComment;
		this.pkocskey = pkocskey;
		this.hangmogName = hangmogName;
		this.hangmogCode = hangmogCode;
		this.jundalPart = jundalPart;
		this.iraiKubun = iraiKubun;
		this.image = image;
		this.imagePath = imagePath;
		this.crTime = crTime;
	}
	public Date getOrderDate() {
		return orderDate;
	}
	public void setOrderDate(Date orderDate) {
		this.orderDate = orderDate;
	}
	public String getGwa() {
		return gwa;
	}
	public void setGwa(String gwa) {
		this.gwa = gwa;
	}
	public String getGwaName() {
		return gwaName;
	}
	public void setGwaName(String gwaName) {
		this.gwaName = gwaName;
	}
	public String getDoctorName() {
		return doctorName;
	}
	public void setDoctorName(String doctorName) {
		this.doctorName = doctorName;
	}
	public String getBunho() {
		return bunho;
	}
	public void setBunho(String bunho) {
		this.bunho = bunho;
	}
	public String getDoctor() {
		return doctor;
	}
	public void setDoctor(String doctor) {
		this.doctor = doctor;
	}
	public String getNaewonType() {
		return naewonType;
	}
	public void setNaewonType(String naewonType) {
		this.naewonType = naewonType;
	}
	public Double getJubsuNo() {
		return jubsuNo;
	}
	public void setJubsuNo(Double jubsuNo) {
		this.jubsuNo = jubsuNo;
	}
	public Double getPkOrder() {
		return pkOrder;
	}
	public void setPkOrder(Double pkOrder) {
		this.pkOrder = pkOrder;
	}
	public String getIoGubun() {
		return ioGubun;
	}
	public void setIoGubun(String ioGubun) {
		this.ioGubun = ioGubun;
	}
	public String getSpecificComment() {
		return specificComment;
	}
	public void setSpecificComment(String specificComment) {
		this.specificComment = specificComment;
	}
	public Double getPkocskey() {
		return pkocskey;
	}
	public void setPkocskey(Double pkocskey) {
		this.pkocskey = pkocskey;
	}
	public String getHangmogName() {
		return hangmogName;
	}
	public void setHangmogName(String hangmogName) {
		this.hangmogName = hangmogName;
	}
	public String getHangmogCode() {
		return hangmogCode;
	}
	public void setHangmogCode(String hangmogCode) {
		this.hangmogCode = hangmogCode;
	}
	public String getJundalPart() {
		return jundalPart;
	}
	public void setJundalPart(String jundalPart) {
		this.jundalPart = jundalPart;
	}
	public String getIraiKubun() {
		return iraiKubun;
	}
	public void setIraiKubun(String iraiKubun) {
		this.iraiKubun = iraiKubun;
	}
	public String getImage() {
		return image;
	}
	public void setImage(String image) {
		this.image = image;
	}
	public String getImagePath() {
		return imagePath;
	}
	public void setImagePath(String imagePath) {
		this.imagePath = imagePath;
	}
	public Date getCrTime() {
		return crTime;
	}
	public void setCrTime(Date crTime) {
		this.crTime = crTime;
	}
}
