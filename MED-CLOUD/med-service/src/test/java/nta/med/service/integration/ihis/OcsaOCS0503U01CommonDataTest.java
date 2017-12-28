package nta.med.service.integration.ihis;

import java.util.concurrent.CountDownLatch;
import java.util.concurrent.TimeUnit;

import nta.med.common.remoting.rpc.protobuf.Rpc;
import nta.med.service.ihis.proto.OcsaServiceProto;

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
public class OcsaOCS0503U01CommonDataTest {


    @Autowired
    protected Vertx vertx;

    @Test
    public void testHandleMessage() throws Exception {
       
        OcsaServiceProto.OcsaOCS0503U01CommonDataRequest request = OcsaServiceProto.OcsaOCS0503U01CommonDataRequest.newBuilder()
        		.setFCode("0010001")
        		.build();
        
        // RESULT : 真性コレラ - 0 - 医師 10001

        Rpc.RpcMessage rpcMessage = Rpc.RpcMessage.newBuilder()
                .setId(System.currentTimeMillis())
                .setService("PatientComment")
                .setVersion("1.0.0")
                .setPayloadClass(OcsaServiceProto.OcsaOCS0503U01CommonDataRequest.class.getSimpleName())
                .setPayloadData(request.toByteString())
                .build();

        final CountDownLatch latch = new CountDownLatch(1);

        vertx.eventBus().send(OcsaServiceProto.OcsaOCS0503U01CommonDataRequest.class.getSimpleName(), rpcMessage.toByteArray(), new Handler<Message<byte[]>>() {
            @Override
            public void handle(Message<byte[]> event) {
                System.out.println("Success!");
                latch.countDown();
            }
        });
        latch.await(10, TimeUnit.SECONDS);
    }

}
