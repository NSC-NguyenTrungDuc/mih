package nta.med.service.integration.ihis;

import java.util.concurrent.CountDownLatch;
import java.util.concurrent.TimeUnit;

import nta.med.common.remoting.rpc.protobuf.Rpc;
import nta.med.service.ihis.proto.NuroServiceProto;

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
public class NuroOUT0101U02InsertPatientTest {


    @Autowired
    protected Vertx vertx;

    @Test
    public void testHandleMessage() throws Exception {
       
        NuroServiceProto.NuroOUT0101U02InsertPatientRequest request = NuroServiceProto.NuroOUT0101U02InsertPatientRequest.newBuilder()
        		.setSysId("40886")
        		.setPatientCode("1")
        		.setPatientName("a")
        		.setSex("M")
        		.setBirth("23/7/1992")
        		.setZipCode1("1")
        		.setZipCode2("2")
        		.setAddress1("A")
        		.setAddress2("B")
        		.setTel("1")
        		.setTel1("1")
        		.setType("1")
        		.setTelHp("1")
        		.setEmail("ricardo")
        		.setPatientName2("h")
        		.setTelType("1")
        		.setTelType2("2")
        		.setTelType3("3")
        		.setDeleteYn("Y")
        		.setPaceMakerYn("Y")
        		.setSelfPaceMaker("N")
        		.setPatientType("1")
        		.build();

        Rpc.RpcMessage rpcMessage = Rpc.RpcMessage.newBuilder()
                .setId(System.currentTimeMillis())
                .setService("PatientComment")
                .setVersion("1.0.0")
                .setPayloadClass(NuroServiceProto.NuroOUT0101U02InsertPatientRequest.class.getSimpleName())
                .setPayloadData(request.toByteString())
                .build();

        final CountDownLatch latch = new CountDownLatch(1);

        vertx.eventBus().send(NuroServiceProto.NuroOUT0101U02InsertPatientRequest.class.getSimpleName(), rpcMessage.toByteArray(), new Handler<Message<byte[]>>() {
            @Override
            public void handle(Message<byte[]> event) {
                System.out.println("Success!");
                latch.countDown();
            }
        });
        latch.await(10, TimeUnit.SECONDS);
    }

}
