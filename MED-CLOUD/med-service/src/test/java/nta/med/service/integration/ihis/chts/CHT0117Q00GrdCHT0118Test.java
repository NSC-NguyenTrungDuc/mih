package nta.med.service.integration.ihis.chts;

import nta.med.common.remoting.rpc.protobuf.Rpc;
import nta.med.service.ihis.proto.ChtsServiceProto;
import nta.med.service.integration.MessageRequestTest;
import org.junit.Test;

/**
 * @author DEV-TiepNM
 */
public class CHT0117Q00GrdCHT0118Test extends MessageRequestTest {

    @Test
    public void test() throws InterruptedException {
        ChtsServiceProto.CHT0117Q00GrdCHT0118Request request = ChtsServiceProto.CHT0117Q00GrdCHT0118Request
                .newBuilder()
                .build();

        sentRequestToMedApp(request, ChtsServiceProto.getDescriptor().
                getOptions().getExtension(Rpc.service));
    }
}