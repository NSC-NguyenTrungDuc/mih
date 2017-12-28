package nta.med.service.integration.system;

import org.junit.Test;

import nta.med.common.remoting.rpc.protobuf.Rpc;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.integration.MessageRequestTest;

public class LoadHangmogInfoCompositeFirstTest extends MessageRequestTest {
    @Test
    public void testCheckUserLogin() throws InterruptedException {
    	
        SystemServiceProto.LoadHangmogInfoCompositeFirstRequest request = SystemServiceProto.
        		LoadHangmogInfoCompositeFirstRequest.newBuilder()
        		.build();

        sentRequestToMedApp(request, SystemServiceProto.getDescriptor().
                getOptions().getExtension(Rpc.service));
    }
}
