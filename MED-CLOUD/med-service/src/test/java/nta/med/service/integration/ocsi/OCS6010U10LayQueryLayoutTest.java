package nta.med.service.integration.ocsi;

import org.junit.Test;

import nta.med.common.remoting.rpc.protobuf.Rpc;
import nta.med.service.ihis.proto.OcsiServiceProto;
import nta.med.service.integration.MessageRequestTest;

public class OCS6010U10LayQueryLayoutTest extends MessageRequestTest{

	@Test
	public void test() throws Exception {

		OcsiServiceProto.OCS6010U10LayQueryLayoutRequest request = OcsiServiceProto.OCS6010U10LayQueryLayoutRequest.newBuilder()
				.setOrderDate("2016/5/7")
				.setBunho("000003227")
				.setFkinp1001("1000.0")
				.build();
		sentRequestToMedApp(request, OcsiServiceProto.getDescriptor().getOptions().getExtension(Rpc.service));
	}
}
