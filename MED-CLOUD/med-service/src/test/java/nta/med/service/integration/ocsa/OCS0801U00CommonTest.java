package nta.med.service.integration.ocsa;

import java.util.concurrent.CountDownLatch;
import java.util.concurrent.TimeUnit;

import nta.med.core.glossary.DataRowState;
import nta.med.common.remoting.rpc.protobuf.Rpc;
import nta.med.service.ihis.proto.InjsServiceProto;
import nta.med.service.ihis.proto.OcsaModelProto;

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
public class OCS0801U00CommonTest {                                                                                          
	@Autowired                                                                                                             
	protected Vertx vertx;                                                                                                 

	@Test                                                                                                                  
	public void Test() throws InterruptedException {   
		OcsaModelProto.OCS0801U00GrdOCS0801ListItemInfo.Builder info = OcsaModelProto.OCS0801U00GrdOCS0801ListItemInfo.newBuilder();
		info.setPatStatus("48");
		info.setPatStatusName("TEST");
		info.setMent("10");
		info.setSeq("10");
		info.setRowSate(DataRowState.ADDED.getValue());
//  		OcsaServiceProto.OCS0801U00TransactionalRequest request = OcsaServiceProto.OCS0801U00TransactionalRequest
//					.newBuilder()
//					.addListInfo1(info)
//					.setUserId("HIEU")
//					.setCallerId("1")
//					.build();                          
		
		InjsServiceProto.INJ1002U01LayReserDateRequest  request = InjsServiceProto.INJ1002U01LayReserDateRequest .newBuilder()
				.setBunho("000033482")
				.build();

			Rpc.RpcMessage rpcMessage = Rpc.RpcMessage                                                                         
					.newBuilder()                                                                                              
					.setId(System.currentTimeMillis())                                                                         
					.setService("patientInsurance ")                                                               
					.setVersion("1.0.0")                                                                           
					.setPayloadClass(                                                                                          
							InjsServiceProto.INJ1002U01LayReserDateRequest.class                                             
									.getSimpleName())                                                                          
					.setPayloadData(request.toByteString()).build();                                                           

			final CountDownLatch latch = new CountDownLatch(1);                                                                
			vertx.eventBus()                                                                                                   
					.send(InjsServiceProto.INJ1002U01LayReserDateRequest.class                                               
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