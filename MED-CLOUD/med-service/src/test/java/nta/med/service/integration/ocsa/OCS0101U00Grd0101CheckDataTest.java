package nta.med.service.integration.ocsa;

import nta.med.common.remoting.rpc.protobuf.Rpc;
import nta.med.service.ihis.proto.OcsaServiceProto;
import nta.med.service.integration.MessageRequestTest;
import org.junit.Test;
import org.springframework.beans.factory.annotation.Autowired;
import org.vertx.java.core.Vertx;


public class OCS0101U00Grd0101CheckDataTest extends MessageRequestTest {
    @Autowired
    protected Vertx vertx;

    @Test
    public void testOCS0101U00Grd0101CheckData() throws InterruptedException {
        OcsaServiceProto.OCS0101U00Grd0101CheckDataRequest request = OcsaServiceProto.OCS0101U00Grd0101CheckDataRequest
                .newBuilder()
                .setValue("B")
                .build();
        sentRequestToMedApp(request, OcsaServiceProto.getDescriptor().
                getOptions().getExtension(Rpc.service));

    }
}