package nta.med.service.integration.ihis.chts;

import nta.med.common.remoting.rpc.protobuf.Rpc;
import nta.med.service.ihis.proto.ChtsServiceProto;
import nta.med.service.integration.MessageRequestTest;
import org.junit.Test;

/**
 * @author DEV-TiepNM
 */
public class CHT0115Q00GrdScPreTest extends MessageRequestTest  {

    @Test
    public void test() throws InterruptedException {
        ChtsServiceProto.CHT0115Q00GrdScPreRequest request = ChtsServiceProto.CHT0115Q00GrdScPreRequest
                .newBuilder().setSusikName("name")
                .build();

        sentRequestToMedApp(request, ChtsServiceProto.getDescriptor().
                getOptions().getExtension(Rpc.service));
    }
}