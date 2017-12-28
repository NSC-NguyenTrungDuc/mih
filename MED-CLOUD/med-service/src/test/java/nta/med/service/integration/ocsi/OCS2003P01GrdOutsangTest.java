package nta.med.service.integration.ocsi;

import org.junit.Test;

import nta.med.common.remoting.rpc.protobuf.Rpc;
import nta.med.service.ihis.proto.OcsiServiceProto;
import nta.med.service.integration.MessageRequestTest;

public class OCS2003P01GrdOutsangTest extends MessageRequestTest {

	@Test
	public void test() throws Exception {

		OcsiServiceProto.OCS2003P01GrdOutsangRequest request = OcsiServiceProto.OCS2003P01GrdOutsangRequest.newBuilder()
				.setBunho("000000045")
				.setGwa("01")
				.setNaewonDate("2025/01/01")
				.build();
		sentRequestToMedApp(request, OcsiServiceProto.getDescriptor().getOptions().getExtension(Rpc.service));
	}
}
