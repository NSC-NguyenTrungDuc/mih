package nta.mss.datacapture;

import java.util.ArrayList;
import java.util.List;

import org.apache.logging.log4j.LogManager;
import org.apache.logging.log4j.Logger;
import org.aspectj.lang.JoinPoint;

/**
 * @description
 * @CrBy dai.nguyen.van
 * @CrDate 12/02/2014 1:21 PM
 * @Copyright Nextop Asia Limited. All rights reserved.
 */
class CallContext {

    private static final Logger LOG = LogManager.getLogger(CallContext.class);
    

	private List<Call> calls = new ArrayList<Call>();

	private Throwable firstFailure;

	private int depth = 0;

	public void before(JoinPoint joinPoint) {
		calls.add(new Call(joinPoint, this.depth++));
	}

	public void afterReturning(Object result) {
        if(calls.size() > 0){
            calls.get(calls.size() - 1).setResult(result == null ? null : result.toString());
        }
		endCall();
	}

	private void endCall() {
		this.depth--;
		if (depth == 0) {
			calls.clear();
		}
	}

	public void afterThrowing(Throwable ex) {
		if (this.firstFailure == null) {
			this.firstFailure = ex;
		}
		log(ex);
		endCall();
	}

	private void log(Throwable ex) {
		for (Call c : calls) {
			StringBuilder builder = new StringBuilder();
			for (int i = 0; i < c.getDepth(); i++) {
				builder.append("    ");
			}
			builder.append(c.toString());
            LOG.info(builder.toString());
		}
        LOG.info("Call resulted in exception", ex);
		if (firstFailure != null && firstFailure != ex) {
			LOG.info("First failure detected other than exception thrown: " + firstFailure.getMessage(), ex);;
		}
	}

}
