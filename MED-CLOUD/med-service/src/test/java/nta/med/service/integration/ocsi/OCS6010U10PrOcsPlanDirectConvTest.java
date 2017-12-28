package nta.med.service.integration.ocsi;

import org.junit.Test;

import nta.med.common.remoting.rpc.protobuf.Rpc;
import nta.med.service.ihis.proto.OcsiServiceProto;
import nta.med.service.integration.MessageRequestTest;

public class OCS6010U10PrOcsPlanDirectConvTest extends MessageRequestTest{

	@Test
	public void test() throws Exception {
		OcsiServiceProto.OCS6010U10PrOcsPlanDirectConvRequest request = OcsiServiceProto.OCS6010U10PrOcsPlanDirectConvRequest
				.newBuilder()
				.setIAppDate("2016/01/01")
				.setIPkocs6015("12345")
				.setIUserId("10323")
				.build();
		sentRequestToMedApp(request, OcsiServiceProto.getDescriptor().getOptions().getExtension(Rpc.service));
	}
}
