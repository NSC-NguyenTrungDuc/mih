package nta.med.service.integration.drgs;

import org.junit.Test;

import nta.med.common.remoting.rpc.protobuf.Rpc;
import nta.med.service.ihis.proto.DrgsServiceProto;
import nta.med.service.integration.MessageRequestTest;

public class DRG3010P10PostLoadTest extends MessageRequestTest {
	@Test
	
	public void Test() throws Exception {
		DrgsServiceProto.DRG3010P10PostLoadRequest request = DrgsServiceProto.DRG3010P10PostLoadRequest.newBuilder()
				.build();
		sentRequestToMedApp(request, DrgsServiceProto.getDescriptor().getOptions().getExtension(Rpc.service));
	}
}
