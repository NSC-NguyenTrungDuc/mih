package nta.med.service.integration.nuro;

import nta.med.common.remoting.rpc.protobuf.Rpc;
import nta.med.service.ihis.proto.NuroServiceProto;
import nta.med.service.integration.MessageRequestTest;
import org.junit.Test;

/**
 * @author DEV-TiepNM
 */
public class NuroPatientGridViewTest extends MessageRequestTest {
    @Test
    public void testNuroPatientGridView() throws InterruptedException {
        NuroServiceProto.NuroPatientGridViewRequest request = NuroServiceProto.NuroPatientGridViewRequest.newBuilder().setPatientCode("abcdefgh4").build();
        sentRequestToMedApp(request, NuroServiceProto.getDescriptor().getOptions().getExtension(Rpc.service));
    }

}
