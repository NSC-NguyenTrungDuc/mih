package nta.med.service.integration.drgs;

import org.junit.Test;

import nta.med.common.remoting.rpc.protobuf.Rpc;
import nta.med.service.ihis.proto.DrgsServiceProto;
import nta.med.service.integration.MessageRequestTest;

public class DRG3041P01grdChulgoListTest extends MessageRequestTest{

	@Test
    public void testDrgsDRG5100P01DsvOrderPrint() throws InterruptedException {
    	DrgsServiceProto.DRG3041P01grdChulgoListRequest request = DrgsServiceProto.DRG3041P01grdChulgoListRequest.newBuilder()
    			.setChulgoDate("2016/1/21")
    			.setBunho("000000001")
    			.setHoDong("T")
                .build();
        sentRequestToMedApp(request, DrgsServiceProto.getDescriptor().getOptions().getExtension(Rpc.service));
    }
}
