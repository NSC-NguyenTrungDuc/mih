package nta.med.service.integration.nuri;

import org.junit.Test;

import nta.med.common.remoting.rpc.protobuf.Rpc;
import nta.med.service.ihis.proto.NuriServiceProto;
import nta.med.service.integration.MessageRequestTest;

public class NURILIBChkBunhoHandlerTest extends MessageRequestTest{
	@Test
	public void test() throws Exception{
		
		NuriServiceProto.NURILIBChkBunhoRequest request = NuriServiceProto.NURILIBChkBunhoRequest.newBuilder()
				.setBunho("000000002")
				.build();
		sentRequestToMedApp(request, NuriServiceProto.getDescriptor().getOptions().getExtension(Rpc.service));
	}
}
