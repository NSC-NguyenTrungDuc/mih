package nta.med.service.ihis.handler.schs;

import org.junit.Test;

import nta.med.common.remoting.rpc.protobuf.Rpc;
import nta.med.service.ihis.proto.SchsServiceProto;
import nta.med.service.integration.MessageRequestTest;

public class SchsSCH0201U99ExecTimeListTest extends MessageRequestTest {

	@Test
	public void testSchsSCH0201U99ExecTimeListTest() throws InterruptedException {

		SchsServiceProto.SchsSCH0201U99ExecTimeListRequest request = SchsServiceProto.SchsSCH0201U99ExecTimeListRequest.newBuilder()
				.setIIpAddress("10.1.20.219")
				.setIReserDate("02/02/2016").build();
		sentRequestToMedApp(request, SchsServiceProto.getDescriptor().getOptions().getExtension(Rpc.service));

	}
}
