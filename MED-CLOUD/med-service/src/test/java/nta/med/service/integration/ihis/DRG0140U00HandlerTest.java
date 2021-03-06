package nta.med.service.integration.ihis;

import java.util.concurrent.CountDownLatch;
import java.util.concurrent.TimeUnit;

import nta.med.core.glossary.DataRowState;
import nta.med.common.remoting.rpc.protobuf.Rpc;
import nta.med.service.ihis.proto.DrgsServiceProto;

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
public class DRG0140U00HandlerTest {

	@Autowired
	protected Vertx vertx;
    
	@Ignore
    @Test
    public void testDRG0140U00ChangeRequest() throws Exception {
        DrgsServiceProto.DRG0140U00ChangeRequest request = DrgsServiceProto.DRG0140U00ChangeRequest.newBuilder()
              .setCallerId("2")
              .setRowState(DataRowState.MODIFIED.getValue())
              .setUserId("test123")
              .setCode("90")
              .setCodeName("test system")
              .setCode1("90")
              .setCodeName1("test system")
              .build();
        
        // 000002327 ; 2013/08/15

        Rpc.RpcMessage rpcMessage = Rpc.RpcMessage.newBuilder()
                .setId(System.currentTimeMillis())
                .setService("PatientInsurance")
                .setVersion("1.0.0")
                .setPayloadClass(DrgsServiceProto.DRG0140U00ChangeRequest.class.getSimpleName())
                .setPayloadData(request.toByteString())
                .build();

        final CountDownLatch latch = new CountDownLatch(1);

        vertx.eventBus().send(DrgsServiceProto.DRG0140U00ChangeRequest.class.getSimpleName(), rpcMessage.toByteArray(), new Handler<Message<byte[]>>() {
            @Override
            public void handle(Message<byte[]> event) {
                System.out.println("Success!");
                latch.countDown();
            }
        });
        latch.await(100, TimeUnit.SECONDS);
    }
    
    @Test
    public void testDRG0140U00MasterDetailGridRequest() throws Exception {
        DrgsServiceProto.DRG0140U00MasterDetailGridRequest request = DrgsServiceProto.DRG0140U00MasterDetailGridRequest.newBuilder()
              .setCode("90")
              .build();
        
        // 000002327 ; 2013/08/15

        Rpc.RpcMessage rpcMessage = Rpc.RpcMessage.newBuilder()
                .setId(System.currentTimeMillis())
                .setService("PatientInsurance")
                .setVersion("1.0.0")
                .setPayloadClass(DrgsServiceProto.DRG0140U00MasterDetailGridRequest.class.getSimpleName())
                .setPayloadData(request.toByteString())
                .build();

        final CountDownLatch latch = new CountDownLatch(1);

        vertx.eventBus().send(DrgsServiceProto.DRG0140U00MasterDetailGridRequest.class.getSimpleName(), rpcMessage.toByteArray(), new Handler<Message<byte[]>>() {
            @Override
            public void handle(Message<byte[]> event) {
                System.out.println("Success!");
                latch.countDown();
            }
        });
        latch.await(100, TimeUnit.SECONDS);
    }
}
