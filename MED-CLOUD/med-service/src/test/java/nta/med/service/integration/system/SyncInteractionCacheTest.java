package nta.med.service.integration.system;

import nta.med.common.remoting.rpc.protobuf.Rpc;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.integration.MessageRequestTest;
import org.junit.Test;

/**
 * @author DEV-TiepNM
 */
public class SyncInteractionCacheTest extends MessageRequestTest {

    @Test
    public void test() throws InterruptedException {
        SystemServiceProto.SyncInteractionCacheRequest request = SystemServiceProto.SyncInteractionCacheRequest
                .newBuilder().setPageNumber("3").setOffset("2")
                .build();
        sentRequestToMedApp(request, SystemServiceProto.getDescriptor().
                getOptions().getExtension(Rpc.service));
    }
}
