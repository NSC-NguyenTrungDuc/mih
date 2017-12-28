package nta.med.service.integration.ocsa;

import org.junit.Test;

import nta.med.common.remoting.rpc.protobuf.Rpc;
import nta.med.service.ihis.proto.OcsaServiceProto;
import nta.med.service.integration.MessageRequestTest;

public class OcsCHTAPPROVEfbxAPPHandlerTest extends MessageRequestTest{
	@Test                                                                                                                  
	public void Test() throws InterruptedException {                                                            
  		OcsaServiceProto.OcsCHTAPPROVEfbxAPPRequest request = OcsaServiceProto.OcsCHTAPPROVEfbxAPPRequest	
				.newBuilder()  
				.setNameControl("gwa")
				.setDate("2016/11/11")
				.setFind1("01")
				.build();                                                                                                  

  		sentRequestToMedApp(request, OcsaServiceProto.getDescriptor().
                getOptions().getExtension(Rpc.service));                                                    
	}
}
