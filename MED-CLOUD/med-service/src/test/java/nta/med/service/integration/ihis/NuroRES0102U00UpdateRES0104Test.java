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
public class NuroRES0102U00UpdateRES0104Test {
	@Autowired
    protected Vertx vertx;

    @Test
    public void testHandleMessage() throws Exception {
        NuroServiceProto.NuroRES0102U00UpdateRES0104Request request = NuroServiceProto.NuroRES0102U00UpdateRES0104Request.newBuilder()
        		.setUserId("M2H_3")
        		.setDoctor("01234567")
        		.setStartDate("2011/12/01")
        		.setEndDate("2015/12/01")
        		.setSayu("987")
        		.build();
        
        Rpc.RpcMessage rpcMessage = Rpc.RpcMessage.newBuilder()
                .setId(System.currentTimeMillis())
                .setService("NuroRES0102U00UpdateRES0104Request")
                .setVersion("1.0.0")
                .setPayloadClass(NuroServiceProto.NuroRES0102U00UpdateRES0104Request.class.getSimpleName())
                .setPayloadData(request.toByteString())
                .build();

        final CountDownLatch latch = new CountDownLatch(1);

        vertx.eventBus().send(NuroServiceProto.NuroRES0102U00UpdateRES0104Request.class.getSimpleName(), rpcMessage.toByteArray(), new Handler<Message<byte[]>>() {
            @Override
            public void handle(Message<byte[]> event) {
                System.out.println("Send _Success!");
                latch.countDown();
            }
        });
        latch.await(10, TimeUnit.SECONDS);
    }
}
