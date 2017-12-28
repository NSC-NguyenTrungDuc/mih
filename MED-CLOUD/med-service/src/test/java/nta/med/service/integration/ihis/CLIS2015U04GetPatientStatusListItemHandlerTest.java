package nta.med.service.integration.ihis;

import nta.med.common.remoting.rpc.protobuf.Rpc;
import nta.med.service.ihis.proto.ClisServiceProto;
import nta.med.service.integration.MessageRequestTest;
import org.junit.Test;

public class CLIS2015U04GetPatientStatusListItemHandlerTest extends MessageRequestTest{

    @Test
    public void testGetPatientStatusListItemRequest() throws Exception {
        ClisServiceProto.CLIS2015U04GetPatientStatusListItemRequest request = ClisServiceProto.CLIS2015U04GetPatientStatusListItemRequest.newBuilder()
        		.setProtocolPatientId("1")
        		.build();

        sentRequestToMedApp(request, ClisServiceProto.getDescriptor().
                getOptions().getExtension(Rpc.service));
	}
}
