package nta.med.service.integration.ihis;

import java.util.concurrent.CountDownLatch;
import java.util.concurrent.TimeUnit;

import nta.med.common.remoting.rpc.protobuf.Rpc;
import nta.med.service.ihis.proto.NuroServiceProto;

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
public class NuroOUT0101U02GridBoheomTest {


    @Autowired
    protected Vertx vertx;

    @Test
    public void testHandleMessage() throws Exception {
        NuroServiceProto.NuroOUT0101U02GridBoheomRequest request = NuroServiceProto.NuroOUT0101U02GridBoheomRequest.newBuilder()
        		.setPatientCode("000042676").build();
        
       

        Rpc.RpcMessage rpcMessage = Rpc.RpcMessage.newBuilder()
                .setId(System.currentTimeMillis())
                .setService("NuroOUT0101U02GridBoheom")
                .setVersion("1.0.0")
                .setPayloadClass(NuroServiceProto.NuroOUT0101U02GridBoheomRequest.class.getSimpleName())
                .setPayloadData(request.toByteString())
                .build();

        final CountDownLatch latch = new CountDownLatch(1);

        vertx.eventBus().send(NuroServiceProto.NuroOUT0101U02GridBoheomRequest.class.getSimpleName(), rpcMessage.toByteArray(), new Handler<Message<byte[]>>() {
            @Override
            public void handle(Message<byte[]> event) {
                System.out.println("Send _Success!");
                latch.countDown();
            }
        });
        latch.await(10, TimeUnit.SECONDS);
    }



}
