package nta.med.service.integration.system;

import org.junit.Test;

import nta.med.common.remoting.rpc.protobuf.Rpc;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.integration.MessageRequestTest;

/**
 * @author DEV-TiepNM
 */
public class FwUserInfoChangePswTest extends MessageRequestTest {
    @Test
    public void testCheckUserLogin() throws InterruptedException {

    	SystemServiceProto.FwUserInfoChangePswRequest request = SystemServiceProto.FwUserInfoChangePswRequest.newBuilder()
    			.setUserId("99999")
                .setNewPassword("123456")
                .setPwdHistory("b59c67bf196a4758191e42f76670ceba")
                .setHospCode("K01").build();

        sentRequestToMedApp(request, SystemServiceProto.getDescriptor().
                getOptions().getExtension(Rpc.service));
    }
}
