package nta.med.service.integration.system;

import nta.med.common.remoting.rpc.protobuf.Rpc;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.integration.MessageRequestTest;
import org.junit.Test;

/**
 * @author Tiepnm
 */
public class HIOcsSpecificCommentTest extends MessageRequestTest {

    @Test
    public void testHIOcsSpecificComment() throws InterruptedException {
        SystemServiceProto.HIOcsSpecificCommentRequest request = SystemServiceProto.HIOcsSpecificCommentRequest
                .newBuilder().setSpecificComment("01")
                .build();
        sentRequestToMedApp(request, SystemServiceProto.getDescriptor().
                getOptions().getExtension(Rpc.service));
    }
}
