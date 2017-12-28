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
@ContextConfiguration(locations = {"classpath:META-INF/spring/spring-master.xml"})
public class NuriNUR1017U00InsertManageInfectionTest {

	@Autowired
    protected Vertx vertx;

    @Test
    public void testHandleMessage() throws Exception {
       
        NuriServiceProto.NuriNUR1017U00InsertManageInfectionRequest request = NuriServiceProto.NuriNUR1017U00InsertManageInfectionRequest.newBuilder()
        		.setSysId("42")
        		.setInfeCode("1")
        		.setBunho("1")
        		.setStartDate("2015/1/14")
        		.setEndDate("2015/1/15")
        		.setEndSayu("03")
        		.setInputText("AAA")
        		.setInfeJaeryo("1")
        		.setPknur1017("1")
        		.build();

        Rpc.RpcMessage rpcMessage = Rpc.RpcMessage.newBuilder()
                .setId(System.currentTimeMillis())
                .setService("NuroOUT1001U01GetDepartmentRequest")
                .setVersion("1.0.0")
                .setPayloadClass(NuriServiceProto.NuriNUR1017U00InsertManageInfectionRequest.class.getSimpleName())
                .setPayloadData(request.toByteString())
                .build();

        final CountDownLatch latch = new CountDownLatch(1);

        vertx.eventBus().send(NuriServiceProto.NuriNUR1017U00InsertManageInfectionRequest.class.getSimpleName(), rpcMessage.toByteArray(), new Handler<Message<byte[]>>() {
            @Override
            public void handle(Message<byte[]> event) {
                System.out.println("Success!");
                latch.countDown();
            }
        });
        latch.await(10, TimeUnit.SECONDS);
    }



}
