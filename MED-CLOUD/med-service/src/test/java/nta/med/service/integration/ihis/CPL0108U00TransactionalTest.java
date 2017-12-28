package nta.med.service.integration.ihis;

import org.junit.Test;
import org.junit.runner.RunWith;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.test.context.ContextConfiguration;
import org.springframework.test.context.junit4.SpringJUnit4ClassRunner;
import org.vertx.java.core.Vertx;

@RunWith(SpringJUnit4ClassRunner.class)
@ContextConfiguration(locations = {"classpath:META-INF/spring/spring-master.xml"})
public class CPL0108U00TransactionalTest {
	@Autowired
    protected Vertx vertx;

    @Test
    public void testHandleMessage() throws Exception {
       
//    	CplsServiceProto.CPL0108U00TransactionalRequest request = CplsServiceProto.CPL0108U00TransactionalRequest.newBuilder()
//        		.setCallerId("2")
//        		.setDataRowState(DataRowState.DELETED.getValue().toString())
//        		.setUserId("ROOT")
//        		.setCodeType("CODETYPE1")
//        		.setCodeTypeName("CODETYPENAME1")
//        		.setCode("CODE")
//        		.setCodeName("CODENAME1")
//        		.setCodeNameRe("CODENAMERE")
//        		.setSystemGubun("CPL")
//        		.setCodeValue("")
//        		.build();
//
//        Rpc.RpcMessage rpcMessage = Rpc.RpcMessage.newBuilder()
//                .setId(System.currentTimeMillis())
//                .setService("DetailPaInfoFormGridInsure")
//                .setVersion("1.0.0")
//                .setPayloadClass(CplsServiceProto.CPL0108U00TransactionalRequest.class.getSimpleName())
//                .setPayloadData(request.toByteString())
//                .build();
//
//        final CountDownLatch latch = new CountDownLatch(1);
//
//        vertx.eventBus().send(CplsServiceProto.CPL0108U00TransactionalRequest.class.getSimpleName(), rpcMessage.toByteArray(), new Handler<Message<byte[]>>() {
//            @Override
//            public void handle(Message<byte[]> event) {
//                System.out.println("Success!");
//                latch.countDown();
//            }
//        });
//        latch.await(10, TimeUnit.SECONDS);
    }
}
