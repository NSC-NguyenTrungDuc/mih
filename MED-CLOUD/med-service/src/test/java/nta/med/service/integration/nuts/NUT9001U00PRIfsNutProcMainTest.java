package nta.med.service.integration.nuts;

import org.junit.Test;

import nta.med.common.remoting.rpc.protobuf.Rpc;
import nta.med.service.ihis.proto.NutsServiceProto;
import nta.med.service.integration.MessageRequestTest;

public class NUT9001U00PRIfsNutProcMainTest extends MessageRequestTest {

	@Test
	public void test() throws Exception {

		NutsServiceProto.NUT9001U00PRIfsNutProcMainRequest request = NutsServiceProto.NUT9001U00PRIfsNutProcMainRequest.newBuilder()
				.setMasterFk("2")
				.setSendYn("Y")
				.build();
		
		sentRequestToMedApp(request, NutsServiceProto.getDescriptor().getOptions().getExtension(Rpc.service));
	}
}
