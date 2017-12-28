package nta.med.service.integration.cpls;

import org.junit.Test;

import nta.med.common.remoting.rpc.protobuf.Rpc;
import nta.med.service.ihis.proto.CplsServiceProto;
import nta.med.service.integration.MessageRequestTest;

public class CPL2010U01layBarcodeTempQueryEndTest extends MessageRequestTest{

	@Test
    public void test() throws InterruptedException {

        CplsServiceProto.CPL2010U01layBarcodeTempQueryEndRequest request = CplsServiceProto.CPL2010U01layBarcodeTempQueryEndRequest.newBuilder()
                .setBunho("123456")
                .build();

        sentRequestToMedApp(request, CplsServiceProto.getDescriptor().
                getOptions().getExtension(Rpc.service));
    }
}
