package nta.med.ext.phr.model;

import java.util.List;

/**
 * @author DEV-TiepNM
 */
public class PhrContext {

    private String username;
    private String password;
    private Long userId;
    private Long defaultProfileId;
    private List<Long> profileIds;

    public PhrContext(Long userId, String username, String password, Long defaultProfileId, List<Long> profileIds) {
        this.userId = userId;
        this.username = username;
        this.password = password;
        this.defaultProfileId = defaultProfileId;
        this.profileIds = profileIds;
    }

    private static InheritableThreadLocal<PhrContext> context = new InheritableThreadLocal<>();

    public static void init(Long userId, String username, String password, Long defaultProfileId, List<Long> profileIds){
        context.set(new PhrContext(userId, username, password, defaultProfileId, profileIds));
    }

    public static PhrContext current(){
        return context == null ? null : context.get();
    }

    public String getUsername() {
        return username;
    }

    public String getPassword() {
        return password;
    }

    public Long getUserId() {
        return userId;
    }

    public Long getDefaultProfileId() {
        return defaultProfileId;
    }

    public List<Long> getProfileIds() {
        return profileIds;
    }


}
