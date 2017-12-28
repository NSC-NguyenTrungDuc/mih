package nta.med.service.integration.ocsi;

import org.junit.Test;

import nta.med.common.remoting.rpc.protobuf.Rpc;
import nta.med.service.ihis.proto.OcsiServiceProto;
import nta.med.service.integration.MessageRequestTest;

public class OCS2004U00DupCheckTest extends MessageRequestTest {

	@Test
	public void test() throws Exception {

		OcsiServiceProto.OCS2004U00DupCheckRequest request = OcsiServiceProto.OCS2004U00DupCheckRequest.newBuilder()
				.setBunho("000048336")
				.setFkinp1001("1617196")
				.setInputGubun("D0")
				.setDirectGubun("03")
				.setDirectCode("0301")
				.setFromDate("2015/01/01")
				.setToDate("2020/01/01")
				.build();
		sentRequestToMedApp(request, OcsiServiceProto.getDescriptor().getOptions().getExtension(Rpc.service));
	}
}
