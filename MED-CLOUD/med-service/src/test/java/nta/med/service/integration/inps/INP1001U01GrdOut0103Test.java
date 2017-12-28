package nta.med.service.integration.inps;

import org.junit.Test;

import nta.med.common.remoting.rpc.protobuf.Rpc;
import nta.med.service.ihis.proto.InpsServiceProto;
import nta.med.service.integration.MessageRequestTest;

public class INP1001U01GrdOut0103Test extends MessageRequestTest {

	@Test
	public void test() throws Exception {

		InpsServiceProto.INP1001U01GrdOut0103Request request = InpsServiceProto.INP1001U01GrdOut0103Request.newBuilder()
				.setBunho("000003227")
				.build();
		sentRequestToMedApp(request, InpsServiceProto.getDescriptor().getOptions().getExtension(Rpc.service));
	}

}
