package nta.med.service.integration.ocsa;

import org.junit.Test;

import nta.med.common.remoting.rpc.protobuf.Rpc;
import nta.med.service.ihis.proto.OcsaServiceProto;
import nta.med.service.integration.MessageRequestTest;

public class OcsCHTAPPROVElayGwaHandlerTest extends MessageRequestTest{

	@Test                                                                                                                  
	public void Test() throws InterruptedException {                                                            
  		OcsaServiceProto.OcsCHTAPPROVElayGwaRequest request = OcsaServiceProto.OcsCHTAPPROVElayGwaRequest
					.newBuilder()    
					.build();                                                                                                  

  		sentRequestToMedApp(request, OcsaServiceProto.getDescriptor().
                getOptions().getExtension(Rpc.service));                                                    
	}   
}
