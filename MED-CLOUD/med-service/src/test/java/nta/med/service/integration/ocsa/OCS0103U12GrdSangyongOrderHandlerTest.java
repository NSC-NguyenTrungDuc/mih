package nta.med.service.integration.ocsa;

import nta.med.common.remoting.rpc.protobuf.Rpc;
import nta.med.service.ihis.proto.OcsaServiceProto;
import nta.med.service.integration.MessageRequestTest;

import org.junit.Test;

public class OCS0103U12GrdSangyongOrderHandlerTest extends MessageRequestTest{

    @Test
    public void testOCS0103U12GrdSangyongOrderRequest() throws Exception {
    	OcsaServiceProto.OCS0103U12GrdSangyongOrderRequest request = OcsaServiceProto.OCS0103U12GrdSangyongOrderRequest.newBuilder()
    			.setIoGubun("O")
    			.setUser("K01OCS")
    			.setOrderGubun("G")
    			.setOrderDate("2016/03/30")
    			.setWonnaeDrgYn("%")
        		.build();

        sentRequestToMedApp(request, OcsaServiceProto.getDescriptor().
                getOptions().getExtension(Rpc.service));
	}
}
