package nta.mss.interceptor;

import nta.mss.controller.BaseController;
import nta.mss.model.NotificationModel;
import org.apache.logging.log4j.LogManager;
import org.apache.logging.log4j.Logger;
import org.aspectj.lang.ProceedingJoinPoint;
import org.springframework.web.servlet.ModelAndView;

import java.util.List;

/**
 * @description
 * @CrBy dai.nguyen.van
 * @CrDate 12/02/2014 1:21 PM
 * @Copyright Nextop Asia Limited. All rights reserved.
 */
public class NotificationAspect {
	private static final String NOTIFICATIONS_KEY = "notifications";
    private static final Logger LOG = LogManager.getLogger(NotificationAspect.class);

    public ModelAndView proceed(ProceedingJoinPoint proceedingJP) throws Throwable {
        ModelAndView resultVal = null;
        String methodInformation = proceedingJP.getStaticPart().getSignature().toString();
        LOG.info("Entering " + methodInformation);
//        try {
        resultVal = (ModelAndView) proceedingJP.proceed();
        if (proceedingJP.getTarget() instanceof BaseController) {
            List<NotificationModel> notifications = ((BaseController) proceedingJP.getTarget()).getNotifications();
            resultVal.getModelMap().addAttribute(NOTIFICATIONS_KEY, notifications);
        }
        LOG.info("Exiting " + methodInformation + " with result: " + resultVal);
        return resultVal;
//        } catch (Throwable ex) {
//            LOG.error("Exception in " + methodInformation, ex);
//            throw ex;
//        } finally {
//            LOG.info("Exiting " + methodInformation + " with result: " + resultVal);
//        }
    }
}
