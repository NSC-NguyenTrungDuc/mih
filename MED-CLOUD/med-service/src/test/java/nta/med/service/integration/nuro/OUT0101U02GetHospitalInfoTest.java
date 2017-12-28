package nta.med.service.integration.nuro;

import nta.med.common.remoting.rpc.protobuf.Rpc;
import nta.med.service.ihis.proto.NuroServiceProto;
import nta.med.service.integration.MessageRequestTest;
import org.junit.Test;

/**
 * @author DEV-TiepNM
 */
public class OUT0101U02GetHospitalInfoTest extends MessageRequestTest {

    @Test
    public void testOUT0101U02GetHospitalInfo() throws InterruptedException {
        NuroServiceProto.OUT0101U02GetHospitalInfoRequest request = NuroServiceProto.OUT0101U02GetHospitalInfoRequest
                .newBuilder().setHospCode("346").setBunho("000000167")
                .build();

        sentRequestToMedApp(request, NuroServiceProto.getDescriptor().getOptions().getExtension(Rpc.service));
    }
}
