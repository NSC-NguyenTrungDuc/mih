package nta.med.service.integration.nuro;

import org.junit.Test;

import nta.med.common.remoting.rpc.protobuf.Rpc;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.integration.MessageRequestTest;

public class GetPatientByCodeTest extends MessageRequestTest {
    @Test
    public void testCheckUserLogin() throws InterruptedException {

        SystemServiceProto.GetPatientByCodeRequest request = SystemServiceProto.
        		GetPatientByCodeRequest.newBuilder()
                .setPatientCode("000000126")
                .build();

        sentRequestToMedApp(request, SystemServiceProto.getDescriptor().
                getOptions().getExtension(Rpc.service));
    }
}
