package nta.med.service.integration.ocsa;

import nta.med.common.remoting.rpc.protobuf.Rpc;
import nta.med.service.ihis.proto.OcsaServiceProto;
import nta.med.service.integration.MessageRequestTest;

import org.junit.Test;

public class OCS0301Q09GrdOCS0303HandlerTest extends MessageRequestTest{

    @Test
    public void testOCS0301Q09GrdOCS0303Request() throws Exception {
    	OcsaServiceProto.OCS0301Q09GrdOCS0303Request request = OcsaServiceProto.OCS0301Q09GrdOCS0303Request.newBuilder()
        		.build();

        sentRequestToMedApp(request, OcsaServiceProto.getDescriptor().
                getOptions().getExtension(Rpc.service));
	}
}
