package nta.med.service.integration.ihis;

import java.util.concurrent.CountDownLatch;
import java.util.concurrent.TimeUnit;

import nta.med.common.remoting.rpc.protobuf.Rpc;
import nta.med.service.ihis.proto.XrtsServiceProto;

import org.junit.Ignore;
import org.junit.Test;
import org.junit.runner.RunWith;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.test.context.ContextConfiguration;
import org.springframework.test.context.junit4.SpringJUnit4ClassRunner;
import org.vertx.java.core.Handler;
import org.vertx.java.core.Vertx;
import org.vertx.java.core.eventbus.Message;

@RunWith(SpringJUnit4ClassRunner.class)
@ContextConfiguration(locations={"classpath:META-INF/spring/spring-master.xml"})
public class XRT0123U00HandlerTest {

	@Autowired
	protected Vertx vertx;
    
	@Ignore
    @Test
    public void testXRT0123U00InitializeHandler() throws Exception {
//        XrtsServiceProto.XRT0123U00InitializeRequest request = XrtsServiceProto.XRT0123U00InitializeRequest.newBuilder()
//        		.setCodeType("X1")
//        		.build();
//        
//        // 000002327 ; 2013/08/15
//
//        Rpc.RpcMessage rpcMessage = Rpc.RpcMessage.newBuilder()
//                .setId(System.currentTimeMillis())
//                .setService("PatientInsurance")
//                .setVersion("1.0.0")
//                .setPayloadClass(XrtsServiceProto.XRT0123U00InitializeRequest.class.getSimpleName())
//                .setPayloadData(request.toByteString())
//                .build();
//
//        final CountDownLatch latch = new CountDownLatch(1);
//
//        vertx.eventBus().send(XrtsServiceProto.XRT0123U00InitializeRequest.class.getSimpleName(), rpcMessage.toByteArray(), new Handler<Message<byte[]>>() {
//            @Override
//            public void handle(Message<byte[]> event) {
//                System.out.println("Success!");
//                latch.countDown();
//            }
//        });
//        latch.await(100, TimeUnit.SECONDS);
    }
    
    @Test
    public void testCPL0106U00ExecuteRequest() throws Exception {
        XrtsServiceProto.XRT0123U00GrdDCodeRequest request = XrtsServiceProto.XRT0123U00GrdDCodeRequest.newBuilder()
        		.setXrayGubun("T")
        		.setBuwiCode("T")
              .build();
        
        // 000002327 ; 2013/08/15

        Rpc.RpcMessage rpcMessage = Rpc.RpcMessage.newBuilder()
                .setId(System.currentTimeMillis())
                .setService("PatientInsurance")
                .setVersion("1.0.0")
                .setPayloadClass(XrtsServiceProto.XRT0123U00GrdDCodeRequest.class.getSimpleName())
                .setPayloadData(request.toByteString())
                .build();

        final CountDownLatch latch = new CountDownLatch(1);

        vertx.eventBus().send(XrtsServiceProto.XRT0123U00GrdDCodeRequest.class.getSimpleName(), rpcMessage.toByteArray(), new Handler<Message<byte[]>>() {
            @Override
            public void handle(Message<byte[]> event) {
                System.out.println("Success!");
                latch.countDown();
            }
        });
        latch.await(100, TimeUnit.SECONDS);
    }
    
    /*@Ignore
    @Test
    public void testCPL0106U00GridColumnChangeRequest() throws Exception {
        XrtsServiceProto.CPL0106U00GridColumnChangeRequest request = XrtsServiceProto.CPL0106U00GridColumnChangeRequest.newBuilder()
              .build();
        
        // 000002327 ; 2013/08/15

        Rpc.RpcMessage rpcMessage = Rpc.RpcMessage.newBuilder()
                .setId(System.currentTimeMillis())
                .setService("PatientInsurance")
                .setVersion("1.0.0")
                .setPayloadClass(XrtsServiceProto.CPL0106U00GridColumnChangeRequest.class.getSimpleName())
                .setPayloadData(request.toByteString())
                .build();

        final CountDownLatch latch = new CountDownLatch(1);

        vertx.eventBus().send(XrtsServiceProto.CPL0106U00GridColumnChangeRequest.class.getSimpleName(), rpcMessage.toByteArray(), new Handler<Message<byte[]>>() {
            @Override
            public void handle(Message<byte[]> event) {
                System.out.println("Success!");
                latch.countDown();
            }
        });
        latch.await(100, TimeUnit.SECONDS);
    }*/
}
