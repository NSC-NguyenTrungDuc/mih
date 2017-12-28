package nta.med.service.integration.system;

import nta.med.common.remoting.rpc.protobuf.Rpc;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.integration.MessageRequestTest;
import org.junit.Test;

/**
 * @author DEV-TiepNM
 */
public class FormEnvironInfoSysDateTest extends MessageRequestTest {

    @Test
    public void test() throws InterruptedException {
        SystemServiceProto.FormEnvironInfoSysDateRequest request = SystemServiceProto.
                FormEnvironInfoSysDateRequest.newBuilder().build();

        sentRequestToMedApp(request, SystemServiceProto.getDescriptor().
                getOptions().getExtension(Rpc.service));
    }

}
