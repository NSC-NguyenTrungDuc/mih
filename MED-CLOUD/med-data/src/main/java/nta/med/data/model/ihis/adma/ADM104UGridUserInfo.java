package nta.med.data.model.ihis.adma;

import java.math.BigDecimal;
import java.sql.Timestamp;

public class ADM104UGridUserInfo {
	private String userId;
	private String userNm;
	private String userScrt;
	private String deptCode;
	private String buseoName;
	private String userGroup;
	private String groupNm;
	private Double userLevel;
	private Timestamp userEndYmd;
	private String userGubun;
	private String nurseConfirmEnableYn;
	private String coId;
	private String email;
	private Integer clisSmoId;
	private BigDecimal loginFlg;
	private BigDecimal changePwdFlg;
	private String pwdHistory;

	public ADM104UGridUserInfo(String userId, String userNm, String userScrt,
			String deptCode, String buseoName, String userGroup,
			String groupNm, Double userLevel, Timestamp userEndYmd,
			String userGubun, String nurseConfirmEnableYn, String coId,
			String email, Integer clisSmoId, BigDecimal loginFlg, BigDecimal changePwdFlg, String pwdHistory) {
		super();
		this.userId = userId;
		this.userNm = userNm;
		this.userScrt = userScrt;
		this.deptCode = deptCode;
		this.buseoName = buseoName;
		this.userGroup = userGroup;
		this.groupNm = groupNm;
		this.userLevel = userLevel;
		this.userEndYmd = userEndYmd;
		this.userGubun = userGubun;
		this.nurseConfirmEnableYn = nurseConfirmEnableYn;
		this.coId = coId;
		this.email = email;
		this.clisSmoId = clisSmoId;
		this.loginFlg = loginFlg;
		this.changePwdFlg = changePwdFlg;
		this.pwdHistory = pwdHistory;
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

	public String getUserScrt() {
		return userScrt;
	}

	public void setUserScrt(String userScrt) {
		this.userScrt = userScrt;
	}

	public String getDeptCode() {
		return deptCode;
	}

	public void setDeptCode(String deptCode) {
		this.deptCode = deptCode;
	}

	public String getBuseoName() {
		return buseoName;
	}

	public void setBuseoName(String buseoName) {
		this.buseoName = buseoName;
	}

	public String getUserGroup() {
		return userGroup;
	}

	public void setUserGroup(String userGroup) {
		this.userGroup = userGroup;
	}

	public String getGroupNm() {
		return groupNm;
	}

	public void setGroupNm(String groupNm) {
		this.groupNm = groupNm;
	}

	public Double getUserLevel() {
		return userLevel;
	}

	public void setUserLevel(Double userLevel) {
		this.userLevel = userLevel;
	}

	public Timestamp getUserEndYmd() {
		return userEndYmd;
	}

	public void setUserEndYmd(Timestamp userEndYmd) {
		this.userEndYmd = userEndYmd;
	}

	public String getUserGubun() {
		return userGubun;
	}

	public void setUserGubun(String userGubun) {
		this.userGubun = userGubun;
	}

	public String getNurseConfirmEnableYn() {
		return nurseConfirmEnableYn;
	}

	public void setNurseConfirmEnableYn(String nurseConfirmEnableYn) {
		this.nurseConfirmEnableYn = nurseConfirmEnableYn;
	}

	public String getCoId() {
		return coId;
	}

	public void setCoId(String coId) {
		this.coId = coId;
	}

	public String getEmail() {
		return email;
	}

	public void setEmail(String email) {
		this.email = email;
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

	public BigDecimal getChangePwdFlg() {
		return changePwdFlg;
	}

	public void setChangePwdFlg(BigDecimal changePwdFlg) {
		this.changePwdFlg = changePwdFlg;
	}

	public String getPwdHistory() {
		return pwdHistory;
	}

	public void setPwdHistory(String pwdHistory) {
		this.pwdHistory = pwdHistory;
	}
}