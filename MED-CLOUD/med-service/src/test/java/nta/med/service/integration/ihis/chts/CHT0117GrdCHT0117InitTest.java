package nta.med.service.integration.ihis.chts;

import nta.med.common.remoting.rpc.protobuf.Rpc;
import nta.med.service.ihis.proto.ChtsServiceProto;
import nta.med.service.integration.MessageRequestTest;
import org.junit.Test;


public class CHT0117GrdCHT0117InitTest extends MessageRequestTest {


    @Test
    public void test() throws InterruptedException {
        ChtsServiceProto.CHT0117GrdCHT0117InitRequest request = ChtsServiceProto.CHT0117GrdCHT0117InitRequest
                .newBuilder().setSearchWord("").setQueryDate("2015/12/29").setOffset("1").setPageNumber("1")
                .build();

        sentRequestToMedApp(request, ChtsServiceProto.getDescriptor().
                getOptions().getExtension(Rpc.service));
    }
}