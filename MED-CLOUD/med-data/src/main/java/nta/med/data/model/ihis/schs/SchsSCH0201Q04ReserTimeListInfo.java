package nta.med.data.model.ihis.schs;

import java.util.Date;

/**
 * @author Administrator
 *
 */
/**
 * @author Administrator
 *
 */
public class SchsSCH0201Q04ReserTimeListInfo {
	
	private String hangmogCode;
	private String hangmogName;
	private Date reserDate;
	private String reserTime;
	private String suname;
	private String inputId ;
	private String inOutGubun;
	private String inputGwa;
	private String sex ;
	private Integer age ;
	private Date actingDate;
	private String comments;
	private String bunho;
	private String doctor ;
	private String updName ;
	public SchsSCH0201Q04ReserTimeListInfo(String hangmogCode,
			String hangmogName, Date reserDate, String reserTime,
			String suname, String inputId, String inOutGubun, String inputGwa,
			String sex, Integer age, Date actingDate, String comments,
			String bunho, String doctor, String updName) {
		super();
		this.hangmogCode = hangmogCode;
		this.hangmogName = hangmogName;
		this.reserDate = reserDate;
		this.reserTime = reserTime;
		this.suname = suname;
		this.inputId = inputId;
		this.inOutGubun = inOutGubun;
		this.inputGwa = inputGwa;
		this.sex = sex;
		this.age = age;
		this.actingDate = actingDate;
		this.comments = comments;
		this.bunho = bunho;
		this.doctor = doctor;
		this.updName = updName;
	}
	public String getHangmogCode() {
		return hangmogCode;
	}
	public void setHangmogCode(String hangmogCode) {
		this.hangmogCode = hangmogCode;
	}
	public String getHangmogName() {
		return hangmogName;
	}
	public void setHangmogName(String hangmogName) {
		this.hangmogName = hangmogName;
	}
	public Date getReserDate() {
		return reserDate;
	}
	public void setReserDate(Date reserDate) {
		this.reserDate = reserDate;
	}
	public String getReserTime() {
		return reserTime;
	}
	public void setReserTime(String reserTime) {
		this.reserTime = reserTime;
	}
	public String getSuname() {
		return suname;
	}
	public void setSuname(String suname) {
		this.suname = suname;
	}
	public String getInputId() {
		return inputId;
	}
	public void setInputId(String inputId) {
		this.inputId = inputId;
	}
	public String getInOutGubun() {
		return inOutGubun;
	}
	public void setInOutGubun(String inOutGubun) {
		this.inOutGubun = inOutGubun;
	}
	public String getInputGwa() {
		return inputGwa;
	}
	public void setInputGwa(String inputGwa) {
		this.inputGwa = inputGwa;
	}
	public String getSex() {
		return sex;
	}
	public void setSex(String sex) {
		this.sex = sex;
	}
	public Integer getAge() {
		return age;
	}
	public void setAge(Integer age) {
		this.age = age;
	}
	public Date getActingDate() {
		return actingDate;
	}
	public void setActingDate(Date actingDate) {
		this.actingDate = actingDate;
	}
	public String getComments() {
		return comments;
	}
	public void setComments(String comments) {
		this.comments = comments;
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
	public String getUpdName() {
		return updName;
	}
	public void setUpdName(String updName) {
		this.updName = updName;
	}
	
	
	
	
	
}
