package nta.med.service.integration.inps;

import org.junit.Test;

import nta.med.common.remoting.rpc.protobuf.Rpc;
import nta.med.service.ihis.proto.InpsServiceProto;
import nta.med.service.integration.MessageRequestTest;

public class INP1001U01GrdInp1004Test extends MessageRequestTest {

	@Test
	public void test() throws Exception {

		InpsServiceProto.INP1001U01GrdInp1004Request request = InpsServiceProto.INP1001U01GrdInp1004Request.newBuilder()
				.setBunho("000041031")
				.setPageNumber("1")
				.setOffset("1000")
				.build();
		sentRequestToMedApp(request, InpsServiceProto.getDescriptor().getOptions().getExtension(Rpc.service));
	}
}
