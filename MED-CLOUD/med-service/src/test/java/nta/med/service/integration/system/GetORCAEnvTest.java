package nta.med.service.integration.system;

import org.junit.Test;

import nta.med.common.remoting.rpc.protobuf.Rpc;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.integration.MessageRequestTest;

public class GetORCAEnvTest extends MessageRequestTest {

	@Test
	public void testGetORCAEnvTest() throws InterruptedException {

		SystemServiceProto.GetORCAEnvRequest request = SystemServiceProto.GetORCAEnvRequest.newBuilder()
				.setHospCode("K01")
				.build();
		
		sentRequestToMedApp(request, SystemServiceProto.getDescriptor().getOptions().getExtension(Rpc.service));

	}
}
