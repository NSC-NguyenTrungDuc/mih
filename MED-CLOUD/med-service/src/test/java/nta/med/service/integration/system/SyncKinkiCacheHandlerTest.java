package nta.med.service.integration.system;

import nta.med.common.remoting.rpc.protobuf.Rpc;
import nta.med.service.ihis.proto.CommonModelProto;
import nta.med.service.ihis.proto.SystemModelProto;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.integration.MessageRequestTest;
import org.junit.Test;

/**
 * @author DEV-TiepNM
 */
public class SyncKinkiCacheHandlerTest extends MessageRequestTest {
    @Test
    public void test() throws InterruptedException {
        SystemServiceProto.SyncKinkiCacheRequest request = SystemServiceProto.SyncKinkiCacheRequest
                .newBuilder().setKinkiType(CommonModelProto.KinkiType.KINKI_MSG)
                .build();
        sentRequestToMedApp(request, SystemServiceProto.getDescriptor().
                getOptions().getExtension(Rpc.service));
    }
}

