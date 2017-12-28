package nta.med.service.integration.ocsa;

import org.junit.Test;

import nta.med.common.remoting.rpc.protobuf.Rpc;
import nta.med.service.ihis.proto.OcsaServiceProto;
import nta.med.service.integration.MessageRequestTest;                                                                               
                  
public class OCS0113U00LaySlipInfoTest extends MessageRequestTest{                                                                              
	
	@Test                                                                                                                  
	public void Test() throws InterruptedException {                                                            
  		OcsaServiceProto.OCS0113U00LaySlipInfoRequest request =OcsaServiceProto.OCS0113U00LaySlipInfoRequest
					.newBuilder()    
					.build();                                                                                                  

  		sentRequestToMedApp(request, OcsaServiceProto.getDescriptor().
                getOptions().getExtension(Rpc.service));                                                    
		}                                                                                                                      
	}                                                                                                                          