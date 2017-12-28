package nta.med.service.integration.ocsi;

import org.junit.Test;

import nta.med.common.remoting.rpc.protobuf.Rpc;
import nta.med.service.ihis.proto.OcsiServiceProto;
import nta.med.service.integration.MessageRequestTest;

public class OCS2003P01SetSameOrderDateGroupSerTest extends MessageRequestTest {

	@Test
	public void test() throws Exception {

		OcsiServiceProto.OCS2003P01SetSameOrderDateGroupSerRequest request = OcsiServiceProto.OCS2003P01SetSameOrderDateGroupSerRequest.newBuilder()
				.setOrderDate("2016/5/7")
				.setInputTab("08")
				.setBunho("000003227")
				.setInputDoctor("0110323")
				.build();
		sentRequestToMedApp(request, OcsiServiceProto.getDescriptor().getOptions().getExtension(Rpc.service));
	}
}
