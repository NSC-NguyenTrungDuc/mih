package nta.med.service.integration.orca;

import nta.med.common.remoting.rpc.protobuf.Rpc;
import nta.med.service.ihis.proto.NuroServiceProto;
import nta.med.service.integration.MessageRequestTest;
import nta.med.service.orca.proto.OrcaServiceProto;
import org.junit.Test;

/**
 * @author DEV-TiepNM
 */
public class ORCATransferOrdersTest extends MessageRequestTest {
    @Test
    public void test() throws InterruptedException {
        OrcaServiceProto.ORCATransferOrdersRequest request = OrcaServiceProto.
                ORCATransferOrdersRequest.newBuilder().setHospCode("K01").setBunho("000001648").setPkout1001("3600").build();

        sentRequestToMedApp(request, OrcaServiceProto.getDescriptor().
                getOptions().getExtension(Rpc.service));
    }
}
