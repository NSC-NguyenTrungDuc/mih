package nta.med.service.integration.ocsi;

import org.junit.Test;

import nta.med.common.remoting.rpc.protobuf.Rpc;
import nta.med.service.ihis.proto.OcsiServiceProto;
import nta.med.service.integration.MessageRequestTest;

public class OCS2003Q02BannabProcessTest extends MessageRequestTest {

	@Test
	public void test() throws Exception {
		OcsiServiceProto.OCS2003Q02BannabProcessRequest request = OcsiServiceProto.OCS2003Q02BannabProcessRequest
				.newBuilder()
				.setWorkGubun("I")
				.setBunho("000009987")
				.setFkinp1001("9789.0")
				.setPkocs2003("3332.0")
				.setStopDate("2016/01/01")
				.setStopDate2("2016/01/02")
				.setInputDoctor("10323")
				.setUserId("10323")
				.setGubun("J")
				.setBannabDv("10.0")
				.setBogyongCodeReturn("A")
				.setToiwonDrgDv("20")
				.setToiwonDrgBogyongCode("A")
				.build();
		sentRequestToMedApp(request, OcsiServiceProto.getDescriptor().getOptions().getExtension(Rpc.service));
	}
}
