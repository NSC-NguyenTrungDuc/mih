package nta.med.data.model.ihis.drgs;

public class PrJihDrgIfsProcInfo {
	private String recGubunPat;
	private String jojeDate;
	private Double drgBunho;
	private String gwa;
	private String bunho;
	private String patName;
	private String birthday;
	private String sex;
	private String cancerFlag;
	private String recGubunMemo;
	private String patMemo;
	private String recGubunDrguser;
	private String drguserName;
	private String recGubunDoctor;
	private String doctorName;
	public PrJihDrgIfsProcInfo(String recGubunPat, String jojeDate,
			Double drgBunho, String gwa, String bunho, String patName,
			String birthday, String sex, String cancerFlag,
			String recGubunMemo, String patMemo, String recGubunDrguser,
			String drguserName, String recGubunDoctor, String doctorName) {
		this.recGubunPat = recGubunPat;
		this.jojeDate = jojeDate;
		this.drgBunho = drgBunho;
		this.gwa = gwa;
		this.bunho = bunho;
		this.patName = patName;
		this.birthday = birthday;
		this.sex = sex;
		this.cancerFlag = cancerFlag;
		this.recGubunMemo = recGubunMemo;
		this.patMemo = patMemo;
		this.recGubunDrguser = recGubunDrguser;
		this.drguserName = drguserName;
		this.recGubunDoctor = recGubunDoctor;
		this.doctorName = doctorName;
	}
	public String getRecGubunPat() {
		return recGubunPat;
	}
	public void setRecGubunPat(String recGubunPat) {
		this.recGubunPat = recGubunPat;
	}
	public String getJojeDate() {
		return jojeDate;
	}
	public void setJojeDate(String jojeDate) {
		this.jojeDate = jojeDate;
	}
	public Double getDrgBunho() {
		return drgBunho;
	}
	public void setDrgBunho(Double drgBunho) {
		this.drgBunho = drgBunho;
	}
	public String getGwa() {
		return gwa;
	}
	public void setGwa(String gwa) {
		this.gwa = gwa;
	}
	public String getBunho() {
		return bunho;
	}
	public void setBunho(String bunho) {
		this.bunho = bunho;
	}
	public String getPatName() {
		return patName;
	}
	public void setPatName(String patName) {
		this.patName = patName;
	}
	public String getBirthday() {
		return birthday;
	}
	public void setBirthday(String birthday) {
		this.birthday = birthday;
	}
	public String getSex() {
		return sex;
	}
	public void setSex(String sex) {
		this.sex = sex;
	}
	public String getCancerFlag() {
		return cancerFlag;
	}
	public void setCancerFlag(String cancerFlag) {
		this.cancerFlag = cancerFlag;
	}
	public String getRecGubunMemo() {
		return recGubunMemo;
	}
	public void setRecGubunMemo(String recGubunMemo) {
		this.recGubunMemo = recGubunMemo;
	}
	public String getPatMemo() {
		return patMemo;
	}
	public void setPatMemo(String patMemo) {
		this.patMemo = patMemo;
	}
	public String getRecGubunDrguser() {
		return recGubunDrguser;
	}
	public void setRecGubunDrguser(String recGubunDrguser) {
		this.recGubunDrguser = recGubunDrguser;
	}
	public String getDrguserName() {
		return drguserName;
	}
	public void setDrguserName(String drguserName) {
		this.drguserName = drguserName;
	}
	public String getRecGubunDoctor() {
		return recGubunDoctor;
	}
	public void setRecGubunDoctor(String recGubunDoctor) {
		this.recGubunDoctor = recGubunDoctor;
	}
	public String getDoctorName() {
		return doctorName;
	}
	public void setDoctorName(String doctorName) {
		this.doctorName = doctorName;
	}
	@Override
	public String toString() {
		return "PrJihDrgIfsProcInfo [recGubunPat=" + recGubunPat
				+ ", jojeDate=" + jojeDate + ", drgBunho=" + drgBunho
				+ ", gwa=" + gwa + ", bunho=" + bunho + ", patName=" + patName
				+ ", birthday=" + birthday + ", sex=" + sex + ", cancerFlag="
				+ cancerFlag + ", recGubunMemo=" + recGubunMemo + ", patMemo="
				+ patMemo + ", recGubunDrguser=" + recGubunDrguser
				+ ", drguserName=" + drguserName + ", recGubunDoctor="
				+ recGubunDoctor + ", doctorName=" + doctorName + "]";
	}
	
}
