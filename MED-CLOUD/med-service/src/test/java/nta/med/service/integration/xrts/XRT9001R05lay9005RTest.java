package nta.med.service.integration.xrts;

import org.junit.Test;

import nta.med.common.remoting.rpc.protobuf.Rpc;
import nta.med.service.ihis.proto.XrtsServiceProto;
import nta.med.service.integration.MessageRequestTest;

public class XRT9001R05lay9005RTest extends MessageRequestTest {
    @Test
    public void test() throws InterruptedException {
    	XrtsServiceProto.XRT9001R05lay9005RRequest request = XrtsServiceProto.XRT9001R05lay9005RRequest.newBuilder()
    			.setDate("20121001")
                .build();
        sentRequestToMedApp(request, XrtsServiceProto.getDescriptor().getOptions().getExtension(Rpc.service));
    }
}