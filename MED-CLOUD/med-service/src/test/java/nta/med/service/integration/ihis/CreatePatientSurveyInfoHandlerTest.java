package nta.med.service.integration.ihis;

import org.junit.Test;

import nta.med.common.remoting.rpc.protobuf.Rpc;
import nta.med.service.ihis.proto.BassServiceProto;

import nta.med.service.integration.MessageRequestTest;

public class CreatePatientSurveyInfoHandlerTest extends MessageRequestTest {
	
	@Test
	public void testCreatePatientSurveyInfoHandler() throws InterruptedException {
		BassServiceProto.CreatePatientSurveyRequest request = BassServiceProto.CreatePatientSurveyRequest.newBuilder().setHospCode("K01").build();
		
		sentRequestToMedApp(request,BassServiceProto.getDescriptor().getOptions().getExtension(Rpc.service));
		
		
		
	}

}
