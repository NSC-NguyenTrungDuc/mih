package nta.med.service.integration.nuri;

import org.junit.Test;

import nta.med.common.remoting.rpc.protobuf.Rpc;
import nta.med.service.ihis.proto.NuriServiceProto;
import nta.med.service.integration.MessageRequestTest;

public class NUR1020U00grdNUR1022INTest extends MessageRequestTest{

	@Test
	public void Test() throws Exception{
		NuriServiceProto.NUR1020U00grdNUR1022INRequest request = NuriServiceProto.NUR1020U00grdNUR1022INRequest.newBuilder()
				.setBunho("00000998")
				.setFkinp1001("1122")
				.setOrderDate("2017/01/01")
				.build();
		
		sentRequestToMedApp(request, NuriServiceProto.getDescriptor().getOptions().getExtension(Rpc.service));
	}
}
