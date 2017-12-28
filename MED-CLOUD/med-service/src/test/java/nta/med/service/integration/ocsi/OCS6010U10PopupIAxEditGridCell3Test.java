package nta.med.service.integration.ocsi;

import org.junit.Test;

import nta.med.common.remoting.rpc.protobuf.Rpc;
import nta.med.service.ihis.proto.OcsiServiceProto;
import nta.med.service.integration.MessageRequestTest;

public class OCS6010U10PopupIAxEditGridCell3Test extends MessageRequestTest{

	@Test
	public void test() throws Exception {
		OcsiServiceProto.OCS6010U10PopupIAxEditGridCell3Request request = OcsiServiceProto.OCS6010U10PopupIAxEditGridCell3Request.newBuilder()
				.setNurGrCode("20")
				.setNurMdCode("2030")
				.build();
		sentRequestToMedApp(request, OcsiServiceProto.getDescriptor().getOptions().getExtension(Rpc.service));
	}
}
