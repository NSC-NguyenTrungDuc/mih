package nta.med.data.model.ihis.schs;

import java.math.BigDecimal;
import java.util.Date;

public class SCH0201U99BookingDetailInfo {
	private String bunho                  ;
	private String suname                 ;
	private Date birth                  ;
	private String sex                    ;
	private String hospCode              ;
	private String yoyangName            ;
	private String tel                    ;                                        
	private Date reserDate             ;
	private String reserTime             ;
	private String bookingDate           ;
	private String outHospCode          ;
	private String hangmogCode           ;
	private BigDecimal linkEmrFlg           ;
	public SCH0201U99BookingDetailInfo(String bunho, String suname, Date birth, String sex, String hospCode,
			String yoyangName, String tel, Date reserDate, String reserTime, String bookingDate, String outHospCode, String hangmogCode, BigDecimal linkEmrFlg) {
		super();
		this.bunho = bunho;
		this.suname = suname;
		this.birth = birth;
		this.sex = sex;
		this.hospCode = hospCode;
		this.yoyangName = yoyangName;
		this.tel = tel;
		this.reserDate = reserDate;
		this.reserTime = reserTime;
		this.bookingDate = bookingDate;
		this.outHospCode = outHospCode;
		this.hangmogCode = hangmogCode;
		this.linkEmrFlg = linkEmrFlg;
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
	public Date getBirth() {
		return birth;
	}
	public void setBirth(Date birth) {
		this.birth = birth;
	}
	public String getSex() {
		return sex;
	}
	public void setSex(String sex) {
		this.sex = sex;
	}
	public String getHospCode() {
		return hospCode;
	}
	public void setHospCode(String hospCode) {
		this.hospCode = hospCode;
	}
	public String getYoyangName() {
		return yoyangName;
	}
	public void setYoyangName(String yoyangName) {
		this.yoyangName = yoyangName;
	}
	public String getTel() {
		return tel;
	}
	public void setTel(String tel) {
		this.tel = tel;
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
	public String getBookingDate() {
		return bookingDate;
	}
	public void setBookingDate(String bookingDate) {
		this.bookingDate = bookingDate;
	}
	public String getOutHospCode() {
		return outHospCode;
	}
	public void setOutHospCode(String outHospCode) {
		this.outHospCode = outHospCode;
	}
	public String getHangmogCode() {
		return hangmogCode;
	}
	public void setHangmogCode(String hangmogCode) {
		this.hangmogCode = hangmogCode;
	}
	public BigDecimal getLinkEmrFlg() {
		return linkEmrFlg;
	}
	public void setLinkEmrFlg(BigDecimal linkEmrFlg) {
		this.linkEmrFlg = linkEmrFlg;
	}
	

}
