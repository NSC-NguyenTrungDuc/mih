package nta.med.service.integration.system;

import org.junit.Test;

import nta.med.common.remoting.rpc.protobuf.Rpc;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.integration.MessageRequestTest;

public class OBIsMeterialOrderTest extends MessageRequestTest{

	@Test
	public void testGetHospitalListTest() throws InterruptedException {

		SystemServiceProto.OBIsMeterialOrderRequest request = SystemServiceProto.OBIsMeterialOrderRequest.newBuilder()
				.setHangmogCode("57834975")
				.build();		
		sentRequestToMedApp(request, SystemServiceProto.getDescriptor().getOptions().getExtension(Rpc.service));
	}
}
