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

public class NuroOUT0101U02GetBirthDayTest {
    @Autowired
    protected Vertx vertx;

    @Test
    public void testHandleMessage() throws Exception {
        NuroServiceProto.NuroOUT0101U02GetBirthDayRequest request = NuroServiceProto.NuroOUT0101U02GetBirthDayRequest.newBuilder()
        		.setSysDate("1/1/2014")
        		.setBirth("3/20/2015")
        		.build();
        
       

        Rpc.RpcMessage rpcMessage = Rpc.RpcMessage.newBuilder()
                .setId(System.currentTimeMillis())
                .setService("NuroOUT0101U02GetInsurance")
                .setVersion("1.0.0")
                .setPayloadClass(NuroServiceProto.NuroOUT0101U02GetBirthDayRequest.class.getSimpleName())
                .setPayloadData(request.toByteString())
                .build();

        final CountDownLatch latch = new CountDownLatch(1);

        vertx.eventBus().send(NuroServiceProto.NuroOUT0101U02GetBirthDayRequest.class.getSimpleName(), rpcMessage.toByteArray(), new Handler<Message<byte[]>>() {
            @Override
            public void handle(Message<byte[]> event) {
                System.out.println("Send _Success!");
                latch.countDown();
            }
        });
        latch.await(10, TimeUnit.SECONDS);
    }




}