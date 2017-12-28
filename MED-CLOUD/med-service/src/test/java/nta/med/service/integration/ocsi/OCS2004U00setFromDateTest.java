package nta.med.service.integration.ocsi;

import org.junit.Test;

import nta.med.common.remoting.rpc.protobuf.Rpc;
import nta.med.service.ihis.proto.OcsiServiceProto;
import nta.med.service.integration.MessageRequestTest;

public class OCS2004U00setFromDateTest extends MessageRequestTest {

	@Test
	public void test() throws Exception {

		OcsiServiceProto.OCS2004U00setFromDateRequest request = OcsiServiceProto.OCS2004U00setFromDateRequest.newBuilder()
				.setPkocs2005("111222")
				.setFkinp1001("1617196")
				.setKijunDate("2015/01/01")
				.setDirectGubun("03")
				.setDirectCode("0301")
				.setKijunTime("2020/01/01")
				.build();
		sentRequestToMedApp(request, OcsiServiceProto.getDescriptor().getOptions().getExtension(Rpc.service));
	}
}
