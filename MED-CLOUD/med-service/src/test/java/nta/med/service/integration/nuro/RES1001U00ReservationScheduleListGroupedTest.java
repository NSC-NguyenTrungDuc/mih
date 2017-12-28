package nta.med.service.integration.nuro;

import nta.med.common.remoting.rpc.protobuf.Rpc;
import nta.med.service.ihis.proto.ClisServiceProto;
import nta.med.service.ihis.proto.NuroServiceProto;
import nta.med.service.integration.MessageRequestTest;

import org.junit.Test;

public class RES1001U00ReservationScheduleListGroupedTest extends MessageRequestTest{
	@Test
	public void testXRT9001R03Lay9003RRequest() throws InterruptedException {
		
		NuroServiceProto.RES1001U00ReservationScheduleListGroupedRequest request = NuroServiceProto.RES1001U00ReservationScheduleListGroupedRequest
				.newBuilder()
				.build();
		sentRequestToMedApp(request, NuroServiceProto.getDescriptor().getOptions().getExtension(Rpc.service));
	}
}
