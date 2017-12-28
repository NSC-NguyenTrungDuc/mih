//package nta.med.service.integration.ihis;
//
//import java.util.concurrent.CountDownLatch;
//import java.util.concurrent.TimeUnit;
//
//import nta.med.common.remoting.rpc.protobuf.Rpc;
//import nta.med.service.ihis.proto.NuroServiceProto;
//
//import org.junit.Ignore;
//import org.junit.Test;
//import org.junit.runner.RunWith;
//import org.springframework.beans.factory.annotation.Autowired;
//import org.springframework.test.context.ContextConfiguration;
//import org.springframework.test.context.junit4.SpringJUnit4ClassRunner;
//import org.vertx.java.core.Handler;
//import org.vertx.java.core.Vertx;
//import org.vertx.java.core.eventbus.Message;
//
//@RunWith(SpringJUnit4ClassRunner.class)
//@ContextConfiguration(locations={"classpath:META-INF/spring/spring-master.xml"})
//public class NuroRES1001U00UserNameHandlerTest {
//
//	@Autowired
//	protected Vertx vertx;
//    
//    @Test
//    public void testNuroRES1001U00UserNameHandler() throws Exception {
//        NuroServiceProto.NuroRES1001U00UserNameRequest request = NuroServiceProto.NuroRES1001U00UserNameRequest.newBuilder()
//                .setUserId("20113").build();
//        
//        // 000002327 ; 2013/08/15
//
//        Rpc.RpcMessage rpcMessage = Rpc.RpcMessage.newBuilder()
//                .setId(System.currentTimeMillis())
//                .setService("PatientInsurance")
//                .setVersion("1.0.0")
//                .setPayloadClass(NuroServiceProto.NuroRES1001U00UserNameRequest.class.getSimpleName())
//                .setPayloadData(request.toByteString())
//                .build();
//
//        final CountDownLatch latch = new CountDownLatch(1);
//
//        vertx.eventBus().send(NuroServiceProto.NuroRES1001U00UserNameRequest.class.getSimpleName(), rpcMessage.toByteArray(), new Handler<Message<byte[]>>() {
//            @Override
//            public void handle(Message<byte[]> event) {
//                System.out.println("Success!");
//                latch.countDown();
//            }
//        });
//        latch.await(100, TimeUnit.SECONDS);
//    }
//}
