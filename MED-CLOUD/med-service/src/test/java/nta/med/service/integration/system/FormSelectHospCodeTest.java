package nta.med.service.integration.system;

import nta.med.common.remoting.rpc.protobuf.Rpc;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.integration.MessageRequestTest;
import org.junit.Test;

/**
 * @author DEV-TiepNM
 */
public class FormSelectHospCodeTest extends MessageRequestTest {

    @Test
    public void test() throws InterruptedException {
        SystemServiceProto.FormSelectHospCodeRequest request = SystemServiceProto.
                FormSelectHospCodeRequest.newBuilder().setHospCode("K01").build();

        sentRequestToMedApp(request, SystemServiceProto.getDescriptor().
                getOptions().getExtension(Rpc.service));
    }
}
