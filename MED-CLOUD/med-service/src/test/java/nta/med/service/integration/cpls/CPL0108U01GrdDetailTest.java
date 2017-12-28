package nta.med.service.integration.cpls;

import nta.med.common.remoting.rpc.protobuf.Rpc;
import nta.med.service.ihis.proto.CplsServiceProto;
import nta.med.service.integration.MessageRequestTest;
import org.junit.Test;

/**
 * @author Tiepnm
 */
public class CPL0108U01GrdDetailTest extends MessageRequestTest {
    @Test
    public void test() throws InterruptedException {

        CplsServiceProto.CPL0108U01GrdDetailRequest request = CplsServiceProto.CPL0108U01GrdDetailRequest.newBuilder()
                .setHospCode("160")
                .setCodeType("BLOOD_KIND")
                .build();

        sentRequestToMedApp(request, CplsServiceProto.getDescriptor().
                getOptions().getExtension(Rpc.service));
    }
}
