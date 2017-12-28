package nta.med.service.integration.system;

import nta.med.common.remoting.rpc.protobuf.Rpc;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.integration.MessageRequestTest;
import org.junit.Test;

/**
 * @author DEV-TiepNM
 */
public class MdiFormMainMenuTest extends MessageRequestTest {
    @Test
    public void test() throws InterruptedException {
        SystemServiceProto.MdiFormMainMenuRequest request = SystemServiceProto.MdiFormMainMenuRequest
                .newBuilder().setHospCode("K01").setUserId("K01DRG").setSystemId("DRGS")
                .build();
        sentRequestToMedApp(request, SystemServiceProto.getDescriptor().
                getOptions().getExtension(Rpc.service));
    }
}
