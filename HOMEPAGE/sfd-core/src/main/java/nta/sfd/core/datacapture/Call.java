package nta.sfd.core.datacapture;

import org.aspectj.lang.JoinPoint;

/**
 * @description
 * @CrBy dai.nguyen.van
 * @CrDate 12/02/2014 1:21 PM
 * @Copyright Nextop Asia Limited. All rights reserved.
 */
class Call {
	private int depth;
	private String signatureAndParameters;
	private String result;

	public Call(JoinPoint joinPoint, int depth) {
		this.depth = depth;
		this.signatureAndParameters = formatSignatureAndParameters(joinPoint);
	}

	private String formatSignatureAndParameters(JoinPoint joinPoint) {
		StringBuilder builder = new StringBuilder();
		builder.append(joinPoint.getStaticPart().getSignature().toString());
		Object[] args = joinPoint.getArgs();
		if (args.length > 0) {
			builder.append(" args ");
			for (Object arg : args) {
				builder.append(arg == null ? null : arg.toString());
				builder.append(" ");
			}
		}
		return builder.toString();
	}

	public int getDepth() {
		return depth;
	}

	public String getSignatureAndParameters() {
		return signatureAndParameters;
	}

	public String getResult() {
		return result;
	}

	public void setResult(String result) {
		this.result = result;
	}
	
	@Override
	public String toString() {
		return signatureAndParameters + (result == null ? "" : " result "+result);
	}


}