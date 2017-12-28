package nta.med.service.integration.system;

import nta.med.common.remoting.rpc.protobuf.Rpc;
import nta.med.service.ihis.proto.SystemModelProto;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.integration.MessageRequestTest;
import org.junit.Test;

/**
 * @author Tiepnm
 */
public class CheckUserLoginTest extends MessageRequestTest {

    @Test
    public void testCheckUserLogin() throws InterruptedException {
        SystemModelProto.UserRequestInfo.Builder userRequestInfo = SystemModelProto.UserRequestInfo.newBuilder();
        userRequestInfo.setUserId("ADM001");
        userRequestInfo.setUserScrt("b59c67bf196a4758191e42f76670ceba");
        SystemServiceProto.CheckUserLoginRequest request = SystemServiceProto.CheckUserLoginRequest
                .newBuilder().setUserId("ADM001").setSystemId("1").setUserInfo(userRequestInfo)
                .build();

        sentRequestToMedApp(request, SystemServiceProto.getDescriptor().
                getOptions().getExtension(Rpc.service));
    }


}
