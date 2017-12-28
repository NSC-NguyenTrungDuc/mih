package nta.med.service.integration.bass;

import java.util.concurrent.CountDownLatch;
import java.util.concurrent.TimeUnit;

import nta.med.core.glossary.DataRowState;
import nta.med.common.remoting.rpc.protobuf.Rpc;
import nta.med.service.ihis.proto.BassModelProto;
import nta.med.service.ihis.proto.BassServiceProto;

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
public class BAS0110U00TransactionalTest {                                                                                          
	@Autowired                                                                                                             
	protected Vertx vertx;       

	

	@Test                                                                                                                  
	public void Test() throws InterruptedException {                               
		BassModelProto.BAS0110U00GrdJohapListItemInfo.Builder info = BassModelProto.BAS0110U00GrdJohapListItemInfo.newBuilder();
		info.setJohap("Johap");
		info.setJohapGubun("JB");
		info.setZipCode1("123");
		info.setZipCode2("456");
		info.setStartDate("2000/1/1");
		info.setTel("TEL");
		info.setRowState(DataRowState.DELETED.getValue());
  		BassServiceProto.BAS0110U00TransactionalRequest request =BassServiceProto.BAS0110U00TransactionalRequest
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
							BassServiceProto.BAS0110U00TransactionalRequest.class                                             
									.getSimpleName())                                                                          
					.setPayloadData(request.toByteString()).build();                                                           

			final CountDownLatch latch = new CountDownLatch(1);                                                                
			vertx.eventBus()                                                                                                   
					.send(BassServiceProto.BAS0110U00TransactionalRequest.class                                               
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