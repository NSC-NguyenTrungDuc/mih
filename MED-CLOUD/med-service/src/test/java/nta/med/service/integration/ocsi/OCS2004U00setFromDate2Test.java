package nta.med.service.integration.ocsi;

import org.junit.Test;

import nta.med.common.remoting.rpc.protobuf.Rpc;
import nta.med.service.ihis.proto.OcsiServiceProto;
import nta.med.service.integration.MessageRequestTest;

public class OCS2004U00setFromDate2Test extends MessageRequestTest {

	@Test
	public void test() throws Exception {

		OcsiServiceProto.OCS2004U00setFromDate2Request request = OcsiServiceProto.OCS2004U00setFromDate2Request.newBuilder()
				.setFkinp1001("1617675")
				.setKijunDate("2015/01/01")
				.setDirectGubun("03")
				.setDirectCode("0301")
				.setKijunTime("2020/01/01")
				.build();
		sentRequestToMedApp(request, OcsiServiceProto.getDescriptor().getOptions().getExtension(Rpc.service));
	}
}
