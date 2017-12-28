package nta.med.service.integration.ihis.chts;

import nta.med.common.remoting.rpc.protobuf.Rpc;
import nta.med.service.ihis.proto.ChtsServiceProto;
import nta.med.service.integration.MessageRequestTest;
import org.junit.Test;

/**
 * @author DEV-TiepNM
 */
public class CHT0110Q01GrdCHT0110MListTest extends MessageRequestTest {
    @Test
    public void testCHT0110Q01GrdCHT0110MList() throws InterruptedException {
        ChtsServiceProto.CHT0110Q01GrdCHT0110MListRequest request = ChtsServiceProto.CHT0110Q01GrdCHT0110MListRequest
                .newBuilder().setIoGubun("").setDate("2015/12/29")
                .build();

        sentRequestToMedApp(request, ChtsServiceProto.getDescriptor().
                getOptions().getExtension(Rpc.service));
    }
}
