package nta.med.service.integration.clis;

import nta.med.common.remoting.rpc.protobuf.Rpc;
import nta.med.service.ihis.proto.ClisServiceProto;
import nta.med.service.integration.MessageRequestTest;

import org.junit.Test;

public class CLIS2015U02GrdTrialDrgTest extends MessageRequestTest{


	@Test
	public void testCLIS2015U02GrdTrialDrgTest() throws InterruptedException {
		
		ClisServiceProto.CLIS2015U02GrdTrialDrgRequest request = ClisServiceProto.CLIS2015U02GrdTrialDrgRequest
				.newBuilder()
				.setProtocolId("6")
				.build();
		sentRequestToMedApp(request, ClisServiceProto.getDescriptor().getOptions().getExtension(Rpc.service));

	}
}
