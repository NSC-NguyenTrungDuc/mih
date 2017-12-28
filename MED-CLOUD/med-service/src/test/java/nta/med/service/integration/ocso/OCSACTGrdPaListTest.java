package nta.med.service.integration.ocso;

import nta.med.common.remoting.rpc.protobuf.Rpc;
import nta.med.service.ihis.proto.OcsoServiceProto;
import nta.med.service.integration.MessageRequestTest;
import org.junit.Test;

/**
 * @author DEV-TiepNM
 */
public class OCSACTGrdPaListTest extends MessageRequestTest {
    @Test
    public void test() throws InterruptedException {


        OcsoServiceProto.OCSACTGrdPaListRequest request = OcsoServiceProto.OCSACTGrdPaListRequest
                .newBuilder()
                .setCboSystem("OCS_ACT_PART_0")
                .setCboVal("%")
                .setCboPart("%")
                .setFromDate("2016/01/05")
                .setToDate("2016/01/05")
                .setBunho("000000007")
                .setActGubun("2").setJundalTableCode("OCS_ACT_PART_0")
                .setIoGubun("1")
                .setSystemId("TSTS")
                .build();
        sentRequestToMedApp(request, OcsoServiceProto.getDescriptor().
                getOptions().getExtension(Rpc.service));
    }
}
