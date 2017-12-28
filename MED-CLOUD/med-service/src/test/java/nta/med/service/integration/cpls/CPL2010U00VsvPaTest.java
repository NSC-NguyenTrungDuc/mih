package nta.med.service.integration.cpls;

import nta.med.common.remoting.rpc.protobuf.Rpc;
import nta.med.service.ihis.proto.CplsServiceProto;
import nta.med.service.integration.MessageRequestTest;

import org.junit.Test;

public class CPL2010U00VsvPaTest extends MessageRequestTest{
	@Test
	public void testXRT9001R03Lay9003RRequest() throws InterruptedException {
		
		CplsServiceProto.CPL2010U00VsvPaRequest request =CplsServiceProto.CPL2010U00VsvPaRequest
				.newBuilder()   
				.setBunho("000001584")
				.build();    
		sentRequestToMedApp(request, CplsServiceProto.getDescriptor().getOptions().getExtension(Rpc.service));

	}
}	
