package nta.med.service.integration.inps;

import org.junit.Test;

import nta.med.common.remoting.rpc.protobuf.Rpc;
import nta.med.service.ihis.proto.InpsServiceProto;
import nta.med.service.integration.MessageRequestTest;

public class INP1001U01GrdInp1001Test extends MessageRequestTest {

	@Test
	public void test() throws Exception {

		InpsServiceProto.INP1001U01GrdInp1001Request request = InpsServiceProto.INP1001U01GrdInp1001Request.newBuilder()
				.setPkinp1001("1606663")
				.setPageNumber("1")
				.setOffset("200")
				.build();
		
		sentRequestToMedApp(request, InpsServiceProto.getDescriptor().getOptions().getExtension(Rpc.service));
	}
}
