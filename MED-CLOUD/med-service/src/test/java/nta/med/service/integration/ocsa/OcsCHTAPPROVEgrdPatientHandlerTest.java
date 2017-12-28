package nta.med.service.integration.ocsa;

import org.junit.Test;

import nta.med.common.remoting.rpc.protobuf.Rpc;
import nta.med.service.ihis.proto.OcsaServiceProto;
import nta.med.service.integration.MessageRequestTest;

public class OcsCHTAPPROVEgrdPatientHandlerTest extends MessageRequestTest{
	@Test                                                                                                                  
	public void Test() throws InterruptedException {                                                            
  		OcsaServiceProto.OcsCHTAPPROVEgrdPatientRequest request = OcsaServiceProto.OcsCHTAPPROVEgrdPatientRequest	
				.newBuilder()    
				.setApproveYn("Y")
				.setIoGubun("I")
				.setUserId("10323")
				.build();                                                                                                  

  		sentRequestToMedApp(request, OcsaServiceProto.getDescriptor().
                getOptions().getExtension(Rpc.service));                                                    
	} 
}
