package nta.med.service.integration.ocsa;

import org.junit.Test;

import nta.med.common.remoting.rpc.protobuf.Rpc;
import nta.med.service.ihis.proto.OcsaServiceProto;
import nta.med.service.integration.MessageRequestTest;

public class OcsCHTAPPROVEgetOneResultHandlerTest extends MessageRequestTest{
	@Test                                                                                                                  
	public void Test() throws InterruptedException {                                                            
  		OcsaServiceProto.OcsCHTAPPROVEgetOneResultRequest request = OcsaServiceProto.OcsCHTAPPROVEgetOneResultRequest	
				.newBuilder()  
				.setGwa("gwa")
				.build();                                                                                                  

  		sentRequestToMedApp(request, OcsaServiceProto.getDescriptor().
                getOptions().getExtension(Rpc.service));                                                    
	}
}
