package nta.med.service.integration.ihis;

import nta.med.common.remoting.rpc.protobuf.Rpc;
import nta.med.service.ihis.proto.ClisServiceProto;
import nta.med.service.integration.MessageRequestTest;

import org.junit.Test;


public class CLIS2015U04GetProtocolItemHandlerTest extends MessageRequestTest{

    @Test
    public void testGetProtocolItemInfoRequest() throws Exception {
        ClisServiceProto.CLIS2015U04GetProtocolItemRequest request = ClisServiceProto.CLIS2015U04GetProtocolItemRequest.newBuilder()
        		.build();

        sentRequestToMedApp(request, ClisServiceProto.getDescriptor().
                getOptions().getExtension(Rpc.service));
	}
}
