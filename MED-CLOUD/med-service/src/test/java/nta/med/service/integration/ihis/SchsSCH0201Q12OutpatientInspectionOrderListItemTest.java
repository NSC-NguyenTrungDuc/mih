package nta.med.service.integration.ihis;

import java.util.concurrent.CountDownLatch;
import java.util.concurrent.TimeUnit;

import nta.med.common.remoting.rpc.protobuf.Rpc;
import nta.med.service.ihis.proto.SchsServiceProto;

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
public class SchsSCH0201Q12OutpatientInspectionOrderListItemTest {

	@Autowired
    protected Vertx vertx;

    @Test
    public void testHandleMessage() throws Exception {
       
    	SchsServiceProto.SCH0201Q12GrdListRequest request = SchsServiceProto.SCH0201Q12GrdListRequest.newBuilder()
    			.setBunho("000018812")
    			.setStatFlg("F")
    			.setNaewonDate("2012/12/20")
    			.setGwa("11")
    			.setDoctor("1110004")
    			.setReserGubun("XRT")
        		.build();

        Rpc.RpcMessage rpcMessage = Rpc.RpcMessage.newBuilder()
                .setId(System.currentTimeMillis())
                .setService("NuroOUT1001U01GetDepartmentRequest")
                .setVersion("1.0.0")
                .setPayloadClass(SchsServiceProto.SCH0201Q12GrdListRequest.class.getSimpleName())
                .setPayloadData(request.toByteString())
                .build();

        final CountDownLatch latch = new CountDownLatch(1);

        vertx.eventBus().send(SchsServiceProto.SCH0201Q12GrdListRequest.class.getSimpleName(), rpcMessage.toByteArray(), new Handler<Message<byte[]>>() {
            @Override
            public void handle(Message<byte[]> event) {
                System.out.println("Success!");
                latch.countDown();
            }
        });
        latch.await(10, TimeUnit.SECONDS);
    }


}