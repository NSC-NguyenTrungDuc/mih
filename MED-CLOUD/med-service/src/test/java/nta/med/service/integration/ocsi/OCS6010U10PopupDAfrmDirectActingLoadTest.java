package nta.med.service.integration.ocsi;

import org.junit.Test;

import nta.med.common.remoting.rpc.protobuf.Rpc;
import nta.med.service.ihis.proto.OcsiServiceProto;
import nta.med.service.integration.MessageRequestTest;

public class OCS6010U10PopupDAfrmDirectActingLoadTest extends MessageRequestTest{

	@Test
	public void test() throws Exception {
		OcsiServiceProto.OCS6010U10PopupDAfrmDirectActingLoadRequest request = OcsiServiceProto.OCS6010U10PopupDAfrmDirectActingLoadRequest.newBuilder()
				.setHospCode("323")
				.build();
		sentRequestToMedApp(request, OcsiServiceProto.getDescriptor().getOptions().getExtension(Rpc.service));
	}
}
