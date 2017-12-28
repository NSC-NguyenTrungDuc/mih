package nta.med.service.integration.nuri;

import org.junit.Test;

import nta.med.common.remoting.rpc.protobuf.Rpc;
import nta.med.service.ihis.proto.NuriServiceProto;
import nta.med.service.integration.MessageRequestTest;

public class NURILIBIsJaewonHandlerTest extends MessageRequestTest{
	@Test
	public void test() throws Exception{
		
		NuriServiceProto.NURILIBIsJaewonRequest request = NuriServiceProto.NURILIBIsJaewonRequest.newBuilder()
				.setBunho("000002398")
				.setIpwonDate("2016/08/11")
				.build();
		sentRequestToMedApp(request, NuriServiceProto.getDescriptor().getOptions().getExtension(Rpc.service));
	}
}
