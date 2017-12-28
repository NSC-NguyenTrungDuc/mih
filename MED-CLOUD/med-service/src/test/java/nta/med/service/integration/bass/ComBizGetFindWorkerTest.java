package nta.med.service.integration.bass;

import nta.med.common.remoting.rpc.protobuf.Rpc;
import nta.med.service.ihis.proto.BassServiceProto;
import nta.med.service.integration.MessageRequestTest;
import org.junit.Test;

/**
 * @author Tiepnm
 */
public class ComBizGetFindWorkerTest extends MessageRequestTest  {

    @Test
    public void testComBizGetFindWorkerTest() throws InterruptedException {

        BassServiceProto.ComBizGetFindWorkerRequest request = BassServiceProto.ComBizGetFindWorkerRequest
                .newBuilder().setColName("slip_code")
                .build();
        sentRequestToMedApp(request, BassServiceProto.getDescriptor().
                getOptions().getExtension(Rpc.service));
    }
}
