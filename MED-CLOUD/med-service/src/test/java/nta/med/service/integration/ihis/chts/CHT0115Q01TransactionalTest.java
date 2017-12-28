package nta.med.service.integration.ihis.chts;

import java.util.concurrent.CountDownLatch;                                                                                
import java.util.concurrent.TimeUnit;                                                                                      

import nta.med.core.glossary.DataRowState;
import nta.med.common.remoting.rpc.protobuf.Rpc;
import nta.med.service.ihis.proto.ChtsModelProto;
import nta.med.service.ihis.proto.ChtsServiceProto;

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
public class CHT0115Q01TransactionalTest {                                                                                          
	@Autowired                                                                                                             
	protected Vertx vertx;                                                                                                 

	@Test                                                                                                                  
	public void Test() throws InterruptedException {     
		ChtsModelProto.CHT0115Q01grdCHT0115Info.Builder info = ChtsModelProto.CHT0115Q01grdCHT0115Info.newBuilder();
		info.setSusikCode("123");
		info.setSusikName("susik");
		info.setSusikNameGana("gana");
		info.setSusikCrDate("2012/12/31");
		info.setSusikGubun("234");
		info.setStartDate("2015/1/1");
		info.setEndDate("9998/12/31");
		info.setSort("123");
		info.setRowState(DataRowState.DELETED.getValue());

  		ChtsServiceProto.CHT0115Q01TransactionalRequest request =ChtsServiceProto.CHT0115Q01TransactionalRequest
					.newBuilder()           
					.addListInfo(info)
					.setUserId("TEST")
					.build();                                                                                                  

			Rpc.RpcMessage rpcMessage = Rpc.RpcMessage                                                                         
					.newBuilder()                                                                                              
					.setId(System.currentTimeMillis())                                                                         
					.setService("patientInsurance ")                                                               
					.setVersion("1.0.0")                                                                           
					.setPayloadClass(                                                                                          
							ChtsServiceProto.CHT0115Q01TransactionalRequest.class                                             
									.getSimpleName())                                                                          
					.setPayloadData(request.toByteString()).build();                                                           

			final CountDownLatch latch = new CountDownLatch(1);                                                                
			vertx.eventBus()                                                                                                   
					.send(ChtsServiceProto.CHT0115Q01TransactionalRequest.class                                               
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