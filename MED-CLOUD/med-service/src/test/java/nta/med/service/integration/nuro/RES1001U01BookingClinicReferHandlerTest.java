package nta.med.service.integration.nuro;

import org.junit.Test;

import nta.med.common.remoting.rpc.protobuf.Rpc;
import nta.med.service.ihis.proto.NuroServiceProto;
import nta.med.service.integration.MessageRequestTest;

public class RES1001U01BookingClinicReferHandlerTest extends MessageRequestTest{

	@Test
	public void testRES1001U01BookingClinicReferHandler() throws InterruptedException{
		NuroServiceProto.RES1001U01BookingClinicReferRequest.Builder request = NuroServiceProto.RES1001U01BookingClinicReferRequest.newBuilder();
		request.setNaewonDate("2015/11/18");
		request.setDoctor("01K01OCS");
		request.setGwa("01");
		
		sentRequestToMedApp(request.build(), NuroServiceProto.getDescriptor().getOptions().getExtension(Rpc.service));
	}
	
}
