package nta.med.service.integration.ihis;

import nta.med.common.remoting.rpc.protobuf.Rpc;
import nta.med.service.ihis.proto.OcsoServiceProto;
import nta.med.service.integration.MessageRequestTest;

import org.junit.Test;


public class OCS1003GrdOUT1001RowFocusChangedHandlerTest extends MessageRequestTest{

    @Test
    public void testGetProtocolListByPatientItemRequest() throws Exception {
        OcsoServiceProto.OCS1003GrdOUT1001RowFocusChangedRequest request = OcsoServiceProto.OCS1003GrdOUT1001RowFocusChangedRequest.newBuilder()
        		.setBunho("000001127")
				.setFkout1001("961")
				.setQueryGubun("D")
				.build();      
	
        sentRequestToMedApp(request, OcsoServiceProto.getDescriptor().
                getOptions().getExtension(Rpc.service));
	}	
}
