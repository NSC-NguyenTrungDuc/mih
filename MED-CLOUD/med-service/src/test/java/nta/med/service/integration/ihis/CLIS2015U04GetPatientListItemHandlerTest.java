package nta.med.service.integration.ihis;

import nta.med.common.remoting.rpc.protobuf.Rpc;
import nta.med.service.ihis.proto.ClisServiceProto;
import nta.med.service.integration.MessageRequestTest;
import org.junit.Test;

public class CLIS2015U04GetPatientListItemHandlerTest extends MessageRequestTest{

    @Test
    public void testGetPatientListItemRequest() throws Exception {
        ClisServiceProto.CLIS2015U04GetPatientListItemRequest request = ClisServiceProto.CLIS2015U04GetPatientListItemRequest.newBuilder()
        		.setClisProtocolId("12")
        		.build();

        sentRequestToMedApp(request, ClisServiceProto.getDescriptor().
                getOptions().getExtension(Rpc.service));
	}
}
