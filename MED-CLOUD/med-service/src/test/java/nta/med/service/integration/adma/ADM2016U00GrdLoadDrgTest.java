package nta.med.service.integration.adma;

import org.junit.Test;

import nta.med.common.remoting.rpc.protobuf.Rpc;
import nta.med.service.ihis.proto.AdmaServiceProto;
import nta.med.service.integration.MessageRequestTest;

public class ADM2016U00GrdLoadDrgTest extends MessageRequestTest {

    @Test
    public void testADM2016U00GrdLoadDrg() throws InterruptedException {
        
    	AdmaServiceProto.ADM2016U00GrdLoadDrgRequest request = AdmaServiceProto.ADM2016U00GrdLoadDrgRequest.newBuilder()
    			.setSearchAccount("Y")
    			.setSearchType("")
    			.setSearchName("")
    			.setPageNumber("5")
    			.setOffset("100")
    			.build();

        sentRequestToMedApp(request, AdmaServiceProto.getDescriptor().
                getOptions().getExtension(Rpc.service));

    }
}
