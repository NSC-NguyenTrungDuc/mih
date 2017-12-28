package nta.med.service.unit.emr;

import org.junit.Test;

import nta.med.common.remoting.rpc.protobuf.Rpc;
import nta.med.service.emr.proto.EmrServiceProto;
import nta.med.service.integration.MessageRequestTest;

public class OCS2015U40EmrMedicalRecordContentTest extends MessageRequestTest {
    @Test
    public void testCheckUserLogin() throws InterruptedException {

    	EmrServiceProto.OCS2015U40EmrMedicalRecordContentRequest request = EmrServiceProto.
    			OCS2015U40EmrMedicalRecordContentRequest.newBuilder()
    			.setVersion("2")
                .build();

        sentRequestToMedApp(request, EmrServiceProto.getDescriptor().
                getOptions().getExtension(Rpc.service));
    }
}

