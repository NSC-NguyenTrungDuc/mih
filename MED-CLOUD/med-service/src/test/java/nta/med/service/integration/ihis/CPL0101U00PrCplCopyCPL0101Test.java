package nta.med.service.integration.ihis;

import java.util.concurrent.CountDownLatch;
import java.util.concurrent.TimeUnit;

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
public class CPL0101U00PrCplCopyCPL0101Test {
	@Autowired
    protected Vertx vertx;

    @Test
    public void testHandleMessage() throws Exception {
       
    	CplsServiceProto.CPL0101U00PrCplCopyCPL0101Request request = CplsServiceProto.CPL0101U00PrCplCopyCPL0101Request.newBuilder()
        		.setHangmogCode("000100")
        		.setSpecimenCode("03")
        		.setEmergency("N")
        		.setNewSpecimenCode("24")
        		.setNewEmergency("Y")
        		.build();

        Rpc.RpcMessage rpcMessage = Rpc.RpcMessage.newBuilder()
                .setId(System.currentTimeMillis())
                .setService("DetailPaInfoFormGridInsure")
                .setVersion("1.0.0")
                .setPayloadClass(CplsServiceProto.CPL0101U00PrCplCopyCPL0101Request.class.getSimpleName())
                .setPayloadData(request.toByteString())
                .build();

        final CountDownLatch latch = new CountDownLatch(1);

        vertx.eventBus().send(CplsServiceProto.CPL0101U00PrCplCopyCPL0101Request.class.getSimpleName(), rpcMessage.toByteArray(), new Handler<Message<byte[]>>() {
            @Override
            public void handle(Message<byte[]> event) {
                System.out.println("Success!");
                latch.countDown();
            }
        });
        latch.await(10, TimeUnit.SECONDS);
    }
}
