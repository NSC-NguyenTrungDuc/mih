package nta.med.service.integration.ihis.chts;

import nta.med.common.remoting.rpc.protobuf.Rpc;
import nta.med.service.ihis.proto.ChtsServiceProto;
import nta.med.service.integration.MessageRequestTest;
import org.junit.Test;

/**
 * @author DEV-TiepNM
 */
public class CHT0113Q00GrdCHT0113Test extends MessageRequestTest {

    @Test
    public void test() throws InterruptedException {
        ChtsServiceProto.CHT0113Q00GrdCHT0113Request request = ChtsServiceProto.CHT0113Q00GrdCHT0113Request
                .newBuilder().setDate("2015/12/29")
                .build();

        sentRequestToMedApp(request, ChtsServiceProto.getDescriptor().
                getOptions().getExtension(Rpc.service));
    }

}
