package nta.med.service.ihis.handler.schs;

import org.junit.Test;

import nta.med.common.remoting.rpc.protobuf.Rpc;
import nta.med.service.ihis.proto.SchsServiceProto;
import nta.med.service.integration.MessageRequestTest;

public class SCH0201U99GetListBookingTest extends MessageRequestTest {

	@Test
	public void testSchsSCH0201U99ExecTimeListTest() throws InterruptedException {

		SchsServiceProto.SCH0201U99GetListBookingRequest request = SchsServiceProto.SCH0201U99GetListBookingRequest.newBuilder()
				.setHospCodeLink("346")
				.setBunhoLink("000001852")
				.setReserDate("2015/11/23")
				.setReserTime("0900")
				.setHangmogCode("9900007")
				.build();
		
		sentRequestToMedApp(request, SchsServiceProto.getDescriptor().getOptions().getExtension(Rpc.service));

	}
}
