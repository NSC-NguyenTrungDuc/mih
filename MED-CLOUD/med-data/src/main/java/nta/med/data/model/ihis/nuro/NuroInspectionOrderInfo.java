package nta.med.data.model.ihis.nuro;

import java.sql.Timestamp;

public class NuroInspectionOrderInfo {
	private String gwa                ;
	private String gwaName           ;
	private String bunho              ;
	private String suname             ;
	private Timestamp reserDate         ;
	private String hangmogName       ;
	private String reserTime         ;
	private String moveName          ;
	private Double reserDay          ;
	private Integer age                ;
	private String birth              ;
	private String suname2            ;
	private String jundalPart        ;
	private String reserMoveName    ;
	private String hangmogCode       ;
	private String jundalTable       ;
	private Timestamp hopeDate          ;
	private Double seq                ;
	private String sort               ;
	private String sortTime          ;
	public NuroInspectionOrderInfo(String gwa, String gwaName, String bunho,
			String suname, Timestamp reserDate, String hangmogName,
			String reserTime, String moveName, Double reserDay, Integer age,
			String birth, String suname2, String jundalPart,
			String reserMoveName, String hangmogCode, String jundalTable,
			Timestamp hopeDate, Double seq, String sort, String sortTime) {
		super();
		this.gwa = gwa;
		this.gwaName = gwaName;
		this.bunho = bunho;
		this.suname = suname;
		this.reserDate = reserDate;
		this.hangmogName = hangmogName;
		this.reserTime = reserTime;
		this.moveName = moveName;
		this.reserDay = reserDay;
		this.age = age;
		this.birth = birth;
		this.suname2 = suname2;
		this.jundalPart = jundalPart;
		this.reserMoveName = reserMoveName;
		this.hangmogCode = hangmogCode;
		this.jundalTable = jundalTable;
		this.hopeDate = hopeDate;
		this.seq = seq;
		this.sort = sort;
		this.sortTime = sortTime;
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
	public String getBunho() {
		return bunho;
	}
	public void setBunho(String bunho) {
		this.bunho = bunho;
	}
	public String getSuname() {
		return suname;
	}
	public void setSuname(String suname) {
		this.suname = suname;
	}
	public Timestamp getReserDate() {
		return reserDate;
	}
	public void setReserDate(Timestamp reserDate) {
		this.reserDate = reserDate;
	}
	public String getHangmogName() {
		return hangmogName;
	}
	public void setHangmogName(String hangmogName) {
		this.hangmogName = hangmogName;
	}
	public String getReserTime() {
		return reserTime;
	}
	public void setReserTime(String reserTime) {
		this.reserTime = reserTime;
	}
	public String getMoveName() {
		return moveName;
	}
	public void setMoveName(String moveName) {
		this.moveName = moveName;
	}
	public Double getReserDay() {
		return reserDay;
	}
	public void setReserDay(Double reserDay) {
		this.reserDay = reserDay;
	}
	public Integer getAge() {
		return age;
	}
	public void setAge(Integer age) {
		this.age = age;
	}
	public String getBirth() {
		return birth;
	}
	public void setBirth(String birth) {
		this.birth = birth;
	}
	public String getSuname2() {
		return suname2;
	}
	public void setSuname2(String suname2) {
		this.suname2 = suname2;
	}
	public String getJundalPart() {
		return jundalPart;
	}
	public void setJundalPart(String jundalPart) {
		this.jundalPart = jundalPart;
	}
	public String getReserMoveName() {
		return reserMoveName;
	}
	public void setReserMoveName(String reserMoveName) {
		this.reserMoveName = reserMoveName;
	}
	public String getHangmogCode() {
		return hangmogCode;
	}
	public void setHangmogCode(String hangmogCode) {
		this.hangmogCode = hangmogCode;
	}
	public String getJundalTable() {
		return jundalTable;
	}
	public void setJundalTable(String jundalTable) {
		this.jundalTable = jundalTable;
	}
	public Timestamp getHopeDate() {
		return hopeDate;
	}
	public void setHopeDate(Timestamp hopeDate) {
		this.hopeDate = hopeDate;
	}
	public Double getSeq() {
		return seq;
	}
	public void setSeq(Double seq) {
		this.seq = seq;
	}
	public String getSort() {
		return sort;
	}
	public void setSort(String sort) {
		this.sort = sort;
	}
	public String getSortTime() {
		return sortTime;
	}
	public void setSortTime(String sortTime) {
		this.sortTime = sortTime;
	}
	
}
