package nta.sfd.core.misc.enums;

/**
 * Created by dainguyen on 8/7/2014.
 */
public enum NotificationType {
    SUCCESS(0), INFO(1), WARN(2), ERROR(3);

    private Integer value;

    NotificationType(Integer value) {
        this.value = value;
    }
    
    public Integer toInt() {
    	return this.value;
    }
}
