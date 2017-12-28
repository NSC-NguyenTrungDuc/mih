package nta.med.service.integration.system;

import nta.med.common.remoting.rpc.protobuf.Rpc;
import org.junit.Test;


import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.integration.MessageRequestTest;

public class GetHospitalListTest extends MessageRequestTest {

	@Test
	public void testGetHospitalListTest() throws InterruptedException {

		SystemServiceProto.GetHospitalListRequest request = SystemServiceProto.GetHospitalListRequest.newBuilder()
				.setHospName("小張病院")	
				.setAddress("千葉県野田市横内")
				.build();		
		sentRequestToMedApp(request, SystemServiceProto.getDescriptor().getOptions().getExtension(Rpc.service));

	}
}
