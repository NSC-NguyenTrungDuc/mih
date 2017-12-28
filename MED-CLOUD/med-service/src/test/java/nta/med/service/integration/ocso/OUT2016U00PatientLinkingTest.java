package nta.med.service.integration.ocso;

import org.junit.Test;

import nta.med.common.remoting.rpc.protobuf.Rpc;
import nta.med.service.ihis.proto.OcsoServiceProto;
import nta.med.service.integration.MessageRequestTest;

/**
 * @author Tiepnm
 */
public class OUT2016U00PatientLinkingTest extends MessageRequestTest {

    @Test
    public void testOUT2016U00PatientLinking() throws InterruptedException {

        OcsoServiceProto.OUT2016U00PatientLinkingRequest request = OcsoServiceProto.OUT2016U00PatientLinkingRequest.newBuilder().
                setHospCode("K01")
                .setBunho("000001650")
                .setHospCodeLink("K01-01")
                .setBunhoLink("000000006")
                .setPassword("1234")
                .build();
        sentRequestToMedApp(request, OcsoServiceProto.getDescriptor().
                getOptions().getExtension(Rpc.service));
    }
}
