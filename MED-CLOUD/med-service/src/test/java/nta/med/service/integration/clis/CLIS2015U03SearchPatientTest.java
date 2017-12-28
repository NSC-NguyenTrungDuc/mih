package nta.med.service.integration.clis;

import nta.med.common.remoting.rpc.protobuf.Rpc;
import nta.med.service.ihis.proto.ClisServiceProto;
import nta.med.service.integration.MessageRequestTest;

import org.junit.Test;

public class CLIS2015U03SearchPatientTest extends MessageRequestTest{
	@Test
	public void testXRT9001R03Lay9003RRequest() throws InterruptedException {
		
		ClisServiceProto.CLIS2015U03SearchPatientRequest request = ClisServiceProto.CLIS2015U03SearchPatientRequest
				.newBuilder()
				.setFromAge("10")
				.setToAge("20")
				.build();
		sentRequestToMedApp(request, ClisServiceProto.getDescriptor().getOptions().getExtension(Rpc.service));
	}
}
