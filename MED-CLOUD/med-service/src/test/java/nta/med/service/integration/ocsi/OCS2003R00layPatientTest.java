package nta.med.service.integration.ocsi;

import org.junit.Test;

import nta.med.common.remoting.rpc.protobuf.Rpc;
import nta.med.service.ihis.proto.OcsiServiceProto;
import nta.med.service.integration.MessageRequestTest;

public class OCS2003R00layPatientTest extends MessageRequestTest{

	@Test
	public void test() throws Exception {
		OcsiServiceProto.OCS2003R00layPatientRequest request = OcsiServiceProto.OCS2003R00layPatientRequest
				.newBuilder()
				.setGwa("01")
				.setDoctor("")
				.setInputGubun("")
				.setBunho("000003227")
				.setFkinp1001("1606664")
				.setOrderDate("2016/07/05")
				.build();
		sentRequestToMedApp(request, OcsiServiceProto.getDescriptor().getOptions().getExtension(Rpc.service));
	}
}
