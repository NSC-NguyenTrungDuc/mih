package nta.med.service.integration.inps;

import org.junit.Test;

import nta.med.common.remoting.rpc.protobuf.Rpc;
import nta.med.service.ihis.proto.InpsServiceProto;
import nta.med.service.integration.MessageRequestTest;

public class INP1001U01LoadIpwonTypeListTest extends MessageRequestTest {

	@Test
	public void test() throws Exception {

		InpsServiceProto.INP1001U01LoadIpwonTypeListRequest request = InpsServiceProto.INP1001U01LoadIpwonTypeListRequest
				.newBuilder()
				.setBunho("000003227")
				.build();
		
		sentRequestToMedApp(request, InpsServiceProto.getDescriptor().getOptions().getExtension(Rpc.service));
	}
}
