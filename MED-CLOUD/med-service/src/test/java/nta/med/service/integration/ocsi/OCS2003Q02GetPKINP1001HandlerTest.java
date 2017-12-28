package nta.med.service.integration.ocsi;
import org.junit.Test;

import nta.med.common.remoting.rpc.protobuf.Rpc;
import nta.med.service.ihis.proto.OcsiServiceProto;
import nta.med.service.integration.MessageRequestTest;

public class OCS2003Q02GetPKINP1001HandlerTest extends MessageRequestTest{
	@Test
	public void test() throws Exception {

		OcsiServiceProto.OCS2003Q02GetPKINP1001Request request = OcsiServiceProto.OCS2003Q02GetPKINP1001Request.newBuilder()
				.setBunho("000003227")
				.build();
		sentRequestToMedApp(request, OcsiServiceProto.getDescriptor().getOptions().getExtension(Rpc.service));
	}
}
