package nta.mss.datacapture;

import org.aspectj.lang.JoinPoint;

/**
 * @description
 * @CrBy dai.nguyen.van
 * @CrDate 12/02/2014 1:21 PM
 * @Copyright Nextop Asia Limited. All rights reserved.
 */
public class FirstFailureDataCaptureAspect {

	private ThreadLocal<CallContext> callContext = new ThreadLocal<CallContext>();

	private CallContext getCallContext() {
		CallContext result = callContext.get();
		if (result == null) {
			callContext.set(new CallContext());
			result = callContext.get();
		}
		return result;
	}

	public void afterThrowing(Throwable ex) {
		getCallContext().afterThrowing(ex);
	}

	public void before(JoinPoint joinPoint) {
		getCallContext().before(joinPoint);
	}

	public void afterReturning(Object result) {
		getCallContext().afterReturning(result);
	}

}
