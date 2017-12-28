package nta.med.service.integration.ihis;

import java.util.concurrent.CountDownLatch;                                                                                
import java.util.concurrent.TimeUnit;                                                                                      

import nta.med.common.remoting.rpc.protobuf.Rpc;
import nta.med.service.ihis.proto.CommonModelProto.LoadSearchOrder1RequestInfo;
import nta.med.service.ihis.proto.CommonModelProto.LoadSearchOrder2RequestInfo;
import nta.med.service.ihis.proto.SystemServiceProto;

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
public class LoadSearchOrder2Test {                                                                                          
	@Autowired                                                                                                             
	protected Vertx vertx;                                                                                                 

	@Test                                                                                                                  
	public void Test() throws InterruptedException {                  
		LoadSearchOrder2RequestInfo.Builder info = LoadSearchOrder2RequestInfo.newBuilder();
		info.setSearchWord("カ");
		//info.setGijunDate();
		info.setInputTab("05");
		info.setWonnaeDrgYn("N");
		info.setSearchCondition("04");
  		SystemServiceProto.LoadSearchOrder2Request request =SystemServiceProto.LoadSearchOrder2Request
					.newBuilder()     
					.setInputInfo(info)
					.build();                                                                                                  

			Rpc.RpcMessage rpcMessage = Rpc.RpcMessage                                                                         
					.newBuilder()                                                                                              
					.setId(System.currentTimeMillis())                                                                         
					.setService("patientInsurance ")                                                               
					.setVersion("1.0.0")                                                                           
					.setPayloadClass(                                                                                          
							SystemServiceProto.LoadSearchOrder2Request.class                                             
									.getSimpleName())                                                                          
					.setPayloadData(request.toByteString()).build();                                                           

			final CountDownLatch latch = new CountDownLatch(1);                                                                
			vertx.eventBus()                                                                                                   
					.send(SystemServiceProto.LoadSearchOrder2Request.class                                               
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