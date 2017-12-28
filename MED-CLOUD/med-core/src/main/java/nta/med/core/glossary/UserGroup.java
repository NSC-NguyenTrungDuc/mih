package nta.med.core.glossary;

/**
 * @author Tiepnm
 */
public enum UserGroup {
    SAM("SAM"),NTA("NTA");
    private String value;

    UserGroup(String value)
    {
        this.value = value;
    }
    public String getValue(){
        return value;
    }

    public static UserGroup get(String value) {
        for (UserGroup userGroup : UserGroup.values()) {
            if (userGroup.value == value) return userGroup;
        }
        return null;
    }
    public static boolean isSupperAdmin(String userGroup, String hospCode)
    {
        return(UserGroup.SAM.getValue().equals(userGroup) && UserGroup.NTA.getValue().equals(hospCode));
    }

}
