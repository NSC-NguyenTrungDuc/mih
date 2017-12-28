package nta.med.service.integration.adma;

import org.junit.Test;

import nta.med.common.remoting.rpc.protobuf.Rpc;
import nta.med.service.ihis.proto.AdmaServiceProto;
import nta.med.service.integration.MessageRequestTest;

public class ADM104UGridUserTest extends MessageRequestTest {

    @Test
    public void testADM104UGridUserSaveLayout() throws InterruptedException {
        
    	AdmaServiceProto.ADM104UGridUserRequest request = AdmaServiceProto.ADM104UGridUserRequest.newBuilder().setHospCode("K02").build();

        sentRequestToMedApp(request, AdmaServiceProto.getDescriptor().
                getOptions().getExtension(Rpc.service));

    }
}
