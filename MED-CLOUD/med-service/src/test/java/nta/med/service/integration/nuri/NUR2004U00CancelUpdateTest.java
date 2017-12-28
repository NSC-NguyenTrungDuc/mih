package nta.med.service.integration.nuri;

import org.junit.Test;

import nta.med.common.remoting.rpc.protobuf.Rpc;
import nta.med.service.ihis.proto.NuriServiceProto;
import nta.med.service.integration.MessageRequestTest;

public class NUR2004U00CancelUpdateTest extends MessageRequestTest{
	@Test
	public void test() throws Exception{
		
		NuriServiceProto.NUR2004U00CancelUpdateRequest request = NuriServiceProto.NUR2004U00CancelUpdateRequest.newBuilder()
				.setBunho("000000011")
				.setFkinp1001("1609812")
				.setTransCnt("1")
				.setUserId("T0014")
				.setCancelSayu("")
				.build();
		sentRequestToMedApp(request, NuriServiceProto.getDescriptor().getOptions().getExtension(Rpc.service));
	}
}
