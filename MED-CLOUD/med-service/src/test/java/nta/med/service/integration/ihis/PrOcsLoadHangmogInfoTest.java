package nta.med.service.integration.ihis;

import org.junit.Test;

import nta.med.common.remoting.rpc.protobuf.Rpc;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.integration.MessageRequestTest;                                                                               
                        
public class PrOcsLoadHangmogInfoTest extends MessageRequestTest {
    @Test
    public void testCheckUserLogin() throws InterruptedException {

        SystemServiceProto.PrOcsLoadHangmogInfoRequest request = SystemServiceProto.
        		PrOcsLoadHangmogInfoRequest.newBuilder()
        		.setAppDate("2016/03/28")
				.setInputPart("01")
				.setHangmogCode("610462040")
				.setInputTab("01")
				.setInputGwa("01")
        		.build();

        sentRequestToMedApp(request, SystemServiceProto.getDescriptor().
                getOptions().getExtension(Rpc.service));
    }
}                                                                          