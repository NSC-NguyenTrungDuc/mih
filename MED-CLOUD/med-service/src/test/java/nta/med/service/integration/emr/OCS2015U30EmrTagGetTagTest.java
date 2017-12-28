package nta.med.service.integration.emr;

import nta.med.common.remoting.rpc.protobuf.Rpc;
import nta.med.service.emr.proto.EmrServiceProto;
import nta.med.service.ihis.proto.OcsoServiceProto;
import nta.med.service.integration.MessageRequestTest;
import org.junit.Test;

/**
 * @author DEV-TiepNM
 */
public class OCS2015U30EmrTagGetTagTest extends MessageRequestTest {
    @Test
    public void testOCS2015U30EmrTagGetTag() throws InterruptedException {
        EmrServiceProto.OCS2015U30EmrTagGetTagRequest request = EmrServiceProto.OCS2015U30EmrTagGetTagRequest.newBuilder().
                setTagLevel("R")
                .build();

        sentRequestToMedApp(request, EmrServiceProto.getDescriptor().
                getOptions().getExtension(Rpc.service));
    }
}
