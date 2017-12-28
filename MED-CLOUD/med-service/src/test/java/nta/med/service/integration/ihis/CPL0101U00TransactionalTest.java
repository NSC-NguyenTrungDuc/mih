package nta.med.service.integration.ihis;

import java.util.concurrent.CountDownLatch;
import java.util.concurrent.TimeUnit;

import nta.med.core.glossary.DataRowState;
import nta.med.common.remoting.rpc.protobuf.Rpc;
import nta.med.service.ihis.proto.CplsServiceProto;

import org.junit.Test;
import org.junit.runner.RunWith;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.test.context.ContextConfiguration;
import org.springframework.test.context.junit4.SpringJUnit4ClassRunner;
import org.vertx.java.core.Handler;
import org.vertx.java.core.Vertx;
import org.vertx.java.core.eventbus.Message;

@RunWith(SpringJUnit4ClassRunner.class)
@ContextConfiguration(locations = {"classpath:META-INF/spring/spring-master.xml"})
public class CPL0101U00TransactionalTest {
	@Autowired
    protected Vertx vertx;

    @Test
    public void testHandleMessage() throws Exception {
       
    	CplsServiceProto.CPL0101U00TransactionalRequest request = CplsServiceProto.CPL0101U00TransactionalRequest.newBuilder()                                                       
    			.setRowState(DataRowState.DELETED.getValue().toString())
    			.setUserId("")                                                        
    			.setJukyongDate("2001/06/02")                                                                
    			.setHangmogCode("008600")                                             
    			.setSpecimenCode("39")                                           
    			.setEmergency("N")                                                 
    			.setDefaultYn("")                                                 
    			.setJundalGubun("")                                             
    			.setDanui("")                                                         
    			.setTubeCode("")                                                   
    			.setUitakCode("DFEG")                                                 
    			.setSutakCode("")                                                 
    			.setSlipCode("")                                                   
    			.setJangbiCode("")                                               
    			.setJangbiOutCode("")                                         
    			.setJangbiCode2("")                                             
    			.setJangbiOutCode2("")                                       
    			.setJangbiCode3("")                                             
    			.setJangbiOutCode3("")                                       
    			.setGroupGubun("")                                               
    			.setGumsaNameRe("")                                               
    			.setBarcode("")                                                     
    			.setGumsaName("")                                                 
    			.setDefaultResult("")                                         
    			.setMedicalJundal("")                                         
    			.setCommentJuCode("")                                         
    			.setSerial("1")                                   
    			.setChubangYn("")                                                 
    			.setResultYn("")                                                 
    			.setResultForm("")                                               
    			.setTongGubun("")                                                 
    			.setSpecimenAmt("2")                         
    			.setOldSlipCode("")                                             
    			.setDetailInfo("")                                               
    			.setDisplayYn("")                                                 
    			.setJundalGubunName("")                                     
    			.setSpcialName("")                                               
    			.setSystemGubun("")                                             
    			.setTongSerial("3")                           
    			.setPoint("4")                                     
    			.setPoint2("5")                 
    			.setPoint3("6")                                   
    			.setOutTube("")                                                     
    			.setOutTube2("")                                                   
    			.setHangmogMarkName("")                                     
    			.setMiddleResult("")                                           
    			.setUserGubun("")
    			
        		.build();

        Rpc.RpcMessage rpcMessage = Rpc.RpcMessage.newBuilder()
                .setId(System.currentTimeMillis())
                .setService("DetailPaInfoFormGridInsure")
                .setVersion("1.0.0")
                .setPayloadClass(CplsServiceProto.CPL0101U00TransactionalRequest.class.getSimpleName())
                .setPayloadData(request.toByteString())
                .build();

        final CountDownLatch latch = new CountDownLatch(1);

        vertx.eventBus().send(CplsServiceProto.CPL0101U00TransactionalRequest.class.getSimpleName(), rpcMessage.toByteArray() ,new Handler<Message<byte[]>>() {
            @Override
            public void handle(Message<byte[]> event) {
                System.out.println("Success!");
                latch.countDown();
            }
        });
        latch.await(10, TimeUnit.SECONDS);
    }
}
