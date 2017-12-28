package nta.med.service.integration.ocsi;

import org.junit.Test;

import nta.med.common.remoting.rpc.protobuf.Rpc;
import nta.med.service.ihis.proto.OcsiServiceProto;
import nta.med.service.ihis.proto.OcsiServiceProto.OCS6010U10PopupIAlayOCS2005Request;
import nta.med.service.integration.MessageRequestTest;

public class OCS6010U10PopupIAlayOCS2005Test extends MessageRequestTest{

	@Test
	public void test() throws Exception {
		OcsiServiceProto.OCS6010U10PopupIAlayOCS2005Request request = OcsiServiceProto.OCS6010U10PopupIAlayOCS2005Request.newBuilder()
				.setHospCode("323")
				.setPkocs2005("47")
				.build();
		sentRequestToMedApp(request, OcsiServiceProto.getDescriptor().getOptions().getExtension(Rpc.service));
	}
}
