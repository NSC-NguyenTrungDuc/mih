package nta.med.service.integration.ocsi;

import org.junit.Test;

import nta.med.common.remoting.rpc.protobuf.Rpc;
import nta.med.service.ihis.proto.OcsiServiceProto;
import nta.med.service.integration.MessageRequestTest;

public class OCS2004U00getPKSeqTest extends MessageRequestTest {

	@Test
	public void test() throws Exception {

		OcsiServiceProto.OCS2004U00getPKSeqRequest request = OcsiServiceProto.OCS2004U00getPKSeqRequest.newBuilder()
				.setBunho("000000001")
				.setFkinp1001("1617675")
				.setOrderDate("11/15/2016 12:00:00 AM")
				.setTabinputGubun("D0")
				.build();
		sentRequestToMedApp(request, OcsiServiceProto.getDescriptor().getOptions().getExtension(Rpc.service));
	}
}
