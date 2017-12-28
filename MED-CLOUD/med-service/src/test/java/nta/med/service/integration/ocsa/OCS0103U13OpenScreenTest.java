package nta.med.service.integration.ocsa;

import org.junit.Test;

import nta.med.common.remoting.rpc.protobuf.Rpc;
import nta.med.service.ihis.proto.OcsaServiceProto;
import nta.med.service.integration.MessageRequestTest;

/**
 * 
 * @author DEV-HuanLT
 *
 */
public class OCS0103U13OpenScreenTest extends MessageRequestTest{

    @Test
    public void testOCS0103U13OpenScreen() throws InterruptedException {

        OcsaServiceProto.OCS0103U13OpenScreenRequest request = OcsaServiceProto.OCS0103U13OpenScreenRequest.newBuilder()
        		.build();

        sentRequestToMedApp(request, OcsaServiceProto.getDescriptor().
                getOptions().getExtension(Rpc.service));
    }
}
