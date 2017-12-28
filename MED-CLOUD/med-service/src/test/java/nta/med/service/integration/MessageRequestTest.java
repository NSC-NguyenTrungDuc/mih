package nta.med.service.integration;

import com.google.protobuf.Message;
import nta.med.common.remoting.rpc.protobuf.Rpc;
import org.junit.runner.RunWith;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.test.context.ContextConfiguration;
import org.springframework.test.context.junit4.SpringJUnit4ClassRunner;
import org.vertx.java.core.Handler;
import org.vertx.java.core.Vertx;
import org.vertx.java.core.buffer.Buffer;

import java.nio.charset.Charset;
import java.util.concurrent.CountDownLatch;
import java.util.concurrent.TimeUnit;

/**
 * @author Tiepnm
 */
@RunWith(SpringJUnit4ClassRunner.class)
@ContextConfiguration(locations = {"classpath:META-INF/spring/spring-master.xml"})
public class MessageRequestTest {

    @Autowired
    protected Vertx vertx;

    public void sentRequestToMedApp(Message message, String service) throws InterruptedException {
        Rpc.RpcMessage rpcMessage = Rpc.RpcMessage
                .newBuilder()
                .setId(System.currentTimeMillis())
                .setService(service)
                .setVersion("1.0.0")
                .setPayloadClass(
                        message.getClass().getSimpleName())
                .setPayloadData(message.toByteString()).build();

        final CountDownLatch latch = new CountDownLatch(1);
        Buffer buf = new Buffer(rpcMessage.toByteArray());
        final String id = "12345678";
        byte[] idByte = id.getBytes(Charset.forName("UTF-8"));

        buf.appendBytes(idByte).appendByte((byte) id.length());
        vertx.eventBus()
                .send(service,
                        buf,
                        new Handler<org.vertx.java.core.eventbus.Message<byte[]>>() {
                            @Override
                            public void handle(org.vertx.java.core.eventbus.Message<byte[]> event) {
                                System.out.println("Success!");
                                latch.countDown();
                            }
                        });
        latch.await(600, TimeUnit.SECONDS);
    }

}
