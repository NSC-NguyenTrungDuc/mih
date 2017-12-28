package nta.med.service.integration.ihis.chts;

import nta.med.common.remoting.rpc.protobuf.Rpc;
import nta.med.service.ihis.proto.ChtsServiceProto;
import nta.med.service.integration.MessageRequestTest;
import org.junit.Test;


public class CHT0110U00GetCodeNameTest extends MessageRequestTest {


    @Test
    public void test() throws InterruptedException {
        ChtsServiceProto.CHT0110U00GetCodeNameRequest request = ChtsServiceProto.CHT0110U00GetCodeNameRequest
                .newBuilder().setCodeMode("sang_code")
                .build();

        sentRequestToMedApp(request, ChtsServiceProto.getDescriptor().
                getOptions().getExtension(Rpc.service));
    }
}