package nta.med.service.integration.ihis;

import nta.med.common.remoting.rpc.protobuf.Rpc;
import nta.med.service.ihis.proto.OcsaServiceProto;
import nta.med.service.integration.MessageRequestTest;

import org.junit.Test;

public class OCS0203U00GetOCSCOMUserIDHandlerTest extends MessageRequestTest{

    @Test
    public void testOCS0203U00GetOCSCOMUserIDRequest() throws Exception {
    	OcsaServiceProto.OCS0203U00GetOCSCOMUserIDRequest request = OcsaServiceProto.OCS0203U00GetOCSCOMUserIDRequest.newBuilder()
        		.setUserGubun("SLIP")
        		.setUserId("SAM001")
        		.build();

        sentRequestToMedApp(request, OcsaServiceProto.getDescriptor().
                getOptions().getExtension(Rpc.service));
	}
}
