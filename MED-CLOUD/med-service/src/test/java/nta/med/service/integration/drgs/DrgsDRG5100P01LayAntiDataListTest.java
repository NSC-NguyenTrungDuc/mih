package nta.med.service.integration.drgs;

import nta.med.common.remoting.rpc.protobuf.Rpc;
import nta.med.service.ihis.proto.DrgsServiceProto;
import nta.med.service.integration.MessageRequestTest;
import org.junit.Test;

/**
 * @author DEV-TiepNM
 */
public class DrgsDRG5100P01LayAntiDataListTest extends MessageRequestTest {
    @Test
    public void test() throws InterruptedException {
        DrgsServiceProto.DrgsDRG5100P01LayAntiDataListRequest request = DrgsServiceProto.DrgsDRG5100P01LayAntiDataListRequest
                .newBuilder()
                .setFkocs("")
                .build();
        sentRequestToMedApp(request, DrgsServiceProto.getDescriptor().getOptions().getExtension(Rpc.service));
    }
}
