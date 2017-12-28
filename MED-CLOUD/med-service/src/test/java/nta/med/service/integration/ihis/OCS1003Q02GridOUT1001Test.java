package nta.med.service.integration.ihis;

import java.util.concurrent.CountDownLatch;                                                                                
import java.util.concurrent.TimeUnit;                                                                                      
import nta.med.common.remoting.rpc.protobuf.Rpc;
import nta.med.service.ihis.proto.OcsoServiceProto;
import org.junit.Test;                                                                                                     
import org.junit.runner.RunWith;                                                                                           
import org.springframework.beans.factory.annotation.Autowired;                                                             
import org.springframework.test.context.ContextConfiguration;                                                              
import org.springframework.test.context.junit4.SpringJUnit4ClassRunner;                                                    
import org.vertx.java.core.Handler;                                                                                        
import org.vertx.java.core.Vertx;                                                                                          
import org.vertx.java.core.eventbus.Message;                                                                               

@RunWith(SpringJUnit4ClassRunner.class)                                                                                    
@ContextConfiguration(locations = { "classpath:META-INF/spring/spring-master.xml" })                          
public class OCS1003Q02GridOUT1001Test {                                                                                          
	@Autowired                                                                                                             
	protected Vertx vertx;                                                                                                 

	@Test                                                                                                                  
	public void Test() throws InterruptedException {                                                            
  		OcsoServiceProto.OCS1003Q02GridOUT1001Request request =OcsoServiceProto.OCS1003Q02GridOUT1001Request
					.newBuilder()  
					.setNaewonDate("2014/02/14")
					.setBunho("000000001")
					.setGwa("IR")
					.setDoctor("0110001")
					.setNaewonYn("%")
					.build();                                                                                                  

			Rpc.RpcMessage rpcMessage = Rpc.RpcMessage                                                                         
					.newBuilder()                                                                                              
					.setId(System.currentTimeMillis())                                                                         
					.setService("patientInsurance ")                                                               
					.setVersion("1.0.0")                                                                           
					.setPayloadClass(                                                                                          
							OcsoServiceProto.OCS1003Q02GridOUT1001Request.class                                             
									.getSimpleName())                                                                          
					.setPayloadData(request.toByteString()).build();                                                           

			final CountDownLatch latch = new CountDownLatch(1);                                                                
			vertx.eventBus()                                                                                                   
					.send(OcsoServiceProto.OCS1003Q02GridOUT1001Request.class                                               
							.getSimpleName(),                                                                                  
							rpcMessage.toByteArray(),                                                                          
							new Handler<Message<byte[]>>() {                                                                   
								@Override                                                                                      
								public void handle(Message<byte[]> event) {                                                    
									System.out.println("Success!");                                                
									latch.countDown();                                                                         
								}                                                                                              
							});                                                                                                
			latch.await(100, TimeUnit.SECONDS);                                                                                
		}                                                                                                                      
	}                                                                                                                          