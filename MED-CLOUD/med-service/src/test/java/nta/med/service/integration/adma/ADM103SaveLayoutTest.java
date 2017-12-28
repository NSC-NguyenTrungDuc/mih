package nta.med.service.integration.adma;

import nta.med.common.remoting.rpc.protobuf.Rpc;
import nta.med.service.ihis.proto.AdmaModelProto;
import nta.med.service.ihis.proto.AdmaServiceProto;
import nta.med.service.integration.MessageRequestTest;
import org.junit.Test;

/**
 * @author DEV-TiepNM
 */
public class ADM103SaveLayoutTest extends MessageRequestTest {
    @Test
    public void testADM103SaveLayout() throws InterruptedException {

        AdmaModelProto.ADM103UgrdUserGrpInfo info =  AdmaModelProto.ADM103UgrdUserGrpInfo.newBuilder()
                .setUserGroup("ADMIN").setRowState("Added").build();

        AdmaServiceProto.ADM103SaveLayoutRequest request = AdmaServiceProto.ADM103SaveLayoutRequest.newBuilder()
                .setHospCode("K01").setSysId("K01ADM").addItemInfo(info).build();

        sentRequestToMedApp(request, AdmaServiceProto.getDescriptor().
                getOptions().getExtension(Rpc.service));
    }
}
