package nta.med.service.integration.system;

import org.junit.Test;

import nta.med.common.remoting.rpc.protobuf.Rpc;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.integration.MessageRequestTest;

/**
 * @author DEV-TiepNM
 */
public class AdmLoginFormCheckLoginUserTest extends MessageRequestTest {
    @Test
    public void testCheckUserLogin() throws InterruptedException {

        SystemServiceProto.AdmLoginFormCheckLoginUserRequest request = SystemServiceProto.
                AdmLoginFormCheckLoginUserRequest.newBuilder().setUser("10323").
                setPassword("25d55ad283aa400af464c76d713c07ad").
                setHospCode("323").build();

        sentRequestToMedApp(request, SystemServiceProto.getDescriptor().
                getOptions().getExtension(Rpc.service));
    }
}
