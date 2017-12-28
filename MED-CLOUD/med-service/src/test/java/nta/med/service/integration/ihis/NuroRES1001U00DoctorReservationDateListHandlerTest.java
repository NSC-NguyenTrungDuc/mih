package nta.med.service.integration.ihis;

import nta.med.common.remoting.rpc.protobuf.Rpc;
import nta.med.service.ihis.proto.NuroServiceProto;
import nta.med.service.integration.MessageRequestTest;

import org.junit.Test;

public class NuroRES1001U00DoctorReservationDateListHandlerTest  extends MessageRequestTest{

	@Test
	public void testXRT9001R03Lay9003RRequest() throws InterruptedException {
		NuroServiceProto.NuroRES1001U00DoctorReservationDateListRequest request = NuroServiceProto.NuroRES1001U00DoctorReservationDateListRequest
			.newBuilder()   
			.setDoctorCode("0110002")
            .setStartDate("29/11/2015")
            .setEndDate("29/11/2015")
			.build();    
	sentRequestToMedApp(request, NuroServiceProto.getDescriptor().getOptions().getExtension(Rpc.service));
}
}
