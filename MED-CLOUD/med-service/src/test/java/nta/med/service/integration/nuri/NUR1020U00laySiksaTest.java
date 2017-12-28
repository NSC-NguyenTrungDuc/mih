package nta.med.service.integration.nuri;

import org.junit.Test;

import nta.med.common.remoting.rpc.protobuf.Rpc;
import nta.med.service.ihis.proto.NuriServiceProto;
import nta.med.service.integration.MessageRequestTest;

public class NUR1020U00laySiksaTest extends MessageRequestTest{

	@Test
	public void Test() throws Exception{
		NuriServiceProto.NUR1020U00laySiksaRequest request = NuriServiceProto.NUR1020U00laySiksaRequest.newBuilder().build();
		sentRequestToMedApp(request, NuriServiceProto.getDescriptor().getOptions().getExtension(Rpc.service));
	}
}
