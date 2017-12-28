package nta.med.service.integration.ocsi;

import org.junit.Test;

import nta.med.common.remoting.rpc.protobuf.Rpc;
import nta.med.service.ihis.proto.OcsiServiceProto;
import nta.med.service.integration.MessageRequestTest;

public class OCS2003P01GrdPatientListTest extends MessageRequestTest{

	@Test
	public void test() throws Exception {

		OcsiServiceProto.OCS2003P01GrdPatientListRequest request = OcsiServiceProto.OCS2003P01GrdPatientListRequest.newBuilder()
				.setBunho("000000045")
				.setOrderDate("2016/11/17")
				.build();
		sentRequestToMedApp(request, OcsiServiceProto.getDescriptor().getOptions().getExtension(Rpc.service));
	}
}
