package nta.med.service.integration.drgs;

import org.junit.Test;

import nta.med.common.remoting.rpc.protobuf.Rpc;
import nta.med.service.ihis.proto.DrgsServiceProto;
import nta.med.service.integration.MessageRequestTest;


public class DRG3041P06grdActListTest extends MessageRequestTest {
    @Test
    public void testDrgsDRG5100P01DsvOrderPrint() throws InterruptedException {
    	DrgsServiceProto.DRG3041P06grdActListRequest request = DrgsServiceProto.DRG3041P06grdActListRequest.newBuilder()
    			.setIpgoDate("2016/1/21")
    			.setBunho("000000001")
    			.setBunryu1("1")
    			.setHoDong("T")
                .build();
        sentRequestToMedApp(request, DrgsServiceProto.getDescriptor().getOptions().getExtension(Rpc.service));
    }
}
