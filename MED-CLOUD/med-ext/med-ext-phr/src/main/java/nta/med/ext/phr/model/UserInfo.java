package nta.med.ext.phr.model;

import java.io.Serializable;
import java.util.List;

/**
 * @author DEV-TiepNM
 */
public class UserInfo implements Serializable {
    /**
	 * 
	 */
	
	private static final long serialVersionUID = 1L;
	
	private Long userId;
    private String userName;
    private String password;
    private Long defaultProfileId;
    private List<Long> profileIds;
    public UserInfo()
    {

    }
    public UserInfo(Long userId, String userName, String password, Long defaultProfileId,  List<Long> profileIds) {
        this.userId = userId;
        this.userName = userName;
        this.password = password;
        this.defaultProfileId = defaultProfileId;
        this.profileIds = profileIds;
    }

    public Long getUserId() {
        return userId;
    }

    public void setUserId(Long userId) {
        this.userId = userId;
    }

    public String getUserName() {
        return userName;
    }

    public void setUserName(String userName) {
        this.userName = userName;
    }

    public String getPassword() {
        return password;
    }

    public Long getDefaultProfileId() {
        return defaultProfileId;
    }

    public void setDefaultProfileId(Long defaultProfileId) {
        this.defaultProfileId = defaultProfileId;
    }

    public List<Long> getProfileIds() {
        return profileIds;
    }

    public void setProfileIds(List<Long> profileIds) {
        this.profileIds = profileIds;
    }
}
