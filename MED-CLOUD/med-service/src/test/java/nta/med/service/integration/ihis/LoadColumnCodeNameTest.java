package nta.med.service.integration.ihis;

import org.junit.Test;

import nta.med.common.remoting.rpc.protobuf.Rpc;
import nta.med.service.ihis.proto.CommonModelProto;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.integration.MessageRequestTest;

public class LoadColumnCodeNameTest extends MessageRequestTest {
    @Test
    public void testCheckUserLogin() throws InterruptedException {

    	CommonModelProto.LoadColumnCodeNameInfo.Builder  info = CommonModelProto.LoadColumnCodeNameInfo.newBuilder();
    	info.setArg1("H");
    	info.setColName("order_gubun_bas");
    	
        SystemServiceProto.LoadColumnCodeNameRequest request = SystemServiceProto.
        		LoadColumnCodeNameRequest.newBuilder()
        		.setRequestValue(info)
                .build();

        sentRequestToMedApp(request, SystemServiceProto.getDescriptor().
                getOptions().getExtension(Rpc.service));
    }
}
