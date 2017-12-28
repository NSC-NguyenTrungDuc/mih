package nta.med.service.integration.nuro;

import org.junit.Test;

import nta.med.common.remoting.rpc.protobuf.Rpc;
import nta.med.service.ihis.proto.NuroServiceProto;
import nta.med.service.integration.MessageRequestTest;

public class PatientInfoHandlerTest extends MessageRequestTest {

    @Test
    public void testPatientInfoHandler() throws InterruptedException {
        NuroServiceProto.PatientInfoRequest request = NuroServiceProto.
        		PatientInfoRequest.newBuilder()
                .setDiseaseName("せつ")
                .build();

        sentRequestToMedApp(request, NuroServiceProto.getDescriptor().
                getOptions().getExtension(Rpc.service));
    }
}
