package nta.med.service.integration.drgs;

import org.junit.Test;

import nta.med.common.remoting.rpc.protobuf.Rpc;
import nta.med.service.ihis.proto.DrgsServiceProto;
import nta.med.service.integration.MessageRequestTest;

public class DRG9001R04lay9001RTest extends MessageRequestTest {
    @Test
    public void testDrgsDRG5100P01DsvOrderPrint() throws InterruptedException {
    	DrgsServiceProto.DRG9001R04lay9001RRequest request = DrgsServiceProto.DRG9001R04lay9001RRequest.newBuilder()
    			.setDate("2012")
    			.setHoDong("1")
                .build();
        sentRequestToMedApp(request, DrgsServiceProto.getDescriptor().getOptions().getExtension(Rpc.service));
    }
}
