package nta.med.service.integration.bass;

import nta.med.common.remoting.rpc.protobuf.Rpc;
import nta.med.service.ihis.proto.BassServiceProto;
import nta.med.service.integration.MessageRequestTest;
import org.junit.Test;

/**
 * @author Tiepnm
 */
public class BAS0310U00GrdListTest extends MessageRequestTest{

    @Test
    public void testBAS0310U00GrdList() throws InterruptedException {

        BassServiceProto.BAS0310U00GrdListRequest request = BassServiceProto.BAS0310U00GrdListRequest.newBuilder().setAText("%").setOffset("2000").setPageNumber("1").build();

        sentRequestToMedApp(request, BassServiceProto.getDescriptor().
                getOptions().getExtension(Rpc.service));
    }
}
