package nta.med.service.integration.ocsi;

import org.junit.Test;

import nta.med.common.remoting.rpc.protobuf.Rpc;
import nta.med.service.ihis.proto.OcsiServiceProto;
import nta.med.service.integration.MessageRequestTest;

public class OCS2004U00proOCS2005Test extends MessageRequestTest{

	@Test
	public void test() throws Exception {
		OcsiServiceProto.OCS2004U00proOCS2005Request request = OcsiServiceProto.OCS2004U00proOCS2005Request
				.newBuilder()
				.setIud("I")
				.setGubun("I")
				.setBunho("000009988")
				.setFkinp1001("12233.0")
				.setFromDate("2016/01/01")
				.setFromTime("2018")
				.setToDate("2016/11/10")
				.setToTime("1110")
				.setMemb("10323")
				.setPkocs2005("12345.0")
				.build();
		sentRequestToMedApp(request, OcsiServiceProto.getDescriptor().getOptions().getExtension(Rpc.service));
	}
}
