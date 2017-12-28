package nta.med.service.integration.nuri;

import org.junit.Test;

import nta.med.common.remoting.rpc.protobuf.Rpc;
import nta.med.service.ihis.proto.NuriServiceProto;
import nta.med.service.integration.MessageRequestTest;

public class NUR2004U00layHoSexTest extends MessageRequestTest {
	
	@Test
	public void test() throws Exception {
		
		NuriServiceProto.NUR2004U00layHoSexRequest  request = NuriServiceProto.NUR2004U00layHoSexRequest.newBuilder()
				.setHoDong("17")
				.setHoCode("T22")
				.setDate("2017/01/01")
				.build();
		sentRequestToMedApp(request, NuriServiceProto.getDescriptor().getOptions().getExtension(Rpc.service));
	}
	
}
