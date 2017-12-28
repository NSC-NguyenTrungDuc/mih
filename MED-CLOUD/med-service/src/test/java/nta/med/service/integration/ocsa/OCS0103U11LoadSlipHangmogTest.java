package nta.med.service.integration.ocsa;

import nta.med.common.remoting.rpc.protobuf.Rpc;
import nta.med.service.ihis.proto.OcsaModelProto;
import nta.med.service.ihis.proto.OcsaServiceProto;
import nta.med.service.integration.MessageRequestTest;
import org.junit.Test;

/**
 * @author Tiepnm
 */
public class OCS0103U11LoadSlipHangmogTest extends MessageRequestTest {

    @Test
    public void testOCS0103U11LoadSlipHangmog() throws InterruptedException {

        OcsaServiceProto.OCS0103U11LoadSlipHangmogRequest request = OcsaServiceProto.OCS0103U11LoadSlipHangmogRequest.newBuilder().setSlipCode("I04").build();

        sentRequestToMedApp(request, OcsaServiceProto.getDescriptor().
                getOptions().getExtension(Rpc.service));
    }
}
