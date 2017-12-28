package nta.med.service.integration.ocsi;

import org.junit.Test;

import nta.med.common.remoting.rpc.protobuf.Rpc;
import nta.med.service.ihis.proto.OcsiServiceProto;
import nta.med.service.integration.MessageRequestTest;

public class OCS2003U03getBogyongCodeTest extends MessageRequestTest {
	@Test
	public void test() throws Exception {

		OcsiServiceProto.OCS2003U03getBogyongCodeRequest request = OcsiServiceProto.OCS2003U03getBogyongCodeRequest.newBuilder()
				.setGubun("TEST")
				.build();
		sentRequestToMedApp(request, OcsiServiceProto.getDescriptor().getOptions().getExtension(Rpc.service));
	}
}
