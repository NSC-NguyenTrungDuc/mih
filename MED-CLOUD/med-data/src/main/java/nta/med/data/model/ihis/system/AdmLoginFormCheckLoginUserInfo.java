package nta.med.data.model.ihis.system;

import java.math.BigDecimal;

public class AdmLoginFormCheckLoginUserInfo {
	private String userId ;
	private String userNm ;
	private String userGroup ;
	private String hospCode ;
	private String language ;
	private Integer clisSmoId;
	private BigDecimal loginFlg;
	private String userEndYmd;
	private String certExpired;
	private Integer timeZone;
	public AdmLoginFormCheckLoginUserInfo(String userId, String userNm, String userGroup, String hospCode,
			String language, Integer clisSmoId, BigDecimal loginFlg, String userEndYmd, String certExpired, Integer timeZone) {
		super();
		this.userId = userId;
		this.userNm = userNm;
		this.userGroup = userGroup;
		this.hospCode = hospCode;
		this.language = language;
		this.clisSmoId = clisSmoId;
		this.loginFlg = loginFlg;
		this.userEndYmd = userEndYmd;
		this.certExpired = certExpired;
		this.timeZone = timeZone;
	}
	public String getUserId() {
		return userId;
	}
	public void setUserId(String userId) {
		this.userId = userId;
	}
	public String getUserNm() {
		return userNm;
	}
	public void setUserNm(String userNm) {
		this.userNm = userNm;
	}
	public String getUserGroup() {
		return userGroup;
	}
	public void setUserGroup(String userGroup) {
		this.userGroup = userGroup;
	}
	public String getHospCode() {
		return hospCode;
	}
	public void setHospCode(String hospCode) {
		this.hospCode = hospCode;
	}
	public String getLanguage() {
		return language;
	}
	public void setLanguage(String language) {
		this.language = language;
	}
	public Integer getClisSmoId() {
		return clisSmoId;
	}
	public void setClisSmoId(Integer clisSmoId) {
		this.clisSmoId = clisSmoId;
	}
	public BigDecimal getLoginFlg() {
		return loginFlg;
	}
	public void setLoginFlg(BigDecimal loginFlg) {
		this.loginFlg = loginFlg;
	}
	public String getUserEndYmd() {
		return userEndYmd;
	}
	public void setUserEndYmd(String userEndYmd) {
		this.userEndYmd = userEndYmd;
	}
	public String getCertExpired() {
		return certExpired;
	}
	public void setCertExpired(String certExpired) {
		this.certExpired = certExpired;
	}
	public Integer getTimeZone() {
		return timeZone;
	}
	public void setTimeZone(Integer timeZone) {
		this.timeZone = timeZone;
	}
	
}
