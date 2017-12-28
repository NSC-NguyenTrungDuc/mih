package nta.med.service.integration.nuro;

import nta.med.common.remoting.rpc.protobuf.Rpc;
import nta.med.service.ihis.proto.NuroServiceProto;
import nta.med.service.integration.MessageRequestTest;

import org.junit.Test;

public class OUT0101PhrInsertTest extends MessageRequestTest {
	@Test
	public void testXRT9001R03Lay9003RRequest() throws InterruptedException {
		
		NuroServiceProto.OUT0101PhrInsertRequest request = NuroServiceProto.OUT0101PhrInsertRequest
				.newBuilder()
				.setHospCode("NTA")
				.setSysId("PHR")
				.setUserName("NTATest")
				.build();
		sentRequestToMedApp(request, NuroServiceProto.getDescriptor().getOptions().getExtension(Rpc.service));
	}
}
