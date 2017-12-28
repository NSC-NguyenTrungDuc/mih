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
public class CPL3020U02RESULTMAPPrCplResultMatchProcTest {
	@Autowired
    protected Vertx vertx;

    @Test
    public void testHandleMessage() throws Exception {
       
    	CplsServiceProto.CPL3020U02RESULTMAPPrCplResultMatchProcRequest request = CplsServiceProto.CPL3020U02RESULTMAPPrCplResultMatchProcRequest.newBuilder()
        		.setProcGubun("Y")
        		.setSpecimenSer("14082200051")
        		.setHangmogCode("00082")
        		.setResultVal("5555")
        		.setJangbiCode("S1")
        		.setResultDate("2014/11/4")
        		.setSampleId("14102800043")
        		.setResultCode("2253071")
        		.build();

        Rpc.RpcMessage rpcMessage = Rpc.RpcMessage.newBuilder()
                .setId(System.currentTimeMillis())
                .setService("DetailPaInfoFormGridInsure")
                .setVersion("1.0.0")
                .setPayloadClass(CplsServiceProto.CPL3020U02RESULTMAPPrCplResultMatchProcRequest.class.getSimpleName())
                .setPayloadData(request.toByteString())
                .build();

        final CountDownLatch latch = new CountDownLatch(1);

        vertx.eventBus().send(CplsServiceProto.CPL3020U02RESULTMAPPrCplResultMatchProcRequest.class.getSimpleName(), rpcMessage.toByteArray(), new Handler<Message<byte[]>>() {
            @Override
            public void handle(Message<byte[]> event) {
                System.out.println("Success!");
                latch.countDown();
            }
        });
        latch.await(10, TimeUnit.SECONDS);
    }
}
