package nta.mss.model;

import java.io.Serializable;

import nta.mss.misc.enums.NotificationType;

/**
 * Created by dainguyen on 8/7/2014.
 */
public class NotificationModel implements Serializable {
	private static final long serialVersionUID = -6323364910459958L;
	private NotificationType notificationType;
    private String message;
    private String timeAppear;

    /**
     * Instantiates a new Notification model.
     *
     * @param notificationType the notification type
     * @param message the message
     */
    public NotificationModel(NotificationType notificationType, String message) {
        this.notificationType = notificationType;
        this.message = message;
    }

    /**
     * Gets notification type.
     *
     * @return the notification type
     */
    public NotificationType getNotificationType() {
        return notificationType;
    }

    /**
     * Gets message.
     *
     * @return the message
     */
    public String getMessage() {
        return message;
    }

    /**
     * Sets notification type.
     *
     * @param notificationType the notification type
     */
    public void setNotificationType(NotificationType notificationType) {
        this.notificationType = notificationType;
    }

    /**
     * Sets message.
     *
     * @param message the message
     */
    public void setMessage(String message) {
        this.message = message;
    }

	public String getTimeAppear() {
		return timeAppear;
	}

	public void setTimeAppear(String timeAppear) {
		this.timeAppear = timeAppear;
	}
    
    
}
