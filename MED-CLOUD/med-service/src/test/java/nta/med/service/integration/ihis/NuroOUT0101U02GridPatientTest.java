package nta.med.service.integration.ihis;

import java.util.concurrent.CountDownLatch;
import java.util.concurrent.TimeUnit;

import nta.med.common.remoting.rpc.protobuf.Rpc;
import nta.med.service.ihis.proto.NuroServiceProto;

import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.integration.MessageRequestTest;
import org.junit.Test;
import org.junit.runner.RunWith;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.test.context.ContextConfiguration;
import org.springframework.test.context.junit4.SpringJUnit4ClassRunner;
import org.vertx.java.core.Handler;
import org.vertx.java.core.Vertx;
import org.vertx.java.core.eventbus.Message;


public class NuroOUT0101U02GridPatientTest extends MessageRequestTest {

    @Autowired
    protected Vertx vertx;

    @Test
    public void testHandleMessage() throws Exception {
        NuroServiceProto.NuroOUT0101U02GridPatientRequest request = NuroServiceProto.NuroOUT0101U02GridPatientRequest.newBuilder()
                .setPatientCode("000015249").build();
        sentRequestToMedApp(request, NuroServiceProto.getDescriptor().
                getOptions().getExtension(Rpc.service));


    }
}
