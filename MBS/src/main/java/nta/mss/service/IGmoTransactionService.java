package nta.mss.service;

import nta.mss.misc.common.GmoPaymentHttp;

public interface IGmoTransactionService {

	public GmoPaymentHttp.Message cancelAuth(String version, String shopId, String shopPass, String accessId, String accessPass, String JobCd);

}
