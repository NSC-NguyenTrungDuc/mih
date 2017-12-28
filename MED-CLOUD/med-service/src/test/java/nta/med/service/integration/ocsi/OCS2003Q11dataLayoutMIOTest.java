package nta.med.service.integration.ocsi;

import org.junit.Test;

import nta.med.common.remoting.rpc.protobuf.Rpc;
import nta.med.service.ihis.proto.OcsiServiceProto;
import nta.med.service.integration.MessageRequestTest;

public class OCS2003Q11dataLayoutMIOTest extends MessageRequestTest{
	@Test
	public void test() throws Exception {

		OcsiServiceProto.OCS2003Q11dataLayoutMIORequest request = OcsiServiceProto.OCS2003Q11dataLayoutMIORequest.newBuilder()
				.setHoDong("T")
				.setSession("D")
				.setHoTeam("A")
				.setOrderDate("2015/01/18")
				.build();
		sentRequestToMedApp(request, OcsiServiceProto.getDescriptor().getOptions().getExtension(Rpc.service));
	}
}
