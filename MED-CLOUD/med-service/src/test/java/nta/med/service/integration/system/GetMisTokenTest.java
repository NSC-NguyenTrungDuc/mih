package nta.med.service.integration.system;

import org.junit.Test;

import nta.med.common.remoting.rpc.protobuf.Rpc;
import nta.med.service.emr.proto.EmrServiceProto;
import nta.med.service.integration.MessageRequestTest;

public class GetMisTokenTest extends MessageRequestTest {

	@Test
	public void test() throws InterruptedException {

		EmrServiceProto.OCS2015U00GetLinkMISRequest rq = EmrServiceProto.OCS2015U00GetLinkMISRequest.newBuilder()
				.build();
		sentRequestToMedApp(rq, EmrServiceProto.getDescriptor().getOptions().getExtension(Rpc.service));
	}
}
