package nta.mss.datacapture;

import org.apache.logging.log4j.LogManager;
import org.apache.logging.log4j.Logger;
import org.aspectj.lang.ProceedingJoinPoint;

/**
 * @description
 * @CrBy dai.nguyen.van
 * @CrDate 12/02/2014 1:21 PM
 * @Copyright Nextop Asia Limited. All rights reserved.
 */
public class ActionTracingAspect {

    private static final Logger LOG = LogManager.getLogger(ActionTracingAspect.class);

    public String trace(ProceedingJoinPoint proceedingJP) throws Throwable {
        String resultVal = "";
        String methodInformation = proceedingJP.getStaticPart().getSignature().toString();
        LOG.info("Entering " + methodInformation);
        try {
            Object result = proceedingJP.proceed();
            resultVal = result == null ? null : result.toString();
            return resultVal;
        } catch (Throwable ex) {
            LOG.error("Exception in " + methodInformation, ex);
            throw ex;
        } finally {
            LOG.info("Exiting " + methodInformation + " with result: " + resultVal);
        }
    }
}
