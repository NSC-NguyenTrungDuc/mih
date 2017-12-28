package nta.med.service.integration.ocsi;

import org.junit.Test;

import nta.med.common.remoting.rpc.protobuf.Rpc;
import nta.med.service.ihis.proto.OcsiServiceProto;
import nta.med.service.integration.MessageRequestTest;

public class OCS6010U10PopupIAgrdOCS2016Test extends MessageRequestTest {

	@Test
	public void test() throws Exception {
		OcsiServiceProto.OCS6010U10PopupIAgrdOCS2016Request request = OcsiServiceProto.OCS6010U10PopupIAgrdOCS2016Request.newBuilder()
				.setHospCode("323")
				.setFkocs2015("1")
				.setOffset("")
				.setPageNumber("")
				.build();
		sentRequestToMedApp(request, OcsiServiceProto.getDescriptor().getOptions().getExtension(Rpc.service));
	}
}
