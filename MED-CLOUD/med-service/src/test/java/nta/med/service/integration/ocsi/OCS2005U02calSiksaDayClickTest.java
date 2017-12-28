package nta.med.service.integration.ocsi;

import org.junit.Test;
import nta.med.common.remoting.rpc.protobuf.Rpc;
import nta.med.service.ihis.proto.OcsiServiceProto;
import nta.med.service.integration.MessageRequestTest;

public class OCS2005U02calSiksaDayClickTest extends MessageRequestTest{
	@Test
	public void Test() throws Exception{
		OcsiServiceProto.OCS2005U02calSiksaDayClickRequest request = OcsiServiceProto.OCS2005U02calSiksaDayClickRequest.newBuilder()
				.setBunho("000030556")
				.setMpressedJaewonYn("T")
				.setNutDate("2016/07/05")
				.build();
		sentRequestToMedApp(request, OcsiServiceProto.getDescriptor().getOptions().getExtension(Rpc.service));
	}
}
