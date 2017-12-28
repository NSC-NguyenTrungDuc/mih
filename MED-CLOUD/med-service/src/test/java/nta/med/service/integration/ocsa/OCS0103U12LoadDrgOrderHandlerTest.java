package nta.med.service.integration.ocsa;

import nta.med.common.remoting.rpc.protobuf.Rpc;
import nta.med.service.ihis.proto.OcsaServiceProto;
import nta.med.service.integration.MessageRequestTest;

import org.junit.Test;

public class OCS0103U12LoadDrgOrderHandlerTest extends MessageRequestTest{

    @Test
    public void testOCS0103U12LoadDrgOrderRequest() throws Exception {
    	OcsaServiceProto.OCS0103U12LoadDrgOrderRequest request = OcsaServiceProto.OCS0103U12LoadDrgOrderRequest.newBuilder()
        		.build();

        sentRequestToMedApp(request, OcsaServiceProto.getDescriptor().
                getOptions().getExtension(Rpc.service));
	}
}
