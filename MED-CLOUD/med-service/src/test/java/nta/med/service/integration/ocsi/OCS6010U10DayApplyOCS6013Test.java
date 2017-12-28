package nta.med.service.integration.ocsi;

import org.junit.Test;

import nta.med.common.remoting.rpc.protobuf.Rpc;
import nta.med.service.ihis.proto.OcsiServiceProto;
import nta.med.service.integration.MessageRequestTest;

public class OCS6010U10DayApplyOCS6013Test extends MessageRequestTest{

	@Test
	public void Test() throws Exception{
		OcsiServiceProto.OCS6010U10DayApplyOCS6013Request request = OcsiServiceProto.OCS6010U10DayApplyOCS6013Request.newBuilder()
				.setBunho("000000240")
				.setFkinp1001("249")
				.setFromDate("2017/01/15")
				.setToDate("2017/01/16")
				.setPkocs6013("1")
				.build();
		sentRequestToMedApp(request, OcsiServiceProto.getDescriptor().getOptions().getExtension(Rpc.service));
	}
}
