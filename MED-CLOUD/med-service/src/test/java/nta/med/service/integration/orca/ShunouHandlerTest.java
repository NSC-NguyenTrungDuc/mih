/*
package nta.med.service.integration.orca;

import nta.med.common.remoting.rpc.protobuf.Rpc;
import nta.med.service.orca.proto.ShunouServiceProto;
import org.junit.After;
import org.junit.Before;
import org.junit.Test;
import org.junit.runner.RunWith;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.test.context.ContextConfiguration;
import org.springframework.test.context.junit4.SpringJUnit4ClassRunner;
import org.vertx.java.core.Handler;
import org.vertx.java.core.Vertx;
import org.vertx.java.core.eventbus.Message;

import java.util.concurrent.CountDownLatch;
import java.util.concurrent.TimeUnit;

*/
/**
 * @author dainguyen.
 *//*

@RunWith(SpringJUnit4ClassRunner.class)
@ContextConfiguration(locations={"classpath:META-INF/spring/spring-master.xml"})
public class ShunouHandlerTest {

    @Autowired
    protected Vertx vertx;

    @Autowired
    private ShunouCommand shunouCommand;

    @Before
    public void setUp() throws Exception {
        shunouCommand.start();
    }

    @Test
    public void testHandleMessage() throws Exception {

        ShunouServiceProto.ShunouRequest request = ShunouServiceProto.ShunouRequest.newBuilder()
                .setPatientId("2")
                .setPerformMonth("2014-12").build();

        Rpc.RpcMessage rpcMessage = Rpc.RpcMessage.newBuilder()
                .setId(System.currentTimeMillis())
                .setService("shunou")
                .setVersion("1.0.0")
                .setPayloadClass(ShunouServiceProto.ShunouRequest.class.getSimpleName())
                .setPayloadData(request.toByteString()).build();
        final CountDownLatch latch = new CountDownLatch(1);

        vertx.eventBus().send(ShunouServiceProto.ShunouRequest.class.getSimpleName(), rpcMessage.toByteArray(), new Handler<Message<byte[]>>() {
            @Override
            public void handle(Message<byte[]> event) {
                System.out.println("Success!");
                latch.countDown();
            }
        });
        latch.await(10, TimeUnit.SECONDS);
    }

    @After
    public void tearDown() throws Exception {
        shunouCommand.stop();
    }
}
*/
