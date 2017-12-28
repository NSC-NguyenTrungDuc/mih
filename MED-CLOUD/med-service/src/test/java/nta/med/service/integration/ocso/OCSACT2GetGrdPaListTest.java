package nta.med.service.integration.ocso;

import org.junit.Test;

import nta.med.common.remoting.rpc.protobuf.Rpc;
import nta.med.service.ihis.proto.OcsoServiceProto;
import nta.med.service.integration.MessageRequestTest;

public class OCSACT2GetGrdPaListTest extends MessageRequestTest {
    @Test
    public void testOCSACT2GetGrdPaListRequest() throws InterruptedException {

    	OcsoServiceProto.OCSACT2GetGrdPaListRequest request = OcsoServiceProto.
    			OCSACT2GetGrdPaListRequest.newBuilder()
               .setJundalTable("TST")
               .setGwa("01")
               .setOrderDateFrom("2016/05/05")
               .setOrderDateTo("2016/05/05")
               .setHospCode("316")
               .setActingFlg("1")
               .build();

        sentRequestToMedApp(request, OcsoServiceProto.getDescriptor().
                getOptions().getExtension(Rpc.service));
    }
}
