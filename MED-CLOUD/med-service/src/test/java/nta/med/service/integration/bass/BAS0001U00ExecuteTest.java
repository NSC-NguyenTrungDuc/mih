package nta.med.service.integration.bass;

import java.util.concurrent.CountDownLatch;
import java.util.concurrent.TimeUnit;

import nta.med.common.remoting.rpc.protobuf.Rpc;
import nta.med.service.ihis.proto.AdmaServiceProto;
import nta.med.service.ihis.proto.DrgsServiceProto;

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
public class BAS0001U00ExecuteTest {                                                                                          
	@Autowired                                                                                                             
	protected Vertx vertx;                                                                                                 

	@Test                                                                                                                  
	public void Test() throws InterruptedException {      
		
		DrgsServiceProto.DRG0102U01GrdDetailRequest request = DrgsServiceProto.DRG0102U01GrdDetailRequest.
				newBuilder()
				.setCodeType("01")
				.build();
		
//		OcsoServiceProto.OCS1003Q09GridOCS1003Request request = OcsoServiceProto.OCS1003Q09GridOCS1003Request
//					.newBuilder()  
//					.setBunho("00000HIEP")
//					.setNaewonDate("2015/05/09")
//					.setNaewonType("O")
//					.setGwa("01")
//					.setDoctor("0199999")
//					.setInputGubun("D0")
//					.setTelYn("%")
//					.setInputTab("%")
//					.setJubsuNo("1")
//					.setPkOrder("329533")
////					.setPkOrder("316588")
//					.setGenericYn("N")
//					.setKijun("O")
//					.setIoGubun("O")
//					.build();                                                                                                  

			Rpc.RpcMessage rpcMessage = Rpc.RpcMessage                                                                         
					.newBuilder()                                                                                              
					.setId(System.currentTimeMillis())                                                                         
					.setService("patientInsurance ")                                                               
					.setVersion("1.0.0")                                                                           
					.setPayloadClass(                                                                                          
							DrgsServiceProto.DRG0102U01GrdMasterRequest.class                                             
									.getSimpleName())                                                                          
					.setPayloadData(request.toByteString()).build();                                                           

			final CountDownLatch latch = new CountDownLatch(1);                                                                
			vertx.eventBus()                                                                                                   
					.send(DrgsServiceProto.DRG0102U01GrdMasterRequest.class                                               
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