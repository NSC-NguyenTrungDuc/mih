package nta.med.service.integration.ocsi;

import org.junit.Test;

import nta.med.common.remoting.rpc.protobuf.Rpc;
import nta.med.service.ihis.proto.OcsiServiceProto;
import nta.med.service.integration.MessageRequestTest;

public class OCS6010U10PopupCase6Test extends MessageRequestTest{

	@Test
	public void test() throws Exception {
		OcsiServiceProto.OCS6010U10PopupCase6Request request = OcsiServiceProto.OCS6010U10PopupCase6Request
				.newBuilder()
				.setOrderDate("2016/07/29")
				.setPkocs6015("12345")
				.build();
		sentRequestToMedApp(request, OcsiServiceProto.getDescriptor().getOptions().getExtension(Rpc.service));
	}
}
