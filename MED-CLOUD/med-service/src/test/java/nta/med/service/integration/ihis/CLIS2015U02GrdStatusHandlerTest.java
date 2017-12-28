package nta.med.service.integration.ihis;

import nta.med.common.remoting.rpc.protobuf.Rpc;
import nta.med.service.ihis.proto.ClisServiceProto;
import nta.med.service.integration.MessageRequestTest;
import org.junit.Test;

public class CLIS2015U02GrdStatusHandlerTest extends MessageRequestTest{

    @Test
    public void testCLIS2015U02GrdStatusRequest() throws Exception {
    	ClisServiceProto.CLIS2015U02GrdStatusRequest request = ClisServiceProto.CLIS2015U02GrdStatusRequest.newBuilder()
        		.setProtocolId("30")
        		.build();

        sentRequestToMedApp(request, ClisServiceProto.getDescriptor().
                getOptions().getExtension(Rpc.service));
	}
}
