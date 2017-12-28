package nta.sfd.controller;

import nta.sfd.common.MedContextHolder;
import nta.sfd.core.model.NotificationModel;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.beans.propertyeditors.StringTrimmerEditor;
import org.springframework.context.MessageSource;
import org.springframework.util.StringUtils;
import org.springframework.web.bind.WebDataBinder;
import org.springframework.web.bind.annotation.InitBinder;
import org.springframework.web.servlet.FlashMap;
import org.springframework.web.servlet.support.RequestContextUtils;

import javax.servlet.http.HttpServletRequest;
import java.util.ArrayList;
import java.util.List;
import java.util.Locale;
import java.util.Map;


/**
 * The Class BaseController.
 *
 * @author DinhNX
 * @CrtDate Jul 23, 2014
 */
public class BaseController {

    private static final String FLASH_MAP_NOTIFICATION_KEY = "FLASH_MAP_NOTIFICATION_KEY";

    @Autowired
    private MessageSource messageSource;

    @Autowired
    private HttpServletRequest request;

    @InitBinder
    public void initBinder(WebDataBinder binder) {
        StringTrimmerEditor stringTrimmer = new StringTrimmerEditor(true);
        binder.registerCustomEditor(String.class, stringTrimmer);
    }
    
    /**
     * Gets the language.
     *
     * @return the language
     */
    public String getLanguage() {
        return MedContextHolder.getUserLanguage();
    }

    /**
     * Gets the locale.
     *
     * @return the locale
     */
    public Locale getLocale() {
        return StringUtils.parseLocaleString(this.getLanguage());
    }

    /**
     * Gets the text.
     *
     * @param key the key
     * @return the text
     */
    public String getText(String key) {
        return this.messageSource.getMessage(key, null, this.getLocale());
    }

    /**
     * Gets the text.
     *
     * @param key  the key
     * @param args the args
     * @return the text
     */
    public String getText(String key, List<Object> args) {
        return this.messageSource.getMessage(key, args.toArray(), this.getLocale());
    }


    /**
     * Add notification.
     *
     * @param notification the notification
     */
    @SuppressWarnings("unchecked")
	public void addNotification(NotificationModel notification) {
        FlashMap flashMap = RequestContextUtils.getOutputFlashMap(request);
        if (!flashMap.containsKey(FLASH_MAP_NOTIFICATION_KEY)) {
            flashMap.put(FLASH_MAP_NOTIFICATION_KEY, new ArrayList<NotificationModel>());
        }
        List<NotificationModel> notificationModels = (List<NotificationModel>) flashMap.get(FLASH_MAP_NOTIFICATION_KEY);
        notificationModels.add(notification);
    }

    @SuppressWarnings("unchecked")
	public List<NotificationModel> getNotifications() {
        Map<String, ?> flashMap = RequestContextUtils.getInputFlashMap(request);
        return flashMap != null && flashMap.containsKey(FLASH_MAP_NOTIFICATION_KEY) ? (List<NotificationModel>) flashMap.get(FLASH_MAP_NOTIFICATION_KEY) : null;
    }
}
