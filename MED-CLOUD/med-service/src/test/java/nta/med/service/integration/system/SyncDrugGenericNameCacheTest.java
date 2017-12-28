package nta.med.service.integration.system;

import nta.med.common.remoting.rpc.protobuf.Rpc;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.integration.MessageRequestTest;
import org.junit.Test;

public class SyncDrugGenericNameCacheTest extends MessageRequestTest {

    @Test
    public void test() throws InterruptedException {
        SystemServiceProto.SyncGenericNameCacheRequest request = SystemServiceProto.SyncGenericNameCacheRequest
                .newBuilder().setPageNumber("1").setOffset("5")
                .build();
        sentRequestToMedApp(request, SystemServiceProto.getDescriptor().
                getOptions().getExtension(Rpc.service));
    }
}
