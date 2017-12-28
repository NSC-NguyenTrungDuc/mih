package nta.med.service.integration.nuri;

import org.junit.Test;

import nta.med.common.remoting.rpc.protobuf.Rpc;
import nta.med.service.ihis.proto.NuriServiceProto;
import nta.med.service.integration.MessageRequestTest;

public class NUR1123U00grdMasterCheckTest extends MessageRequestTest {
	
	@Test
	public void test() throws Exception{
		
		NuriServiceProto.NUR1123U00grdMasterCheckRequest request = NuriServiceProto.NUR1123U00grdMasterCheckRequest.newBuilder()
				.build();
		sentRequestToMedApp(request, NuriServiceProto.getDescriptor().getOptions().getExtension(Rpc.service));
	}
}
