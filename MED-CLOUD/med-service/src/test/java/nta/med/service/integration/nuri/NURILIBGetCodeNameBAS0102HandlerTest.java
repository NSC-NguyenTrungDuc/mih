package nta.med.service.integration.nuri;

import org.junit.Test;

import nta.med.common.remoting.rpc.protobuf.Rpc;
import nta.med.service.ihis.proto.NuriServiceProto;
import nta.med.service.integration.MessageRequestTest;

public class NURILIBGetCodeNameBAS0102HandlerTest extends MessageRequestTest{
	@Test
	public void test() throws Exception{
		
		NuriServiceProto.NURILIBGetCodeNameBAS0102Request request = NuriServiceProto.NURILIBGetCodeNameBAS0102Request.newBuilder()
				.setCode("01")
				.setCodeType("A51")
				.build();
		sentRequestToMedApp(request, NuriServiceProto.getDescriptor().getOptions().getExtension(Rpc.service));
	}
}
