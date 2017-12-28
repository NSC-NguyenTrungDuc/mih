package nta.med.service.integration.ocsa;

import nta.med.common.remoting.rpc.protobuf.Rpc;
import nta.med.service.ihis.proto.OcsaServiceProto;
import nta.med.service.integration.MessageRequestTest;
import org.junit.Test;
import org.springframework.beans.factory.annotation.Autowired;
import org.vertx.java.core.Vertx;


public class OCS0101U00GrdOcs0101InitTest extends MessageRequestTest {
    @Autowired
    protected Vertx vertx;

    @Test
    public void testOCS0101U00GrdOcs0101InitTest() throws InterruptedException {
        OcsaServiceProto.OCS0101U00GrdOcs0101InitRequest request = OcsaServiceProto.OCS0101U00GrdOcs0101InitRequest
                .newBuilder()
                .build();
        sentRequestToMedApp(request, OcsaServiceProto.getDescriptor().
                getOptions().getExtension(Rpc.service));
    }
}