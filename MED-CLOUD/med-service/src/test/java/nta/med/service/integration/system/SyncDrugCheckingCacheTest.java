package nta.med.service.integration.system;

import org.junit.Test;

import nta.med.common.remoting.rpc.protobuf.Rpc;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.integration.MessageRequestTest;

public class SyncDrugCheckingCacheTest  extends MessageRequestTest{

	@Test
    public void test() throws InterruptedException {
        SystemServiceProto.SyncDrugCheckingCacheRequest request = SystemServiceProto.SyncDrugCheckingCacheRequest
                .newBuilder().setPageNumber("1").setOffset("2")
                .build();
        sentRequestToMedApp(request, SystemServiceProto.getDescriptor().
                getOptions().getExtension(Rpc.service));
    }
}
