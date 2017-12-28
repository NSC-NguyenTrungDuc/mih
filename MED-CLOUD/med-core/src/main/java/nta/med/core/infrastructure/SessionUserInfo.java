package nta.med.core.infrastructure;


import java.io.Serializable;

import nta.med.core.glossary.UserGroup;
import nta.med.core.glossary.UserRole;
import org.apache.logging.log4j.util.Strings;


/**
 * @author Tiepnm
 */
public class SessionUserInfo implements Serializable {
	
	private static final long serialVersionUID = 1L;
	private String hospitalCode;
    private String language;
    private String userId;
    private String role;
    private Integer clisSmoId;
    private Integer timeZone;
    private String userGroup;

    public SessionUserInfo()
    {
    }
    
    public SessionUserInfo(String hospitalCode, String language, String userId, String role, Integer clisSmoId)
    {
        if(Strings.isEmpty(hospitalCode))
        {
            hospitalCode = UserGroup.NTA.getValue();
        }
    	this.hospitalCode = hospitalCode;
    	this.language = language;
    	this.userId = userId;
    	this.role = role;
    	this.clisSmoId = clisSmoId;
    }
    
    public SessionUserInfo(String hospitalCode, String language, String userId, Integer clisSmoId)
    {
    	this.hospitalCode = hospitalCode;
    	this.language = language;
    	this.userId = userId;
    	this.clisSmoId = clisSmoId;
    }
    
    public static SessionUserInfo setSessionUserInfoByUserGroup(String hospitalCode, String language, String userId, Integer clisSmoId, String userGroup)
    {
    	String role = UserRole.NORMAL_ADMIN.getValue();
    	if (UserGroup.isSupperAdmin(userGroup, hospitalCode)) {
    		role = UserRole.SUPER_ADMIN.getValue();
    	}
        SessionUserInfo sessionUserInfo =  new SessionUserInfo(hospitalCode, language, userId, role, clisSmoId);
        sessionUserInfo.setUserGroup(userGroup);
    	return sessionUserInfo;
    }
    
    public static SessionUserInfo setSessionUserInfoByUserGroup(String hospitalCode, String language, String userId, Integer clisSmoId){
    	return new SessionUserInfo(hospitalCode, language, userId, UserRole.SUPER_ADMIN.getValue(), clisSmoId);
    }
    
    public String getHospitalCode() {
        return hospitalCode;
    }

    public void setHospitalCode(String hospitalCode) {
        this.hospitalCode = hospitalCode;
    }

    public String getLanguage() {
        return language;
    }

    public void setLanguage(String language) {
        this.language = language;
    }

    public String getUserId() {
        return userId;
    }

    public void setUserId(String userId) {
        this.userId = userId;
    }

    public String getRole() {
        return role;
    }

    public void setRole(String role) {
        this.role = role;
    }

	public Integer getClisSmoId() {
		return clisSmoId;
	}

	public void setClisSmoId(Integer clisSmoId) {
		this.clisSmoId = clisSmoId;
	}

    public Integer getTimeZone() {
        return timeZone;
    }

    public void setTimeZone(Integer timeZone) {
        this.timeZone = timeZone;
    }

    public String getUserGroup() {
        return userGroup;
    }

    public void setUserGroup(String userGroup) {
        this.userGroup = userGroup;
    }
}
