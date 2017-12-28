package nta.med.service.integration.ihis;

import nta.med.common.remoting.rpc.protobuf.Rpc;
import nta.med.service.ihis.proto.OcsaServiceProto;
import nta.med.service.integration.MessageRequestTest;

import org.junit.Test;
import org.junit.runner.RunWith;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.test.context.ContextConfiguration;
import org.springframework.test.context.junit4.SpringJUnit4ClassRunner;
import org.vertx.java.core.Vertx;

@RunWith(SpringJUnit4ClassRunner.class)                                                                                    
@ContextConfiguration(locations = { "classpath:META-INF/spring/spring-master.xml" })                          
public class OcsaOCS0204U00SangNameTest extends MessageRequestTest {                                                                                          
	@Autowired                                                                                                             
	protected Vertx vertx;                                                                                                 

	@Test                                                                                                                  
	public void Test() throws InterruptedException {        
  		OcsaServiceProto.OcsaOCS0204U00SangNameRequest request =OcsaServiceProto.OcsaOCS0204U00SangNameRequest
					.newBuilder()                                                                                              
					.build();                                                                                                  
  		sentRequestToMedApp(request, OcsaServiceProto.getDescriptor().
  				getOptions().getExtension(Rpc.service));

		}                                                                                                                      
	}                                                                                                                          