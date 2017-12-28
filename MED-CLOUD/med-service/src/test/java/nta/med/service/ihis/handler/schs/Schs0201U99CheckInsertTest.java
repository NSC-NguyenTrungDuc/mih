package nta.med.service.ihis.handler.schs;

import org.junit.Test;

import nta.med.common.remoting.rpc.protobuf.Rpc;
import nta.med.service.ihis.proto.SchsServiceProto;
import nta.med.service.integration.MessageRequestTest;

public class Schs0201U99CheckInsertTest extends MessageRequestTest {

	@Test
	public void testSchsSCH0201U99ExecTimeListTest() throws InterruptedException {

		SchsServiceProto.Schs0201U99CheckInsertRequest request = SchsServiceProto.Schs0201U99CheckInsertRequest.newBuilder()
				.setDoctor("")
				.setBunho("")
				.setHospCode("")
				.setNaewonDate("")
				.build();
		
		sentRequestToMedApp(request, SchsServiceProto.getDescriptor().getOptions().getExtension(Rpc.service));

	}
}
