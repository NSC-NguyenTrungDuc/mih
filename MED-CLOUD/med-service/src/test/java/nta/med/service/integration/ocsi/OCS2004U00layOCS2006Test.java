package nta.med.service.integration.ocsi;

import org.junit.Test;

import nta.med.common.remoting.rpc.protobuf.Rpc;
import nta.med.service.ihis.proto.OcsiServiceProto;
import nta.med.service.integration.MessageRequestTest;

public class OCS2004U00layOCS2006Test extends MessageRequestTest {

	@Test
	public void test() throws Exception {

		OcsiServiceProto.OCS2004U00layOCS2006Request request = OcsiServiceProto.OCS2004U00layOCS2006Request.newBuilder()
				.setBunho("000000130")
				.setFkinp1001("1617527")
				.setOrderDate("2017/01/01")
				.setPkSeq("")
				.build();
		sentRequestToMedApp(request, OcsiServiceProto.getDescriptor().getOptions().getExtension(Rpc.service));
	}
}
