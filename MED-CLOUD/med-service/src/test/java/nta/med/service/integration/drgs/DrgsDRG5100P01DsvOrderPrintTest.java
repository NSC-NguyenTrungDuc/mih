package nta.med.service.integration.drgs;

import org.junit.Test;

import nta.med.common.remoting.rpc.protobuf.Rpc;
import nta.med.service.ihis.proto.DrgsServiceProto;
import nta.med.service.integration.MessageRequestTest;


public class DrgsDRG5100P01DsvOrderPrintTest extends MessageRequestTest {
    @Test
    public void testDrgsDRG5100P01DsvOrderPrint() throws InterruptedException {
    	DrgsServiceProto.DrgsDRG5100P01DsvOrderPrintRequest request = DrgsServiceProto.DrgsDRG5100P01DsvOrderPrintRequest
                .newBuilder()
                .setDrgBunho("1")
                .setIoGobun("O")
                .setJubsuDate("2015/12/04")
                .build();
        sentRequestToMedApp(request, DrgsServiceProto.getDescriptor().getOptions().getExtension(Rpc.service));
    }
}
