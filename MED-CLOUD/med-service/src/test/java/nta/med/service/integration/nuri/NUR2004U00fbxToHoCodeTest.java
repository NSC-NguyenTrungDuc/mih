package nta.med.service.integration.nuri;

import org.junit.Test;

import nta.med.common.remoting.rpc.protobuf.Rpc;
import nta.med.service.ihis.proto.NuriServiceProto;
import nta.med.service.integration.MessageRequestTest;

public class NUR2004U00fbxToHoCodeTest extends MessageRequestTest {
	
	@Test
	public void test() throws Exception {
		
		NuriServiceProto.NUR2004U00fbxToHoCodeRequest request = NuriServiceProto.NUR2004U00fbxToHoCodeRequest.newBuilder()
				.setDate("2017/01/01")
				.setHodong("17")
				.build();
		sentRequestToMedApp(request, NuriServiceProto.getDescriptor().getOptions().getExtension(Rpc.service));
	}
	
}
