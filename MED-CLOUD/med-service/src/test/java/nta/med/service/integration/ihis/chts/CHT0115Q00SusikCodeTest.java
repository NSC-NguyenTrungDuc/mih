package nta.med.service.integration.ihis.chts;

import nta.med.common.remoting.rpc.protobuf.Rpc;
import nta.med.service.ihis.proto.ChtsServiceProto;
import nta.med.service.integration.MessageRequestTest;
import org.junit.Test;

/**
 * @author DEV-TiepNM
 */
public class CHT0115Q00SusikCodeTest extends MessageRequestTest {
    @Test
    public void test() throws InterruptedException {
        ChtsServiceProto.CHT0115Q00SusikCodeRequest request = ChtsServiceProto.CHT0115Q00SusikCodeRequest
                .newBuilder().setSusikCode("")
                .build();

        sentRequestToMedApp(request, ChtsServiceProto.getDescriptor().
                getOptions().getExtension(Rpc.service));
    }
}
