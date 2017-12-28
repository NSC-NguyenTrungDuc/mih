package nta.med.service.integration.ihis;

import nta.med.common.remoting.rpc.protobuf.Rpc;
import nta.med.service.ihis.proto.ClisServiceProto;
import nta.med.service.integration.MessageRequestTest;

import org.junit.Test;


public class CLIS2015U04GetProtocolListByPatientItemHandlerTest extends MessageRequestTest{

    @Test
    public void testGetProtocolListByPatientItemRequest() throws Exception {
        ClisServiceProto. CLIS2015U04GetProtocolListByPatientItemRequest request = ClisServiceProto. CLIS2015U04GetProtocolListByPatientItemRequest.newBuilder()
        		.setPatientCode("000000359")
        		.build();

        sentRequestToMedApp(request, ClisServiceProto.getDescriptor().
                getOptions().getExtension(Rpc.service));
	}
}
