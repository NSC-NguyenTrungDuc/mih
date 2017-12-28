package nta.med.service.integration.ocsi;

import org.junit.Test;

import nta.med.common.remoting.rpc.protobuf.Rpc;
import nta.med.service.ihis.proto.OcsiServiceProto;
import nta.med.service.integration.MessageRequestTest;

public class OCS2004U00layTabItemTest extends MessageRequestTest {

	@Test
	public void test() throws Exception {

		OcsiServiceProto.OCS2004U00layTabItemRequest request = OcsiServiceProto.OCS2004U00layTabItemRequest.newBuilder()
				.build();
		sentRequestToMedApp(request, OcsiServiceProto.getDescriptor().getOptions().getExtension(Rpc.service));
	}
}
