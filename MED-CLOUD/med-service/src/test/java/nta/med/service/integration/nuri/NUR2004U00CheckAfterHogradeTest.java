package nta.med.service.integration.nuri;

import org.junit.Test;

import nta.med.common.remoting.rpc.protobuf.Rpc;
import nta.med.service.ihis.proto.NuriServiceProto;
import nta.med.service.integration.MessageRequestTest;

public class NUR2004U00CheckAfterHogradeTest extends MessageRequestTest {
	
	@Test
	public void test() throws Exception {
		
		NuriServiceProto.NUR2004U00CheckAfterHogradeRequest request = NuriServiceProto.NUR2004U00CheckAfterHogradeRequest.newBuilder()
				.setBunho("000000115")
				.setFkinp1001("1612522")
				.setDate("2017/01/01")
				.build();
		sentRequestToMedApp(request, NuriServiceProto.getDescriptor().getOptions().getExtension(Rpc.service));
	}
	
}
