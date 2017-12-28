package nta.med.service.integration.ocsi;

import org.junit.Test;

import nta.med.common.remoting.rpc.protobuf.Rpc;
import nta.med.service.ihis.proto.OcsiServiceProto;
import nta.med.service.integration.MessageRequestTest;

public class OCS6010U10InsertOCS2016Test extends MessageRequestTest {

	@Test
	public void test() throws Exception {
		OcsiServiceProto.OCS6010U10InsertOCS2016Request request = OcsiServiceProto.OCS6010U10InsertOCS2016Request.newBuilder()
				.setQUserId("1234")
				.setFFkocs2015("123")
				.setFHangmogCode("123")
				.setFSuryang("123")
				.setFBomYn("")
				.setFBomSourceKey("123")
				.setFSeq("123")
				.build();
		sentRequestToMedApp(request, OcsiServiceProto.getDescriptor().getOptions().getExtension(Rpc.service));
	}
}
