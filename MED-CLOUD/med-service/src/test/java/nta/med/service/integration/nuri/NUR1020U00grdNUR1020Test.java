package nta.med.service.integration.nuri;

import org.junit.Test;

import nta.med.common.remoting.rpc.protobuf.Rpc;
import nta.med.service.ihis.proto.NuriServiceProto;
import nta.med.service.integration.MessageRequestTest;

public class NUR1020U00grdNUR1020Test extends MessageRequestTest{

	@Test
	public void Test() throws Exception{
		NuriServiceProto.NUR1020U00grdNUR1020Request request = NuriServiceProto.NUR1020U00grdNUR1020Request.newBuilder()
				.setBunho("000009989")
				.setFkinp1001("123")
				.setDate("2017/01/01")
				.build();
		
		sentRequestToMedApp(request, NuriServiceProto.getDescriptor().getOptions().getExtension(Rpc.service));
	}
}
