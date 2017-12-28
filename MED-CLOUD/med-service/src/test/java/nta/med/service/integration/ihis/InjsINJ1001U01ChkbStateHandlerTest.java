/*package nta.med.service.integration.ihis;

import java.util.concurrent.CountDownLatch;
import java.util.concurrent.TimeUnit;

import nta.med.common.remoting.rpc.protobuf.Rpc;
import nta.med.service.ihis.proto.InjsServiceProto;

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
public class InjsINJ1001U01ChkbStateHandlerTest {

	@Autowired
	protected Vertx vertx;
    
    @Test
    public void testInjsINJ1001U01ChkbStateRequest() throws Exception {
        InjsServiceProto.InjsINJ1001U01ChkbStateRequest request = InjsServiceProto.InjsINJ1001U01ChkbStateRequest.newBuilder()
                .build();
        
        // 000002327 ; 2013/08/15

        Rpc.RpcMessage rpcMessage = Rpc.RpcMessage.newBuilder()
                .setId(System.currentTimeMillis())
                .setService("PatientInsurance")
                .setVersion("1.0.0")
                .setPayloadClass(InjsServiceProto.InjsINJ1001U01ChkbStateRequest.class.getSimpleName())
                .setPayloadData(request.toByteString())
                .build();

        final CountDownLatch latch = new CountDownLatch(1);

        vertx.eventBus().send(InjsServiceProto.InjsINJ1001U01ChkbStateRequest.class.getSimpleName(), rpcMessage.toByteArray(), new Handler<Message<byte[]>>() {
            @Override
            public void handle(Message<byte[]> event) {
                System.out.println("Success!");
                latch.countDown();
            }
        });
        latch.await(100, TimeUnit.SECONDS);
    }
}
*/

package nta.med.service.integration.ihis;

import org.junit.Test;

import nta.med.common.remoting.rpc.protobuf.Rpc;
import nta.med.service.ihis.proto.InjsServiceProto;
import nta.med.service.integration.MessageRequestTest;

public class InjsINJ1001U01ChkbStateHandlerTest extends MessageRequestTest {
    @Test
    public void testInjsINJ1001U01ChkbStateRequest() throws InterruptedException {

    	InjsServiceProto.InjsINJ1001U01ChkbStateRequest request = InjsServiceProto.
        		InjsINJ1001U01ChkbStateRequest.newBuilder()
               .setBunho("000001703")
               .setActingFlag("N")
               .setDoctor("0110316")
               //.setDoctor("K01OCS")
               .setReserDate("2016/05/05")
                .build();

        sentRequestToMedApp(request, InjsServiceProto.getDescriptor().
                getOptions().getExtension(Rpc.service));
    }
}
