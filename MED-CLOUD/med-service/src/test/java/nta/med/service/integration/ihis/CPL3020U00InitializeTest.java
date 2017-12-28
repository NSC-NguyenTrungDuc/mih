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
public class CPL3020U00InitializeTest {
	@Autowired
    protected Vertx vertx;

    @Test
    public void testHandleMessage() throws Exception {
       
    	CplsServiceProto.CPL3020U00InitializeRequest request = CplsServiceProto.CPL3020U00InitializeRequest.newBuilder()
    			 .setSpecimenSerDsvNote("1012170009")
    			 .setJundalGubunDsvNote("04")
    			 .setCodeTypeFwkJundalGubun("01")
                 .setJundalGubunFwkNote("01")
     			 .setFind1FwkJundalGubun("0")
    			 .setJundalGubunDsvNote("01")
    			 .setFind1FwkNote("0")
    			 .setGubunGrdPa("Y")
    			 .setJundalGubunGrdPa("03")
    			 .setFromDateGrdPa("2013/1/1")
    			 .setToDateGrdPa("2013/2/1")
    			 .setLabNoGrdResult("0203230001")
    			 .setSpecimenSerGrdResult("13032300001")
    			 .setJundalGubunGrdResult("02")
    			 .setCodeTypeGrdResult("03")
    			 .setUserGroupFwkActor("CPL")
    			 .setCodeVsvJubsuja("10001")
    			 .setCodeTypeVsvJundalGubun("01")
    			 .setCodeVsvJundalGubun("01")
    			 .setJundalGubunVsvNote("01")
    			 .setCodeVsvNote("01")
        		.build();

        Rpc.RpcMessage rpcMessage = Rpc.RpcMessage.newBuilder()
                .setId(System.currentTimeMillis())
                .setService("DetailPaInfoFormGridInsure")
                .setVersion("1.0.0")
                .setPayloadClass(CplsServiceProto.CPL3020U00InitializeRequest.class.getSimpleName())
                .setPayloadData(request.toByteString())
                .build();

        final CountDownLatch latch = new CountDownLatch(1);

        vertx.eventBus().send(CplsServiceProto.CPL3020U00InitializeRequest.class.getSimpleName(), rpcMessage.toByteArray(), new Handler<Message<byte[]>>() {
            @Override
            public void handle(Message<byte[]> event) {
                System.out.println("Success!");
                latch.countDown();
            }
        });
        latch.await(10, TimeUnit.SECONDS);
    }
}
