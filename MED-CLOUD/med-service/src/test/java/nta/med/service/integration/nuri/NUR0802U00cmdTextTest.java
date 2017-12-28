package nta.med.service.integration.nuri;

import org.junit.Test;

import nta.med.common.remoting.rpc.protobuf.Rpc;
import nta.med.service.ihis.proto.NuriServiceProto;
import nta.med.service.integration.MessageRequestTest;

public class NUR0802U00cmdTextTest extends MessageRequestTest {

	@Test

	public void Test() throws Exception {
		NuriServiceProto.NUR0802U00cmdTextRequest request = NuriServiceProto.NUR0802U00cmdTextRequest.newBuilder()
				.setNeedAsmtCode("")
				.setNeedGubun("")
				.setNeedType("")
				.build();

		sentRequestToMedApp(request, NuriServiceProto.getDescriptor().getOptions().getExtension(Rpc.service));
	}
}
