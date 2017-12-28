package nta.med.service.integration.ocsa;

import java.util.concurrent.CountDownLatch;                                                                                
import java.util.concurrent.TimeUnit;                                                                                      
import nta.med.common.remoting.rpc.protobuf.Rpc;
import nta.med.service.ihis.proto.OcsaServiceProto;
import nta.med.service.integration.MessageRequestTest;
import org.junit.Test;
import org.junit.runner.RunWith;                                                                                           
import org.springframework.beans.factory.annotation.Autowired;                                                             
import org.springframework.test.context.ContextConfiguration;                                                              
import org.springframework.test.context.junit4.SpringJUnit4ClassRunner;                                                    
import org.vertx.java.core.Handler;                                                                                        
import org.vertx.java.core.Vertx;                                                                                          
import org.vertx.java.core.eventbus.Message;                                                                               


public class OCS0101U00Grd0102CheckDataTest extends MessageRequestTest{
	@Autowired                                                                                                             
	protected Vertx vertx;                                                                                                 

	@Test                                                                                                                  
	public void Test() throws InterruptedException {                                                            
  		OcsaServiceProto.OCS0101U00Grd0102CheckDataRequest request =OcsaServiceProto.OCS0101U00Grd0102CheckDataRequest
					.newBuilder()        
					.setValue("B")
					.build();
		sentRequestToMedApp(request, OcsaServiceProto.getDescriptor().
				getOptions().getExtension(Rpc.service));
		}                                                                                                                      
	}                                                                                                                          