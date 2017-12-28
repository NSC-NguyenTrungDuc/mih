package nta.med.service.integration.ihis;

import java.util.concurrent.CountDownLatch;
import java.util.concurrent.TimeUnit;

import nta.med.core.glossary.DataRowState;
import nta.med.common.remoting.rpc.protobuf.Rpc;
import nta.med.service.ihis.proto.OcsoServiceProto;

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
public class OUTSANGU00TransactionTest {


    @Autowired
    protected Vertx vertx;

    @Test
    public void testHandleMessage() throws Exception {
       
        OcsoServiceProto.OUTSANGU00TransactionRequest request = OcsoServiceProto.OUTSANGU00TransactionRequest.newBuilder()
        		.setDataRowState(DataRowState.DELETED.getValue().toString())
        		.setBunho("000042109")
        		.setGwa("01")
        		.setIoGubun("I")
        		.setFkinp1001("123456")
        		.setSangCode("654321")
        		.setSangName("hehe1")
        		.setPostModifierName("123")
        		.setPreModifierName("321")
        		.setSangStartDate ("2000/1/1")
        		.setSangEndDate("2005/1/1")
        		.setSangJindanDate("2015/1/1")
        		.setDataGubun("I")
        		.setUserId("5556555")
        		.setPkSeq("3")
        		.setNaewonDate("2012/3/9")
        		.setDoctor("12")
        		.setNaewonType("N")
        		.setJubsuNo ("12")
        		.setSer ("9")
        		.setSangEndSayu("")
        		.setPreModifier1("1")
        		.setPreModifier2("2")
        		.setPreModifier3("3")
        		.setPreModifier4("4")
        		.setPreModifier5("5")
        		.setPreModifier6("6")
        		.setPreModifier7("7")
        		.setPreModifier8("8")
        		.setPreModifier9("9")
        		.setPreModifier10("10")
        		.setPostModifier1("1")
        		.setPostModifier2("2")
        		.setPostModifier3("3")
        		.setPostModifier4("4")
        		.setPostModifier5("5")
        		.setPostModifier6("6")
        		.setPostModifier7("6")
        		.setPostModifier8("7")
        		.setPostModifier9("9")
        		.setPostModifier10("1")
        		.setJuSangYn("N") 
        		.build();
        

        Rpc.RpcMessage rpcMessage = Rpc.RpcMessage.newBuilder()
                .setId(System.currentTimeMillis())
                .setService("PatientComment")
                .setVersion("1.0.0")
                .setPayloadClass(OcsoServiceProto.OUTSANGU00TransactionRequest.class.getSimpleName())
                .setPayloadData(request.toByteString())
                .build();

        final CountDownLatch latch = new CountDownLatch(1);

        vertx.eventBus().send(OcsoServiceProto.OUTSANGU00TransactionRequest.class.getSimpleName(), rpcMessage.toByteArray(), new Handler<Message<byte[]>>() {
            @Override
            public void handle(Message<byte[]> event) {
                System.out.println("Success!");
                latch.countDown();
            }
        });
        latch.await(10, TimeUnit.SECONDS);
    }

}
