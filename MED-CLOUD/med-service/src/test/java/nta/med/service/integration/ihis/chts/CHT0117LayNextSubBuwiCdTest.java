package nta.med.service.integration.ihis.chts;

import nta.med.common.remoting.rpc.protobuf.Rpc;
import nta.med.service.ihis.proto.ChtsServiceProto;
import nta.med.service.integration.MessageRequestTest;
import org.junit.Test;


public class CHT0117LayNextSubBuwiCdTest extends MessageRequestTest {


    @Test
    public void test() throws InterruptedException {
        ChtsServiceProto.CHT0117LayNextSubBuwiCdRequest request = ChtsServiceProto.CHT0117LayNextSubBuwiCdRequest
                .newBuilder()
                .build();

        sentRequestToMedApp(request, ChtsServiceProto.getDescriptor().
                getOptions().getExtension(Rpc.service));
    }
}