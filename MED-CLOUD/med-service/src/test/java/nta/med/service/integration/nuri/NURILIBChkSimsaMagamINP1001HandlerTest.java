package nta.med.service.integration.nuri;

import org.junit.Test;

import nta.med.common.remoting.rpc.protobuf.Rpc;
import nta.med.service.ihis.proto.NuriServiceProto;
import nta.med.service.integration.MessageRequestTest;

public class NURILIBChkSimsaMagamINP1001HandlerTest extends MessageRequestTest{
	@Test
	public void test() throws Exception{
		
		NuriServiceProto.NURILIBChkSimsaMagamINP1001Request request = NuriServiceProto.NURILIBChkSimsaMagamINP1001Request.newBuilder()
				.setPkinp1001("1606664")
				.build();
		sentRequestToMedApp(request, NuriServiceProto.getDescriptor().getOptions().getExtension(Rpc.service));
	}
}
