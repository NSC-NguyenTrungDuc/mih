package nta.med.service.integration.ihis;

import java.util.concurrent.CountDownLatch;
import java.util.concurrent.TimeUnit;

import nta.med.common.remoting.rpc.protobuf.Rpc;
import nta.med.service.ihis.proto.NuriServiceProto;

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
public class NuriNUR7001U00GetMaxSeqInNUR7001HandlerTest {

	@Autowired
	protected Vertx vertx;
    
    @Test
    public void testNuriNUR7001U00GetMaxSeqInNUR7001Request() throws Exception {
        NuriServiceProto.NuriNUR7001U00GetMaxSeqInNUR7001Request request = NuriServiceProto.NuriNUR7001U00GetMaxSeqInNUR7001Request.newBuilder()
                .setBunho("000000010")
                .setMeasureDate("2010/12/21")
                .build();
        
        // 000002327 ; 2013/08/15

        Rpc.RpcMessage rpcMessage = Rpc.RpcMessage.newBuilder()
                .setId(System.currentTimeMillis())
                .setService("PatientInsurance")
                .setVersion("1.0.0")
                .setPayloadClass(NuriServiceProto.NuriNUR7001U00GetMaxSeqInNUR7001Request.class.getSimpleName())
                .setPayloadData(request.toByteString())
                .build();

        final CountDownLatch latch = new CountDownLatch(1);

        vertx.eventBus().send(NuriServiceProto.NuriNUR7001U00GetMaxSeqInNUR7001Request.class.getSimpleName(), rpcMessage.toByteArray(), new Handler<Message<byte[]>>() {
            @Override
            public void handle(Message<byte[]> event) {
                System.out.println("Success!");
                latch.countDown();
            }
        });
        latch.await(100, TimeUnit.SECONDS);
    }
}