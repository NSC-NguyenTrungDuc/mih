package nta.med.service.integration.nuri;

import org.junit.Test;

import nta.med.common.remoting.rpc.protobuf.Rpc;
import nta.med.service.ihis.proto.NuriServiceProto;
import nta.med.service.integration.MessageRequestTest;

public class NUR1123U00grdDetailCheckTest extends MessageRequestTest {
	
	@Test
	public void test() throws Exception{
		
		NuriServiceProto.NUR1123U00grdDetailCheckRequest request = NuriServiceProto.NUR1123U00grdDetailCheckRequest.newBuilder()
				.setCodeType("030")
				.setCode("007")
				.build();
		sentRequestToMedApp(request, NuriServiceProto.getDescriptor().getOptions().getExtension(Rpc.service));
	}
}