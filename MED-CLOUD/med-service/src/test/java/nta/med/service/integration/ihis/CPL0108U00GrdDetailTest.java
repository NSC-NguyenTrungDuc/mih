package nta.med.service.integration.ihis;

import java.util.concurrent.CountDownLatch;
import java.util.concurrent.TimeUnit;

import nta.med.common.remoting.rpc.protobuf.Rpc;
import nta.med.service.ihis.proto.CplsServiceProto;

import nta.med.service.integration.MessageRequestTest;
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
public class CPL0108U00GrdDetailTest extends MessageRequestTest {
	@Autowired
    protected Vertx vertx;

    @Test
    public void testHandleMessage() throws Exception {

        CplsServiceProto.CPL0108U00GrdDetailRequest request =  CplsServiceProto.CPL0108U00GrdDetailRequest.newBuilder().
                setOffset("20").setPageNumber("1").setCodeType("03").build();

        sentRequestToMedApp(request, CplsServiceProto.getDescriptor().
                getOptions().getExtension(Rpc.service));
    }
}
