package nta.med.service.integration.ihis;

import org.junit.Test;

import nta.med.common.remoting.rpc.protobuf.Rpc;
import nta.med.service.ihis.proto.OcsoServiceProto;
import nta.med.service.integration.MessageRequestTest;

public class OCS1023U00GrdOCS1023Test extends MessageRequestTest{


	@Test
	public void testCLIS2015U02GrdTrialDrgTest() throws InterruptedException {
		
		OcsoServiceProto.OCS1023U00GrdOCS1023Request request = OcsoServiceProto.OCS1023U00GrdOCS1023Request
				.newBuilder()
				.setBunho("000001725")
				.setGwa("01")
				.setInputTab("01")
				.setGenericYn("N")
				.build();
		sentRequestToMedApp(request, OcsoServiceProto.getDescriptor().getOptions().getExtension(Rpc.service));

	}
}
